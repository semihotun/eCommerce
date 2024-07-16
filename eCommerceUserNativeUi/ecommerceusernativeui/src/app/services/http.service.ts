import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { ToastController } from '@ionic/angular';

@Injectable({
  providedIn: 'root',
})
export class HttpService {
  constructor(private http: HttpClient, private toast: ToastController) {}

  public post<T>(
    url: string,
    data: any,
    takeUntil$: Observable<void>,
    onNext: (data: T) => void,
    onError: (error: HttpErrorResponse) => void = async (err) => {
      const toast = await this.toast.create({
        message: err.message,
        duration: 2000,
        color: 'danger',
      });
      await toast.present();
    },
    onComplete: () => void = () => {
      console.log('HTTP request completed', url);
    }
  ): void {
    this.http.post<T>(url, data).pipe(takeUntil(takeUntil$)).subscribe({
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
      const toast = await this.toast.create({
        message: err.message,
        duration: 2000,
        color: 'danger',
      });
      await toast.present();
    }
  ): void {
    this.http.get<T>(url, { params }).pipe(takeUntil(takeUntil$)).subscribe({
      next: onNext,
      error: onError,
    });
  }
}
