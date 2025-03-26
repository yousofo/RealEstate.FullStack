export interface IUser {
    email: string,
    firstName: string,
    token: string,
    id: string,
    roles: string[],
    image: string,
    phone: string,
    address: string,
    description: string,
}
export interface IAuthState {
    user: IUser | null,
    loading: boolean,
    error: string,
    isAuthenticated: boolean,
}