import { ApplicationConfig } from '@angular/core';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { providePrimeNG } from 'primeng/config';
import Aura from '@primeng/themes/aura';
import { definePreset, palette } from '@primeng/themes';
import {
  provideRouter,
  withComponentInputBinding,
  withViewTransitions,
} from '@angular/router';
import { routes } from './app.routes';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { loadingInterceptor } from './app/interceptors/loading/loading.interceptor';
import { authInterceptor } from './app/interceptors/auth/auth.interceptor';
//naming pattern goes 'property' + 'in Dark/Light' => color //textLight = #131313 // => text color in light mode = #131313
const MyPreset = definePreset(Aura, {
  semantic: {
    primary: {
      50: '{indigo.50}',
      100: '{indigo.100}',
      200: '{indigo.200}',
      300: '{indigo.300}',
      400: '{primary.text}',
      500: '{indigo.500}',
      600: '{indigo.600}',
      700: '{indigo.700}',
      800: '{indigo.800}',
      900: '{indigo.900}',
      950: '{indigo.950}',
      textLight: '#0e0e10',
      textDark: '#efeff1',
      bgLight: '#ffffff',
      bgDark: '#0e0e10',
      hoverLight: '#f7f7f8',
      hoverDark: '#adadb8',
      activeLight: '#53535f',
      activeDark: '#adadb8',
    },
    secondary: {
      textLight: '#10100E',
      textDark: '#D4D4D9',
      bgLight: '#E6E6E6',
      bgDark: '#10100E',
    },
    info: {
      textLight: '#53535f',
      textDark: '#adadb8',
      bgLight: '#53535f',
      bgDark: '#adadb8',
    },
    highlight: {
      purpleLight: '#5c16c5',
      purpleDark: '#bf94ff',
      red: '#eb0400',
    },
    header: {
      bgLight: '#ffffff',
      bgDark: '#18181b',
    },
    body: {
      bgLight: '#f7f7f8',
      bgDark: '{primary.textLight}',
    },
    sideNav: {
      bgLight: '{primary.textDark}',
      bgDark: '#1f1f23',
    },
    colorScheme: {
      light: {
        primary: {
          color: '{primary.950}',
          bg: '{primary.bgLight}',
          text: '{text.primaryLight}',
          inverseColor: '#ffffff',
          hoverColor: '{primary.hoverLight}',
          activeColor: '{primary.activeLight}',
        },
        secondary: {
          color: '{primary.800}',
          bg: '{secondary.bgLight}',
          text: '{secondary.textLight}',
          inverseColor: '#ffffff',
          hoverColor: '{primary.900}',
          activeColor: '{primary.800}',
        },
        info: {
          text: '{info.textLight}',
        },
        highlight: {
          purple: '{highlight.purpleLight}',
          red: '{highlight.red}',
        },
        body: {
          bg: '{body.bgLight}',
        },
        header: {
          bg: '{header.bgLight}',
        },
        sideNav: {
          bg: '{sideNav.bgLight}',
        },
      },
      dark: {
        primary: {
          color: '{primary.50}',
          bg: '{primary.bgDark}',
          text: '{primary.textDark}',
          inverseColor: '{primary.950}',
          hoverColor: '{primary.hoverDark}',
          activeColor: '{primary.activeDark}',
        },
        secondary: {
          color: '{primary.50}',
          bg: '{secondary.bgDark}',
          text: '{secondary.textDark}',
          inverseColor: '{primary.950}',
          hoverColor: '{primary.100}',
          activeColor: '{primary.200}',
        },
        info: {
          text: '{info.textDark}',
        },
        highlight: {
          purple: '{highlight.purpleDark}',
          red: '{highlight.red}',
        },
        body: {
          bg: '{body.bgDark}',
        },
        header: {
          bg: '{header.bgDark}',
        },
        sideNav: {
          bg: '{sideNav.bgDark}',
        },
      },
    },
  },
});

export const appConfig: ApplicationConfig = {
  providers: [
    provideHttpClient(withInterceptors([
      loadingInterceptor,
      authInterceptor
    ])),
    provideRouter(routes, withViewTransitions(), withComponentInputBinding()),
    provideAnimationsAsync(),
    providePrimeNG({
      theme: {
        preset: MyPreset,
        options: {
          darkModeSelector: '.my-app-dark',
          cssLayer: {
            name: 'primeng',
            order: 'tailwindBase, primeng, styles',
          },
        },
      },
    }),
  ],
};
