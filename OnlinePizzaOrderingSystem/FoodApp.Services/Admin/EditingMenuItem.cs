using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodApp.Entities;

namespace FoodApp.Services.Admin
{
    public class EditingMenuItem
    { 
           public string newName {  get; set; }
           public  string newItemDescription {  get; set; }
           public int newCalories {get; set; }
           public bool newIsAvailable {  get; set; }
            public VegOrNonVeg newVegOrNonVeg {  get; set; }
            public MenuItemCategory newCategory {  get; set; }
            public string newImageUrl {  get; set; }
            public int newPreparationTime {  get; set; }
            public decimal newPrice {  get; set; }
        

    }
}
