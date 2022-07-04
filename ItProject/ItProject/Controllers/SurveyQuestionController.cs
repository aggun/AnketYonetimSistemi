using Buss.Concrete;
using BussinesLayer.Concrete;
using BussinesLayer.ValidationRules;
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
  //  [AllowAnonymous]
    public class SurveyQuestionController : Controller
    {
        // GET: Heading
        CompanyManager cm = new CompanyManager(new EfCompanyDal());
        SurveyManager sm = new SurveyManager(new EfSurveyDal());
        SurveyQuestionManager sqm = new SurveyQuestionManager(new EfSurveyQuestionDal());
        SurveyQuestionValidator surveyquestionvalidator = new SurveyQuestionValidator();
        //adminin soruları gördüğü sayfadır.
        public ActionResult Index()
        {
            var SurveyQuestionValues = sqm.getlist();
            return View(SurveyQuestionValues);
        }
        [HttpGet]
        //yeni soru eklme syfası. öncelikle hangi ankete işlenceği seçilir.
        public ActionResult AddSurveyQuestion()
        {
            List<SelectListItem> valuecategory = (from x in sm.getlist()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.SurveyName,
                                                      Value = x.SurveyId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }
        //onaylandıktan sonra soru veri tabanına işler
        [HttpPost]
        public ActionResult AddSurveyQuestion(SurveyQuestion p)
        {
            ValidationResult results = surveyquestionvalidator.Validate(p);
            if (results.IsValid)
            {
                p.SurveyQuestionStatus = true;
                // p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                sqm.SurveyQuestionlAdd(p);
                return RedirectToAction("Index");
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
        //anket sorusunu düzenlme syfası
        [HttpGet]
        public ActionResult EditSurveyQuestion(int id)
        {
            List<SelectListItem> valuesurvey = (from x in sm.getlist()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.SurveyName,
                                                      Value = x.SurveyId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuesurvey;
            var SurveyQuestion = sqm.GetbyId(id);
            return View();
        }
        //onaylandıktan sonra soru veri tabanına işler
        [HttpPost]
        public ActionResult EditSurveyQuestion(SurveyQuestion p)
        {
            ValidationResult results = surveyquestionvalidator.Validate(p);
            if (results.IsValid)
            {
                //  p.HeadingStatus = true;
                sqm.SurveyQuestionUpdate(p);
                return RedirectToAction("Index");
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
        //anket sorusunun veri tabanındaki değeri false olarak çekilir.
        public ActionResult DeleteHeading(int id)
        {
            var SurveyQuestionValue = sqm.GetbyId(id);
           // SurveyQuestionValue.SurveyQuestionStatus = false;
            sqm.SurveyQuestionDelete(SurveyQuestionValue); 
            return RedirectToAction("Index");
        }
    }
}