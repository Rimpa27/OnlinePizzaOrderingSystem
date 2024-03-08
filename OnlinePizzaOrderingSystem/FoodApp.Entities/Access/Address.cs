using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Entities
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
     
        [Required(ErrorMessage = "Line1 is required.")]//line1 is required for delivery
        [StringLength(100, ErrorMessage = "Street cannot be longer than 100 characters.")]
        public string Line1 { get; set; }

        [Required(ErrorMessage = "Line1 is required.")]//line1 is required for delivery
        [StringLength(100, ErrorMessage = "Street cannot be longer than 100 characters.")]
        public string Line2 { get; set; }


        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "City cannot be longer than 50 characters.")]
        public string City { get; set; }// city is required for delivery

        [Required(ErrorMessage = "State is required.")]
        [StringLength(50, ErrorMessage = "State cannot be longer than 50 characters.")]
        public string State { get; set; }// state is required  

        [Required(ErrorMessage = "Country is required.")]
        [StringLength(50, ErrorMessage = "Country cannot be longer than 50 characters.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Postal code is required.")]// pinCode is required for located the address
        [StringLength(10, ErrorMessage = "Postal code cannot be longer than 10 characters.")]
        [DataType(DataType.PostalCode)]
        public string PinCode { get; set; }
    }
}
