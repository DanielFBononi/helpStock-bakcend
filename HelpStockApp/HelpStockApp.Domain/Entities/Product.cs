﻿using HelpStockApp.Domain.Validation;
using System.Net.Http.Headers;

namespace HelpStockApp.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        private void ValidateDomain(string name, string description,decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(price < 0, "Invalid price, price negative value is improbable");
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),"Invalid name, name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");
            DomainExceptionValidation.When(description.Length < 3, "Invalid description, too short, minimum 3 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description, description is required");
            DomainExceptionValidation.When(stock < 0, "Invalid stock, stock negative is improbable");
            DomainExceptionValidation.When(image.Length > 250, "Invalid image, too long, maximum 250 characters");
        }
    }
}
