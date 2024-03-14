import { createFeatureSelector, createSelector } from '@ngrx/store';
import { IUserState } from '@app-shared/store/user/user.reducer';

export const featureUserSelector =
  createFeatureSelector<IUserState>('feature_user');

export const userLoadingSignInSelector = createSelector(
  featureUserSelector,
  (state) => state.loadingSignIn,
);

export const userLoadingSignUpSelector = createSelector(
  featureUserSelector,
  (state) => state.loadingSignUp,
);

export const userLoadingGetMeSelector = createSelector(
  featureUserSelector,
  (state) => state.loadingGetMe,
);

export const userMeSelector = createSelector(
  featureUserSelector,
  (state) => state.user,
);
