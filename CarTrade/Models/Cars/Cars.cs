using System;
using System.Collections.Generic;
using System.Data.Entity; //Access Entity framework classes
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.ComponentModel.DataAnnotations; // for validation
/*
 * Car Trader => MODEL CLASSES
 * Represent data needed for displaying page with ads from DB 
 * 
 * */

namespace CarTrader.Models
{
    public class Cars // fields for storing cars data 
    {    // (auto generated) TODO: remove nullables all in this model
        public int id { get; set; }

        public DateTime? date { get; set; } = DateTime.Now; // TODO: make local instead of US
        
        public virtual CarModel CarModel { get; set; }  // virtual property (reference to CarModel)

        
        [Required(ErrorMessage = "Пожалуйста введите цену")]
        public int? price { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите пробег")]
        public int? mileage { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите телефон")]
        public string tel { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите имя продавца")]
        public string seller { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Пожалуйста введите текст объявления")]
        public string description { get; set; } // textarea
    }

    public class CarModel // fields for storing car models data 
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите модель Вашего авто")]
        public string model { get; set; }

        public virtual ICollection<Cars> Vehicles { get; set; }
    }
    


    public class CarsContext : DbContext // context for Entity Framework
    {
        public CarsContext() : base("DefaultConnection") // to use Default Connection in web.config connection strings in this db
        { }
        public DbSet<Cars> Ads { get; set; }
        public DbSet<CarModel> Mdls { get; set; }
    }


}