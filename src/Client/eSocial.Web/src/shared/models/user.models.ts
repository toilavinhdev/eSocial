export interface ISignInRequest {
  email: string;
  password: string;
}

export interface ISignInResponse {
  accessToken: string;
}

export interface ISignUpRequest {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
}

export interface IGetMeResponse {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  avatarUrl: string;
}
