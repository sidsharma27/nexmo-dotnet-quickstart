using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nexmo.Api;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NexmoQuickStart.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult SearchMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SearchMessage(string messageID)
        {
            var message = Search.GetMessage(messageID);
            if (message.messageId != null)
            {
                ViewData.Add("message", message);
            }
            else {
                bool notFound = true;
                ViewData.Add("notFound", notFound);
            }
            return View();
        }
        [HttpGet]
        public IActionResult SearchRejection()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SearchRejection(string messageID, string number, DateTime rejectionDate )
        {

            string date = rejectionDate.Year + "-" + rejectionDate.Month + "-" + rejectionDate.Day;
          
            var msgs = Search.GetRejections(new Search.SearchRequest
            {
                date = date,
                to = number
            });
            ViewData.Add("items", msgs.items);
            return View();
        }
    }
}
