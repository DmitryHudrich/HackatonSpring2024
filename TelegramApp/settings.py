from dotenv import load_dotenv
import os
from typing import Final

if os.getenv("ISCONTAINER") != "TRUE":
    load_dotenv()

class Settings:

    telegram_api: Final[str] = os.getenv("TELEGRAM_API")

settings = Settings()