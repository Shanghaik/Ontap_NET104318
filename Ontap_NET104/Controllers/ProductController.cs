using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ontap_NET104.Models;

namespace Ontap_NET104.Controllers
{
    public class ProductController : Controller
    {
        AppDbContext _context;
        public ProductController()
        {
            _context = new AppDbContext();
        }
        // GET: ProductController
        public ActionResult Index() // Get all sản phẩm
        {
            var data = _context.Products.ToList();
            return View(data);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(Guid id) // Get 1 sản phẩm
        {
            var data = _context.Products.Find(id);
            return View(data);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var data = _context.Products.Find(id);
            return View(data);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                var editProduct = _context.Products.Find(product.Id);
                editProduct.Name = product.Name;
                editProduct.Description = product.Description;
                // Sửa thêm thì tùy
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var deleteItem = _context.Products.Find(id);
            _context.Products.Remove(deleteItem);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        // Add to cart - thêm vào giỏ hàng
        public IActionResult AddToCart(Guid id, int quantity)
        {
            // Kiểm tra xem có đang đăng nhập ko, nếu ko thì bắt đăng nhập
            var check = HttpContext.Session.GetString("username");
            if (String.IsNullOrEmpty(check))
            {
                return RedirectToAction("Login", "Account"); // chuyển hướng về trang login
            }
            else
            {
                // Lấy ra từ sanh sách CartDetail của user đang đăng nhập xem có sản phẩm nào trùng id ko?
                var cartItem = _context.CartDetails.FirstOrDefault(p => p.Username == check && p.ProductId == id);
                // Nếu sản phẩm chưa tồn tại <=> cartItem có giá trị null => Tạo ra 1 cart Details với username là tai
                // khoản đang đăng nhập và idProduct là sản phẩm được chọn và số lượng được chọn
                if(cartItem == null)
                {
                    CartDetails details = new CartDetails() // Tạo mới 1 cart Details
                    {
                        Id = Guid.NewGuid(), ProductId = id, Username = check, Quantity = quantity,Status = 1
                    };
                    _context.CartDetails.Add(details); _context.SaveChanges();
                }else
                {
                    cartItem.Quantity = cartItem.Quantity + quantity; // Chưa check gì trong kho đâu nhé =)))))
                    _context.CartDetails.Update(cartItem); _context.SaveChanges();
                } 
            }
            return RedirectToAction("Index", "Product");
        }

    }
}
