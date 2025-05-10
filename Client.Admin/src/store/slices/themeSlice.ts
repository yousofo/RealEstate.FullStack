"use client";
import { getItem } from "@/utils/storage";
import { createSlice } from "@reduxjs/toolkit";
import { PaletteMode } from "@mui/material";
const initialState: {
    mode: PaletteMode;
} = {
    mode: (getItem("theme") === "dark" && "dark") || "light",
};
const themeSlice = createSlice({
    name: "theme",
    initialState,
    reducers: {
        setTheme: (state, action: { payload: "light" | "dark" }) => {
            state.mode = action.payload;
        },
    },
});
export const { setTheme } = themeSlice.actions;
export default themeSlice.reducer;
