using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(SignalR2048.Startup))]
namespace SignalR2048
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}