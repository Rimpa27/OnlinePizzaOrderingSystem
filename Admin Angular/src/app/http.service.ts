import { HttpClient} from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Imenu, IUser } from './interface/menu';


@Injectable({
  providedIn: 'root'
})
export class HttpService {
  apiUrl = 'http://localhost:5217';
  constructor(private http: HttpClient){}
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
  AddMenuItem(MenuItem: Imenu) {
    return this.http.post(this.apiUrl + '/api/Admin/AddMenuItem', MenuItem);
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

}
  


