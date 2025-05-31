import { HttpInterceptorFn } from '@angular/common/http';
import { storage } from '../../utils/storage/storage.utils';
import { environment } from '../../../environments/environment';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const token = storage.getItem('appSession')?.token;

  if (token && req.url.startsWith(environment.apiUrl)) {
    const cloned = req.clone({
      
      setHeaders: {
        Authorization: `Bearer ${token}`,
      },
    });
    return next(cloned);
  
  }
  // const clonedRequest = req.clone({
  //   // withCredentials: true,
  //   headers: req.headers.set('Authorization', `Bearer ${token}`),
  // });
  return next(req);
};
