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
            _context= new AppDbContext();
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
        // Add to cart

    }
}
