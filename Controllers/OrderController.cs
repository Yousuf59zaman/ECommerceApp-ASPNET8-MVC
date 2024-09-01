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
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using ECommerceApp.Identity;

namespace ECommerceApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public OrderController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Checkout action to display order summary
        public async Task<IActionResult> Checkout()
        {
            // Get the current user
            var user = await _userManager.GetUserAsync(User);

            // Get cart from session
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

            // Pass the user's address to the view
            ViewBag.ShippingAddress = user.Address;

            return View(productsInCart);
        }


        // Method to handle the order submission
        // Method to handle the order submission
        [HttpPost]
        public async Task<IActionResult> PlaceOrder(string ShippingAddress, string PaymentMethod)
        {
            // Get the current user
            var user = await _userManager.GetUserAsync(User);

            // Get cart from session
            var cart = HttpContext.Session.Get<Dictionary<Guid, int>>("Cart") ?? new Dictionary<Guid, int>();

            if (!cart.Any())
            {
                return RedirectToAction("Cart", "Home");
            }

            // Calculate the total amount
            decimal totalAmount = 0;
            var orderDetails = new List<OrderDetails>();

            foreach (var item in cart)
            {
                var product = await _context.Products.FindAsync(item.Key);
                if (product != null)
                {
                    totalAmount += product.ProductUnitPrice * item.Value;

                    orderDetails.Add(new OrderDetails
                    {
                        ProductID = product.ProductId,
                        Quantity = item.Value,
                        UnitPrice = product.ProductUnitPrice,
                        Total = product.ProductUnitPrice * item.Value // Ensure this value is set
                    });
                }
            }

            // Create Order
            var order = new Order
            {
                CustomerID = user.Id,
                OrderStatus = "Pending",
                TotalAmount = totalAmount,
                ShippingAddress = ShippingAddress,
                OrderDetails = orderDetails
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync(); // Save here to generate OrderID

            // Create Payment
            var payment = new Payment
            {
                OrderID = order.OrderID,
                PaymentAmount = totalAmount,
                Method = PaymentMethod,
                Status = PaymentStatus.Pending  // Set initial status to Pending
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync(); // Save the payment to generate PaymentID

            // Update Order with PaymentID
            order.PaymentID = payment.PaymentID;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync(); // Save changes to update the PaymentID in the Order

            // Clear the cart
            HttpContext.Session.Remove("Cart");

            // Redirect to a confirmation page or back to the home page
            return RedirectToAction("OrderConfirmation", new { orderId = order.OrderID });
        }


        // Order confirmation view
        [HttpGet("OrderConfirmation/{orderId}")]
        public async Task<IActionResult> OrderConfirmation(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .FirstOrDefaultAsync(o => o.OrderID == orderId);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        public async Task<IActionResult> OrderHistory()
        {
            // Get the current user
            var user = await _userManager.GetUserAsync(User);

            // Fetch orders for the current user
            var orders = await _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .Where(o => o.CustomerID == user.Id)
                .ToListAsync();

            return View(orders);
        }



    }
}

