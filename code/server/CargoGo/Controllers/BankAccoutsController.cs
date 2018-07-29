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
    builder.EntitySet<BankAccout>("BankAccouts");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class BankAccoutsController : ODataController
    {
        private MyDBContext db = new MyDBContext();

        // GET: odata/BankAccouts
        [EnableQuery]
        public IQueryable<BankAccout> GetBankAccouts()
        {
            return db.BankAccouts;
        }

        // GET: odata/BankAccouts(5)
        [EnableQuery]
        public SingleResult<BankAccout> GetBankAccout([FromODataUri] int key)
        {
            return SingleResult.Create(db.BankAccouts.Where(bankAccout => bankAccout.ID == key));
        }

        // PUT: odata/BankAccouts(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<BankAccout> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BankAccout bankAccout = await db.BankAccouts.FindAsync(key);
            if (bankAccout == null)
            {
                return NotFound();
            }

            patch.Put(bankAccout);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankAccoutExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(bankAccout);
        }

        // POST: odata/BankAccouts
        public async Task<IHttpActionResult> Post(BankAccout bankAccout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BankAccouts.Add(bankAccout);
            await db.SaveChangesAsync();

            return Created(bankAccout);
        }

        // PATCH: odata/BankAccouts(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<BankAccout> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BankAccout bankAccout = await db.BankAccouts.FindAsync(key);
            if (bankAccout == null)
            {
                return NotFound();
            }

            patch.Patch(bankAccout);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankAccoutExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(bankAccout);
        }

        // DELETE: odata/BankAccouts(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            BankAccout bankAccout = await db.BankAccouts.FindAsync(key);
            if (bankAccout == null)
            {
                return NotFound();
            }

            db.BankAccouts.Remove(bankAccout);
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

        private bool BankAccoutExists(int key)
        {
            return db.BankAccouts.Count(e => e.ID == key) > 0;
        }
    }
}
