from aiogram.dispatcher.middlewares.base import BaseMiddleware
from typing import Callable, Dict, Any, Awaitable
from aiogram import types
from models.UserModels import RegistrationUser
from api.user_api import UserService
from aiogram.exceptions import AiogramError
from exceptions.bot_exception import DetailedAiogramError
from config import configuration_app_for_auth
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

        #CODE FOR AUTH user
        user_reg_info: RegistrationUser = RegistrationUser(
            telegramId=event.from_user.id,
            firstname=event.from_user.first_name,
            lastname=event.from_user.last_name if event.from_user.last_name else "",
            bio="",
            photoBase64=id_photo_user
        )

        user_service: UserService = UserService()
        result = user_service.get_user_token(user=user_reg_info)
        
        if result:
            if configuration_app_for_auth.count_join <= 0:
                await event.answer(
                    text="Вы успешно вошли в систему..."
                )

            configuration_app_for_auth.count_join += 1
            
            return await handler(event, data)
        else:
            await event.reply(
                text="Не удается идентифицировать вас"
            )
            return DetailedAiogramError(message="Ошибка аутентификации пользователя")
        