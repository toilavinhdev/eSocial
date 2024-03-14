import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '@app-core/abstractions';
import {
  FormBuilder,
  ReactiveFormsModule,
  UntypedFormGroup,
  Validators,
} from '@angular/forms';
import { Store } from '@ngrx/store';
import { signIn } from '@app-shared/store/user';
import { NzInputDirective, NzInputGroupComponent } from 'ng-zorro-antd/input';
import { NzIconDirective } from 'ng-zorro-antd/icon';
import { NzButtonComponent } from 'ng-zorro-antd/button';

@Component({
  selector: 'app-sign-in',
  standalone: true,
  imports: [
    NzInputDirective,
    ReactiveFormsModule,
    NzInputGroupComponent,
    NzIconDirective,
    NzButtonComponent,
  ],
  templateUrl: './sign-in.component.html',
  styles: ``,
})
export class SignInComponent extends BaseComponent implements OnInit {
  form!: UntypedFormGroup;
  passwordVisible = false;

  constructor(
    private formBuilder: FormBuilder,
    private store: Store,
  ) {
    super();
  }

  ngOnInit() {
    this.buildForm();
  }

  onSubmit() {
    if (this.form.invalid) return;
    this.store.dispatch(signIn({ payload: this.form.value }));
  }

  private buildForm() {
    this.form = this.formBuilder.group({
      email: ['hoangdvinh68@gmail.com', [Validators.required]],
      password: [
        'Password@123',
        [Validators.required, Validators.minLength(6)],
      ],
    });
  }
}
