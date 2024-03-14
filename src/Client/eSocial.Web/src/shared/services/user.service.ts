import { Injectable } from '@angular/core';
import { BaseService } from '@app-core/abstractions';

@Injectable({
  providedIn: 'root',
})
export class UserService extends BaseService {
  constructor() {
    super();
    this.setEndpoint('user');
  }
}
