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
    builder.EntitySet<Contract>("Contracts");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ContractsController : ODataController
    {
        private MyDBContext db = new MyDBContext();

        // GET: odata/Contracts
        [EnableQuery]
        public IQueryable<Contract> GetContracts()
        {
            return db.Contracts;
        }

        // GET: odata/Contracts(5)
        [EnableQuery]
        public SingleResult<Contract> GetContract([FromODataUri] int key)
        {
            return SingleResult.Create(db.Contracts.Where(contract => contract.ID == key));
        }

        // PUT: odata/Contracts(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Contract> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Contract contract = await db.Contracts.FindAsync(key);
            if (contract == null)
            {
                return NotFound();
            }

            patch.Put(contract);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(contract);
        }

        // POST: odata/Contracts
        public async Task<IHttpActionResult> Post(Contract contract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contracts.Add(contract);
            await db.SaveChangesAsync();

            return Created(contract);
        }

        // PATCH: odata/Contracts(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Contract> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Contract contract = await db.Contracts.FindAsync(key);
            if (contract == null)
            {
                return NotFound();
            }

            patch.Patch(contract);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(contract);
        }

        // DELETE: odata/Contracts(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Contract contract = await db.Contracts.FindAsync(key);
            if (contract == null)
            {
                return NotFound();
            }

            db.Contracts.Remove(contract);
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

        private bool ContractExists(int key)
        {
            return db.Contracts.Count(e => e.ID == key) > 0;
        }
    }
}
