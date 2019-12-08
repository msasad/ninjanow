using SmsAnalyzeService.Areas.HelpPage.service;
using SmsAnalyzeService.Models;
using SmsAnalyzeService.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmsAnalyzeService.Controllers
{
    /// <summary>
    /// Controller Responsible for Triggering Sms Score Processor
    /// </summary>
    [RoutePrefix("api/SmsAnalysis")]
    public class SmsScoreProcessorController : ApiController
    {

        public SmsScoreProcessorController() {
            RepositoryService.init();
        }

        [HttpPost]
        [Route("RunProcessor")]
        public GrabCreditScoreBase RunComputerSms(SmsScoreComputerInpute input) {
            var score =  new SmsScoreComputer().Calculate(input as SmsScoreComputerInpute);
            return score;
        }



    }
}
