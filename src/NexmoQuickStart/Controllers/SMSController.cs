using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nexmo.Api;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NexmoQuickStart.Controllers
{
    public class SMSController : Controller
    {
        public IConfiguration configuration;

        public IActionResult Index()
        {
            return View();
        }
        // GET: /<controller>/
        public IActionResult Send()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Send(string to, string text)
        {
            var results = SMS.Send(new SMS.SMSRequest
            {
                
                from = "NEXMO_NUMBER",
                to = to,
                text = text
            });
            return View("Index");
        }

        [HttpGet]
        public IActionResult Recieve([FromQuery]SMS.SMSInbound response)
        {

            if (null != response.to && null != response.msisdn)
            {
                Debug.WriteLine("-------------------------------------------------------------------------");
                Debug.WriteLine("INCOMING TEXT");
                Debug.WriteLine("From: " + response.msisdn);
                Debug.WriteLine(" Message: " + response.text);
                Debug.WriteLine("-------------------------------------------------------------------------");
                return StatusCode(200);
            }
            else
            {
                Debug.WriteLine("-------------------------------------------------------------------------");
                Debug.WriteLine("Endpoint was hit.");
                Debug.WriteLine("-------------------------------------------------------------------------");
                return StatusCode(200);
;            }

        }
        
        [HttpGet]
        public ActionResult DLR([FromQuery]SMS.SMSDeliveryReceipt response)
        {

            Debug.WriteLine("-------------------------------------------------------------------------");
            Debug.WriteLine("DELIVERY RECIEPT");
            Debug.WriteLine("Message ID: " + response.messageId);
            Debug.WriteLine("From: " + response.msisdn);
            Debug.WriteLine("To: " + response.to);
            Debug.WriteLine("Status: " + response.status);
            Debug.WriteLine("-------------------------------------------------------------------------");
            return StatusCode(200);
        }
    }
}
