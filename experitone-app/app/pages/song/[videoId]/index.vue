<script setup lang="ts">
import type {Annotation} from "~/entities/Annotation";
import AnnotationCard from "~/components/AnnotationCard.vue";

const route = useRoute()
const videoId = route.params.videoId as string

const annotations = ref<Annotation[]>([])

const { t } = useI18n();

onMounted(async () => {
  annotations.value = await $fetch<Annotation[]>(`/api/annotations/get-annotations-of-song?videoId=${videoId}`)
})
</script>

<template>
  <div class="main-container">
    <YoutubePlayer :videoId="videoId" class="video-col"/>

    <div class="annotation-col">
      <div class="inner-annotation-container">
        <v-list>
          <v-list-item
              v-for="annotation in annotations"
              :key="annotation.annotationId"
          >
            <AnnotationCard :annotation="annotation" />
          </v-list-item>
        </v-list>
        <v-btn prepend-icon="mdi-plus" color="primary" flat>{{ t("song-page.add-btn") }}</v-btn>
      </div>
    </div>
  </div>
</template>

<style scoped>
.main-container {
  display: flex;
  gap: 16px;
  overflow: hidden;
  max-height: 70vh;
}

.video-col {
  flex: 2;
  min-width: 0;
}

.annotation-col {
  flex: 1;
  min-width: 250px;
  max-width: 600px;
  overflow-y: auto;
  border-left: 1px solid #ddd;
  max-height: 100%;
  padding: 8px;
}

.inner-annotation-container {
  display: flex;
  flex-direction: column;
  height: 100%;
  justify-content: space-between;
}
</style>
