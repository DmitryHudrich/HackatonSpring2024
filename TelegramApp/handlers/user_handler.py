from aiogram import Router, types
import logging


user_router: Router = Router()


@user_router.message()
async def all_react_to_message(message: types.Message) -> None:
    """
        React other message
    """
    logging.info(msg="Пользователь отправил текстовое сообщение")
    await message.answer(text="Не могу обработать ваш запрос, ожидает команда!")