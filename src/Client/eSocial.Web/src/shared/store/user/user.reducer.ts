import { IGetMeResponse } from '@app-shared/models/user.models';
import { createReducer, on } from '@ngrx/store';
import {
  getMe,
  getMeFailed,
  getMeSuccess,
  signIn,
  signInFailed,
  signInSuccess,
  signUp,
  signUpFailed,
  signUpSuccess,
} from '@app-shared/store/user/user.actions';

export interface IUserState {
  loadingSignIn?: boolean;
  loadingSignUp?: boolean;
  loadingGetMe?: boolean;
  user?: IGetMeResponse;
}

const initialState: IUserState = {};

export const userReducer = createReducer(
  initialState,
  on(signIn, (state) => ({ ...state, loadingSignIn: true })),
  on(signInSuccess, (state) => ({ ...state, loadingSignIn: false })),
  on(signInFailed, (state) => ({ ...state, loadingSignIn: false })),
  on(signUp, (state) => ({ ...state, loadingSignUp: true })),
  on(signUpSuccess, (state) => ({ ...state, loadingSignUp: false })),
  on(signUpFailed, (state) => ({ ...state, loadingSignUp: false })),
  on(getMe, (state) => ({ ...state, loadingSignUp: true })),
  on(getMeSuccess, (state, { response }) => ({
    ...state,
    loadingSignUp: false,
    user: response,
  })),
  on(getMeFailed, (state) => ({ ...state, loadingSignUp: false })),
);
