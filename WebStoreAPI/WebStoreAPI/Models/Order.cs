using System;
using System.ComponentModel.DataAnnotations;

namespace WebStoreAPI.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; } //1
        public Product Product { get; set; } //{int id, string name, string type, string description, double price, int amount}
        public DateTime Date { get; set; } //{06/08/2021 22:00}
        public double Price { get; set; } //Total price: 2000
        public Address Address { get; set; } //


    }
}
