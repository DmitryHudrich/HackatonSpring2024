from aiogram.methods import SetMyCommands, SetMyDescription, SetMyShortDescription, SetChatPhoto, SetMyName
from aiogram.types import BotCommand


async def set_description_on_bot(bot):
    """
        Set description on bot
    """

    return await bot(SetMyDescription(
        description="Я бот Даттум, и я помогу тебе узнать личную информацию о себе, историю мероприятий!\nДавай же, начни со мной разговор.."
    ))


async def set_bot_name(bot):
    """
        Set short description on bot
    """

    return await bot(SetMyName(name="Датум Бот"))


async def set_commands_on_bot(bot):
    """
        Set commands on bot
    """

    return await bot(SetMyCommands(
        commands=[
            BotCommand(command="start", description="Запуск бота"),
            BotCommand(command="help", description="Поддержка бота"),
            BotCommand(command="my_profile", description="Мой профиль"),
            BotCommand(command="clear", description="Очистка состояния"),
            BotCommand(command="active_event", description="Активные мероприятия"),
            BotCommand(command="create_review", description="Создание отзыва")
        ]
    ))