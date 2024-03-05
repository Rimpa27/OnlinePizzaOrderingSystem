using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1
{
    public class MenuItem
    {

        [Key]
        public int FoodId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
        public string FoodName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500,MinimumLength =10, ErrorMessage = "Description must be between 10 and 500 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price required")]
        [Range(0,1000, ErrorMessage = "Price must be between 0 and 1000")]
        [DataType(DataType.Currency)]
        public Decimal Price { get; set; }

        //[Required(ErrorMessage = "Ingredients are required")]
       // [MinLength(1,ErrorMessage = "Atleast one ingredient is required")]
      //  public List<string>Ingredients { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [EnumDataType(typeof(FoodCategory),ErrorMessage ="Invalid Category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Calories are required")]
        [Range(0,5000,ErrorMessage ="Calories must be between 0 and 5000")]
        public int calories {  get; set; }

        [Required(ErrorMessage = "Availability status is required")]
        public bool IsAvailable { get; set; }

        [Required(ErrorMessage = "Image is required")]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString ="{0:HH:mm}",ApplyFormatInEditMode = true)]
        public TimeSpan PreparationTime { get; set; }  
    }

    public enum FoodCategory
    {
        Pizza = 1
            ,Pasta,Sides,Salad,Dessert,Beverage
    }
}
