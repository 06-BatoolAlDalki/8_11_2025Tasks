using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApplication57.Models;

namespace WebApplication57.Controllers
{
    public class SupplyController : Controller
    {
        static List<Offer> offers = new List<Offer>
        {

       //ggg
            // Certificates
        new Offer { Id = 1, Category = "Certificates", SupplierName = "Supplier A", OfferName = "Premium Certificate Package", Quantity = 35, UnitPrice = 2 },
        new Offer { Id = 2, Category = "Certificates", SupplierName = "Supplier B", OfferName = "Standard Certificate Package", Quantity = 35, UnitPrice = 1.5m },
        new Offer { Id = 3, Category = "Certificates", SupplierName = "Supplier C", OfferName = "Luxury Certificate Package", Quantity = 35, UnitPrice = 2.5m },

        // Hospitality
        new Offer { Id = 4, Category = "Hospitality", SupplierName = "Supplier D", OfferName = "Coffee & Drinks Package", Quantity = 100, UnitPrice = 2 },
        new Offer { Id = 5, Category = "Hospitality", SupplierName = "Supplier E", OfferName = "Sandwiches & Snacks Package", Quantity = 100, UnitPrice = 3 },
        new Offer { Id = 6, Category = "Hospitality", SupplierName = "Supplier F", OfferName = "Full Hospitality Package", Quantity = 100, UnitPrice = 4 },

        // Gifts
        new Offer { Id = 7, Category = "Gifts", SupplierName = "Supplier G", OfferName = "Customized Mugs Package", Quantity = 35, UnitPrice = 2 },
        new Offer { Id = 8, Category = "Gifts", SupplierName = "Supplier H", OfferName = "Graduation Bags Package", Quantity = 35, UnitPrice = 3 },
        new Offer { Id = 9, Category = "Gifts", SupplierName = "Supplier I", OfferName = "Premium Gift Boxes Package", Quantity = 35, UnitPrice = 4 }
    };
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SelectOffer(int id)
        {
            var offer = offers.FirstOrDefault(x => x.Id == id);

            if (offer == null)
            {
                return RedirectToAction("Index");
            }

            string key = "";

            if (offer.Category == "Certificates")
            {
                key = "CertificateOffer";
            }
            else if (offer.Category == "Hospitality")
            {
                key = "HospitalityOffer";
            }
            else if (offer.Category == "Gifts")
            {
                key = "GiftOffer";
            }

            HttpContext.Session.SetString(
                key,
                JsonSerializer.Serialize(offer)
            );

            return RedirectToAction("Index");
        }


        public IActionResult Review()
        {
            var certificate = HttpContext.Session.GetString("CertificateOffer");
            var hospitality = HttpContext.Session.GetString("HospitalityOffer");
            var gift = HttpContext.Session.GetString("GiftOffer");

            if (certificate == null || hospitality == null || gift == null)
            {
                return RedirectToAction("Index");
            }

            List<Offer> selectedOffers = new List<Offer>();

            selectedOffers.Add(JsonSerializer.Deserialize<Offer>(certificate));
            selectedOffers.Add(JsonSerializer.Deserialize<Offer>(hospitality));
            selectedOffers.Add(JsonSerializer.Deserialize<Offer>(gift));

            decimal total = 0;

            foreach (var offer in selectedOffers)
            {
                total += offer.Quantity * offer.UnitPrice;
            }

            decimal discountPercentage = 0;

            if (total > 500)
            {
                discountPercentage = 15;
            }
            else if (total > 300)
            {
                discountPercentage = 10;
            }

            decimal discountAmount = total * discountPercentage / 100;

            decimal finalTotal = total - discountAmount;

            ViewBag.DiscountPercentage = discountPercentage;
            ViewBag.Total = total;
            ViewBag.DiscountAmount = discountAmount;
            ViewBag.FinalTotal = finalTotal;

            return View(selectedOffers);
        }
    }
}
