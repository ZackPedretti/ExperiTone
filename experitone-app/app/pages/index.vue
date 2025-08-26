<script setup lang="ts">
import type {Song} from "~/entities/Song";

const { t } = useI18n()

const recentlyAnnotatedSongs = await $fetch<Song[]>("/api/annotations/get-recent")
</script>

<template>
  <h1 class="mb-6 w-75 mx-auto">{{ t("homepage.recently-annotated.title") }}</h1>
  <SongCard v-for="song in recentlyAnnotatedSongs" :key="song.videoId" :song="song" />
</template>

<style scoped>

</style>