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
    builder.EntitySet<Invoice>("Invoices");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class InvoicesController : ODataController
    {
        private MyDBContext db = new MyDBContext();

        // GET: odata/Invoices
        [EnableQuery]
        public IQueryable<Invoice> GetInvoices()
        {
            return db.Invoices;
        }

        // GET: odata/Invoices(5)
        [EnableQuery]
        public SingleResult<Invoice> GetInvoice([FromODataUri] int key)
        {
            return SingleResult.Create(db.Invoices.Where(invoice => invoice.ID == key));
        }

        // PUT: odata/Invoices(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Invoice> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Invoice invoice = await db.Invoices.FindAsync(key);
            if (invoice == null)
            {
                return NotFound();
            }

            patch.Put(invoice);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(invoice);
        }

        // POST: odata/Invoices
        public async Task<IHttpActionResult> Post(Invoice invoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Invoices.Add(invoice);
            await db.SaveChangesAsync();

            return Created(invoice);
        }

        // PATCH: odata/Invoices(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Invoice> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Invoice invoice = await db.Invoices.FindAsync(key);
            if (invoice == null)
            {
                return NotFound();
            }

            patch.Patch(invoice);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(invoice);
        }

        // DELETE: odata/Invoices(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Invoice invoice = await db.Invoices.FindAsync(key);
            if (invoice == null)
            {
                return NotFound();
            }

            db.Invoices.Remove(invoice);
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

        private bool InvoiceExists(int key)
        {
            return db.Invoices.Count(e => e.ID == key) > 0;
        }
    }
}
