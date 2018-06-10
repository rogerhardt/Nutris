using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Nutris.Models;

namespace Nutris.Controllers
{
    public class UsuarioController : Controller
    {
        private NutrisEntities db = new NutrisEntities();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "login,password,email,nutricionista")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(usuario);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Usuario");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "login,password,rememberMe")] UsuarioLogin usu, string ReturnUrl = "")
        {
            string message = "";
            using (db)
            {
                Usuario v = db.Usuarios.Where(a => a.login == usu.login).FirstOrDefault();
                if (v != null)
                {
                    if (string.Compare(usu.password, v.password) == 0)
                    {
                        int timeout = usu.rememberMe ? 525600 : 20; // 525600 min = 1 year
                        var ticket = new FormsAuthenticationTicket(usu.login, usu.rememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);


                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            if (v.nutricionista)
                            {
                                return RedirectToAction("IndexNutri", "Home");
                            }
                            else
                            {
                                return RedirectToAction("IndexCliente", "Home");
                            }
                        }
                    }
                    else
                    {
                        message = "Usuário ou Senha Inválido";
                    }
                }
                else
                {
                    message = "Usuário ou Senha Inválido";
                }
            }
            ViewBag.Message = message;
            return View();
        }
    }
}
