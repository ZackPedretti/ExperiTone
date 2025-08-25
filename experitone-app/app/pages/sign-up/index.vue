<script setup lang="ts">
import { createAuthClient } from "better-auth/client"
const authClient = createAuthClient()
const { t } = useI18n()

const email = ref("")
const name = ref("")
const password = ref("")

async function signUp(): Promise<void> {
  const response = await authClient.signUp.email({
    email: email.value,
    password: password.value,
    name: name.value,
  })
  console.log(response)
}

</script>

<template>
  <v-container class="fill-height d-flex justify-center align-center mt-6">
    <v-form>
      <v-card width="400" class="pa-6">
        <v-card-title class="text-h5">{{ t('sign-up-form.title') }}</v-card-title>

        <v-text-field :label="t('sign-up-form.name')" v-model="name" outlined dense />
        <v-text-field :label="t('sign-up-form.email')" v-model="email" outlined dense />
        <v-text-field :label="t('sign-up-form.password')" v-model="password" type="password" outlined dense />

        <v-btn color="primary" class="mt-4" block @click="signUp">{{ t('sign-up-form.button-text') }}</v-btn>
        <v-card-text>{{ t('sign-up-form.has-account') }}<NuxtLink href="sign-in">{{ t('sign-up-form.has-account-link') }}</NuxtLink></v-card-text>
      </v-card>
    </v-form>
  </v-container>
</template>

<style scoped>

</style>