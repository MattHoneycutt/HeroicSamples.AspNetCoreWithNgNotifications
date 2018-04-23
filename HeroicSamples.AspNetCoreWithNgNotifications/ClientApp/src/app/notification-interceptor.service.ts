import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpEvent, HttpResponse } from '@angular/common/http'
import {HttpRequest} from '@angular/common/http/src/request';
import {HttpHandler} from '@angular/common/http/src/backend';
import { NotificationsService } from 'angular2-notifications';
import 'rxjs/add/operator/do';

@Injectable()
export class NotificationInterceptorService implements HttpInterceptor {

  constructor(
    //The angular2-notification service
    private notifications: NotificationsService,
    ) { }

  intercept(request: HttpRequest<any>, next: HttpHandler) {

    return next.handle(request)
      .do((ev: HttpEvent<any>) => {
        if (ev instanceof HttpResponse) {
          const headers = ev.headers;

          const type = headers.get('x-notification-type');
          const title = headers.get('x-notification-title');
          const body = headers.get('x-notification-body');

          if (type && title && body) {
            this.notifications.create(title, body, type);
          }
        }
      });
  }

}
