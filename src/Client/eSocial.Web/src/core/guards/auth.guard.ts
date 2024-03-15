import { CanActivateFn } from '@angular/router';
import { inject } from '@angular/core';
import { CommonService, UserService } from '@app-shared/services';
import { authConst } from '@app-core/constants';

export const authGuard: CanActivateFn = (route, state) => {
  const userService = inject(UserService);
  const commonService = inject(CommonService);
  const accessToken = localStorage.getItem(authConst.ACCESS_TOKEN);

  if (!accessToken) {
    commonService.redirectToLoginPage();
    return false;
  } else {
    const userClaim = userService.getUserClaimValue(accessToken);
    if (userClaim.exp * 1000 < Date.now()) {
      commonService.redirectToLoginPage();
      return false;
    }
  }

  return true;
};
