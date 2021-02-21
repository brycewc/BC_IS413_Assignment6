using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BC_IS413_Assignment6.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorFirst { get; set; }
        public string AuthorMiddle { get; set; }
        [Required]
        public string AuthorLast { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        //Regular Expression to validate entered ISBN Numbers
        [RegularExpression("^[0-9]{3}-[0-9]{10}$", ErrorMessage = "Must be a valid ISBN number in format and 10 or 13 digits")]
        public string ISBN { get; set; }
        [Required]
        public string Classification { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        [DataType(DataType.Currency, ErrorMessage = "Must be valid monetary value")]
        public double Price { get; set; }
        [Required]
        public int NumOfPages { get; set; }
    }
}
