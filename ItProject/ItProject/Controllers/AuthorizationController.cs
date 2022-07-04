using BussinesLayer.Abstract;
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
    public class AuthorizationController : Controller
    {
        // GET: Authorization
       // IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()), new PersonelManager (new EfPersonalDal()));
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        RoleManager roleManager = new RoleManager(new EfRoleDal());
        AdminValidator adminvalidator = new AdminValidator();

        public ActionResult Index()
        {
            var result = adminManager.GetAdmins();
            return View(result);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> valueadminrole = (from c in roleManager.GetRoles()
                                                   select new SelectListItem
                                                   {
                                                       Text = c.RoleName,
                                                       Value = c.RoleId.ToString()

                                                   }).ToList();

            ViewBag.valueadmin = valueadminrole;
            return View();
        }
        //girilen bilgiler bussines katmanındaki şartlara uygunsa ekleme işleme yapılır.
        [HttpPost]
        public ActionResult AddAdmin(Admin p)

        {
            ValidationResult results = adminvalidator.Validate(p);
            if (results.IsValid)
            {
                p.AdminStatus = true;
                adminManager.Add(p);
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
        public ActionResult UpdateAdmin(int id)
        {
            List<SelectListItem> valueadminrole = (from c in roleManager.GetRoles()
                                                   select new SelectListItem
                                                   {
                                                       Text = c.RoleName,
                                                       Value = c.RoleId.ToString()

                                                   }).ToList();

            ViewBag.valueadmin = valueadminrole;
            var result = adminManager.GetById(id);
            return View(result);
        }
        //girilen bilgiler bussines katmanındaki şartlara uygunsa ekleme işleme yapılır.
        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {
            ValidationResult results = adminvalidator.Validate(admin);
            if (results.IsValid)
            {
                admin.AdminStatus = true;
                adminManager.Update(admin);
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

        public ActionResult DeleteAdmin(int id)
        {
            var result = adminManager.GetById(id);
            if (result.AdminStatus == true)
            {
                result.AdminStatus = false;
            }
            else
            {
                result.AdminStatus = true;
            }
            adminManager.Update(result);
            return RedirectToAction("Index");
        }
    }
}