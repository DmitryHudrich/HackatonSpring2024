import logging

from aiogram.types import Update
from aiogram.exceptions import (AiogramError, )

from main import dp


@dp.errors()
async def errors_handler(update: Update, exception):
    
    if isinstance(exception, AiogramError):
        logging.critical(msg="Ошибка обработки бота")
        await update.message.answer(text="Ошибка обработки..")
        return True