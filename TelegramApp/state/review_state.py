from aiogram.fsm.state import State, StatesGroup


class ReviewState(StatesGroup):
    description: str = State()
    like_or_not: bool = State()