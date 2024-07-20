import { Component, forwardRef, Input, OnInit } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.scss'],
  standalone: true,
  imports: [TranslateModule],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputComponent),
      multi: true,
    },
  ],
})
export class InputComponent implements ControlValueAccessor, OnInit {
  constructor() {}
  ngOnInit(): void {
    this.inputType = this.type == 'number' ? 'text' : this.type;
  }
  onChange: any = () => {};
  onTouched: any = () => {};
  val!: any;
  inputType: any = 'text';
  public disabled: boolean = false;

  @Input() placeholder: string = '';
  @Input() label: string = '';
  @Input() type: 'text' | 'number' | 'email' | 'password' = 'text';
  @Input() id!: string;
  @Input() class!: string;

  writeValue(obj: any): void {
    if (obj !== undefined && this.val !== obj) {
      const numericValue = parseFloat(obj);
      this.val = this.type == 'number' ? numericValue : obj;
      this.onChange(this.val);
      this.onTouched();
    }
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  setDisabledState?(isDisabled: boolean): void {
    this.disabled = isDisabled;
  }

  onInputChange(event: any): void {
    const value = event.target.value;

    if (this.type === 'number' && !/^\d*\.?\d*$/.test(value)) {
      event.target.value = this.val;
      return;
    }

    this.val = value;
    this.onChange(this.type === 'number' ? parseFloat(value) : value);
    this.onTouched();
  }
  convertTypeText() {
    this.type = 'text';
    this.inputType = 'text';
  }
}
