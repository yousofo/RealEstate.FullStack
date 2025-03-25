export interface IUser {
    email: string,
    name: string,
    token: string,
    id: string,
    role: 'admin' | 'user',
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