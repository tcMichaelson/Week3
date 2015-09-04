﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductWithTests.Models {
    public class Product : IValidatableObject {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(25, ErrorMessage = "Product name is too long!")]
        public string Name { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {

            var results = new List<ValidationResult>();
            if (this.Price == 17) {
                results.Add(new ValidationResult("Price cannot be $17.00.", new string[] { "Price" }));
            }
            return results;
        }
    }
}