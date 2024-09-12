﻿# Тестовое задание C# Backend


Необходимо разработать вариант сервиса для работы с пользователями и их IP адресов. 
Сервис накапливает данные от источника событий о подключении пользователя со случайного IP адреса и сохраняет их в БД (предпочтительно PostgreSQL). IP адреса в событии для каждого счета могут повторяться или могут быть новыми. Один пользователь может подключаться с разных IP адресов, несколько пользователей могут подключаться с одного IP адреса. 
Формат данных в событии (пользователь long, строка IP адреса)
100001, “127.0.0.1”

** Сервис должен позволять: **

- найти пользователей по начальной или полной части IP адреса (например, если в качестве строки поиска указать “31.214”, а у пользователя 1234567 зафиксированы ранее следующие IP ["31.214.157.141", "62.4.36.194"], то метод сервиса вернет список, в котором помимо прочих подходящих пользователей будет и 1234567) 
- найти все накопленные IP адреса пользователя 
- найти время и IP адреса последнего подключения пользователя

** Критерии оценки: **
- Полнота выполнения условий задачи 
- Продуманность решения с точки зрения оптимальности работы сервиса (то как он собирает данные и обновляет их в БД, то как реализован поиск по IP адресам)
- Качество кода, правильность архитектурных решений 
- Покрытие ключевых моментов тестами

# Реализация
Для реализации этого тестового задания на C#, можно использовать ASP.NET Core для создания веб-сервиса и PostgreSQL как базу данных для хранения пользователей и их IP-адресов.

** Основные шаги: **
1. Создание модели данных: Мы будем использовать две сущности: User и UserIP. Сущность User представляет пользователя, а UserIP хранит IP-адреса и время подключения пользователя.
2. Создание базы данных: Используем PostgreSQL, где в таблице Users будем хранить информацию о пользователях, а в таблице UserIPs – IP-адреса, с которых пользователь подключался, и время подключения.
3. Методы сервиса:
    - Поиск пользователей по IP-адресу: Метод, который возвращает пользователей, чьи IP-адреса содержат указанную строку.
    - Получение всех IP-адресов пользователя: Метод возвращает список всех IP-адресов, с которых подключался пользователь.
    - Получение последнего IP-адреса и времени подключения пользователя: Метод возвращает последний IP-адрес и время последнего подключения пользователя.