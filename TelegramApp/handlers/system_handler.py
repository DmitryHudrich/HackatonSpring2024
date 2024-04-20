from aiogram import Router, types
from aiogram.filters.command import Command
from aiogram.types import FSInputFile
from aiogram.fsm.context import FSMContext 

from text.text_for_commands import get_text_for_start, get_text_for_help, get_text_for_my_profile
from keyboard.inline_btn import generate_button_for_profile


system_router: Router = Router()


@system_router.message(Command("start"))
async def start_command(msg: types.Message) -> None:
    """
        React to start command
    """

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

    for_message_help: str = "\n".join(await get_text_for_help(msg.from_user.first_name))
    await msg.answer_animation(
        animation=FSInputFile("TelegramApp/static/sakura.gif"),
        caption=for_message_help,
        parse_mode="HTML"
    )


@system_router.message(Command("my_profile"))
async def my_profile_command(msg: types.Message) -> None:
    """
        React to my_profile command
    """

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

    await state.clear()
    await msg.reply(
        text=f"Все состояния были успешно сброшены 🔥"
    )


@system_router.message(Command("active_event"))
async def activate_event_command(msg: types.Message):
    """
        Select all activate events for user
    """

    events = ... #Заглушка

    await msg.answer(
        text=f"🔥 Список <b>активных</b> мероприятий: ",
        parse_mode="HTML"
    )