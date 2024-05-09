using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ontap_NET104.Models;

namespace Ontap_NET104.Controllers
{
    public class AccountController : Controller
    {
        // Khởi tạo context và tạo constructor
        AppDbContext context;
        public AccountController()
        {
            context = new AppDbContext();
        }
        // Các action thực thi
        public ActionResult Login(string username, string password) // Đăng nhập
        {
            if (username == null && password == null)
            {
                return View();
            }
            else
            {
                var account = context.Accounts.FirstOrDefault(p => p.Username == username && p.Password == password);
                if (account == null) return Content("Tài khoản bạn đang đăng nhập khum tồn tại");
                else
                {
                    HttpContext.Session.SetString("username", username); // Lưu username vào session
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        // GET: AccountController/Details/5
        public ActionResult Details(string username) // Xem thông tin tài khoản
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult SignUp() // Tạo tài khoản - mở view để tạo
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        public ActionResult SignUp(Account account) // Tạo tài khoản - Thực hiện tạo mới account
        {
            try
            {
                context.Accounts.Add(account);
                context.SaveChanges();
                TempData["SuccessMessage"] = "Create account successfully!";
                return RedirectToAction("Login", "Account");
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
