using Nancy;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexmoVoiceASPNetCoreQuickStarts.Modules
{
    public class VoiceMailModule : NancyModule
    {
        public VoiceMailModule()
        {
            Get["/webhook/answer/"] = x => { var response = (Response)GetVoiceMailNCCO();
                                             response.ContentType = "application/json";
                                             return response;
                                           }; 
            Post["/webhook/event"] = x => Request.Query["status"];
        }
        private dynamic GetVoiceMailNCCO()
        {
            dynamic TalkNCCO = new JObject();
            TalkNCCO.action = "talk";
            TalkNCCO.text = "Hello. You have reached Bibi. Please, leave your message after the beep.";
            TalkNCCO.voiceName = "Emma";

            dynamic RecordNCCO = new JObject();
            RecordNCCO.action = "record";
            RecordNCCO.beepStart = true;
            RecordNCCO.eventUrl = "https://example.com/recording";
            RecordNCCO.endOnSilence = 3;


            JArray nccoObj = new JArray
            {
                TalkNCCO,
                RecordNCCO
            };

            return nccoObj.ToString();
        }
    }
}
