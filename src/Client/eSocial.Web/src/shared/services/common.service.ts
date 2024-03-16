import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CommonService {
  spinnerSubject$ = new Subject<boolean>();

  constructor(private router: Router) {}

  redirectToLoginPage() {
    this.router.navigate(['/auth']).then();
  }

  redirectToMainPage() {
    this.router.navigate(['/']).then();
  }

  showLoading() {
    this.spinnerSubject$.next(true);
  }

  hideLoading() {
    this.spinnerSubject$.next(false);
  }
}
