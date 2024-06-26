import logging
import requests

from settings import settings
from typing import Dict
from models.UserModels import RegistrationUser
from config import configuration_app_for_auth


class UserService:
    
    def __init__(self) -> None:
        self.__api_url: str = settings.api_url
        self.session_req: requests.Session = requests.Session()

    def get_user_token(self, user: RegistrationUser) -> bool:
        """
            Returns user token
        """

        try:
            request = self.session_req.post(
                url=self.__api_url + "auth/registration/telegram",
                json=user.model_dump()
            )

            if request.status_code in (200, 201):
                configuration_app_for_auth.refresh_token = request.cookies.get_dict()["X-Refresh"]
                configuration_app_for_auth.token = request.text
                return True
            raise requests.ConnectionError("Не удалось зарегистрировать/авторизировать пользователя")
        except Exception as ex:
            logging.critical(msg=ex)
            return False