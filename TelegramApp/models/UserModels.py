from pydantic import BaseModel, Field
from typing import Annotated


class RegistrationUser(BaseModel):
    """
        Registration user in system
    """

    telegramId: Annotated[int, Field()]
    firstname: Annotated[str, Field()]
    lastname: Annotated[str, Field()]
    bio: Annotated[str, Field()]


class GetInfoByToken(BaseModel):
    """
        Get info from endpoint api, use token
    """

    token: Annotated[str, Field()]