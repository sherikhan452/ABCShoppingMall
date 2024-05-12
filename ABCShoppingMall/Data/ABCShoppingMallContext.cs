using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ABCShoppingMall.Data
{
    public class ABCShoppingMallContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ABCShoppingMallContext() : base("name=ABCShoppingMallContext")
        {
        }

        public System.Data.Entity.DbSet<ABCShoppingMall.Models.AdminLogin> AdminLogins { get; set; }

        public System.Data.Entity.DbSet<ABCShoppingMall.Models.Feedback> Feedbacks { get; set; }

        public System.Data.Entity.DbSet<ABCShoppingMall.Models.FoodCourt> FoodCourts { get; set; }

        public System.Data.Entity.DbSet<ABCShoppingMall.Models.Gallery> Galleries { get; set; }

        public System.Data.Entity.DbSet<ABCShoppingMall.Models.Movie> Movies { get; set; }

        public System.Data.Entity.DbSet<ABCShoppingMall.Models.Multiplex> Multiplexes { get; set; }

        public System.Data.Entity.DbSet<ABCShoppingMall.Models.ShoppingCenter> ShoppingCenters { get; set; }

        public System.Data.Entity.DbSet<ABCShoppingMall.Models.Ticket> Tickets { get; set; }
    }
}
