using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
namespace WebApplication.Models
{
    public class Product
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Display(Name = "Модель")]
        public string Name { get; set; }
        [Display(Name = "Производитель")]
        public string Company { get; set; }
        [Display(Name = "Цена")]
        public int Price { get; set; }
    }
}
