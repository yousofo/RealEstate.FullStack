import authInterceptor from "./authInterceptor";
import loadingInterceptor from "./loadingInterceptor";

export default async function clientFetch(
    path: string = "/",
    options: RequestInit = {}
): Promise<Response> {
    const defaultOptions: RequestInit = {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
        },
    };

    const finalOptions = { ...defaultOptions, ...options };

    // Apply interceptors
    authInterceptor(finalOptions);
    loadingInterceptor(true);

    try {
        try {
            const response = await fetch(`${process.env.NEXT_PUBLIC_API_URL}/api/${path}`, finalOptions);
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            return await response.json();
        } catch (error) {
            throw error;
        }
    } finally {
        loadingInterceptor(false);
        console.log("Fetch completed");
    }
}
