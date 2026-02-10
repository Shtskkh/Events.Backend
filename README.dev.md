# Запуск

Команда для запуска после обновления (в папке с проектом):

```shell
docker compose -f .\docker-compose.dev.yaml up --build
```

Команда запуска (в папке с проектом):

```shell
docker compose -f .\docker-compose.dev.yaml up
```

Основные ссылки:

+ <http://localhost:8080/scalar> - документация API.
+ <http://localhost:8080/api/v/1/{endpoint}> - URL для запросов на {endpoint}.
+ <http://localhost:9001> - ссылка на UI RustFS (**логин и пароль**: rustfsadmin)
+ localhost:5433 - база данных PostgreSQL (**логин**: postgres, **пароль**: 1)
