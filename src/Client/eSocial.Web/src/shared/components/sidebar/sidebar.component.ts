import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '@app-core/abstractions';
import { NzAvatarComponent } from 'ng-zorro-antd/avatar';
import { commonConst } from '@app-core/constants';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { Store } from '@ngrx/store';
import { signOut, userMeSelector } from '@app-shared/store/user';
import { Observable, takeUntil } from 'rxjs';
import { IGetMeResponse } from '@app-shared/models/user.models';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [NzAvatarComponent, RouterLink, RouterLinkActive, AsyncPipe],
  templateUrl: './sidebar.component.html',
  styles: ``,
})
export class SidebarComponent extends BaseComponent implements OnInit {
  protected readonly commonConst = commonConst;
  user$!: Observable<IGetMeResponse | undefined>;

  constructor(private store: Store) {
    super();
  }

  ngOnInit() {
    this.user$ = this.store
      .select(userMeSelector)
      .pipe(takeUntil(this.destroy$));
  }

  onSignOut() {
    this.store.dispatch(signOut());
  }
}
