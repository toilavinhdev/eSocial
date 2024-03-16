import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SpinnerOverlayComponent } from '@app-shared/components';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, SpinnerOverlayComponent],
  templateUrl: './app.component.html',
})
export class AppComponent {}
