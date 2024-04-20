from aiogram import Router, types
from aiogram.filters.command import Command
from aiogram.types import FSInputFile

from text.text_for_commands import get_text_for_start, get_text_for_help


system_router: Router = Router()


@system_router.message(Command("start"))
async def start_command(msg: types.Message) -> None:
    """
        React to start command
    """

    for_message_start: str = "\n".join(await get_text_for_start(msg.from_user.first_name))
    await msg.answer_animation(
        animation=FSInputFile("TelegramApp/static/start.gif"),
        caption=for_message_start
    )


@system_router.message(Command("help"))
async def help_command(msg: types.Message) -> None:
    """
        React to help command
    """

    for_message_help: str = "\n".join(await get_text_for_help(msg.from_user.first_name))
    await msg.answer_animation(
        animation=FSInputFile("TelegramApp/static/sakura.gif"),
        caption=for_message_help
    )