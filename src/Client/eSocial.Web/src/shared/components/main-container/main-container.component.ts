import { Component } from '@angular/core';
import {SidebarComponent} from "@app-shared/components";

@Component({
  selector: 'app-main-container',
  standalone: true,
  imports: [SidebarComponent],
  templateUrl: './main-container.component.html',
  styles: ``,
})
export class MainContainerComponent {}
