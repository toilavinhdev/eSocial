import { CanActivateFn } from '@angular/router';
import { inject } from '@angular/core';
import { CommonService } from '@app-shared/services';
import { authConst } from '@app-core/constants/auth.const';

export const signedInGuard: CanActivateFn = (route, state) => {
  const commonService = inject(CommonService);
  const accessToken = localStorage.getItem(authConst.ACCESS_TOKEN);

  if (accessToken) {
    commonService.redirectToMainPage();
    return false;
  }

  return true;
};
