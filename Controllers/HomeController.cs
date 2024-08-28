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
        public IActionResult AddToCart(Guid productId, int quantity)
        {
            var cart = HttpContext.Session.Get<Dictionary<Guid, int>>("Cart") ?? new Dictionary<Guid, int>();

            if (cart.ContainsKey(productId))
            {
                cart[productId] += quantity;  // Update quantity if the product is already in the cart
            }
            else
            {
                cart.Add(productId, quantity);  // Add new product with the specified quantity
            }

            HttpContext.Session.Set("Cart", cart);

            return RedirectToAction("Index");
        }

        // Get Cart Count
        public int GetCartCount()
        {
            var cart = HttpContext.Session.Get<Dictionary<Guid, int>>("Cart");
            return cart?.Count ?? 0;
        }

        // Cart Action
        public IActionResult Cart()
        {
            var cart = HttpContext.Session.Get<Dictionary<Guid, int>>("Cart") ?? new Dictionary<Guid, int>();

            var productsInCart = _context.Products
                .Where(p => cart.Keys.Contains(p.ProductId))
                .Select(p => new ProductViewModel
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    ProductDesc = p.ProductDesc,
                    ProductUnitPrice = p.ProductUnitPrice,
                    ProductImage = $"/images/{p.ProductImage}",
                    CategoryName = p.Category.CategoryName,
                    Quantity = cart[p.ProductId]  // Get the quantity from the session cart
                })
                .ToList();

            return View(productsInCart);
        }

        // Remove product from cart
        public IActionResult RemoveFromCart(Guid id)
        {
            var cart = HttpContext.Session.Get<List<Guid>>("Cart") ?? new List<Guid>();

            cart.Remove(id);

            HttpContext.Session.Set("Cart", cart);

            return RedirectToAction("Cart");
        }

        // Edit product (dummy implementation for now, you can expand this)
        public IActionResult EditProduct(Guid id)
        {
            // Implement the logic to edit the product in the cart if necessary
            // For now, we can redirect back to the Cart page
            return RedirectToAction("Cart");
        }

        // Checkout (dummy implementation for now)
        public IActionResult Checkout()
        {
            // Implement the checkout process later
            return RedirectToAction("Cart");
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