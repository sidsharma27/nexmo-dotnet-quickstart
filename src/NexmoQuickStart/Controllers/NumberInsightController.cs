using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nexmo.Api;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NexmoQuickStart.Controllers
{
    public class NumberInsightController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Basic()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Basic(string number)
        {
            var results = NumberInsight.RequestBasic(new NumberInsight.NumberInsightBasicRequest
            {
                number = number,
            });
            HttpContext.Session.SetString("requestID", results.request_id);
            HttpContext.Session.SetString("iNumber", results.international_format_number);
            HttpContext.Session.SetString("nNumber", results.national_format_number);
            HttpContext.Session.SetString("status", results.status_message);
            HttpContext.Session.SetString("country", results.country_name);
            HttpContext.Session.SetString("countryCode", results.country_code);

            return RedirectToAction("BasicResults");
        }

        [HttpGet]
        public IActionResult BasicResults()
        {

            ViewBag.requestID = HttpContext.Session.GetString("requestID");
            ViewBag.iNumber = HttpContext.Session.GetString("iNumber");
            ViewBag.nNumber = HttpContext.Session.GetString("nNumber");
            ViewBag.status = HttpContext.Session.GetString("status");
            ViewBag.country = HttpContext.Session.GetString("country");
            ViewBag.countryCode = HttpContext.Session.GetString("countryCode");

            return View();
        }


        [HttpGet]
        public IActionResult Standard()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Standard(string number)
        {
            var results = NumberInsight.RequestStandard(new NumberInsight.NumberInsightBasicRequest()
            {
                number = number,
            });
            HttpContext.Session.SetString("requestID", results.request_id);
            HttpContext.Session.SetString("iNumber", results.international_format_number);
            HttpContext.Session.SetString("nNumber", results.national_format_number);
            HttpContext.Session.SetString("country", results.country_name);
            HttpContext.Session.SetString("countryCode", results.country_code);
            HttpContext.Session.SetString("status", results.status_message);
            HttpContext.Session.SetString("currentCarrierName", results.original_carrier.name);
            HttpContext.Session.SetString("currentCarrierCode", results.current_carrier.network_code);
            HttpContext.Session.SetString("currentCarrierType", results.current_carrier.network_type);
            HttpContext.Session.SetString("currentCarrierCountry", results.current_carrier.country);
            HttpContext.Session.SetString("originalCarrierName", results.original_carrier.name);
            HttpContext.Session.SetString("originalCarrierCode", results.original_carrier.network_code);
            HttpContext.Session.SetString("originalCarrierType", results.original_carrier.network_type);
            HttpContext.Session.SetString("originalCarrierCountry", results.original_carrier.country);



            return RedirectToAction("StandardResults");
        }

        [HttpGet]
        public IActionResult StandardResults()
        {
            ViewBag.requestID = HttpContext.Session.GetString("requestID");
            ViewBag.iNumber = HttpContext.Session.GetString("iNumber");
            ViewBag.nNumber = HttpContext.Session.GetString("nNumber");
            ViewBag.status = HttpContext.Session.GetString("status");
            ViewBag.country = HttpContext.Session.GetString("country");
            ViewBag.countryCode = HttpContext.Session.GetString("countryCode");
            ViewBag.currentCarrierName = HttpContext.Session.GetString("currentCarrierName");
            ViewBag.currentCarrierCode = HttpContext.Session.GetString("currentCarrierCode");
            ViewBag.currentCarrierType = HttpContext.Session.GetString("currentCarrierType");
            ViewBag.currentCarrierCountry = HttpContext.Session.GetString("currentCarrierCountry");
            ViewBag.originalCarrierName = HttpContext.Session.GetString("originalCarrierName");
            ViewBag.originalCarrierCode = HttpContext.Session.GetString("originalCarrierCode");
            ViewBag.originalCarrierType = HttpContext.Session.GetString("originalCarrierType");
            ViewBag.originalCarrierCountry = HttpContext.Session.GetString("originalCarrierCountry");
            return View();
        }

    }

}
