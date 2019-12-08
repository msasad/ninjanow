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
    /// Controller Responsible for Triggering Social Score Processor
    /// </summary>
    [RoutePrefix("api/SocialNetwork")]
    public class SocialNetworkScoreProcessorController : ApiController
    {

        public SocialNetworkScoreProcessorController() {
            RepositoryService.init();
        }

        [HttpPost]
        [Route("RunProcessor")]
        public GrabCreditScoreBase RunComputerSocial( [FromBody] SocialScoreComputerInpute input)
        {
            var score = new SocialWebsiteScoreComputer().Calculate(input);
            return score;
        }

    }
}
