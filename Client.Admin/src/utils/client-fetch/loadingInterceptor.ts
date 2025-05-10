export let currentRequestsCount: number = 0;

export default function loadingInterceptor(loading: boolean ): void {
    if (loading) {
        currentRequestsCount++;
        //TODO: Show loading spinner or any other loading indicator
    } else {
        currentRequestsCount--;
        //TODO: Hide loading spinner or any other loading indicator
    }
}
