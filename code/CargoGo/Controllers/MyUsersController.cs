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
    builder.EntitySet<MyUser>("MyUsers");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class MyUsersController : ODataController
    {
        private MyDBContext db = new MyDBContext();

        // GET: odata/MyUsers
        [EnableQuery]
        public IQueryable<MyUser> GetMyUsers()
        {
            return db.MyUsers;
        }

        // GET: odata/MyUsers(5)
        [EnableQuery]
        public SingleResult<MyUser> GetMyUser([FromODataUri] int key)
        {
            return SingleResult.Create(db.MyUsers.Where(myUser => myUser.ID == key));
        }

        // PUT: odata/MyUsers(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<MyUser> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MyUser myUser = await db.MyUsers.FindAsync(key);
            if (myUser == null)
            {
                return NotFound();
            }

            patch.Put(myUser);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyUserExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(myUser);
        }

        // POST: odata/MyUsers
        public async Task<IHttpActionResult> Post(MyUser myUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MyUsers.Add(myUser);
            await db.SaveChangesAsync();

            return Created(myUser);
        }

        // PATCH: odata/MyUsers(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<MyUser> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MyUser myUser = await db.MyUsers.FindAsync(key);
            if (myUser == null)
            {
                return NotFound();
            }

            patch.Patch(myUser);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyUserExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(myUser);
        }

        // DELETE: odata/MyUsers(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            MyUser myUser = await db.MyUsers.FindAsync(key);
            if (myUser == null)
            {
                return NotFound();
            }

            db.MyUsers.Remove(myUser);
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

        private bool MyUserExists(int key)
        {
            return db.MyUsers.Count(e => e.ID == key) > 0;
        }
    }
}
