import { CommonModule } from '@angular/common';
import { Component, inject, OnInit} from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpService } from '../http.service';
import { Imenu } from '../interface/menu';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
@Component({
  selector: 'app-add-menu-item',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, FormsModule,HttpClientModule],
  templateUrl: './add-menu-item.component.html',
  styleUrl: './add-menu-item.component.css'
})

export class AddMenuItemComponent {
  menuItemForm: FormGroup; 
  categories: string[] = ['Pizza','Pasta','Sides','Salad', 'Dessert', 'Beverage']; 
  selectedCategory: string | undefined;
  photo:any;
  isEdit=false
  router = inject(Router);
  route = inject(ActivatedRoute);
  MenuItemId!: number;
  constructor(private formBuilder: FormBuilder,private httpservice:HttpService) {
    this.menuItemForm = this.formBuilder.group({
      ItemName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      ItemDescription: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10000)]],
      Price: ['', Validators.required],
      VegOrNonVeg: ['', Validators.required],
      MenuItemCategory: ['', Validators.required],
      Calories: ['', Validators.required],
      PreparationTime: ['', Validators.required],
      IsAvailable:['',Validators.required]
    });
   }
   updateFile(event: any) {
    if (event.target.files.length > 0) {
      this.photo = event.target.files[0];
      console.log("File Updated");
    } else {
      console.log("No file was selected");
      this.photo = undefined; // Reset photo if not selected
    }
  };
  onSubmit() {
    // this.menuItemForm.markAllAsTouched();
      console.log('Form submitted!');
      console.log(this.menuItemForm.value);
      var formData = new FormData();
      formData.append("data", JSON.stringify(this.menuItemForm.value));
      formData.append("Photo", this.photo);
      this.httpservice.AddMenuItem(formData).subscribe(
        (response) => {
          // Handle successful response
          console.log("MenuItem Added",response);
          alert('MenuItem Added Sucessfully');
          this.router.navigateByUrl('menu');
        },
        (error) => {
          // Handle error
          console.log("Some error occurred",error);
          // alert('Error assigning ticket:');
        });
        alert('MenuItem Added Sucessfully');
        this.router.navigateByUrl('menu');
    }
}  

