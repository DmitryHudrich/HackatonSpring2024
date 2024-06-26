from dotenv import load_dotenv
import os
from typing import Final

if os.getenv("ISCONTAINER") != "TRUE":
    load_dotenv()

class Settings:

    __telegram_api: Final[str] = os.getenv("TELEGRAM_API")
    __limit_req: int = 2
    __api_url: str = os.getenv("API_URL")

    @property
    def limit_req(self) -> int: return self.__limit_req

    @limit_req.setter
    def limit_req(self, limit: int) -> None:
        self.__limit_req = limit

    @property
    def telegram_api(self) -> str: return self.__telegram_api

    @property
    def api_url(self) -> str: return self.__api_url

settings = Settings()