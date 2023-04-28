using ePizzaHub.Core.Entities;
using ePizzaHub.Models;
using ePizzaHub.Services.Interfaces;
using ePizzaHub.UI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ePizzaHub.UI.Controllers
{
    public class PaymentController : BaseController
    {
        IConfiguration _config;
        IPaymentService _paymentService;
        IOrderService _orderService;
        public PaymentController(IConfiguration config, IPaymentService paymentService, IOrderService orderService)
        {
            _config = config;
            _paymentService = paymentService;
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            PaymentModel payment = new PaymentModel();
            CartModel cart = TempData.Peek<CartModel>("Cart");
            if (cart != null)
            {
                payment.Cart = cart;
                payment.GrandTotal = Math.Round(cart.GrandTotal);
                payment.Currency = "INR";
                payment.Description = string.Join(",", cart.Items.Select(r => r.Name));
                payment.RazorpayKey = _config["Razorpay:Key"];
                payment.Receipt = payment.Description;

                payment.OrderId = _paymentService.CreateOrder(payment.GrandTotal * 100, payment.Currency, payment.Receipt);
            }
            return View(payment);
        }

        public IActionResult Status(IFormCollection form)
        {
            try
            {
                if (form.Keys.Count > 0 && !string.IsNullOrEmpty(form["rzp_paymentid"]))
                {
                    string paymentId = form["rzp_paymentid"];
                    string orderId = form["rzp_orderid"];
                    string signature = form["rzp_signature"];
                    string transactionId = form["Receipt"];
                    string currency = form["Currency"];

                    var payment = _paymentService.GetPaymentDetails(paymentId);
                    bool IsVerified = _paymentService.VerifySignature(signature, orderId, paymentId);
                    if (IsVerified)
                    {
                        CartModel cart = TempData.Get<CartModel>("Cart");
                        PaymentDetail model = new PaymentDetail();

                        model.CartId = cart.Id;
                        model.Total = cart.Total;
                        model.Tax = cart.Tax;
                        model.GrandTotal = cart.GrandTotal;

                        model.Status = payment.Attributes["status"]; //captured
                        model.TransactionId = transactionId;
                        model.Currency = payment.Attributes["currency"];
                        model.Email = payment.Attributes["email"];
                        model.Id = paymentId;
                        model.UserId = CurrentUser.Id;

                        int status = _paymentService.SavePaymentDetails(model);
                        if (status > 0)
                        {
                            AddressModel address = TempData.Get<AddressModel>("Address");
                            _orderService.PlaceOrder(CurrentUser.Id, orderId, paymentId, cart, address);
                            Response.Cookies.Append("CId", "");

                            TempData.Set("PaymentDetails", model);
                            return RedirectToAction("Receipt");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            ViewBag.Message = "Your payment has been failed. You can contact us at support@dotnettricks.com.";
            return View();
        }

        public IActionResult Receipt()
        {
            PaymentDetail model = TempData.Peek<PaymentDetail>("PaymentDetails");
            return View(model);
        }
    }
}
