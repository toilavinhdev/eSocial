import { HttpInterceptorFn } from '@angular/common/http';
import { authConst } from '@app-core/constants';

export const accessTokenInterceptor: HttpInterceptorFn = (req, next) => {
  const accessToken = localStorage.getItem(authConst.ACCESS_TOKEN);
  return !accessToken
    ? next(req)
    : next(
        req.clone({
          setHeaders: {
            Authorization: `Bearer ${accessToken}`,
          },
        }),
      );
};
