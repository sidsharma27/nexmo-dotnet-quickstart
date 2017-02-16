using System;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Nexmo.Api;
using System.Windows;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NexmoQuickStart.Controllers
{
    public class VerifyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Start() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Start(string to)
        {
            var start = NumberVerify.Verify(new NumberVerify.VerifyRequest
            {
                number = to,
                brand = "NexmoQS"
            });
            HttpContext.Session.SetString("requestID", start.request_id);
            return RedirectToAction("Check");
        }
        [HttpGet]
        public IActionResult Check()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Check(string code)
        {
           var result = NumberVerify.Check(new NumberVerify.CheckRequest
            {
                request_id = HttpContext.Session.GetString("requestID"),
                code = code
            });
            
            if (result.status == "0")
            {
                ViewBag.Message = "Verification Sucessful";
            }
            else
            {
                ViewBag.Message = result.error_text;
            }
            return View();

        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Search(string requestID)
        {
            var search = NumberVerify.Search(new NumberVerify.SearchRequest
            {
                request_id = requestID
            });
            ViewBag.status = search.status;
            return View();
        }

        [HttpGet]
        public IActionResult Cancel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cancel(string requestID)
        {
            var results = NumberVerify.Control(new NumberVerify.ControlRequest
            {
                request_id = requestID,
                cmd = "cancel"
            });
            
            ViewBag.status = results.status;
            return View();
        }
    }
}
