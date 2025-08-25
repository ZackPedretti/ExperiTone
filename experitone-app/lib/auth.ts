import { betterAuth } from "better-auth";
import { prismaAdapter } from "better-auth/adapters/prisma"
import { PrismaClient } from "@prisma/client";
import { config as loadEnv } from "dotenv";
loadEnv();

const prisma = new PrismaClient();

export const auth = betterAuth({
    emailAndPassword: { enabled: true },
    database: prismaAdapter(prisma, {
        provider: "postgresql",
    }),
    secret: process.env.betterAuthSecret,
    baseURL: process.env.betterAuthUrl,
});