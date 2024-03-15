import { Component, OnInit } from '@angular/core';
import { SidebarComponent } from '@app-shared/components';
import { RouterOutlet } from '@angular/router';
import { BaseComponent } from '@app-core/abstractions';
import { Store } from '@ngrx/store';
import { getMe } from '@app-shared/store/user';

@Component({
  selector: 'app-main-container',
  standalone: true,
  imports: [SidebarComponent, RouterOutlet],
  templateUrl: './main-container.component.html',
  styles: ``,
})
export class MainContainerComponent extends BaseComponent implements OnInit {
  constructor(private store: Store) {
    super();
  }

  ngOnInit() {
    this.store.dispatch(getMe());
  }
}
