import { Injectable } from '@angular/core';

@Injectable()
export class BaseService {
  private readonly host = 'http://localhost:5043';
  private endpoint = '';

  constructor() {}

  setEndpoint(tag: string) {
    this.endpoint = `${this.host}/api/v1/${tag}`;
  }

  getApi(action: string, query: string = '') {
    return `${this.endpoint}/${action}${query}`;
  }
}
