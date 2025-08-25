<script setup lang="ts">
import {authClient} from "~~/lib/authClient";
const {data: session} = await authClient.useSession(useFetch);
const defaultPicture = "/img/default.png"
</script>

<template>
  <v-avatar size="42">
    <img :src="session?.user?.image ?? defaultPicture"  alt=""/>
  </v-avatar>
</template>

<style scoped>

</style>