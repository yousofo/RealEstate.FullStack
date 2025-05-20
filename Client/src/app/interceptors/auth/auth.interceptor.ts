import { HttpInterceptorFn } from '@angular/common/http';
import { storage } from '../../utils/storage/storage.utils';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const clonedRequest = req.clone({
    // withCredentials: true,
    headers: req.headers.set('Authorization', `Bearer ${storage.getItem("appSession")?.token}`),
  });
  return next(clonedRequest);
};
