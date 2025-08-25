<script setup lang="ts">
import { authClient } from "~~/lib/authClient";

const { data: session } = await authClient.useSession(useFetch);
console.log("Session", session);
</script>

<template>
  <p>
    {{ session }}
  </p>
</template>

<style scoped>

</style>