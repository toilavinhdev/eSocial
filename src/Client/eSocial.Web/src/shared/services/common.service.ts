import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class CommonService {
  constructor(private router: Router) {}

  redirectToLoginPage() {
    this.router.navigate(['/auth']).then();
  }

  redirectToMainPage() {
    this.router.navigate(['/']).then();
  }
}
