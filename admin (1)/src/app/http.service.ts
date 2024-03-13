import { HttpClient} from '@angular/common/http';
import { inject, Injectable } from '@angular/core';


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
  
  
}

