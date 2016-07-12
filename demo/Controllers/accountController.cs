using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Demo.Model;
using Demo.Access;
namespace demo.Controllers
{
    public class accountController : Controller
    {
        private User _user = null;
        DemoAccess aceess = new DemoAccess();
        //
        // GET: /account/

        public ActionResult Index()
        {

            _user = aceess.GetLoginDetails();
            return View();
        }
        

    }
}
