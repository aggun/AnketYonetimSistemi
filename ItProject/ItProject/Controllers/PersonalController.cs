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
    public class PersonalController : Controller
    {
        CompanyManager cm = new CompanyManager(new EfCompanyDal());
        PersonelManager pm = new PersonelManager(new EfPersonalDal());
        PerconalValidator perconalvalidator = new PerconalValidator();
        public ActionResult Index()
        {
            var PersonalValues = pm.getlist();
            return View(PersonalValues);
        }
        //admin için personel eklme sayfası öncelikle hangi şirkete ekleme yapacağını seçmeli
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
        //onaylandıkran sonra personel veri tabnaına işler.
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
        [HttpGet]
        //personel bilgileri düznelme sayfaı.
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
        //onaylandıkran sonra personel veri tabnaına işler.
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
        //personelin durumunu verit abanında false olarak çekilir.
        public ActionResult DeletePersonal(int id)
        {
            var PersonalValue = pm.GetbyId(id);
            PersonalValue.PersonalStatus = false;
            pm.PersonalDelete(PersonalValue);
            return RedirectToAction("Index");
        }
    }
}