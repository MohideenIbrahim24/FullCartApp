import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, tap } from 'rxjs';
import { IUser } from '../shared/_models/user';
import { Router } from '@angular/router';
import { environments } from 'src/environments/environments.development';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environments.apiUrl;
  private currentUserSource = new BehaviorSubject<IUser | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient,private router: Router) { }


  login(values: any){
    return this.http.post(this.baseUrl + 'account/login', values).pipe(
      map((response: any) => {
        // Transform the response if needed
        const user: IUser = response; // Adjust this assignment based on the actual structure of your response
        if (user) {
          localStorage.setItem('token', user.token);
          this.currentUserSource.next(user);
        }
        return user;
      })
    );
  }

  register(values: any){
    return this.http.post(this.baseUrl + 'account/register', values).pipe(
      map((response: any) => {
        const user: IUser = response; // Adjust this assignment based on the actual structure of your response
        if (user) {
          localStorage.setItem('token', user.token);
        }
      })
    );
  }

  logout(){
    localStorage.removeItem('token');
    this.currentUserSource.next(null);
    this.router.navigateByUrl('/');
  }

  checkEmailExists(email: string){
    return this.http.get(this.baseUrl + '/account/emailexists?email='+email);
  }
}
