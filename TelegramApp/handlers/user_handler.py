from aiogram import Router, types


user_router: Router = Router()


@user_router.message()
async def all_react_to_message(message: types.Message) -> None:
    await message.answer(text="Не могу обработать ваш запрос, ожидает команда!")