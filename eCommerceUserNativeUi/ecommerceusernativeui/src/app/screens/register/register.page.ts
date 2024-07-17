import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  ValidationErrors,
  ValidatorFn,
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
import { MobileFooterComponent } from 'src/app/uı/mobile-footer/mobile-footer.component';
import { InputComponent } from 'src/app/uı/input/input.component';
import { TranslateModule } from '@ngx-translate/core';
import { BtnSubmitComponent } from 'src/app/uı/btn-submit/btn-submit.component';
import { GlobalService } from 'src/app/services/global.service';
import { CheckboxComponent } from '../../u\u0131/checkbox/checkbox.component';
import { RouterModule } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { SubHeaderComponent } from 'src/app/uı/sub-header/sub-header.component';

@Component({
  selector: 'app-register',
  templateUrl: './register.page.html',
  styleUrls: ['./register.page.scss'],
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
export class RegisterPage implements OnInit {
  form!: FormGroup;
  glb = inject(GlobalService);
  userService = inject(UserService);
  submitted: boolean = false;
  constructor(private formBuilder: FormBuilder) {
    this.initForm();
  }
  ngOnInit() {}
  initForm() {
    this.form = this.formBuilder.group({
      name: ['', [Validators.required]],
      surname: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      password: [''.trim(), [Validators.required]],
      termsOfUse: [false, this.trueValidator()],
    });
  }

  trueValidator(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      return control.value === true ? null : { termOfUseFalse: true };
    };
  }
  saveForm() {
    this.submitted = true;
    if (this.form.valid) {
      this.userService.register(this.form.value);
    }
  }
  hasError(controlName: string, errorName: string) {
    const control = this.form.get(controlName);
    return this.submitted && control?.hasError(errorName);
  }
}
