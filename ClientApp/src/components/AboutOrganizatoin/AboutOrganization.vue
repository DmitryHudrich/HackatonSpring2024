<script setup>
import { Card, CardHeader, CardContent, CardFooter } from '@/components/ui/card'
</script>

<template>
    <Card>
        <CardHeader>
            <div class="header">
                <div class="header__about">
                    <P class="title">Название организации</P>
                    <img src="@/assets/image/18+.png">
                </div>
                <button>Добавить</button>      
            </div>
             <div class="time__org">
                <p class="time">Время работы</p>
             </div>
             <CardContent>
                <p class="description">Описание организации</p>
             </CardContent>   
             <CardFooter>
                <div class="footer__badge">
                    <p class="badge__text">Тишина</p>
                </div>
             </CardFooter>       
        </CardHeader>
    </Card>
</template>

<style scoped>
.header {
    display: flex;
    flex-direction: row;
    justify-content: space-between;
}

.header__about {
    display: flex;
    flex-direction: row;
    align-items: center;
    gap: 18px;
}

.time__org {
    margin-top: 10px;
}

.time {
   font-weight: 400; 
}

button {
    border: none;
    color: white;
    background-image: var(--main-gradient);
    padding: 9px 11px;
    font-weight: 700;
    border-radius: 10px;
}

.description {
    margin-top: 20px;
    max-width: 617px;
    font-size: 18px;
    font-weight: 500;
}

/* CardFooter {
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
    gap: 20px;
    margin-top: 20px;
} */

.footer__badge {
    background-image: var(--active-gradient);
    border-radius: 10px;
    padding: 4px 9px;
}

.badge__text {
    color: white;
    font-weight: 500;
    font-size: 14px;
}
</style>