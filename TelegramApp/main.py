from aiogram import Bot, Dispatcher
from aiogram.types import InputFile
from aiogram.fsm.storage.memory import MemoryStorage
from settings import settings
from handlers.user_handler import user_router
from handlers.system_handler import system_router
from handlers.profile_handler import profile_handler
from utils.settings_bot import set_description_on_bot, set_short_description_on_bot, set_commands_on_bot
from middleware.system_anti_spam import Throtling

import asyncio
import logging


bot: Bot = Bot(settings.telegram_api)
storage: MemoryStorage = MemoryStorage()
dp: Dispatcher = Dispatcher(bot=bot, storage=storage)


async def start_application():
    """

        Start Telegram bot
    """


    #Include routers
    dp.include_router(system_router)
    dp.include_router(profile_handler)
    dp.include_router(user_router)

    await set_commands_on_bot(bot=bot)
    await set_description_on_bot(bot=bot)
    await set_short_description_on_bot(bot=bot)
    #await set_photo_on_bot(bot=bot)

    #Delete last messages
    await bot.delete_webhook(drop_pending_updates=True)

    #Include middleware
    dp.message.middleware.register(Throtling())

    try:
        await dp.start_polling(bot)
    except KeyboardInterrupt as kb:
        await bot.close()
        logging.critical(msg="Бот окончил своб работу")


if __name__ == "__main__":
    #Start application..
    try:
        logging.basicConfig(level=logging.INFO)
        asyncio.run(start_application())
    except Exception as ex:
        logging.critical(msg="Бот окончил свою работу")
    except KeyboardInterrupt as kb:
        logging.critical(msg="Бот завершил свою работу")