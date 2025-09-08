// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  compatibilityDate: '2024-11-01',
  devtools: { enabled: true },
  future: {
    compatibilityVersion: 4
  },
  modules: ['@prisma/nuxt', '@nuxtjs/i18n', '@pinia/nuxt'],
  i18n: {
    strategy: 'prefix',
    defaultLocale: 'en',
    locales: [
      { code: 'en', name: 'English', file: 'en.json' },
      { code: 'fr', name: 'French', file: 'fr.json' }
    ],
    detectBrowserLanguage: {
      useCookie: true,
      cookieKey: 'i18n_redirected',
      alwaysRedirect: true,
      fallbackLocale: 'en'
    },
  },
  prisma: {
    datasourceUrl: process.env.DATABASE_URL,
    log: ['query', 'info', 'warn', 'error'],
    errorFormat: 'pretty',
  },
  css: [
    'vuetify/styles',
    '@mdi/font/css/materialdesignicons.min.css',
    '~/assets/scss/main.scss'
  ],
  plugins: ['~/plugins/vuetify.ts'],
  build: {
    transpile: ['vuetify'],
  },
  vite: {
    server: {
      watch: {
        usePolling: true,
      },
    },
    css: {
      preprocessorOptions: {
        scss: {
          additionalData: `
            @use "~/assets/scss/mixins" as *;
            @use "~/assets/scss/variables" as *;
          `
        }
      }
    },
  },
})
