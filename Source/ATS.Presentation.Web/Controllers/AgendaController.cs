using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATS.Presentation.Web.Controllers
{
    public class AgendaController : BaseController
    {
        // GET: Agenda
        public ActionResult Index()
        {
            return View();
        }
    }
}