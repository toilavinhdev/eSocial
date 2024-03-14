import { createAction, props } from '@ngrx/store';
import {
  IGetMeResponse,
  ISignInRequest,
  ISignInResponse,
  ISignUpRequest,
} from '@app-shared/models/user.models';

const SIGN_IN = '[User] Sign In';
const SIGN_IN_SUCCESS = '[User] Sign In Success';
const SIGN_IN_FAILED = '[User] Sign In Failed';
const SIGN_UP = '[User] Sign Up';
const SIGN_UP_SUCCESS = '[User] Sign Up Success';
const SIGN_UP_FAILED = '[User] Sign Up Failed';
const GET_ME = '[User] Get Me';
const GET_ME_SUCCESS = '[User] Get Me Success';
const GET_ME_FAILED = '[User] Get Me Failed';

/** Sign In **/
export const signIn = createAction(
  SIGN_IN,
  props<{ payload: ISignInRequest }>(),
);

export const signInSuccess = createAction(
  SIGN_IN_SUCCESS,
  props<{ response: ISignInResponse }>(),
);

export const signInFailed = createAction(SIGN_IN_FAILED);

/** Sign Up **/
export const signUp = createAction(
  SIGN_UP,
  props<{ payload: ISignUpRequest }>(),
);

export const signUpSuccess = createAction(SIGN_UP_SUCCESS);

export const signUpFailed = createAction(SIGN_UP_FAILED);

/** Get Me **/
export const getMe = createAction(GET_ME);

export const getMeSuccess = createAction(
  GET_ME_SUCCESS,
  props<{ response: IGetMeResponse }>(),
);

export const getMeFailed = createAction(GET_ME_FAILED);
