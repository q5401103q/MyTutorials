using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QRLoginTutorial.Startup))]
namespace QRLoginTutorial
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR("/signalr", new Microsoft.AspNet.SignalR.HubConfiguration() { EnableJSONP = true });
            ConfigureAuth(app);
        }
    }
}
