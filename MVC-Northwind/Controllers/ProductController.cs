using MVC_Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVC_Northwind.Controllers
{
    public class ProductController : Controller
    {
        //Model yontemiyle birden çok veri listesi yollayarak ViewBag'e gerek kalmadı.Yeni bir sınıf oluşturdum.O sınıftan bir instance oluşturdum ve listeleri bu sınıfa attım.
        ProductCategory pc = new ProductCategory();
        
        NorthwindEntities1 ctx = new NorthwindEntities1();

        // GET: Product
        // GET Action : Bir view'i calistirmayi saglar. Deger alabilir ve aldıgı degeri view'e gönderir.
        // Post Action : View tarafından girilen değerleri alır ve SQL'E gönderir.
        // Bir action get/pos olarak belirtilmezse, varsayılanı Get Action'dır.
        public ActionResult Index()

        {
            List<Category> catList = ctx.Categories.ToList();
            List<Product> productList = ctx.Products.ToList();

            //View bag yöntemiylede verilere ulaşabilirim .
            //ViewBag.Kategoriler = catList;
            pc.categories = catList;
            pc.products = productList;
            //return View(productList);
            return View(pc); 
        }
        public ActionResult AddProduct()
        {
            List<Category> cat = ctx.Categories.ToList();
            List<Supplier> sup = ctx.Suppliers.ToList();

            ViewBag.catList = cat;
            ViewBag.supList = sup;

            return View();
        }

        //View tarafından girilen verileri çekmemizi sağlayan Action'dir.
        [HttpPost]
        public ActionResult AddProduct(string prdName,decimal prdPrice, short prdStock, int prdCatID, int prdSupID)
        {
            Product prd = new Product();
            prd.ProductName = prdName;
            prd.UnitPrice = prdPrice;
            prd.UnitsInStock = prdStock;
            prd.CategoryID = prdCatID;
            prd.SupplierID = prdSupID;

            ctx.Products.Add(prd);
            ctx.SaveChanges();

            //return View("Index") satırı aynı controller'daki  Index action'ının çalıştırdığı Index sayfasını açar ama Index Action'ını çalıştırmaz.
            //return View("Index");


            return RedirectToAction("Index");//Bu şekilde action'ı çalıştırabilir fakat farklı controller'daki actionu çalıştırmak istersek  return RedirectToAction("Index", "ControllerName") yapabiliriz.
        }
    }
}