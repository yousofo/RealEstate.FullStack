"use client";
import { createTheme } from "@mui/material/styles";
import store from "@/store/store";

const theme = createTheme({
    cssVariables: true,
    palette: {
        mode: store.getState().theme.mode, 
      },
    typography: {
        fontFamily: "var(--font-roboto)",
    },
});

export default theme;
// import { ThemeOptions } from '@mui/material/styles';

// export const themeOptions: ThemeOptions = {
//   palette: {
//     mode: 'dark',
//     primary: {
//       main: '#1976d2',
//     },
//     secondary: {
//       main: '#9c27b0',
//     },
//   },
//   overrides: {
//     MuiAppBar: {
//       colorInherit: {
//         backgroundColor: '#689f38',
//         color: '#fff',
//       },
//     },
//   },
// };
