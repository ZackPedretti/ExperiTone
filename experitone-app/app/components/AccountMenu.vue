<script setup lang="ts">
import {authClient} from "~~/lib/authClient";

async function signOut() {
  await authClient.signOut()
}

const {data: session} = await authClient.useSession(useFetch);
const {t} = useI18n();

function goToSettingsPage() {

}

function goToProfilePage() {

}
</script>

<template>
  <v-menu
      location="bottom start"
      origin="top start"
      width="300"
  >
    <template #activator="{ props }">
      <v-btn v-bind="props" icon>
        <AccountPicture/>
      </v-btn>
    </template>

    <v-list>
      <v-list-item class="w-100 py-2">
        <v-btn
          flat
          class="h-100 w-100 justify-start py-2"
          @click="goToProfilePage"
        >
          <v-row class="align-center" no-gutters>
            <v-col cols="auto">
              <AccountPicture/>
            </v-col>
            <v-col class="ml-2">
              <v-list-item-title>{{ session?.user.name }}</v-list-item-title>
            </v-col>
          </v-row>
        </v-btn>
      </v-list-item>
      <v-list-item>
        <v-btn
            class="w-100 justify-start text-body-1"
            flat
            prepend-icon="mdi-cog"
            @click="goToSettingsPage"
        >
          {{ t("layout.user-menu.settings") }}
        </v-btn>
      </v-list-item>
      <v-list-item>
        <v-btn
            class="w-100 justify-start text-body-1"
            flat
            prepend-icon="mdi-logout"
            @click="signOut"
        >
          {{ t("layout.user-menu.sign-out") }}
        </v-btn>
      </v-list-item>
    </v-list>
  </v-menu>
</template>

<style scoped>
</style>