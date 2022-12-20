using System;
using BookShop.Data;
using BookShop.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.AspNetCore.Session;


namespace BookShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly BookDbContext dbContext;
        

        public AccountController(BookDbContext context)
        {
            dbContext = context;
            
        }

      

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Account model)
        {

            if (ModelState.IsValid)
            {
                var check = dbContext.Accounts.FirstOrDefault(s => s.Email == model.Email);
              
                if (check == null)
                {
                    Account account = new Account()
                    {
                        Email = model.Email,
                        Password = GetMD5(model.Password),
                        Role = model.Role,
                    };
                    dbContext.Add(account);
                    await dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Login));
                } else
                {
                    ViewBag.error = "This email already exist!";
                    return View();
                } 
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var encodePassword = GetMD5(password);
                var data = dbContext.Accounts.Where(s => s.Email.Equals(email) && s.Password.Equals(encodePassword)).ToList();
                if (data.Count() > 0)
                {
                    //data.FirstOrDefault().Role
                    return RedirectToAction("Index", "Book");
                    
                }
                else
                {
                    ViewBag.error = "Login failed!";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            /*Microsoft.AspNetCore.Session.Clear()*/;//remove session
            return RedirectToAction("Login");
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }



    }
}
