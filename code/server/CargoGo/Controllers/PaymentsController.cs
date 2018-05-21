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
    builder.EntitySet<Payment>("Payments");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PaymentsController : ODataController
    {
        private MyDBContext db = new MyDBContext();

        // GET: odata/Payments
        [EnableQuery]
        public IQueryable<Payment> GetPayments()
        {
            return db.Payments;
        }

        // GET: odata/Payments(5)
        [EnableQuery]
        public SingleResult<Payment> GetPayment([FromODataUri] int key)
        {
            return SingleResult.Create(db.Payments.Where(payment => payment.ID == key));
        }

        // PUT: odata/Payments(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Payment> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Payment payment = await db.Payments.FindAsync(key);
            if (payment == null)
            {
                return NotFound();
            }

            patch.Put(payment);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(payment);
        }

        // POST: odata/Payments
        public async Task<IHttpActionResult> Post(Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Payments.Add(payment);
            await db.SaveChangesAsync();

            return Created(payment);
        }

        // PATCH: odata/Payments(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Payment> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Payment payment = await db.Payments.FindAsync(key);
            if (payment == null)
            {
                return NotFound();
            }

            patch.Patch(payment);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(payment);
        }

        // DELETE: odata/Payments(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Payment payment = await db.Payments.FindAsync(key);
            if (payment == null)
            {
                return NotFound();
            }

            db.Payments.Remove(payment);
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

        private bool PaymentExists(int key)
        {
            return db.Payments.Count(e => e.ID == key) > 0;
        }
    }
}
