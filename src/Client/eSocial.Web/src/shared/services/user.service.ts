import { Injectable } from '@angular/core';
import { BaseService } from '@app-core/abstractions';
import {
  IGetMeResponse,
  ISignInRequest,
  ISignInResponse,
  ISignUpRequest,
} from '../models/user.models';
import { map, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IAPIResponse, IUserClaimValue } from '@app-core/models';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class UserService extends BaseService {
  constructor(private httpClient: HttpClient) {
    super();
    this.setEndpoint('user');
  }

  signIn(payload: ISignInRequest): Observable<ISignInResponse> {
    const api = this.getApi('sign-in');
    return this.httpClient
      .post<IAPIResponse<ISignInResponse>>(api, payload)
      .pipe(map((res) => res.data));
  }

  signUp(payload: ISignUpRequest): Observable<any> {
    const api = this.getApi('sign-up');
    return this.httpClient.post<IAPIResponse<any>>(api, payload);
  }

  getMe(): Observable<IGetMeResponse> {
    const api = this.getApi('me');
    return this.httpClient
      .get<IAPIResponse<IGetMeResponse>>(api)
      .pipe(map((res) => res.data));
  }

  getUserClaimValue(accessToken: string): IUserClaimValue {
    return jwtDecode<IUserClaimValue>(accessToken);
  }
}
