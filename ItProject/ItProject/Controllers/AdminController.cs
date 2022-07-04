using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItProject.Controllers
{
    public class AdminController : Controller
    {
        //soruların cevaplarının getirildiği görünümün kodları
        SurveyAnswerManager sam = new SurveyAnswerManager(new EfsurveyAnswerDal());
        // GET: Admin
        public ActionResult AnswerQuestion()
        {
            var answervalues = sam.getlist();
            return View(answervalues);
        }
    }
}