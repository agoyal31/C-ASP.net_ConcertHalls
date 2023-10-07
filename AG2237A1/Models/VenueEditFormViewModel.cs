using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AG2237A1.Models
{
    public class VenueEditFormViewModel: VenueEditViewModel
    {
        [Required]
        [StringLength(80)]
        public string Company { get; set; }


        [DataType(DataType.Password, ErrorMessage = "Password should not be empty")]
        [Display(Name = "Advance Ticket Sale Password")]
        public string TicketSalePassword { get; set; }

        [RegularExpression("^[A-Z]{2}[0-9]{3}$", ErrorMessage = "Promo Code should contain two capital letters and three numeric numbers.")]
        [Display(Name = "Promo Code")]
        public string PromoCode { get; set; }

        [Range(1, 100000, ErrorMessage = "Capacity should only be between 1 and 100,000")]
        [Display(Name = "Capacity")]
        public int Capacity { get; set; }
    }
}