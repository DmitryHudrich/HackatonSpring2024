
class ConfigApp:
    __token: set
    __refresh_token: str

    count_join: int = 0

    @property
    def token(self) -> str: return self.__token

    @token.setter
    def token(self, new_token: str) -> None:
        self.__token = new_token
    
    @property
    def refresh_token(self) -> str: return self.__refresh_token

    @refresh_token.setter
    def refresh_token(self, new_refresh_token: str) -> None:
        self.__refresh_token = new_refresh_token


configuration_app_for_auth = ConfigApp()