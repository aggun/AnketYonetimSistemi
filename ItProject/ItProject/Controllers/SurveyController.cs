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
   // [AllowAnonymous]
    public class SurveyController : Controller
    {
        CompanyManager cm = new CompanyManager(new EfCompanyDal());
        SurveyManager sm = new SurveyManager(new EfSurveyDal());
        SurveyValidator surveyvalidator = new SurveyValidator();
        //adminin anketleri gördüğü dayfa.
        public ActionResult Index()
        {
            var SurveyValues = sm.getlist();
            return View(SurveyValues);
        }
        //anket ekleme sayfası
        [HttpGet]
        public ActionResult AddSurvey()
        {
            List<SelectListItem> surveycategory = (from x in cm.Getlist()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CompanyName,
                                                       Value = x.CompanyId.ToString()
                                                   }).ToList();
            ViewBag.vlc = surveycategory;
            return View();
        }
        //onaylandıkan sonra anket veritabanına işler.
        [HttpPost]
        public ActionResult AddSurvey(Survey p)
        {
            ValidationResult results = surveyvalidator.Validate(p);
            if (results.IsValid)
            {
                p.SurveyStatus = true;
                sm.SurveyAdd(p);
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
        [HttpGet]
        //anket düzenlme sayfası
        public ActionResult EditSurvey(int id)
        {
            List<SelectListItem> valuesurvey = (from x in sm.getlist()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.SurveyName,
                                                      Value = x.SurveyId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuesurvey;
            var SurveyValue = sm.GetbyId(id);
            return View(SurveyValue);
        }
        //onaylandıkan sonra anket veritabanına işler.
        [HttpPost]
        public ActionResult EditSurvey(Survey p)
        {
            ValidationResult results = surveyvalidator.Validate(p);
            if (results.IsValid)
            {
                p.SurveyStatus = true;
                sm.SurveyUpdate(p);
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
        //anketin durumu veritabanında false olarak çekilir.
        public ActionResult DeleteSurvey(int id)
        {
            var SurveyValue = sm.GetbyId(id);
            SurveyValue.SurveyStatus = false;
            sm.SurveyDelete(SurveyValue);
            return RedirectToAction("Index");
        }
    }
}