using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalR2048.Controllers
{
    public static class SessionRef
    {
       public static bool InSession = false;
    }

    public class PlayController : Controller
    {
        //
        // GET: /Vote/
        public ActionResult Index()
        {
            System.Diagnostics.Trace.TraceInformation("Index entered");

            if (SessionRef.InSession)
            {
                return View("InSession");
            }

            System.Diagnostics.Trace.TraceInformation("Returning index view");

            return View("Game2");                
        }

        //
        // GET: /Vote/
        public ActionResult Reset()
        {
            SessionRef.InSession = false;
            return RedirectToAction("Game");
        }

        public ActionResult TestTest()
        {
            return View();
        }
	}
}