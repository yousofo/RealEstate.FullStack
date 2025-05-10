 import clientFetch from "@/utils/client-fetch";
import { redirect } from "next/navigation";

export default function Layout({ children }: { children: React.ReactNode }) {
    if (typeof window !== "undefined") {
        const token = localStorage.getItem("token");
        if (!token) {
            redirect("/");
        } else {
            clientFetch("auth/verify").catch(() => {
                redirect("/");
            });
        }
    }

    return (
        <>
            {children}
        </>
    );
}
