from dotenv import load_dotenv
import os
from typing import Final

load_dotenv()

class Settings:

    telegram_api: Final[str] = os.getenv("TELEGRAM_API")

settings = Settings()