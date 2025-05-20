export interface IFetchCount {
  pageCount: number;
}

export interface IResult {
  isSuccess: boolean;
  error: {
    message: string;
    code: string;
  };
}
