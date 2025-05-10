"use client";
import { useEffect } from "react";
import { usePathname } from "next/navigation";
import { toast } from "react-toastify";

export default function NavigationTracker() {
    const pathname = usePathname();

    useEffect(() => {
       toast.dismiss();
       console.log("Navigated to:", pathname);
    }, [pathname]);

    return null;
}
