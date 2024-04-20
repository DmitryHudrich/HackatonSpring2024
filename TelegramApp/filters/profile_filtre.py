from typing import Any
from aiogram.filters import BaseFilter
from aiogram import types


class ProfileFilter(BaseFilter):
    """
        Processing btn data
    """

    async def __call__(self, data: types.CallbackQuery) -> bool:
        """
            React to callback
        """

        if data.data.endswith("ntb"):
            return True
        return False
    


class DeleteFilter(BaseFilter):
    """
        Processing btn to del user
    """

    async def __call__(self, data: types.Message) -> bool:
        if data.data == "delete_profile":
            return True
        return False