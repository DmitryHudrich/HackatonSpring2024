<script setup>
import { Card, CardHeader, CardContent, CardFooter } from '@/components/ui/card'
import { Switch } from '@/components/ui/switch'
</script>

<template>
    <Card>
        <CardHeader>
            <h1>Фильтр</h1>
        </CardHeader>
        <CardContent>
            <div class="sex">
                <h1>Ограничение по возрасту</h1>
                <Switch />
            </div>
            <div class="list__badges">
                <div class="block">
                    <p>Тишина</p>
                </div>
                <div class="block">
                    <p>Вкусная еда</p>
                </div>
                <div class="block">
                    <p>Атмосфера</p>
                </div>
                <div class="block">
                    <p>Дешево</p>
                </div>
                <div class="block">
                    <p>Приятная музыка</p>
                </div>
                <div class="block">
                    <p>Просторный зал</p>
                </div>
                <div class="block">
                    <p>круглосуточно</p>
                </div>
            </div>
        </CardContent>
        <button>Применить</button>
    </Card>
</template>

<style scoped>
h1 {
    font-weight: 700;
    font-size: 20px;
}

.sex {
    display: flex;
    flex-direction: row;
    align-items: center;
    gap: 17px;
}

.list__badges {
    display: flex;
    flex-wrap: wrap;
    align-items: left;
    justify-content: center;
    gap: 80px;
}

.block {
    background-image: var(--active-gradient);
    border-radius: 20px;
    padding: 4px 9px;
}

p {
    font-weight: 500;
    font-size: 14px;
    color: white;
}

button {
    border-radius: 10px;
    background-image: var(--main-gradient);
    padding: 9px 11px;
    color: white;
    position: ;
}
</style>