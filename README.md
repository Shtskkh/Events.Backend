# Events.Backend

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=.net&logoColor=white&style=flat-square)](https://dotnet.microsoft.com/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-18-4169E1?logo=postgresql&logoColor=white&style=flat-square)](https://www.postgresql.org/)
[![ClickHouse](https://img.shields.io/badge/ClickHouse-Latest-FFCC00?logo=clickhouse&logoColor=black&style=flat-square)](https://clickhouse.com/)
[![Docker](https://img.shields.io/badge/Docker-Compose-2496ED?logo=docker&logoColor=white&style=flat-square)](https://www.docker.com/)
[![OpenTelemetry](https://img.shields.io/badge/OpenTelemetry-Collector-F05032?logo=opentelemetry&logoColor=white&style=flat-square)](https://opentelemetry.io/)

Бэкенд-сервис для управления мероприятиями, бронирования помещений, аренды оборудования и сбора аналитики. Разработан на платформе **.NET 10.0** с применением архитектурных паттернов **DDD (Domain-Driven Design)**, **CQRS (Command Query Responsibility Segregation)** и **Clean Architecture**.

---

## Архитектура Системы

Проект спроектирован по принципам **Clean Architecture**:

*   `src/Domain/Events.Domain` — Чистый домен. Содержит агрегаты (`Event`, `User`, `Location`, `Equipment`), спецификации, Value Objects, доменные ошибки и исключения. Не имеет внешних зависимостей.
*   `src/Application/Events.Application.Services` — Прикладной слой. CQRS команды и запросы, маппинги AutoMapper, валидаторы FluentValidation и MediatR Pipeline Behaviors (включая `AnalyticsBehavior` для трекинга просмотров страниц).
*   `src/Contracts/Events.Contracts` — Контракты данных (DTO) и интерфейсы взаимодействия.
*   `src/Infrastructure/Events.Infrastructure.DataAccess` — Слой доступа к PostgreSQL (EF Core, репозитории, конфигурации сущностей).
*   `src/Infrastructure/Events.Infrastructure.Analytics` — Слой доступа к ClickHouse для сохранения и чтения аналитики.
*   `src/Hosts/Events.Hosts.API` — Точка входа. ASP.NET Core Web API, контроллеры, JWT-авторизация и конфигурация Scalar.
*   `src/Hosts/*Migrator` — Специализированные воркеры для автоматической миграции баз данных (PostgreSQL, ClickHouse) и подготовки S3-бакетов при запуске окружения.

---

## Технологический Стек

*   **Платформа:** .NET 10 SDK
*   **Базы данных:** PostgreSQL 18 (операционные данные) + ClickHouse (аналитика)
*   **S3 Хранилище:** RustFS (S3-совместимое объектное хранилище)
*   **Телеметрия:** OpenTelemetry Collector
*   **API Документация:** Scalar API Reference + OpenAPI
*   **Инструменты контейнеризации:** Docker & Docker Compose
*   **Тестирование:** xUnit, FluentAssertions

---

## Спецификация API Эндпоинтов

Базовый путь для всех запросов: `/api/v/1`

### 1. Мероприятия (Events) — `api/v/1/events`

| Метод | Путь | Описание действия |
| :--- | :--- | :--- |
| **POST** | `/` | Создать мероприятие |
| **GET** | `/` | Получить список мероприятий по фильтру |
| **GET** | `/analytics` | Получить общую аналитику просмотров мероприятий |
| **GET** | `/{eventId:guid}` | Получить детальную информацию о мероприятии по ID |
| **GET** | `/{eventId:guid}/analytics` | Получить аналитику просмотров конкретного мероприятия |
| **PATCH** | `/{eventId:guid}` | Частично обновить данные мероприятия | Принимает `UpdateEventDto` |
| **DELETE** | `/{eventId:guid}` | Удалить мероприятие |
| **POST** | `/{eventId:guid}/tags/{tagId:int}` | Добавить тег к мероприятию |
| **DELETE** | `/{eventId:guid}/tags/{tagId:int}` | Удалить тег из мероприятия |
| **GET** | `/tags/analytics` | Получить аналитику популярности тегов |
| **POST** | `/{eventId:guid}/participants` | Зарегистрировать участника на мероприятие |
| **GET** | `/{eventId:guid}/participants` | Получить список зарегистрированных участников |
| **DELETE** | `/{eventId:guid}/participants` | Отменить регистрацию участника |
| **GET** | `/types` | Получить список доступных типов мероприятий |
| **GET** | `/types/analytics` | Получить аналитику по типам мероприятий |
| **GET** | `/formats` | Получить список доступных форматов мероприятий |
| **GET** | `/formats/analytics` | Получить аналитику по форматам мероприятий |
| **GET** | `/placeholders` | Получить список ключей плейсхолдеров превью |
| **GET** | `/locations/analytics` | Получить аналитику популярности локаций мероприятий |
| **GET** | `/places/analytics` | Получить аналитику популярности помещений |

---

### 2. Локации и Помещения (Locations & Places) — `api/v/1/locations`

| Метод | Путь | Описание действия |
| :--- | :--- | :--- |
| **POST** | `/` | Создать новую локацию |
| **GET** | `/` | Получить отфильтрованный список локаций |
| **GET** | `/{locationId:int}` | Получить локацию по ID |
| **PATCH** | `/{locationId:int}` | Обновить информацию о локации |
| **DELETE** | `/{locationId:int}` | Удалить локацию |
| **POST** | `/{locationId:int}/places` | Добавить помещение (площадку) в локацию |
| **GET** | `/{locationId:int}/places` | Получить список помещений для локации |
| **GET** | `/{locationId:int}/places/availability` | Проверить доступность помещений на период | Требует диапазон дат |
| **GET** | `/{locationId:int}/places/{placeId:int}`| Получить информацию о помещении по ID |
| **PATCH** | `/{locationId:int}/places/{placeId:int}`| Обновить параметры помещения | Принимает `UpdatePlaceDto` |
| **DELETE** | `/{locationId:int}/places/{placeId:int}`| Удалить помещение из локации |
| **GET** | `/places/types` | Получить доступные типы помещений |

---

### 3. Оборудование (Equipment) — `api/v/1/equipment`

| Метод | Путь | Описание действия |
| :--- | :--- | :--- |
| **POST** | `/` | Добавить единицу оборудования |
| **GET** | `/` | Получить список оборудования по фильтру |
| **GET** | `/{equipmentId:int}` | Получить информацию об оборудовании по ID |
| **PATCH** | `/{equipmentId:int}` | Обновить параметры оборудования |
| **DELETE** | `/{equipmentId:int}` | Удалить единицу оборудования |
| **GET** | `/types` | Получить типы оборудования |

---

### 4. Пользователи (Users) — `api/v/1/users`

| Метод | Путь | Описание действия |
| :--- | :--- | :--- |
| **POST** | `/` | Зарегистрировать нового пользователя |
| **POST** | `/login` | Пройти аутентификацию и получить JWT |
| **GET** | `/` | Получить список пользователей по фильтру |
| **GET** | `/{userId:guid}` | Получить детальный профиль пользователя |
| **GET** | `/{userId:guid}/events/recent` | Получить список недавних мероприятий пользователя |
| **PATCH** | `/{userId:guid}` | Обновить профиль пользователя |
| **PATCH** | `/{userId:guid}/password` | Изменить пароль пользователя |
| **DELETE** | `/{userId:guid}` | Удалить аккаунт пользователя |

---

### 5. Теги (Tags) — `api/v/1/tags`

| Метод | Путь | Описание действия |
| :--- | :--- | :--- |
| **POST** | `/` | Создать новый тег |
| **GET** | `/` | Получить список тегов по фильтру |
| **DELETE** | `/{tagId:int}` | Удалить тег по его ID |

---

### 6. Файловый сервис (Files) — `api/v/1/files`

| Метод | Путь | Описание действия |
| :--- | :--- | :--- |
| **GET** | `/{bucket}/{key}` | Скачать файл из хранилища S3 |

---

## Локальное Развертывание

Для локального запуска требуются установленные **Docker** и **Docker Compose**.

### Сборка и первый запуск контейнеров
```shell
docker compose -f ./docker-compose.dev.yaml up --build --force-recreate
```

### Последующие запуски
```shell
docker compose -f ./docker-compose.dev.yaml up
```

Фоновые воркеры-миграторы при старте окружения автоматически создадут необходимые схемы баз данных PostgreSQL и ClickHouse, а также подготовят бакеты объектного хранилища S3.

---

## Адреса сервисов и доступы (Development-окружение)

| Сервис | URL / Адрес | Учетные данные | Описание |
| :--- | :--- | :--- | :--- |
| **Events API** | `http://localhost:8080/api/v/1/...` | *Зависит от ресурса* | Точка доступа к API-интерфейсу |
| **Scalar Docs**| [http://localhost:8080/scalar](http://localhost:8080/scalar) | — | Интерактивная техническая спецификация |
| **RustFS Console** | [http://localhost:9001](http://localhost:9001) | `rustfsadmin` / `rustfsadmin` | UI консоль объектного S3-хранилища |
| **PostgreSQL** | `localhost:5433` | `postgres` / `1` | СУБД для OLTP-операций (БД `Events`) |
| **ClickHouse** | `localhost:8123` (HTTP) / `9002` (TCP) | `default` / `1` | СУБД для аналитики (БД `EventsAnalytics`) |

---

## Телеметрия и Мониторинг

Пайплайн сбора данных развернут на базе **OpenTelemetry (OTLP)**. Конфигурация представлена в файле `configs/otel/otel-collector-config.yaml`.

*   Сбор трасс и логов выполняется с S3-совместимого хранилища **RustFS**.
*   Сбор метрик работы СУБД выполняется напрямую с контейнера **PostgreSQL**.
*   Данные агрегируются, фильтруются и экспортируются в таблицы **ClickHouse** для последующего анализа.

---

## Тестирование

Запуск модульных тестов из корневой директории решения:

```shell
dotnet test
```

Unit-тесты расположены в директории `tests/Events.Unit.Tests/` и проверяют доменную логику, корректность работы спецификаций, валидаторов и фабрик сущностей.
