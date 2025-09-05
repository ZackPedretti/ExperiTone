import {PrismaClient} from "@prisma/client";
const prisma = new PrismaClient();

export default defineEventHandler(async (event) => {
    const userId = getQuery(event).userId as string;
    return prisma.user.findUnique({
        where :{
            id: userId,
        },
        select: {
            name: true,
            image: true,
        }
    });
});
