from aiogram.utils.keyboard import ReplyKeyboardMarkup, KeyboardButton


async def get_del_btn() -> ReplyKeyboardMarkup:

    btn_del: ReplyKeyboardMarkup = ReplyKeyboardMarkup(
        keyboard=[
            [
                KeyboardButton(text="Да, удалить профиль"),
                KeyboardButton(text="Нет, отказываюсь")
            ]
        ],
        resize_keyboard=True,
        one_time_keyboard=True
    )

    return btn_del