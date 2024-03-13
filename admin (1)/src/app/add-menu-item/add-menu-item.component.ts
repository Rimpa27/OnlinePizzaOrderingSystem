import { CommonModule } from '@angular/common';
import { Component, OnInit} from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpService } from '../http.service';
// import { IMenuItem } from '../interface/menu';
@Component({
  selector: 'app-add-menu-item',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, FormsModule],
  templateUrl: './add-menu-item.component.html',
  styleUrl: './add-menu-item.component.css'
})

export class AddMenuItemComponent implements OnInit {
  menuItemForm: FormGroup; 
  selectfoodtypes: string | undefined;
  categories: string[] = ['Pizza','Pasta','Sides','Salad', 'Dessert', 'Beverage']; 
  selectedCategory: string | undefined;
  constructor(private formBuilder: FormBuilder,private httpservice:HttpService) {
    this.menuItemForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      description: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10000)]],
      price: ['', Validators.required],
      VegorNonVeg: ['', Validators.required],
      category: ['', Validators.required],
      calories: ['', Validators.required],
      preparationTime: ['', Validators.required],
      photo: ['']
    });
   }
   MenuItemId!:number;
   isEdit=false;
  ngOnInit()
  { 
    // this.MenuItemId = this.router.snapshot.params['id'];
    // if (this.MenuItemId) {
    //   this.isEdit = true;
    //   this.httpservice.getEmployee(this.MenuItemId).subscribe((result) => {
    //     console.log(result);
    //     this.menuItemForm.patchValue(result);
    //     this.menuItemForm.controls.description.disable();
    //   });
    // }
  }
  onSubmit() {
    this.menuItemForm.markAllAsTouched();
      console.log('Form submitted!');
      console.log(this.menuItemForm.value);
      //const menuItem: IMenuItem = {
      //   name: this.menuItemForm.value.name!,
      //   description:this.menuItemForm.value.description!,
      //   price: this.menuItemForm.value.price,
      //   foodtype:this.menuItemForm.value.foodType,
      //   category: this.menuItemForm.value.category,
      //   calories: this.menuItemForm.value.calories,
      //   preparationTime:this.menuItemForm.value.preparationTime,
      //   photo:this.menuItemForm.value.photo
      // };
    }  
}

