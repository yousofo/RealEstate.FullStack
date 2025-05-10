"use client";
import { configureStore } from "@reduxjs/toolkit";
import authReducer from "./slices/authSlice";
import themeReducer from "./slices/themeSlice";

// const store 

// export const makeStore = () => {
    //return 
     const store =configureStore({
        reducer: {
            theme: themeReducer,
            auth: authReducer,
        },
    });
// };
export default store

// export type AppStore = ReturnType<typeof store>;
