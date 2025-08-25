<script setup lang="ts">
import {authClient} from "~~/lib/authClient";

async function logOut() {
  await authClient.signOut()
}
const {data: session} = await authClient.useSession(useFetch);
</script>

<template>
  <v-menu
      location="bottom start"
      origin="top start"
      width="300"
  >
    <template #activator="{ props }">
      <v-btn v-bind="props" icon>
        <AccountPicture />
      </v-btn>
    </template>

    <v-list>
      <v-list-item class="w-100">
        <v-row class="align-center" no-gutters>
          <v-col cols="auto">
            <AccountPicture />
          </v-col>
          <v-col class="ml-2">
            <v-list-item-title>{{ session?.user.name }}</v-list-item-title>
          </v-col>
        </v-row>
      </v-list-item>
      <v-list-item>
        <v-btn class="w-100" @click="logOut" flat>Log out</v-btn>
      </v-list-item>
    </v-list>
  </v-menu>
</template>

<style scoped>

</style>