export interface IUser {
    id: string,
    email: string,
    firstName: string,
    lastName: string,
    token: string,
    expiresIn: number,
    refreshToken: string,
    roles: string[],
    refreshTokenExpirationDate: string,
    // image: string,
    // phone: string,
    // address: string,
    // description: string,
}
export interface IAuthState {
    user: IUser | null,
    // loading: boolean,
     isAuthenticated: boolean,
 }

export interface ISignupRequest {
    email: string,
    password: string,
    firstName: string,
    lastName: string,
    username: string,
    phone: string,
}