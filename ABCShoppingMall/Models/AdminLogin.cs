using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ABCShoppingMall.Models
{
    public class AdminLogin
    {
        [Key]
        public int AdminId { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "Username")]
        [MinLength(3, ErrorMessage = "Min is 3")]
        [MaxLength(10, ErrorMessage = "10 is Maximum")]

        public string AdminName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Min is 3")]
        [MaxLength(20, ErrorMessage = "Min 10 char req")]
        public string Password { get; set; }
    }


    public class ShoppingCenter
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Shop Name is Required")]
        public string ShopName { get; set; }

        [Required(ErrorMessage = "Shop Name is Required")]
        public string Shop_Detail { get; set; }
        public string Image { get; set; }
        
        [NotMapped]
        public HttpPostedFileBase File { get; set; }
    }


    public class FoodCourt
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Food Name is Required")]
        public string FoodName { get; set; }
        public string Food_Detail { get; set; }
        public string Image { get; set; }
        public string Items { get; set; }

        [NotMapped]
        public HttpPostedFileBase File { get; set; }


    }

    public class Gallery
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Gallery Name is Required")]
        public string GalleryName { get; set; }
        public string Gallery_Detail { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase File { get; set; }

    }

    public class Feedback
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email  { get; set; }
        public string Message { get; set; }
        

    }


    public class Multiplex
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
        public int TotalSeats { get; set; }
    }

    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MultiplexId { get; set; }
        public Multiplex Multiplex { get; set; }
        public int SeatsAvailable { get; set; }
    }

    public class Ticket
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public string CardDetails { get; set; }
        public bool IsBooked { get; set; }
    }


}