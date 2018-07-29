using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using CargoGo.Models;

namespace CargoGo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SupportedMediaTypes.Clear();

            // Web API 路由
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Truck>("trucks");
            builder.EntitySet<Company>("companies");
            builder.EntitySet<BankAccout>("bankaccouts");
            builder.EntitySet<CompanyDeliveryAddress>("companydeliveryaddresses");
            builder.EntitySet<Contract>("contracts");
            builder.EntitySet<Direction>("directions");
            builder.EntitySet<Invoice>("invoices");
            builder.EntitySet<PaymentType>("paymenttypes");
            builder.EntitySet<Payment>("payments");
            builder.EntitySet<Product>("products");
            builder.EntitySet<SalesDetail>("salesdetails");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
