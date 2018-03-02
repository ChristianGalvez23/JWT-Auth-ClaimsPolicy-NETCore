using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers {
    public class OperationsController : Controller {
        public OperationsController () {

        }

        [Route ("api/users")]
        [Authorize (Policy = "Users")]
        [HttpGet]
        public JsonResult Users () {
            return Json ("List of Users");
        }

        [Route ("api/admins")]
        [Authorize (Policy = "Admins")]
        [HttpGet]
        public JsonResult Admins () {
            return Json ("List of admins");
        }

        [Route ("api/articles")]
        [Authorize]
        [HttpGet]
        public JsonResult Articles () {
            return Json ("List of Articles");
        }

        [Route ("api/books")]
        [AllowAnonymous]
        [HttpGet]
        public JsonResult Books () {
            return Json ("List of Books");
        }
    }
}