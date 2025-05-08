'use client';
import { configureStore } from "@reduxjs/toolkit";
import authReducer from "./slices/authSlice";

export const makeStore = () => {
	return configureStore({
	  reducer: {
		auth:authReducer
	  },
	})
  }
  
  export type AppStore = ReturnType<typeof makeStore>
