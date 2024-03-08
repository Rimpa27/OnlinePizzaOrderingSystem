using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Entities
{
    public class MenuItem
    {
        [Key]
        public int MenuItemId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression("^[a-zA-Z ]{3,100}$", ErrorMessage = "Name must be between 3 and 100 characters")]
        public string MenuItemName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 500 characters")]

        public string MenuItemDescription { get; set; }

        [Required(ErrorMessage = "Price required")]
        [Range(1, 1000, ErrorMessage = "Price must be between 1 and 1000")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Calories are required")]
        [Range(0, 5000, ErrorMessage = "Calories must be between 0 and 5000")]
        public int calories { get; set; }

        [Required(ErrorMessage = "Availability status is required")]
        public bool IsAvailable { get; set; } = false;

        [Required(ErrorMessage = "Image is required")]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public int PreparationTime { get; set; }

        //VegorNorVeg - Enum
        [Required(ErrorMessage = "Category is required")]
        [EnumDataType(typeof(VegOrNonVeg), ErrorMessage = "Invalid Category")]
        public VegOrNonVeg VegOrNonVeg { get; set; }
        //Pizza, pasta, Dessert
        [Required(ErrorMessage = "Category is required")]
        [EnumDataType(typeof(MenuItemCategory), ErrorMessage = "Invalid Category")]
        public MenuItemCategory MenuItemCategory { get; set; }

        public string ProductPhoto {  get; set; }

    }

}

