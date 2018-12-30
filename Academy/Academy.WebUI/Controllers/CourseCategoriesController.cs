using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Academy.Application;
using Academy.Application.Contracts;
using Academy.Application.Contracts.CourseCategories;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Academy.WebUI.Controllers
{
    public class CourseCategoriesController : Controller
    {
        private readonly ICourseCategoryService _service;
        public CourseCategoriesController(ICourseCategoryService service)
        {
            _service = service;
        }

        public JsonResult CreateRoot(string title)
        {
            _service.CreateRoot(title);
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }

        // GET: CourseCategories
        public JsonResult CreateChild(string title, long parentId)
        {
            _service.CreateChild(title, parentId);
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            var allCategories = _service.GetAll();
            return View(allCategories);
        }

        public JsonResult Tree(DataSourceRequest request)
        {
            var allCategories = _service.GetAll();
            return Json(allCategories.ToTreeDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}