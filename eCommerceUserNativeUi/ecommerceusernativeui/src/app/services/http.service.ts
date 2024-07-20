import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class HttpService {
  constructor(private http: HttpClient) {}

  public post<T>(
    url: string,
    data: any,
    takeUntil$: Observable<void>,
    onNext: (data: T) => void,
    onError: (error: HttpErrorResponse) => void = async (err) => {
      console.log(err);
    },
    onComplete: () => void = () => {
      console.log('HTTP request completed', url);
    }
  ): void {
    this.http.post<T>(url, data).subscribe({
      next: onNext,
      error: onError,
      complete: onComplete,
    });
  }
  public get<T>(
    url: string,
    params: any,
    takeUntil$: Observable<void>,
    onNext: (data: T) => void,
    onError: (error: HttpErrorResponse) => void = async (err) => {
      console.log(err);
    },
    onComplete: () => void = () => {
      console.log('HTTP request completed', url);
    }
  ): void {
    this.http.get<T>(url, { params }).subscribe({
      next: onNext,
      error: onError,
      complete: onComplete,
    });
  }
}
