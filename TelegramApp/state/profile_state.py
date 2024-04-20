from aiogram.fsm.state import State, StatesGroup


class DeleteProfileState(StatesGroup):
    
    like_do_del: bool = State()


class ChangeDataUserState(StatesGroup):
    name_user: str = State()
    age: str = State()
    password: str = State()