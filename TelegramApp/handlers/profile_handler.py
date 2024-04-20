from aiogram import types, Router
from filters.profile_filtre import ProfileFilter, DeleteFilter
from aiogram.fsm.context import FSMContext
from state.profile_state import DeleteProfileState
from state.review_state import ReviewState
from keyboard.reply_btn import get_del_btn
from keyboard.inline_btn import generate_button_for_review
from aiogram.types import ReplyKeyboardRemove, FSInputFile

import logging


profile_handler: Router = Router()


@profile_handler.callback_query(ProfileFilter())
async def profile_btn_reac(clb_data: types.CallbackQuery) -> None:
    """
        React to profile btn
    """

    logging.info(msg="Пользователь выбрал опцию личного меню")
    await clb_data.message.answer(
        text=f"Вы выбрали кнопку с датой {clb_data.data}"
    )


@profile_handler.callback_query(DeleteFilter())
async def delete_profile_btn_reac(message: types.CallbackQuery, state: FSMContext) -> None:
    """
        Access to delete profile
    """

    logging.info(msg="Пользователь выбрал опцию - Удалить профиль")
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
        logging.info(msg="Пользователь удалил свой профиль")
        await state.update_data(like_do_del=True)
        await clb_data.answer(text="Отлично! Вы удалили свой профиль.", reply_markup=ReplyKeyboardRemove())
        await state.clear()
    elif clb_data.text == "Нет, отказываюсь":
        logging.info(msg="Пользователь отменил удаление своего профиля")
        await state.update_data(like_do_del=False)
        await clb_data.answer(text="Вы отменили процесс удаления профиля", reply_markup=ReplyKeyboardRemove())
        await state.clear()
    else:
        await clb_data.answer(text="Пожалуйста нажмите на кнопку 'Да/Нет'")


@profile_handler.message(ReviewState.title_review)
async def get_name_organization_from_user(msg: types.Message, state: FSMContext) -> None:
    """
        Get name organization
    """

    logging.info(msg="Пользователь заполняет форму отзывов - заголовок отзыва")
    if msg.content_type == "text":
        await state.update_data(name_organization = msg.text)
        await msg.answer(
            text=f"💥 Отлично <b>{msg.from_user.first_name}</b>, пожалуйста опишите ваш отзыв",
            parse_mode="HTML"
        )
        await state.set_state(ReviewState.description)
    else:
        await msg.answer(text="Ожидается текст!")


@profile_handler.message(ReviewState.description)
async def get_description_from_user(msg: types.Message, state: FSMContext) -> None:
    """
        Get description for organization from user
    """

    logging.info(msg="Пользователь заполняет форму отзывов - описание отзыва")

    if msg.content_type == "text":
        await state.update_data(description=msg.text)
        await msg.answer(
            text=f"💥 <b>Замечательно!</b> Пожалуйста выберите <i>утвердительную оценку</i>, вам понравилась данная организация?",
            parse_mode="HTML",
            reply_markup=await generate_button_for_review()
        )
        await state.set_state(ReviewState.like_or_not)
    else:
        await msg.answer("Ожидается текст!")


@profile_handler.callback_query(lambda message: message.data.endswith("btn"))
async def get_choices_review_score_from_user(msg: types.CallbackQuery, state: FSMContext) -> None:
    """
        Get score review from user
    """
    
    logging.info(msg="Пользователь заполняет форму отзывов - оценка организации")
    result_score: bool = False
    if msg.data == "yep_btn":
        result_score = True

    await state.update_data(like_or_note=result_score)

    await msg.message.reply_animation(
        animation=FSInputFile("TelegramApp/static/review.gif"),
        caption=f"Превосходно <b>{msg.from_user.first_name}</b>, ваш отзыв был успешно сохранён!",
        parse_mode="HTML"
    )
    await state.clear()