export interface IAPIResponse<T> {
  success: boolean;
  statusCode: number;
  message?: string;
  errors?: any;
  data: T;
}
