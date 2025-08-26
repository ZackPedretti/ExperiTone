<script setup lang="ts">
import type { Song } from "~/entities/Song";
import SongThumbnail from "~/components/SongCard/SongThumbnail.vue";

defineProps<{
  song: Song
}>()

const { t } = useI18n()

function getTimeAgo(date: Date): { n: number, unit: string } {
  const now = new Date()
  const seconds = Math.floor((now.getTime() - date.getTime()) / 1000)

  const intervals = [
    { unit: t("time-units.year"), seconds: 31536000 },
    { unit: t("time-units.month"), seconds: 2592000 },
    { unit: t("time-units.week"), seconds: 604800 },
    { unit: t("time-units.day"), seconds: 86400 },
    { unit: t("time-units.hour"), seconds: 3600 },
    { unit: t("time-units.minute"), seconds: 60 },
    { unit: t("time-units.second"), seconds: 1 },
  ]

  for (const interval of intervals) {
    const n = Math.floor(seconds / interval.seconds)
    if (n >= 1) {
      return { n, unit: interval.unit }
    }
  }

  return { n: 0, unit: t("time-units.second") }
}
</script>

<template>
  <v-card flat class="w-75 mx-auto main-card">
    <v-row justify="center">
      <v-col cols="auto">
        <SongThumbnail :video-id="song.videoId" />
      </v-col>
      <v-col cols="auto">
        <v-card-title class="pb-0 text-h5">{{ song.title }}</v-card-title>
        <v-card-subtitle>{{ t("song-card.annotation-count", {n: song.annotationCount}) }} - {{ t("song-card.created-at", getTimeAgo(new Date(song.lastUpdated)))}}</v-card-subtitle>
        <v-card-title class="pb-0 text-h6">{{ song.author }}</v-card-title>
        <v-card-text>{{ song.description }}</v-card-text>
      </v-col>
    </v-row>
  </v-card>
</template>

<style scoped>
.main-card {
  height: 600px;
}
</style>