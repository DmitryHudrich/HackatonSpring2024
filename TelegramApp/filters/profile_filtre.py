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