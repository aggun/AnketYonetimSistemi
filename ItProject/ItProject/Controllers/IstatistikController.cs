using DataAccesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItProject.Controllers
{
    //istatistiklerin gelmesi ve listelnmesi için oluşturulmuş bölüm
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        public ActionResult Index()
        {
            Context context = new Context();
            var result = context.surveys.Count();
            var result2 = context.SurveyQuestions.Count();
            var result3 = context.surveyAnswers.Count(x => x.SurveyAnswerText.Contains ("evet"));
            var result4 = context.surveyAnswers.Count(x => x.SurveyAnswerText.Contains("hayır"));
            var result5 = context.companies.Count();
            var result6 = context.admins.Count();
            var result7 = context.managers.Count();
            var result8 = context.personals.Count();
            var result9 = context.surveyAnswers.Count();
            ViewBag.survey = result;
            ViewBag.SurveyQuestion = result2;
            ViewBag.surveyAnswer = result9;
            ViewBag.admins = result6;
            ViewBag.manager = result7;
            ViewBag.company = result5;
            ViewBag.personal = result8;
            ViewBag.Answeryes = result3;
            ViewBag.Answerno = result4;

            return View();
        }
    }
}