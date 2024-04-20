from aiogram.dispatcher.middlewares.base import BaseMiddleware
from aiogram import types
from typing import Callable, Dict, Any, Awaitable
from settings import settings
import cachetools


class Throtling(BaseMiddleware):
    """
        System for anti-spam
    """

    def __init__(self, limit_req: int = settings.limit_req) -> None:
        self.limit_req = cachetools.TTLCache(maxsize=8_000, ttl=limit_req)

        

    async def __call__(
            self,
            handler: Callable[[types.TelegramObject, Dict[str, Any]], Awaitable[Any]], #Принимаем handler
            event: types.Message, #Ивент обработка
            data: Dict[str, Any] #Дату получаем
    ) -> None:
        """
            Check message from user
        """

        if event.chat.id in self.limit_req:
            await event.answer(
                text="Сработала система анти-спама, пожалуйста подождите.."
            )
        else:
            self.limit_req[event.chat.id] = None
        return await handler(event, data)

        