<script setup lang="ts">
import { createAuthClient } from "better-auth/client"
const authClient = createAuthClient()

const email = ref("");
const password = ref("");

async function signIn(): Promise<void> {
  const response = await authClient.signIn.email({
    email: email.value,
    password: password.value,
  })
  console.log(response)
}

</script>

<template>
  <v-container class="fill-height d-flex justify-center align-center mt-6">
    <v-form>
      <v-card width="400" class="pa-6">
        <v-card-title class="text-h5">Sign in</v-card-title>

        <v-text-field label="Email" v-model="email" outlined dense />
        <v-text-field label="Password" v-model="password" type="password" outlined dense />

        <v-btn color="primary" class="mt-4" block @click="signIn">Sign in</v-btn>
        <v-card-text>No account? Sign up <a href="/sign-up">here</a></v-card-text>
      </v-card>
    </v-form>
  </v-container>
</template>


<style scoped>

</style>