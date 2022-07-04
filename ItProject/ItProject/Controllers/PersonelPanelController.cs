using BussinesLayer.Concrete;
using BussinesLayer.ValidationRules;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItProject.Controllers
{
    //personelin kendi bilgilerini ona tanımlı anketleri gördüğü cevapladığı kendi bilgileri güncelleği alandır.
    [Authorize]
    public class PersonelPanelController : Controller
    {

        PersonelManager pm = new PersonelManager(new EfPersonalDal());
        SurveyManager sm = new SurveyManager(new EfSurveyDal());
        SurveyQuestionManager sqm = new SurveyQuestionManager(new EfSurveyQuestionDal());
        SurveyAnswerManager sam = new SurveyAnswerManager(new EfsurveyAnswerDal());
        PerconalValidator perconalvalidator = new PerconalValidator();
        SurveyAnsverValidator surveyanswervalidator = new SurveyAnsverValidator();
        //session ile değerler taşınarak personelin kendi bilgileri getirlir.
        public ActionResult Index(string p)
        {
            Context c = new Context();
            p = (string)Session["PersonalUsername"];
            var personalidinfo = c.personals.Where(x => x.PersonalUsername == p).Select(y => y.PersonalId).FirstOrDefault();
            var personalvalues = pm.GetListByPersonalId(personalidinfo);
            return View(personalvalues);
        }
        //session ile değerler taşınarak personelin kendi bilgileri getirlir.
        public ActionResult MyInform(string p)
        {
            Context c = new Context();
            p = (string)Session["PersonalUsername"];
            var personalidinfo = c.personals.Where(x => x.PersonalUsername == p).Select(y => y.PersonalId).FirstOrDefault();
            var personalvalues = pm.GetListByPersonalId(personalidinfo);
            return View(personalvalues);
        }
        //personelin kendi bilgilerini düzenlmesi için geln sayfa
        [HttpGet]
        public ActionResult EditInform(int id)
        {
            List<SelectListItem> personalsurvey = (from x in pm.getlist()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.PersonalName,
                                                       Value = x.PersonalId.ToString()
                                                   }).ToList();
            ViewBag.vlc = personalsurvey;
            var PersonalValue = pm.GetbyId(id);
            return View(PersonalValue);
        }
        //onaylandıktan sonra bilgiler veri tabanına işler.
        [HttpPost]
        public ActionResult EditInform(Personal p)
        {
            ValidationResult results = perconalvalidator.Validate(p);
            if (results.IsValid)
            {
                p.PersonalStatus = true;
                pm.PersonalUpdate(p);
                return RedirectToAction("MyInform");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        //personele tanımlı anketlerin görüldüğü sayfa
        public ActionResult Survey(string p)
        {
            Context c = new Context();
            p = (string)Session["PersonalUsername"];
            var personalcompanyinfo = c.personals.Where(x => x.PersonalUsername == p).Select(y => y.CompanyId).FirstOrDefault();
            var SurveyValues = sm.GetListBySurveyId(personalcompanyinfo);
            return View(SurveyValues);

        }
        //anket soruların çıktığı sayfa
        [HttpGet]
        public ActionResult SurveyQuestion(int id)
        {
            var surveyquestionvalue = sqm.GetListBySurveyQuestionId(id);
            return View(surveyquestionvalue);

        }
        [HttpPost]
        public ActionResult SurveyQuestion(SurveyAnswer p)
        {
            sam.SurveyAnswerUpdate(p);
            return RedirectToAction("Survey");
        }
        //anket sorusuna cevap vermek için yönlendirilen sayfa
        [HttpGet]
        public ActionResult SurveyAnswer(int id)
        {
            var answervalue = sam.GetbyId(id);
            return View(answervalue);
        }
        //onaylandıktan sonra anket cevabının veri tabanına işlenir
        [HttpPost]
        public ActionResult SurveyAnswer(SurveyAnswer p)
        {
            ValidationResult results = surveyanswervalidator.Validate(p);
            if (results.IsValid)
            {
                sam.SurveyAnswerUpdate(p);
                return RedirectToAction("SurveyQuestion/1");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}