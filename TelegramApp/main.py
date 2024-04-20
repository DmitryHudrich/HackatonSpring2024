from aiogram import Bot, Dispatcher
from aiogram.fsm.storage.memory import MemoryStorage
from settings import settings
from handlers.user_handler import user_router
from handlers.system_handler import system_router
from utils.settings_bot import set_description_on_bot, set_short_description_on_bot, set_commands_on_bot

import asyncio
import logging


async def start_application():
    """
        Start Telegram bot
    """


    bot: Bot = Bot(settings.telegram_api, parse_mode="HTML")
    storage: MemoryStorage = MemoryStorage()
    dp: Dispatcher = Dispatcher(bot=bot, storage=storage)

    #Include routers
    dp.include_router(system_router)
    dp.include_router(user_router)

    await set_short_description_on_bot(bot=bot)
    await set_description_on_bot(bot=bot)
    await set_commands_on_bot(bot=bot)

    try:
        await dp.start_polling(bot)
    except KeyboardInterrupt as kb:
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