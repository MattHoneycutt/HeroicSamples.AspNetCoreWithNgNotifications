import { Component, OnInit } from '@angular/core';
import { NotificationsService } from 'angular2-notifications';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  result: string;

  constructor(
    private notifications: NotificationsService,
    private httpClient: HttpClient
  ) {
  }

  ngOnInit() {
    this.notifications.success('Hi!', 'Everything is initialized!');
  }

  async callAction(action: string) {
    this.result = null;

    const options = {responseType: 'text' as 'text'};
    const result = await this.httpClient.get(`/api/notifications/${action}`, options).toPromise();

    this.result = result;
  }
}
