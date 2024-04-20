from aiogram.dispatcher.middlewares.base import BaseMiddleware
from typing import Callable, Dict, Any, Awaitable
from aiogram import types
from api.user_api import user_service

import logging


class AuthenticationUser(BaseMiddleware):
    """
        Class for authentication user in telegram system
    """

    async def __call__(
        self,
        handler: Callable[[types.TelegramObject, Dict[str, Any]], Awaitable[Any]],
        event: types.Message,
        data: Dict[str, Any]
    ) -> None:
        
        await self.auth_user(event=event, handler=handler, data=data)

    #Calling async method for auth user
    async def auth_user(self, event: types.Message, handler, data: Dict[str, Any]):

        #Get user photo, id photo
        id_photo_user = dict(dict(await event.from_user.get_profile_photos()).get("photos")[0][0]).get("file_id")
        
        #class for check user
        user_service = user_service


        #CODE FOR AUTH user