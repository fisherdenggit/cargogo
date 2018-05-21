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
    builder.EntitySet<Direction>("Directions");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class DirectionsController : ODataController
    {
        private MyDBContext db = new MyDBContext();

        // GET: odata/Directions
        [EnableQuery]
        public IQueryable<Direction> GetDirections()
        {
            return db.Directions;
        }

        // GET: odata/Directions(5)
        [EnableQuery]
        public SingleResult<Direction> GetDirection([FromODataUri] int key)
        {
            return SingleResult.Create(db.Directions.Where(direction => direction.ID == key));
        }

        // PUT: odata/Directions(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Direction> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Direction direction = await db.Directions.FindAsync(key);
            if (direction == null)
            {
                return NotFound();
            }

            patch.Put(direction);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(direction);
        }

        // POST: odata/Directions
        public async Task<IHttpActionResult> Post(Direction direction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Directions.Add(direction);
            await db.SaveChangesAsync();

            return Created(direction);
        }

        // PATCH: odata/Directions(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Direction> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Direction direction = await db.Directions.FindAsync(key);
            if (direction == null)
            {
                return NotFound();
            }

            patch.Patch(direction);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(direction);
        }

        // DELETE: odata/Directions(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Direction direction = await db.Directions.FindAsync(key);
            if (direction == null)
            {
                return NotFound();
            }

            db.Directions.Remove(direction);
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

        private bool DirectionExists(int key)
        {
            return db.Directions.Count(e => e.ID == key) > 0;
        }
    }
}
