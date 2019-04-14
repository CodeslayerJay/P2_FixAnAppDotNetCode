using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace P2_FixAnAppDotNetCode.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }

        [Required(ErrorMessage = "ErrorMissingName")]
        public string Name { get; set; }

        [Required(ErrorMessage = "ErrorMissingAdress")]
        public string Address { get; set; }

        [Required(ErrorMessage = "ErrorMissingCity")]
        public string City { get; set; }

        public string Zip { get; set; }

        [Required(ErrorMessage = "ErrorMissingCountry")]
        public string Country { get; set; }

        [BindNever]
        public DateTime Date { get; set; }
    }
}
