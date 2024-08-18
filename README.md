# Стоматологическая Клиника - ASP.NET Blazor Server

## Описание

Этот проект представляет собой веб-приложение для управления стоматологической клиникой, разработанное с использованием ASP.NET Core и Blazor Server. Приложение предоставляет функциональность для управления пациентами, записями на прием, медицинскими записями и отчетами.

## Технологии

**Backend & Frontend**: Blazor Server (ASP.NET Core)

 **Database**: Microsoft SQL Server (MS SQL)
 
 **UI/UX**: Bootstrap для стилизации интерфейса
 
## Использование
Авторизация 

Войдите в систему с учетными данными администратора или пользователя, чтобы начать использовать приложение.

Вход от имени администратора: логин - admin@ya.ru, пароль - 1Qwerty!

Вход от имени контент-менеджера: логин - content@ya.ru, пароль - 1Qwerty!

## Установка и настройка
1.Клонируйте репозиторий на свой компьютер: 

git clone (https://github.com/Anastasia-creat/FinalWorkDentistry.git) 

cd repository

2.Настройка строки подключения к базе данных

Откройте проект в Visual Studio.

Перейдите к файлу appsettings.json.

Найдите секцию 

ConnectionStrings и отредактируйте строку подключения к базе данных: 

"ConnectionStrings": { "DefaultConnection": "Server=YourServerName;Database=FinalDentistry;Trusted_Connection=True;" }

3.Применение миграций к базе данных

Update-Database

4.Запуск приложения









