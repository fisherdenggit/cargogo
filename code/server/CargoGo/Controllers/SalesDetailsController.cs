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
    builder.EntitySet<SalesDetail>("SalesDetails");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class SalesDetailsController : ODataController
    {
        private MyDBContext db = new MyDBContext();

        // GET: odata/SalesDetails
        [EnableQuery]
        public IQueryable<SalesDetail> GetSalesDetails()
        {
            return db.SalesDetails;
        }

        // GET: odata/SalesDetails(5)
        [EnableQuery]
        public SingleResult<SalesDetail> GetSalesDetail([FromODataUri] int key)
        {
            return SingleResult.Create(db.SalesDetails.Where(salesDetail => salesDetail.ID == key));
        }

        // PUT: odata/SalesDetails(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<SalesDetail> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SalesDetail salesDetail = await db.SalesDetails.FindAsync(key);
            if (salesDetail == null)
            {
                return NotFound();
            }

            patch.Put(salesDetail);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesDetailExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(salesDetail);
        }

        // POST: odata/SalesDetails
        public async Task<IHttpActionResult> Post(SalesDetail salesDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SalesDetails.Add(salesDetail);
            await db.SaveChangesAsync();

            return Created(salesDetail);
        }

        // PATCH: odata/SalesDetails(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<SalesDetail> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SalesDetail salesDetail = await db.SalesDetails.FindAsync(key);
            if (salesDetail == null)
            {
                return NotFound();
            }

            patch.Patch(salesDetail);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesDetailExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(salesDetail);
        }

        // DELETE: odata/SalesDetails(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            SalesDetail salesDetail = await db.SalesDetails.FindAsync(key);
            if (salesDetail == null)
            {
                return NotFound();
            }

            db.SalesDetails.Remove(salesDetail);
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

        private bool SalesDetailExists(int key)
        {
            return db.SalesDetails.Count(e => e.ID == key) > 0;
        }
    }
}
