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
using CargoGo.Util;

namespace CargoGo.Controllers
{
    /*
    在为此控制器添加路由之前，WebApiConfig 类可能要求你做出其他更改。请适当地将这些语句合并到 WebApiConfig 类的 Register 方法中。请注意 OData URL 区分大小写。

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using CargoGo.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Truck>("Trucks");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class TrucksController : ODataController
    {
        private MyDBContext db = new MyDBContext();

        // GET: odata/Trucks
        [EnableQuery]
        public IQueryable<Truck> GetTrucks()
        {
            return db.Trucks;
        }

        // GET: odata/Trucks(5)
        [EnableQuery]
        public SingleResult<Truck> GetTruck([FromODataUri] string key)
        {
            /*此部分为重新改写*/
            Boolean weChatLoginResult = false;
            try
            {
                String weChatAPPID = "wx7e6c11974fbb3699";
                String weChatSecretString = "a2af134685148f465721879f6ceab094";
                String weChatLoginCode = Request.GetQueryNameValuePairs().ElementAt(0).Value;
                String weChatNickName = Request.GetQueryNameValuePairs().ElementAt(1).Value;
                WeChatTool wct = new WeChatTool(weChatAPPID, weChatSecretString);
                wct.WeChatLoginCode = weChatLoginCode;
                wct.TencentWeChatAPIUrlForCheckLogin = "https://api.weixin.qq.com/sns/jscode2session";
                weChatLoginResult = wct.LoadOpenID();
                wct.LoadNickName(weChatNickName);
                if(weChatLoginResult)
                {
                    wct.SaveOpenIDandNickName(wct.OpenID, wct.NickName);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            /*此部分为重新改写*/

            //针对从微信小程序平台发起的请求并成功从微信小程序登录服务器换取登录令牌并获取到openId的用户，返回对应检索值
            if(weChatLoginResult)
            {
                return SingleResult.Create(db.Trucks.Where(truck => truck.TruckID == key));
            }
            //此处对非从微信小程序平台发起的请求一律返回空值
            else
            {
                return SingleResult.Create(db.Trucks.Where(truck => truck.TruckID == null));
            }
        }

        // PUT: odata/Trucks(5)
        public async Task<IHttpActionResult> Put([FromODataUri] string key, Delta<Truck> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Truck truck = await db.Trucks.FindAsync(key);
            if (truck == null)
            {
                return NotFound();
            }

            patch.Put(truck);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TruckExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(truck);
        }

        // POST: odata/Trucks
        public async Task<IHttpActionResult> Post(Truck truck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Trucks.Add(truck);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TruckExists(truck.TruckID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(truck);
        }

        // PATCH: odata/Trucks(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<Truck> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Truck truck = await db.Trucks.FindAsync(key);
            if (truck == null)
            {
                return NotFound();
            }

            patch.Patch(truck);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TruckExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(truck);
        }

        // DELETE: odata/Trucks(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] string key)
        {
            Truck truck = await db.Trucks.FindAsync(key);
            if (truck == null)
            {
                return NotFound();
            }

            db.Trucks.Remove(truck);
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

        private bool TruckExists(string key)
        {
            return db.Trucks.Count(e => e.TruckID == key) > 0;
        }
    }
}
