export default function authInterceptor(options: RequestInit) {
    const token = localStorage.getItem("token");
    if (token) {
        options.headers = {
            ...options.headers,
            Authorization: `Bearer ${token}`,
        };
    }
}
