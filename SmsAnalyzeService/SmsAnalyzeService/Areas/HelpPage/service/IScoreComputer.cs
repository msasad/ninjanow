using SmsAnalyzeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsAnalyzeService.Areas.HelpPage.service
{
    /// <summary>
    /// Each Score computer should extend this Module
    /// </summary>
    /// <typeparam name="SCI ">ScoreComputerInpute </typeparam>
    /// <typeparam name="GCS"> Grabe Credit Score class </typeparam>
    interface IScoreComputer<SCI , GCS>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        GCS Calculate(SCI input);

    }
}
