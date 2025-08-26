<script setup lang="ts">
import type {Song} from "~/entities/Song";

const { t } = useI18n()

const recentlyAnnotatedSongs = await $fetch<Song[]>("/api/annotations/get-recent")
</script>

<template>
  <h1 class="mb-6 w-75 mx-auto">{{ t("homepage.recently-annotated.title") }}</h1>
  <v-list>
    <v-list-item v-for="song in recentlyAnnotatedSongs" :key="song.videoId" class="my-3">
      <SongCard :song="song" />
    </v-list-item>
  </v-list>
</template>

<style scoped>
</style>