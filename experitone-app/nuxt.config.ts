// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  compatibilityDate: '2024-11-01',
  devtools: { enabled: true },
  future: {
    compatibilityVersion: 4
  },
  modules: ['@prisma/nuxt'],
  prisma: {
    datasourceUrl: process.env.DATABASE_URL,
    log: ['query', 'info', 'warn', 'error'],
    errorFormat: 'pretty',
  },
})
