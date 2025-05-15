export interface IPaginatedResponse<T> {
    totalCount: number;
    pageSize: number;
    pageNumber: number;
    totalPages: number;
    hasPrevious: boolean;
    hasNext: boolean;
    items: T[]
}