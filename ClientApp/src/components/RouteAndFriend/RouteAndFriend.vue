<script setup>
import { Card, CardHeader, CardContent, CardFooter } from '@/components/ui/card'
import { Input } from '@/components/ui/input'
</script>

<template>
  <Card class="wrapper">
    <Card>
      <CardHeader>
        <div class="header">
          <h1>Маршрут</h1>
          <route-link to="/route">
            <button>Выбрать существующий</button>
          </route-link>
        </div>
      </CardHeader>
      <CardContent>
        <div class="content__header">
          <Input type="text" placeholder="Название маршрута" />
          <label for="date">Дата мероприятия</label
          ><Input name="date" type="date" placeholder="00.00.00" />
        </div>
        <div class="content__list">
          <div class="content__item">
            <ol>
              <li>Название организации</li>
            </ol>
          </div>
          <div class="content__time">
            <Input type="time" placeholder="00:00" />
          </div>
        </div>
      </CardContent>
    </Card>
    <Card>
      <CardHeader>
        <h1>Друзья</h1>
      </CardHeader>
      <CardContent>
        <div class="friend_list">
          <div class="friend_item">
            <img src="" alt="" />
            <h2>Имя пользователя</h2>
          </div>
          <img src="@/assets/image/main/add.png" alt="" class="add">
        </div>
      </CardContent>
    </Card>
    <CardFooter class="footer">
      <button>Построить</button>
      <button>Сохранить</button>
    </CardFooter>
  </Card>
</template>
<style scoped>
h1 {
  font-size: 20px;
  font-weight: 700;
}

.wrapper {
  padding: 10px;
}
.header {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
}

li {
  font-size: 20px;
  font-weight: 400;
}

.content__list {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}

.friend_list {
  display: flex;
  flex-direction: column;
  align-items: top;
  justify-content: center;
}

.friend_item {
  display: flex;
  flex-direction: row;
  align-items: center;
  gap: 10px;
}

img {
  border-radius: 50%;
  width: 50px;
  height: 50px;
}

h2 {
  font-size: 20px;
  font-weight: 400;
}
button {
  border-radius: 10px;
  background-image: var(--main-gradient);
  padding: 9px 11px;
  color: white;
  position: relative;
  right: 0;
}
.footer {
  display: flex;
  gap: 10px;
  margin-top: 10px;
}
</style>
