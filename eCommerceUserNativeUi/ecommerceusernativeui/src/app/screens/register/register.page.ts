import { Component, inject, OnInit } from '@angular/core';
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
import { MobileFooterComponent } from 'src/app/uı/mobile-footer/mobile-footer.component';
import { InputComponent } from 'src/app/uı/input/input.component';
import { TranslateModule } from '@ngx-translate/core';
import { BtnSubmitComponent } from 'src/app/uı/btn-submit/btn-submit.component';
import { GlobalService } from 'src/app/services/global.service';
import { CheckboxComponent } from '../../u\u0131/checkbox/checkbox.component';
import { RouterModule } from '@angular/router';

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
  ],
})
export class RegisterPage implements OnInit {
  form!: FormGroup;

  glb = inject(GlobalService);
  constructor(private formBuilder: FormBuilder) {
    this.initForm();
  }
  ngOnInit() {}
  initForm() {
    this.form = this.formBuilder.group({
      name: ['', Validators.required],
      surname: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  }
  saveForm() {
    console.log(this.form.value);
    console.log(this.form.valid);
  }
}
