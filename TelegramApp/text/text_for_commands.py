from typing import List
from emoji import emojize

async def get_text_for_start(user_name: str) -> List[str]:
    """
        Returned list with text for start command
    """

    lst_text_for_str_cmd: List = [
        f"Привет <b>{user_name}</b>, я бот <i>Даттум</i>, и я помогу тебе украсить твои будни! {emojize(':dizzy:', language='en')}\n",
        f"В этом <b>боте</b> ты сможешь просматривать <b><i>личную информацию</i></b> {emojize(':man:', language='en')}, <b><i>статистику своих посещений</i></b> {emojize(':bar_chart:', language='en')}, а также сможешь <b><i>оставлять отзывы</i></b>!"
    ]

    return lst_text_for_str_cmd


async def get_text_for_help(user_name: str) -> List[str]:
    """
        Returned list with text for help command
    """

    lst_text_for_hlp_cmd: List = [
        f"Добро пожаловать в пункт поддержки бота {user_name} {emojize(':raised_hand:', language='en')}\n",
        "Мой перечень команд: ",
        f"{emojize(':first_quarter_moon:', language='en')}\t/start - Запуск бота",
        f"{emojize(':waxing_crescent_moon:', language='en')}\t/help - Пункт поддержки",
        f"{emojize(':waxing_crescent_moon:', language='en')}\t/clear - Очистка состояния"
    ]

    return lst_text_for_hlp_cmd


async def get_text_for_my_profile(user_name: str) -> List[str]:
    """
        Returned list with text for my_profile command
    """

    lst_text_for_profile: List = [
        f"{user_name}, <i><b>добро пожаловать</b></i> в личный профиль.\n",
        "Здесь ты можешь просматривать личную информацию о себе, историю своих посещений, своих друзей."
    ]

    return lst_text_for_profile