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

export class AddMenuItemComponent implements OnInit {
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
   updateFile(event:any){
    console.log(event);
      if(event.target.files.length > 0)
      {
         this.photo = event.target.files[0];
         console.log("File Updatd");
      }
      else
        console.log("No file was selected");
  }
  ngOnInit() { }
  onSubmit() {
    // this.menuItemForm.markAllAsTouched();
      console.log('Form submitted!');
      console.log(this.menuItemForm.value);
      const MenuItem:Imenu = {
        menuItemName:this.menuItemForm.value.menuItemName,
        menuItemDescription:this.menuItemForm.value.menuItemDescription,
        price:this.menuItemForm.value.price,
        vegOrNonVeg:this.menuItemForm.value.vegOrNonVeg,
        menuItemCategory:this.menuItemForm.value.menuItemCategory,
        calories:this.menuItemForm.value.calories,
        isAvailable:this.menuItemForm.value.isAvailable,
        preparationTime:this.menuItemForm.value.preparationTime
      };
      if (this.isEdit) {
        this.httpservice
          .EditMenuItem(this.MenuItemId,MenuItem)
          .subscribe(() => {
            console.log('success');
          alert("Record updated sucessfully.");
            this.router.navigateByUrl('menu');
          });
      }
      else{
        this.httpservice.AddMenuItem(MenuItem).subscribe(() => {
          console.log('success');
          alert("Record added sucessfully.");
          this.router.navigateByUrl('menu');
        });
      }
    }  
}

