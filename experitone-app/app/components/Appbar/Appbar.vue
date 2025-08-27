<script setup lang="ts">
import {authClient} from "~~/lib/authClient";
import Searchbar from "~/components/Appbar/Searchbar.vue";
import AccountMenu from "~/components/Appbar/AccountMenu.vue";

const {data: session} = await authClient.useSession(useFetch);
</script>

<template>
  <v-app-bar app color="primary" class="position-relative position-sticky">
    <template v-slot:prepend>
      <v-app-bar-nav-icon></v-app-bar-nav-icon>
    </template>

    <v-app-bar-title>
      <NuxtLink to="/public" class="text-white text-decoration-none">
        ExperiTone
      </NuxtLink>
    </v-app-bar-title>

    <Searchbar />

    <template v-slot:append>
      <AccountMenu v-if="session"/>
      <NuxtLink v-else href="sign-in" class="mr-4">
        <v-btn flat color="white">
          Sign in
        </v-btn>
      </NuxtLink>
    </template>
  </v-app-bar>
</template>

<style scoped>
</style>