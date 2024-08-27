using ECommerceApp.DBContext;
using ECommerceApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ECommerceApp.Utilities; // For serializing and deserializing objects to and from JSON format in session


namespace ECommerceApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Fetch products to display on the home page
            var products = await _context.Products
                .Include(p => p.Category)  // Include Category to get CategoryName
                .Select(p => new ProductViewModel
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    ProductDesc = p.ProductDesc,
                    ProductUnitPrice = p.ProductUnitPrice,
                    ProductImage = $"/images/{p.ProductImage}",  // Assume the image file name is stored in the ProductImage field
                    CategoryName = p.Category.CategoryName
                })
                .ToListAsync();

            ViewBag.CartCount = GetCartCount();
            return View(products);
        }


        // Add to Cart
        [HttpPost]
        public IActionResult AddToCart(Guid productId)
        {
            List<Guid> cart = HttpContext.Session.Get<List<Guid>>("Cart") ?? new List<Guid>();

            if (!cart.Contains(productId))
            {
                cart.Add(productId);
                HttpContext.Session.Set("Cart", cart);
            }

            return RedirectToAction("Index");
        }

        // Get Cart Count
        public int GetCartCount()
        {
            var cart = HttpContext.Session.Get<List<Guid>>("Cart");
            return cart?.Count ?? 0;
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}