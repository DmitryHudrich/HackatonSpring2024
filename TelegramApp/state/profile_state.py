from aiogram.fsm.state import State, StatesGroup


class DeleteProfileState(StatesGroup):
    
    like_do_del: bool = State()