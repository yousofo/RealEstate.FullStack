export default interface IPaginatedSearchRequest {
    pageNumber?: number;
    pageSize?: number;
    searchTerm?: string;
    orderBy?: string;
}