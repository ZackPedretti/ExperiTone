/**
 * main.ts
 *
 * Bootstraps Vuetify and other plugins then mounts the App`
 */

import { createManager } from '@vue-youtube/core'

// Composables
import { createApp } from 'vue'

// Plugins
import { registerPlugins } from '@/plugins'
// Components
import App from './App.vue'

// Styles
import 'unfonts.css'

const app = createApp(App)

const manager = createManager({
  deferLoading: {
    enabled: true,
    autoLoad: true,
  },
})

registerPlugins(app)

app.use(manager).mount('#app')
