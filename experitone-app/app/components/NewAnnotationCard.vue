<script setup lang="ts">
import type {PutAnnotation} from "~~/entities/PutAnnotation";

const { t } = useI18n()

const props = defineProps<{ annotation: PutAnnotation }>()
const startMinutes = ref(Math.round(props.annotation.startTimestamp / 60))
const startSeconds = ref(props.annotation.startTimestamp % 60)
const endMinutes = ref(0)
const endSeconds = ref(0)
const hasEnd = ref(false)
</script>

<template>
  <v-card flat>
    <v-row class="w-100 mb-4" align="center" justify="space-between">
      <v-col cols="auto">
        <v-text-field
            :label="t('song-page.new-annotation-card.title')"
            variant="outlined"
            width="300"
            hide-details
        />
      </v-col>
      <v-col cols="auto" >
        <v-btn icon="mdi-close" flat/>
      </v-col>
    </v-row>
    <v-textarea
        :label="t('song-page.new-annotation-card.description')"
        variant="outlined"
        hide-details
    />
    <v-card-text class="pl-0 text-body-2">
      {{ t("song-page.new-annotation-card.start") }}
    </v-card-text>
    <v-row class="pa-3" align="center" justify="start">
      <v-number-input
          v-model="startMinutes"
          :min="0"
          reverse
          variant="outlined"
          control-variant="stacked"
          density="compact"
          hide-details
          class="timestamp-input"
      />
      <span class="timestamp-separator">:</span>
      <v-number-input
          v-model="startSeconds"
          :min="0"
          :max="59"
          reverse
          variant="outlined"
          control-variant="stacked"
          density="compact"
          hide-details
          class="timestamp-input"
      />

    </v-row>
    <v-checkbox
        :label="t('song-page.new-annotation-card.has-end')"
        class="pl-0 text-body-2"
        v-model="hasEnd"
        hide-details
    />
    <div v-if="hasEnd" class="pa-0 ma-0">
      <v-card-text class="pl-0 text-body-2">
        {{ t("song-page.new-annotation-card.end") }}
      </v-card-text>
      <v-row class="pa-3" align="center" justify="start">
        <v-number-input
            v-model="endMinutes"
            :min="0"
            reverse
            variant="outlined"
            control-variant="stacked"
            density="compact"
            hide-details
            class="timestamp-input"
        />
        <span class="timestamp-separator">:</span>
        <v-number-input
            v-model="endSeconds"
            :min="0"
            :max="59"
            reverse
            variant="outlined"
            control-variant="stacked"
            density="compact"
            hide-details
            class="timestamp-input"
        />

      </v-row>
    </div>
    <v-card-actions>
      <v-btn class="text-body-2 mt-4" color="primary" flat prepend-icon="mdi-pencil-plus" variant="tonal">
        {{ t("song-page.new-annotation-card.create") }}
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<style scoped lang="scss">

.timestamp-input {
  max-width: 25%;
  font-size: 0.75rem;
  text-align: center;
  padding: 0;

  input {
    font-family: monospace;
    letter-spacing: 10px;
  }
}

.timestamp-dash {
  width: 10px;
  text-align: center;
}

</style>