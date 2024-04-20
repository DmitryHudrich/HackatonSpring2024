from aiogram.methods import SetMyCommands, SetMyDescription, SetMyShortDescription
from aiogram.types import BotCommand


async def set_description_on_bot(bot) -> bool:
    """
        Set description on bot
    """

    return await bot(SetMyDescription(
        description="Я бот Даттум, и я помогу тебе узнать личную информацию о себе, историю мероприятий!\nДавай же, начни со мной разговор.."
    ))


async def set_short_description_on_bot(bot) -> bool:
    """
        Set short description on bot
    """

    return await bot(SetMyShortDescription(
        short_description="Что умеет этот бот?"
    ))


async def set_commands_on_bot(bot):
    """
        Set commands on bot
    """

    return await bot(SetMyCommands(
        commands=[
            BotCommand("start", "Запуск бота"),
            BotCommand("help", "Поддержка бота")
        ]
    ))