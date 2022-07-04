using Buss.Concrete;
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
    public class ManagerController : Controller
    {
        // GET: Manager
        CompanyManager cm = new CompanyManager(new EfCompanyDal());
        PersonelManager pm = new PersonelManager(new EfPersonalDal());
        ManagerManager mm = new ManagerManager (new EfManagerDal());
        SurveyManager sm = new SurveyManager(new EfSurveyDal());
        SurveyQuestionManager sqm = new SurveyQuestionManager(new EfSurveyQuestionDal());
        SurveyAnswerManager sam = new SurveyAnswerManager(new EfsurveyAnswerDal());
        SurveyValidator surveyvalidator = new SurveyValidator();
        PerconalValidator perconalvalidator = new PerconalValidator();
        SurveyQuestionValidator surveyquestionvalidator = new SurveyQuestionValidator();

        //personal ekleme sayfasına geçiş
        [HttpGet]
        public ActionResult AddPersonal()
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
        //girilen bilgiler bussines katmanındaki şartlara uygunsa ekleme işleme yapılır.
        //girilen bilgiler alınarak perosnel veri tabanına işlenmiş olur.
        [HttpPost]
        public ActionResult AddPersonal(Personal p)
        {
            ValidationResult results = perconalvalidator.Validate(p);
            if (results.IsValid)
            {
                p.PersonalStatus = true;
                pm.PersonalAdd(p);
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
        //hangi personele basılırsa onun bilgileri gelir ve düzeltme alanı gelir.
        [HttpGet]
        public ActionResult EditPersonal(int id)
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
        //onaylanınca sistem veri tabanındaki bilgileri değiştirir. fakat öncelikle validation sınıfında
        //istenilen şartların sağlandığı sorgulanır.
        [HttpPost]
        public ActionResult EditPersonal(Personal p)
        {
            ValidationResult results = perconalvalidator.Validate(p);
            if (results.IsValid)
            {
                p.PersonalStatus = true;
                pm.PersonalUpdate(p);
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
        //Personel status değeri false çekilir.
        public ActionResult DeletePersonal(int id)
        {
            var PersonalValue = pm.GetbyId(id);
            PersonalValue.PersonalStatus = false;
            pm.PersonalDelete(PersonalValue);
            return RedirectToAction("Index");
        }
        public ActionResult Index (string p)
        {
            Context c = new Context();
            p = (string)Session["ManagerSurname"];
            var manageridinfo = c.managers.Where(x => x.ManagerSurname == p).Select(y => y.ManagerId).FirstOrDefault();
            var managervalues = mm.GetListById(manageridinfo);
            return View(managervalues);
        }
        //yöneticicn şirket bilgisi ile o şirkete kayıtlı olan personeller getirlir.
        public ActionResult Perconel (string p)
        {
            Context c = new Context();
            p = (string)Session["ManagerUsername"];
            var manageridinfo = c.managers.Where(x => x.ManagerUsername == p).Select(y => y.CompanyId).FirstOrDefault();
            var managervalues = pm.GetListBycompanyId(manageridinfo);
            return View(managervalues);
        }
        [HttpGet]
        //yeni anket tanımlama sayfası
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
        [HttpPost]
        //onaylandıktan sonra anket veritabanına işler.
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
        //anket düzenleme sayfası.
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
        //onaylandıktan sonra anket veritabanına işler.
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
        [HttpGet]
        //ankete soru ekleme sayfası.
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
        [HttpPost]
        //onaylandıktan sonra anket sorusu veritabanına işler.
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
        //soruyu düzeltme sayfası
        public ActionResult EditQuestion(SurveyQuestion p)
        {
            ValidationResult results = surveyquestionvalidator.Validate(p);
            if (results.IsValid)
            {
                var SurveyQuestionValues = sqm.getlist();
                return View(SurveyQuestionValues);
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
        //eğer cevaplanan cevap herkese açıksa true ise o cevapları görür yönetici false olsa da görür.
        public ActionResult SurveyAnswer ()
        {
            var answervalues = sam.getlist();
            return View(answervalues);
        }
    }
}