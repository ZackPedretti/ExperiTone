<script setup lang="ts">
import { createAuthClient } from "better-auth/client"
const authClient = createAuthClient()
const { t } = useI18n()
const router = useRouter()

const email = ref("");
const password = ref("");

async function signIn(): Promise<void> {
  const response = await authClient.signIn.email({
    email: email.value,
    password: password.value,
  })
  console.log(response)
  if (response?.data) {
    await router.push("/")
  }
}

</script>

<template>
  <v-container class="fill-height d-flex justify-center align-center mt-6">
    <v-form>
      <v-card width="400" class="pa-6">
        <v-card-title class="text-h5">{{ t('sign-in-form.title')}}</v-card-title>

        <v-text-field :label="t('sign-in-form.email')" v-model="email" outlined dense />
        <v-text-field :label="t('sign-in-form.password')" v-model="password" type="password" outlined dense />

        <v-btn color="primary" class="mt-4" block @click="signIn">{{ t('sign-in-form.button-text') }}</v-btn>
        <v-card-text>{{ t('sign-in-form.no-account') }}<NuxtLink to="/sign-up"> {{ t('sign-in-form.no-account-link') }}</NuxtLink></v-card-text>
      </v-card>
    </v-form>
  </v-container>
</template>


<style scoped>

</style>