using ATS.Cadastro.Application.Interfaces;
using ATS.Cadastro.Application.ViewModels;
using ATS.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATS.Presentation.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {     
            return View();
        }
    }
}