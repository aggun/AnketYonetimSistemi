using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BussinesLayer.Abstract;
using BussinesLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Newtonsoft.Json;

namespace ItProject.Controllers
{
    //giriş yapılması için herkese izin verildi. bu sayfaya erişim her zaman sağlanmalı.
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AdminLoginManager adminLogin = new AdminLoginManager(new EfAdminDal());
        ManagerLoginManager managerLogin = new ManagerLoginManager(new EfManagerDal());
        PerconelLoginManager perconelLogin = new PerconelLoginManager(new EfPersonalDal());

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        //parametreden gelen değer ve veri tabanındaki değerlerin örtüşüp örtüşmediği karşılaştırıldı.
        //session ile otantike olan kullanıcı bilgileri alındı ve ona ait bilgiler erişeceği alan getirildi.
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var adminuserinfo = adminLogin.Getadmin(p.AdminUsername, p.AdminPassword);
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUsername, false);
                Session["AdminUsername"] = adminuserinfo.AdminUsername;
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewData["ErrorMessage"] = "Kullanıcı adı veya Parola yanlış";
                return View();
            }

        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
        public ActionResult PersonalLogOut()
        {

            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AllHeading", "WriterPanel");
        }
        //parametreden gelen değer ve veri tabanındaki değerlerin örtüşüp örtüşmediği karşılaştırıldı.
        //session ile otantike olan kullanıcı bilgileri alındı ve ona ait bilgiler erişeceği alan getirildi.
        [HttpGet]
        public ActionResult PersonalLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonalLogin(Personal p)
        {
            var personaluserinfo = perconelLogin.GetPersonel(p.PersonalUsername, p.PersonalPassword);

            if (personaluserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(personaluserinfo.PersonalUsername, false);
                Session["PersonalUsername"] = personaluserinfo.PersonalUsername;
                return RedirectToAction("MyInform", "PersonelPanel");
            }
            else
            {
                ViewData["ErrorMessage"] = "Kullanıcı adı veya Parola yanlış";
                return View();
            }

        }
        //parametreden gelen değer ve veri tabanındaki değerlerin örtüşüp örtüşmediği karşılaştırıldı.
        //session ile otantike olan kullanıcı bilgileri alındı ve ona ait bilgiler erişeceği alan getirildi.
        [HttpGet]
        public ActionResult ManagerLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ManagerLogin(Manager p)
        {
            var manageruserinfo = managerLogin.GetManager(p.ManagerUsername, p.ManagerPassword);

            if (manageruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(manageruserinfo.ManagerUsername, false);
                Session["ManagerUsername"] = manageruserinfo.ManagerPassword;
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewData["ErrorMessage"] = "Kullanıcı adı veya Parola yanlış";
                return View();
            }

        }
    }
}