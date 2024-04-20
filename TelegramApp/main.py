from aiogram import Bot, Dispatcher
from aiogram.fsm.storage.memory import MemoryStorage
from settings import settings

import asyncio
import logging


async def start_application():
    """
        Start Telegram bot
    """


    bot: Bot = Bot(settings.telegram_api)
    storage: MemoryStorage = MemoryStorage()
    dp: Dispatcher = Dispatcher(bot=bot, storage=storage)

    await dp.start_polling(bot)


if __name__ == "__main__":
    try:
        logging.basicConfig(level=logging.INFO)
        asyncio.run(start_application())
    except Exception as ex:
        logging.critical(msg="Бот окончил свою работу")