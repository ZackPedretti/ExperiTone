// types/prisma.d.ts
import 'nuxt/schema'

declare module 'nuxt/schema' {
    interface NuxtConfig {
        prisma?: {
            datasourceUrl?: string
            log?: Array<'query' | 'info' | 'warn' | 'error'>
            errorFormat?: 'pretty' | 'minimal' | 'colorless'
        }
    }
}
