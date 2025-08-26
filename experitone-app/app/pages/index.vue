<script setup lang="ts">
import { authClient } from "~~/lib/authClient";
import type {Song} from "~/entities/Song";

const { data: session } = await authClient.useSession(useFetch);

const recentlyAnnotatedSongs = await $fetch<Song[]>("/api/annotations/get-recent")
</script>

<template>
  <SongCard v-for="song in recentlyAnnotatedSongs" :key="song.videoId" :song="song" />
</template>

<style scoped>

</style>