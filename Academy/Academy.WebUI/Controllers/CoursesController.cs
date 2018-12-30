using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Academy.Application.Contracts;
using Academy.Application.Contracts.Courses;
using Framework.Kendo;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Academy.WebUI.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _service;
        public CoursesController(ICourseService service)
        {
            _service = service;
        }
        // GET: Courses
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Grid([DataSourceRequest]DataSourceRequest request)
        {
            var courses = _service.GetAll(new KendoFilter(request));
            return Json(courses, JsonRequestBehavior.AllowGet);
        }
    }
}