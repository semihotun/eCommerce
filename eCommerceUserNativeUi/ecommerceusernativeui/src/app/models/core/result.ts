export interface Result<T> {
  data: T;
  success: boolean;
  message: string;
}
