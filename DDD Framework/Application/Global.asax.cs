using System.Web.Http;

namespace Application
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start() 
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            UnityConfig.RegisterComponents();
            //var config = new MapperConfiguration(cfg => {
            //    cfg.AddMaps("Infraestructure");
            //});
        }
    }
}
