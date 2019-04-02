using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Northwind.Models
{
    public class ProductCategory
    {
        public List<Category> categories { get; set; }
        public List<Product> products { get; set; }

    }
}