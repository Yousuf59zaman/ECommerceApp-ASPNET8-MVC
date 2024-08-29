using Microsoft.AspNetCore.Mvc;
using ECommerceApp.DBContext;
using ECommerceApp.Models;
using ECommerceApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Utilities;

namespace ECommerceApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Checkout action to display order summary
        public IActionResult Checkout()
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

            ViewBag.TotalAmount = productsInCart.Sum(p => p.ProductUnitPrice * p.Quantity);

            return View(productsInCart);
        }

        // Method to handle the order submission
        [HttpPost]
        public async Task<IActionResult> PlaceOrder()
        {
            var cart = HttpContext.Session.Get<Dictionary<Guid, int>>("Cart") ?? new Dictionary<Guid, int>();

            if (!cart.Any())
            {
                return RedirectToAction("Cart", "Home");
            }

            var userId = User.Identity.Name;

            // Create an order
            var order = new Order
            {
                CustomerID = userId,
                OrderDate = DateTime.Now,
                OrderStatus = "Pending",
                TotalAmount = cart.Sum(c => c.Value * _context.Products.Find(c.Key).ProductUnitPrice),
                ShippingAddress = "Your Shipping Address" // Add your logic to capture shipping address
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Create order details
            foreach (var item in cart)
            {
                var product = _context.Products.Find(item.Key);

                var orderDetails = new OrderDetails
                {
                    OrderID = order.OrderID,
                    ProductID = item.Key,
                    Quantity = item.Value,
                    UnitPrice = product.ProductUnitPrice,
                    Total = product.ProductUnitPrice * item.Value
                };

                _context.OrderDetails.Add(orderDetails);
            }

            await _context.SaveChangesAsync();

            // Clear the cart
            HttpContext.Session.Remove("Cart");

            return RedirectToAction("OrderConfirmation", new { id = order.OrderID });
        }

        // Order confirmation view
        public async Task<IActionResult> OrderConfirmation(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)  // Include related Product data in OrderDetails
                .FirstOrDefaultAsync(o => o.OrderID == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

    }
}

