<script setup lang="ts">
import type { Song } from "~~/entities/Song";
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
  <v-card color="transparent" flat class="w-75 mx-auto main-card h-auto">
    <v-row justify="center" align="start">
      <v-col
          cols="12"
          sm="8"
          md="6"
          lg="4"
          class="d-flex justify-center"
      >
        <SongThumbnail :video-id="song.videoId" />
      </v-col>

      <v-col cols="12" sm="8" md="6" lg="7">
        <v-card-text class="pb-0 text-h5 text">{{ song.title }}</v-card-text>
        <v-card-subtitle class="text">{{ t("song-card.annotation-count", {n: song.annotationCount}) }} - {{ t("song-card.created-at", getTimeAgo(new Date(song.lastUpdated)))}}</v-card-subtitle>
        <v-card-text class="pb-0 text-h6 text">{{ song.author }}</v-card-text>
        <v-card-text class="text py-0">{{ song.description }}</v-card-text>
      </v-col>
    </v-row>
  </v-card>
</template>

<style scoped>
.main-card {
  height: 600px;
}
.text {
  display: -webkit-box;
  -webkit-line-clamp: 3; /* show max 3 lines */
  -webkit-box-orient: vertical;
  overflow: hidden;
  text-overflow: ellipsis;
}
</style>