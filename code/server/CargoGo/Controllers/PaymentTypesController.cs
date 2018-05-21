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
    builder.EntitySet<PaymentType>("PaymentTypes");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PaymentTypesController : ODataController
    {
        private MyDBContext db = new MyDBContext();

        // GET: odata/PaymentTypes
        [EnableQuery]
        public IQueryable<PaymentType> GetPaymentTypes()
        {
            return db.PaymentTypes;
        }

        // GET: odata/PaymentTypes(5)
        [EnableQuery]
        public SingleResult<PaymentType> GetPaymentType([FromODataUri] int key)
        {
            return SingleResult.Create(db.PaymentTypes.Where(paymentType => paymentType.ID == key));
        }

        // PUT: odata/PaymentTypes(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<PaymentType> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PaymentType paymentType = await db.PaymentTypes.FindAsync(key);
            if (paymentType == null)
            {
                return NotFound();
            }

            patch.Put(paymentType);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTypeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(paymentType);
        }

        // POST: odata/PaymentTypes
        public async Task<IHttpActionResult> Post(PaymentType paymentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PaymentTypes.Add(paymentType);
            await db.SaveChangesAsync();

            return Created(paymentType);
        }

        // PATCH: odata/PaymentTypes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<PaymentType> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PaymentType paymentType = await db.PaymentTypes.FindAsync(key);
            if (paymentType == null)
            {
                return NotFound();
            }

            patch.Patch(paymentType);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTypeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(paymentType);
        }

        // DELETE: odata/PaymentTypes(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            PaymentType paymentType = await db.PaymentTypes.FindAsync(key);
            if (paymentType == null)
            {
                return NotFound();
            }

            db.PaymentTypes.Remove(paymentType);
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

        private bool PaymentTypeExists(int key)
        {
            return db.PaymentTypes.Count(e => e.ID == key) > 0;
        }
    }
}
