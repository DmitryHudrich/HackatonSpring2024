from aiogram import types, Router
from filters.profile_filtre import ProfileFilter


profile_handler: Router = Router()


@profile_handler.callback_query(ProfileFilter())
async def profile_btn_reac(clb_data: types.CallbackQuery) -> None:
    """
        React to profile btn
    """

    await clb_data.message.answer(
        text=f"Вы выбрали кнопку с датой {clb_data.data}"
    )