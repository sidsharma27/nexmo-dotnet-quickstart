using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nexmo.Api;
using Nexmo.Api.Voice;
using System.Diagnostics;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

    
    //INC

namespace NexmoQuickStart.Controllers
{
    public class VoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MakeCall()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MakeCall(string to)
        {
          
            var results = Call.Do(new Call.CallCommand
            {
                to = new[]
                {
                    new Call.Endpoint {
                        type = "phone",
                        number = to
                    }
                },
                from = new Call.Endpoint
                {
                    type = "phone",
                    number = Configuration.Instance.Settings["appSettings:NEXMO_FROM_NUMBER"]
                },
                answer_url = new[]
                {
                    "https://nexmo-community.github.io/ncco-examples/first_call_talk.json"
                }
            });
            StatusCode(200);
            return RedirectToAction("Index", "Voice");
        }

        [HttpGet]
        public IActionResult CallList()
        {
            var results = Call.List()._embedded.calls;
            for(int i = 0; i < results.Count; i++)
            {
                Debug.WriteLine(results[i].conversation_uuid);
            }
            ViewData.Add("results",results);
            ViewData.Add("count", results.Count);
            return View();
        }

        [HttpGet]
        public IActionResult GetCall()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetCall(string id)
        {
            var call = Call.Get(id);
            ViewData.Add("call", call);
            return View();
        }
    }
}
