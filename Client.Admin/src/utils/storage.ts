export function getItem(key: string): string | null {
  if (typeof window !== "undefined") {
    return localStorage.getItem(key);
  }
  return null;
}
export function setItem(key: string, value: string): void {
  if (typeof window !== "undefined") {
    localStorage.setItem(key, value);
  }
}