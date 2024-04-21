from aiogram import Router, types
from aiogram.filters.command import Command
from aiogram.types import FSInputFile, ReplyKeyboardRemove
from aiogram.fsm.context import FSMContext 

from text.text_for_commands import get_text_for_start, get_text_for_help, get_text_for_my_profile
from keyboard.inline_btn import generate_button_for_profile
from state.review_state import ReviewState
from random import choice as choice_gif
import logging

system_router: Router = Router()


@system_router.message(Command("start"))
async def start_command(msg: types.Message) -> None:
    """
        React to start command
    """

    logging.info(msg="Обработка команды - start")
    for_message_start: str = "\n".join(await get_text_for_start(msg.from_user.first_name))
    await msg.answer_animation(
        animation=FSInputFile("TelegramApp/static/start.gif"),
        caption=for_message_start,
        parse_mode="HTML"
    )


@system_router.message(Command("help"))
async def help_command(msg: types.Message) -> None:
    """
        React to help command
    """

    logging.info(msg="Обработка команды - help")
    for_message_help: str = "\n".join(await get_text_for_help(msg.from_user.first_name))
    
    all_gif_for_help: tuple = (
        "TelegramApp/static/sakura.gif", "TelegramApp/static/city.gif",
        "TelegramApp/static/rain.gif", "TelegramApp/static/snow.gif",
        "TelegramApp/static/minimoss.gif", "TelegramApp/static/train.gif"
    )

    await msg.answer_animation(
        animation=FSInputFile(choice_gif(all_gif_for_help)),
        caption=for_message_help,
        parse_mode="HTML"
    )


@system_router.message(Command("my_profile"))
async def my_profile_command(msg: types.Message) -> None:
    """
        React to my_profile command
    """

    logging.info(msg="Обработка команды - my_profile")
    for_message_profile: str = "\n".join(await get_text_for_my_profile(msg.from_user.first_name))
    await msg.answer(
        text=for_message_profile,
        reply_markup=await generate_button_for_profile(),
        parse_mode="HTML"
    )


@system_router.message(Command("clear"))
async def clear_state_command(msg: types.Message, state: FSMContext):
    """
        Clear all states
    """

    logging.info(msg="Обработка команды - clear")
    await state.clear()
    await msg.reply(
        text=f"Все состояния были успешно сброшены 🔥",
        reply_markup=ReplyKeyboardRemove()
    )


@system_router.message(Command("active_event"))
async def activate_event_command(msg: types.Message):
    """
        Select all activate events for user
    """

    logging.info(msg="Обработка команды - active_event")
    events = ... #Заглушка

    await msg.answer(
        text=f"🔥 Список <b>активных</b> мероприятий: ",
        parse_mode="HTML"
    )


@system_router.message(Command("create_review"))
async def create_review(msg: types.Message, state: FSMContext) -> None:
    """
        Form to create review
    """

    logging.info(msg="Обработка команды - create_review")
    await msg.answer(text=f"💥 Вы выбрали пункт <b>'Создать отзыв'</b>\n\nПожалуйста введите краткое описание отзыва: ", parse_mode="HTML")
    await state.set_state(ReviewState.title_review)