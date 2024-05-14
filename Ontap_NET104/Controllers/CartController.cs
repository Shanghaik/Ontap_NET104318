using Microsoft.AspNetCore.Mvc;
using Ontap_NET104.Models;

namespace Ontap_NET104.Controllers
{
    public class CartController : Controller
    {
        AppDbContext context;
        public CartController()
        {
            context = new AppDbContext();
        }
        // Cái Action này để xem những sản phẩm nào có trong Cart => CartDetails
        public IActionResult Index() // Model Class chọn cartDetails để xem danh sách cartDetails
        {
            // Kiểm tra dữ liệu đăng nhập
            var check = HttpContext.Session.GetString("username");
            if (String.IsNullOrEmpty(check))
            {
                return RedirectToAction("Login", "Account"); // chuyển hướng về trang login
            }else
            {
                var allCartItem = context.CartDetails.Where(p=>p.Username== check).ToList();
                return View(allCartItem);
            }     
        }
    }
}
