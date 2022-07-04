using Buss.Concrete;
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
    //hangi role sahip kişilerin erişeceği bilgisi verildi.
    [Authorize(Roles="A")]
    public class CompanyController : Controller
    {
        CompanyManager cm = new CompanyManager(new EfCompanyDal());
        CompanyValidator companyvalidator = new CompanyValidator();
        //tüm şirket bilgileri getirildi
        public ActionResult Index()
        {
            var companyvalues = cm.Getlist();
            return View(companyvalues);
        }
        // yeni şirket eklemek için kullanılacak view httpget olduğunda burası çalışıyor
        [HttpGet]
        public ActionResult AddCompany()
        {
            return View();
        }
        //post olduğunda bilgiler ve ekleme alanı geliyor ardından yeniden ındex sayfasna yönledniriliyor.
        //girilen bilgiler bussines katmanındaki şartlara uygunsa ekleme işleme yapılır.
        [HttpPost]
        public ActionResult AddCompany(Company p)
        {
            //cm.CategoryAddBl(p);
        
            ValidationResult results = companyvalidator.Validate(p);
            if (results.IsValid)
            {
                p.CompanyStatus = true;
                cm.CompanyAdd(p);
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
        //  şirket bilgilerini güncellemek için kullanılacak view httpget olduğunda burası çalışıyor
        [HttpGet]
        public ActionResult EditCompany(int id)
        {
            var companyvalue = cm.GetByID(id);
            return View(companyvalue);
        }
        //post olduğunda bilgiler ve düzenleme alanı geliyor ardından yeniden ındex sayfasna yönledniriliyor.
        //girilen bilgiler bussines katmanındaki şartlara uygunsa düzenleme işleme yapılır.
        [HttpPost]
        public ActionResult EditCompany(Company p)
        {
            ValidationResult results = companyvalidator.Validate(p);
            if (results.IsValid)
            {
                cm.CompanyUpdate(p);
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
    }
}
