from aiogram.fsm.state import State, StatesGroup


class ReviewState(StatesGroup):
    title_review: str = State()
    description: str = State()
    like_or_not: bool = State()