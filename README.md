# MyBackend

REST API для управления пользователями, разработанный на **ASP.NET Core Web API** с использованием **Entity Framework Core**, **AutoMapper** и **SQL Server**.

Проект демонстрирует построение чистой архитектуры приложения с разделением бизнес-логики, моделей, DTO и слоя доступа к данным.

---

# Возможности

- CRUD операции для пользователей
- Soft Delete
- Валидация входящих данных
- Хэширование паролей (BCrypt)
- Использование DTO
- AutoMapper
- Swagger/OpenAPI
- Сервисный слой (Service Layer)
- Entity Framework Core
- SQL Server

---

# Стек технологий

| Технология | Версия |
|------------|---------|
| .NET | 10 |
| ASP.NET Core Web API | 10 |
| Entity Framework Core | 10.0.9 |
| SQL Server | LocalDB / SQL Server |
| AutoMapper | Latest |
| BCrypt.Net-Next | Latest |
| Swagger (Swashbuckle) | Latest |

---

# Структура проекта

```
MyBackend
│
├── Controllers/
│   └── UsersController.cs
│
├── Data/
│   ├── ApplicationDbContext.cs
│   └── Configurations/
│
├── DTOs/
│   ├── CreateUserDto.cs
│   ├── UpdateUserDto.cs
│   └── UserDto.cs
│
├── Mappings/
│   └── MappingProfile.cs
│
├── Models/
│   └── User.cs
│
├── Services/
│   ├── Interfaces/
│   └── Implementations/
│
├── Program.cs
├── appsettings.json
└── README.md
```

---

# Запуск проекта

## 1. Клонировать репозиторий

```bash
git clone https://github.com/<username>/MyBackend.git

cd MyBackend
```

---

## 2. Восстановить зависимости

```bash
dotnet restore
```

---

## 3. Настроить подключение к базе данных

В файле **appsettings.json**:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=MyBackendDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

---

## 4. Применить миграции

```bash
dotnet ef database update
```

---

## 5. Запустить приложение

```bash
dotnet run
```

После запуска Swagger будет доступен по адресу

```
https://localhost:7117/swagger
```

> Порт может отличаться в зависимости от настроек проекта.

---

# API

## Получение всех пользователей

```
GET /api/users
```

---

## Получение пользователя

```
GET /api/users/{id}
```

---

## Создание пользователя

```
POST /api/users
```

Пример запроса

```json
{
  "name": "Алексей Петров",
  "email": "alex@example.com",
  "password": "StrongPass123"
}
```

---

## Обновление пользователя

```
PUT /api/users/{id}
```

---

## Удаление пользователя (Soft Delete)

```
DELETE /api/users/{id}
```

---

# Особенности реализации

✔ Разделение Entity и DTO

✔ Service Layer

✔ AutoMapper

✔ Soft Delete

✔ BCrypt для хранения паролей

✔ Dependency Injection

✔ Entity Framework Core

✔ Swagger

✔ Готовность к масштабированию

---

# Добавление новой миграции

```bash
dotnet ef migrations add MigrationName
```

Применение миграции

```bash
dotnet ef database update
```

---

# Возможные улучшения

- JWT Authentication
- Refresh Token
- Identity
- Authorization
- Roles
- Global Exception Middleware
- Logging
- Repository Pattern
- Unit Tests
- Docker
- CI/CD
- Pagination
- Filtering
- Search
- FluentValidation

---

# Лицензия

Проект распространяется в образовательных целях.

---

## Автор

**Июль 2026**

Разработано как учебный проект для изучения ASP.NET Core Web API, Entity Framework Core и построения REST API.
