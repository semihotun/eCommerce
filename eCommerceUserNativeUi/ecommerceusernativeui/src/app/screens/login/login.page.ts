import {
  Component,
  ElementRef,
  inject,
  OnInit,
  ViewChild,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import {
  IonContent,
  IonHeader,
  IonTitle,
  IonToolbar,
} from '@ionic/angular/standalone';
import { HeaderComponent } from 'src/app/uı/header/header.component';
import { FooterComponent } from 'src/app/uı/footer/footer.component';
import { GlobalService } from 'src/app/services/global.service';
import { MobileFooterComponent } from 'src/app/uı/mobile-footer/mobile-footer.component';
import { InputComponent } from 'src/app/uı/input/input.component';
import { TranslateModule } from '@ngx-translate/core';
import { BtnSubmitComponent } from 'src/app/uı/btn-submit/btn-submit.component';
import { CheckboxComponent } from 'src/app/uı/checkbox/checkbox.component';
import { BehaviorSubject, Observable } from 'rxjs';
import { RouterModule } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { SubHeaderComponent } from 'src/app/uı/sub-header/sub-header.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
  standalone: true,
  imports: [
    IonContent,
    IonHeader,
    IonTitle,
    IonToolbar,
    CommonModule,
    FormsModule,
    HeaderComponent,
    FooterComponent,
    MobileFooterComponent,
    InputComponent,
    TranslateModule,
    ReactiveFormsModule,
    BtnSubmitComponent,
    CheckboxComponent,
    RouterModule,
    SubHeaderComponent,
  ],
})
export class LoginPage implements OnInit {
  form!: FormGroup;
  submitted: boolean = false;
  passwordTypeCheck: boolean = false;
  passwordType: BehaviorSubject<'text' | 'password'> = new BehaviorSubject<
    'text' | 'password'
  >('password');
  glb = inject(GlobalService);
  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService
  ) {
    this.initForm();
  }
  initForm() {
    this.form = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      rememberMe: [true, Validators.required],
    });
  }
  saveForm() {
    this.userService.login(this.form.value);
  }
  ngOnInit() {}
  changePasswordType() {
    this.passwordTypeCheck = !this.passwordTypeCheck;
    this.passwordType.next(this.passwordTypeCheck ? 'text' : 'password');
    let passwordDom = document.getElementById('password') as HTMLInputElement;
    passwordDom.type = this.passwordType.value;
  }
  hasError(controlName: string, errorName: string) {
    const control = this.form.get(controlName);
    return this.submitted && control?.hasError(errorName);
  }
}
