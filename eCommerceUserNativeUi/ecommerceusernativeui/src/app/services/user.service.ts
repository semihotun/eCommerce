import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { inject, Injectable, OnDestroy } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UserRegister } from '../models/requestModel/userRegister';
import { UserLogin } from '../models/requestModel/userLogin';
import { Result } from '../models/core/result';
import { UserLoginResponse } from '../models/responseModel/UserLoginResponse';
import { Observable, Subject, takeUntil } from 'rxjs';
import { UserRegisterResponse } from '../models/responseModel/UserRegisterResponse';
import { HttpService } from './http.service';
import { Destroyable } from '../shared/destroyable.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class UserService extends Destroyable {
  router = inject(Router);
  constructor() {
    super();
  }
  private http = inject(HttpService);
  login(data: UserLogin) {
    const path = environment.baseUrl + 'customerauthservice/login';
    this.http.post<Result<UserLoginResponse>>(
      path,
      data,
      this.onDestroy,
      (response) => {
        localStorage.setItem('token', response.data.token);
        localStorage.setItem('claims', JSON.stringify(response.data.claims));
        this.router.navigate(['/home']);
      }
    );
  }
  register(data: UserRegister) {
    const path = environment.baseUrl + 'customerauthservice/register';
    console.log(path);
    this.http.post<Result<UserRegisterResponse>>(
      path,
      data,
      this.onDestroy,
      (response) => {
        localStorage.setItem('token', response.data.token);
        localStorage.setItem('claims', JSON.stringify(response.data.claims));
        this.router.navigate(['/home']);
      }
    );
  }
  isLogin(): boolean {
    return localStorage.getItem('token') == null ? false : true;
  }
  logOut() {
    localStorage.removeItem('token');
    localStorage.removeItem('claims');
    this.router.navigate(['/home']);
  }
}
