<script setup lang="ts">
import { createAuthClient } from "better-auth/client"
const authClient = createAuthClient()

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
        <v-card-title class="text-h5">Sign up</v-card-title>

        <v-text-field label="Name" v-model="name" outlined dense />
        <v-text-field label="Email" v-model="email" outlined dense />
        <v-text-field label="Password" v-model="password" type="password" outlined dense />

        <v-btn color="primary" class="mt-4" block @click="signUp">Sign up</v-btn>
        <v-card-text>Already have an account? Sign in <a href="/sign-in">here</a></v-card-text>
      </v-card>
    </v-form>
  </v-container>
</template>

<style scoped>

</style>