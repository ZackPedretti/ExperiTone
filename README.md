# ExperiTone

ExperiTone is a web application that lets users annotate songs based on their notable musical experiments — whether it’s an unusual time signature, a unique sound texture, or an unexpected transition.
The platform integrates Elasticsearch for powerful search and filtering capabilities, and uses a C# ASP.NET API as its backend service.

With ExperiTone, you ~~can~~ (will be able to):
- Select a song from YouTube (no audio is hosted on the platform).
- Mark specific points or time ranges where musical experiments occur.
- Add descriptions, tags, and categories for each annotation.
- Search and filter annotations across the whole database.

Tech stack:
- Frontend: Web interface in Vue.js 3 in Nuxt 3 with Vuetify 3
- Backend: C# ASP.NET API for annotation and song fetching, Nuxt 3 for authentication
- Search Engine: Elasticsearch
- Database: PostgreSQL + Prisma ORM

API features :
- Insert annotation
- Fetch annotations of song (by video ID)
- Full text search of songs
- Fetch the most recently annotated songs
