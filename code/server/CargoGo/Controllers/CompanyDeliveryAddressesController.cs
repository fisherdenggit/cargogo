using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using CargoGo.Models;

namespace CargoGo.Controllers
{
    /*
    在为此控制器添加路由之前，WebApiConfig 类可能要求你做出其他更改。请适当地将这些语句合并到 WebApiConfig 类的 Register 方法中。请注意 OData URL 区分大小写。

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using CargoGo.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<CompanyDeliveryAddress>("CompanyDeliveryAddresses");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CompanyDeliveryAddressesController : ODataController
    {
        private MyDBContext db = new MyDBContext();

        // GET: odata/CompanyDeliveryAddresses
        [EnableQuery]
        public IQueryable<CompanyDeliveryAddress> GetCompanyDeliveryAddresses()
        {
            return db.CompanyDeliveryAddresses;
        }

        // GET: odata/CompanyDeliveryAddresses(5)
        [EnableQuery]
        public SingleResult<CompanyDeliveryAddress> GetCompanyDeliveryAddress([FromODataUri] int key)
        {
            return SingleResult.Create(db.CompanyDeliveryAddresses.Where(companyDeliveryAddress => companyDeliveryAddress.ID == key));
        }

        // PUT: odata/CompanyDeliveryAddresses(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<CompanyDeliveryAddress> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CompanyDeliveryAddress companyDeliveryAddress = await db.CompanyDeliveryAddresses.FindAsync(key);
            if (companyDeliveryAddress == null)
            {
                return NotFound();
            }

            patch.Put(companyDeliveryAddress);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyDeliveryAddressExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(companyDeliveryAddress);
        }

        // POST: odata/CompanyDeliveryAddresses
        public async Task<IHttpActionResult> Post(CompanyDeliveryAddress companyDeliveryAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CompanyDeliveryAddresses.Add(companyDeliveryAddress);
            await db.SaveChangesAsync();

            return Created(companyDeliveryAddress);
        }

        // PATCH: odata/CompanyDeliveryAddresses(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<CompanyDeliveryAddress> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CompanyDeliveryAddress companyDeliveryAddress = await db.CompanyDeliveryAddresses.FindAsync(key);
            if (companyDeliveryAddress == null)
            {
                return NotFound();
            }

            patch.Patch(companyDeliveryAddress);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyDeliveryAddressExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(companyDeliveryAddress);
        }

        // DELETE: odata/CompanyDeliveryAddresses(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            CompanyDeliveryAddress companyDeliveryAddress = await db.CompanyDeliveryAddresses.FindAsync(key);
            if (companyDeliveryAddress == null)
            {
                return NotFound();
            }

            db.CompanyDeliveryAddresses.Remove(companyDeliveryAddress);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyDeliveryAddressExists(int key)
        {
            return db.CompanyDeliveryAddresses.Count(e => e.ID == key) > 0;
        }
    }
}
