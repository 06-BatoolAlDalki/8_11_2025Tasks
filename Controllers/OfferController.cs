using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication57.Models;

namespace WebApplication57.Controllers
{
    public class OfferController : Controller
    {

        static List<NewOffer> offers = new List<NewOffer>{
            new NewOffer { OfferId =1, Category = "GraduationCertificates" , Supply = "Supplier A" , OfferName
    = "Premium Certificate Package" , Quantity
     = 35 , UnitPrice = 2
    },

             new NewOffer { OfferId = 2, Category = "GraduationCertificates" , Supply = "Supplier B" , OfferName
    = "Standard Certificate Package" , Quantity
     = 35 , UnitPrice = 1.5
    },
 new NewOffer { OfferId = 3, Category = "GraduationCertificates" , Supply = "Supplier C" , OfferName
    = "Luxury Certificate Package" , Quantity
     = 35 , UnitPrice = 2.5
    },
  new NewOffer { OfferId = 4, Category = "Hospitality" , Supply = "Supplier D" , OfferName
    = "Coffee & Drinks Package" , Quantity
     = 100 , UnitPrice = 2
    },

  new NewOffer { OfferId = 5, Category = "Hospitality" , Supply = "Supplier E" , OfferName
    = "Sandwiches & Snacks Package" , Quantity
     = 100 , UnitPrice = 3
    },
   new NewOffer { OfferId = 6, Category = "Hospitality" , Supply = "Supplier F" , OfferName
    = "Full Hospitality Package" , Quantity
     = 100 , UnitPrice = 4
    },
    new NewOffer { OfferId = 7, Category = "GraduationGifts" , Supply = "Supplier G" , OfferName
    = "Customized Mugs Package" , Quantity
     = 35 , UnitPrice = 2
    },
     new NewOffer { OfferId = 8, Category = "GraduationGifts" , Supply = "Supplier H" , OfferName
    = "Graduation Bags Package" , Quantity
     = 35 , UnitPrice = 3
    },
      new NewOffer { OfferId = 9, Category = "GraduationGifts" , Supply = "Supplier I" , OfferName
    = "Premium Gift Boxes Package" , Quantity
     = 35 , UnitPrice = 4
    },



            };
        public IActionResult Index()
        {

            return View(offers);
        }

        public IActionResult SelectedOffer(int id)
        {
            ViewBag.OfferId = id;

            var offer = offers.FirstOrDefault(x => x.OfferId == id);


            var categoryName = "";
            if (offer.Category == "GraduationCertificates")
            {
                categoryName = "GraduationCertificates";
              
           
            }
            else if (offer.Category == "Hospitality")
            {
                categoryName = "Hospitality";
               
            }
            else if (offer.Category == "GraduationGifts")
            {
                categoryName = "GraduationGifts";
               
            }

            HttpContext.Session.SetString(
                categoryName,
                System.Text.Json.JsonSerializer.Serialize(offer)
            );

            //HttpContext.Session.SetString(categoryName, offer);
            return View();
        }

       
        public IActionResult Review()
        {

            var GraduationCertificates = System.Text.Json.JsonSerializer.Deserialize<NewOffer>(HttpContext.Session.GetString("GraduationCertificates"));
            var Hospitality = System.Text.Json.JsonSerializer.Deserialize<NewOffer>(HttpContext.Session.GetString("Hospitality"));
            var GraduationGifts = System.Text.Json.JsonSerializer.Deserialize<NewOffer>(HttpContext.Session.GetString("GraduationGifts"));


            var newOfferList = new List<NewOffer>
            { GraduationCertificates, Hospitality, GraduationGifts };

            decimal total = 0;
            foreach (var item in newOfferList)
            {
                total += item .Quantity * (decimal)item.UnitPrice;
               
            }
            ViewBag.Total = total;
            return View(newOfferList);

        }
    }
}
