from aiogram import types, Router
from filters.profile_filtre import ProfileFilter, DeleteFilter
from aiogram.fsm.context import FSMContext
from state.profile_state import DeleteProfileState
from keyboard.reply_btn import get_del_btn
from aiogram.types import ReplyKeyboardRemove


profile_handler: Router = Router()


@profile_handler.callback_query(ProfileFilter())
async def profile_btn_reac(clb_data: types.CallbackQuery) -> None:
    """
        React to profile btn
    """

    await clb_data.message.answer(
        text=f"Вы выбрали кнопку с датой {clb_data.data}"
    )


@profile_handler.callback_query(DeleteFilter())
async def delete_profile_btn_reac(message: types.CallbackQuery, state: FSMContext) -> None:
    """
        Access to delete profile
    """

    await message.message.answer(
        text="Вы выбрали пункт - 'Удалить профиль', вы уверены: ",
        reply_markup=(await get_del_btn())
    )
    await state.set_state(DeleteProfileState.like_do_del)

@profile_handler.message(DeleteProfileState.like_do_del)
async def del_profile_choice(clb_data: types.Message, state: FSMContext):
    """
        Del profile
    """

    if clb_data.text == "Да, удалить профиль":
        await state.update_data(like_do_del=True)
        await clb_data.answer(text="Отлично! Вы удалили свой профиль.", reply_markup=ReplyKeyboardRemove())
        await state.clear()
    elif clb_data.text == "Нет, отказываюсь":
        await state.update_data(like_do_del=False)
        await clb_data.answer(text="Вы отменили процесс удаления профиля", reply_markup=ReplyKeyboardRemove())
        await state.clear()
    else:
        await clb_data.answer(text="Пожалуйста нажмите на кнопку 'Да/Нет'")
