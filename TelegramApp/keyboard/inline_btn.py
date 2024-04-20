from aiogram.utils.keyboard import InlineKeyboardBuilder, InlineKeyboardButton
from emoji import emojize


async def generate_button_for_review() -> InlineKeyboardBuilder.as_markup:
    """
        Button for review
    """

    bt_review_like: InlineKeyboardBuilder = InlineKeyboardBuilder()

    bt_review_like.add(InlineKeyboardButton(text=f"{emojize(':heavy_check_mark:', language='en')} Да", callback_data="yep_btn"))
    bt_review_like.add(InlineKeyboardButton(text=f"{emojize(':x:', language='en')} Нет", callback_data="nope_btn"))

    return bt_review_like.as_markup()


async def generate_button_for_profile() -> InlineKeyboardBuilder.as_markup:
    """
        Button for profile
    """

    bt_profile: InlineKeyboardBuilder = InlineKeyboardBuilder()

    bt_profile.row(
        InlineKeyboardButton(text=f"📊 Моя история", callback_data="my_history_ntb"),
        InlineKeyboardButton(text=f"👥 Мои друзья", callback_data="my_friend_ntb"),
    )
    bt_profile.row(
        InlineKeyboardButton(text=f"🛠️ Изменить данные", callback_data="change_data_ntb"),
        InlineKeyboardButton(text=f"📢 Оставить отзыв", callback_data="review_ntb")
    )

    return bt_profile.as_markup()