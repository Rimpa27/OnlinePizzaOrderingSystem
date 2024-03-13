import { HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import {Injectable } from '@angular/core';
import {Observable, throwError } from 'rxjs';
import { Imenu, IUser } from './interface/menu';
import {Router } from '@angular/router';
import {catchError} from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  apiUrl = 'http://localhost:5217';
  private token:any;
  constructor(private http: HttpClient,private router:Router){}
  login(email: string, password: string) {
    return this.http.post<{ token: string }>(this.apiUrl + '/api/Admin/Login', {
      email: email,
      password: password,
    });
  }
  getAllMenuItem() {
    console.log('getAllMenuItem', localStorage.getItem('token'));
    return this.http.get<Imenu[]>(this.apiUrl + '/api/Admin/AllMenuItems');
  }
  EditMenuItem(menuItemId: number, MenuItem: Imenu) {
    return this.http.put<Imenu>(
      this.apiUrl + '/api/Admin/EditMenuItem' + menuItemId,
      MenuItem
    );
  }
  deleteMenuItem(menuItemId: number) {
    return this.http.delete(this.apiUrl + '/api/Admin/DeleteMenuItem' + menuItemId);
  }
  AddUser(User: IUser) {
    return this.http.post(this.apiUrl + '/api/Admin/addUser',User);
  }
  
  getAllUser() {
    console.log('getAllUser', localStorage.getItem('token'));
    return this.http.get<IUser[]>(this.apiUrl + '/api/Admin/AllUser');
  }
 
  // deleteUser(UserID: number) {
  //   return this.http.delete(this.apiUrl +'/api/Admin/DeleteUser'+ UserID);
  // }

  editUser(UserID: number, User: IUser) {
    return this.http.put<Imenu>(
      this.apiUrl + '/api/Admin/EditUser' + UserID,
      User
    );
  }
  AddMenuItem(formData: FormData): Observable<any> {
 
    const url = this.apiUrl+'/api/Admin/AddMenuItem';
      const accessToken = localStorage.getItem("accessToken");
   
      if (!accessToken) {
        this.router.navigate(['/login']);
       
      }else{
        const temp = JSON.parse(accessToken || "");
        this.token = temp.token;
      }
   
      // Set the authorization header with the access token
      const headers = new HttpHeaders({
        'Authorization': `Bearer ${this.token}`
      });
   
      return this.http.post(url, formData, { headers }).pipe(
        catchError((error: HttpErrorResponse) => {
          return throwError(error); // Rethrow the error
        })
      );
    }

}
  


