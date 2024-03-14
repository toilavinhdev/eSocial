import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { CommonService, UserService } from '@app-shared/services';
import {
  signIn,
  signInFailed,
  signInSuccess,
} from '@app-shared/store/user/user.actions';
import { catchError, map, of, switchMap, tap } from 'rxjs';
import { authConst } from '@app-core/constants/auth.const';

@Injectable()
export class UserEffects {
  constructor(
    private actions$: Actions,
    private userService: UserService,
    private commonService: CommonService,
  ) {}

  signIn$ = createEffect(() =>
    this.actions$.pipe(
      ofType(signIn),
      switchMap(({ payload }) =>
        this.userService.signIn(payload).pipe(
          map((res) => signInSuccess({ response: res })),
          catchError(() => of(signInFailed)),
        ),
      ),
    ),
  );

  signInSuccess$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(signInSuccess),
        tap(({ response }) => {
          localStorage.setItem(authConst.ACCESS_TOKEN, response.accessToken);
          localStorage.setItem(
            authConst.USER_DATA,
            JSON.stringify(
              this.userService.getUserClaimValue(response.accessToken),
            ),
          );
          this.commonService.redirectToMainPage();
        }),
      ),
    { dispatch: false },
  );
}
