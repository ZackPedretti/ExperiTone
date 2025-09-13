<script setup lang="ts">
import type {Annotation} from "~~/entities/Annotation";

const {t} = useI18n();

const props = defineProps<{
  annotation: Annotation,
}
>()

const author = await $fetch<{ name: string, image: string }>(`/api/users/get-by-id?userId=${props.annotation.authorId}`)
const defaultPicture = "/img/default.png"

const {player} = storeToRefs(useYoutubePlayerStore());

function playFrom(seconds: number) {
  player.value?.seekTo(seconds)
}

function formatSecondsToMinutes(seconds: number): string {
  const minutes = Math.floor(seconds / 60);
  const remainingSeconds = seconds % 60;
  const paddedSeconds = remainingSeconds.toString().padStart(2, '0');
  return `${minutes}:${paddedSeconds}`;
}
</script>

<template>
  <v-card flat>
    <v-row class="w-100" align="center" justify="space-between">
      <v-col class="pa-0" cols="auto">
        <v-card-title class="pb-0">{{ annotation.title }}</v-card-title>
      </v-col>
      <v-col class="pa-0" cols="auto">
        <v-row align="center">
          <v-btn class="rounded-full mx-2" flat>
            <v-icon>mdi-thumb-up</v-icon>
          </v-btn>

          <p>{{ annotation.votes }}</p>

          <v-btn class="rounded-full mx-2" flat>
            <v-icon>mdi-thumb-down</v-icon>
          </v-btn>
        </v-row>
      </v-col>
    </v-row>
    <v-row>
      <v-card-text class="font-italic pb-0 d-flex align-center justify-start ga-1 timestamp-container">
        <span class="timestamp" @click="playFrom(annotation.startTimestamp)">{{ formatSecondsToMinutes(annotation.startTimestamp) }}</span>
        <span v-if="annotation.endTimestamp" class="timestamp-dash"> - </span>
        <span v-if="annotation.endTimestamp" class="timestamp" @click="playFrom(annotation.endTimestamp)">{{ formatSecondsToMinutes(annotation.endTimestamp) }}</span>
      </v-card-text>
    </v-row>
    <v-row>
      <v-card-text class="pt-0">{{ annotation.description ?? '' }}</v-card-text>
    </v-row>
    <v-row class="ml-4 mb-1" align="center">
      <v-avatar size="32">
        <img :src="author?.image ?? defaultPicture" alt=""/>
      </v-avatar>
      <v-card-text>{{ author.name }}</v-card-text>
    </v-row>
    <v-card-actions>
      <v-btn class="text-body-2" prepend-icon="mdi-play" @click="playFrom(annotation.startTimestamp)">
        {{ t('song-page.annotation-card.play-btn') }}
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<style scoped lang="scss">
.timestamp-container {
  width: 50px;
}

.timestamp {
  font-weight: normal;
  transition: font-weight 0.1s;
  width: 32px;

  &:hover {
    font-weight: bold;
  }
}

.timestamp-dash {
  width: 10px;
  text-align: center;
}

</style>