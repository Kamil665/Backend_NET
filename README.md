```markdown
# MyBackend

Простой, но хорошо структурированный REST API бэкенд на **ASP.NET Core**.

---

## О проекте

Это учебный/стартовый проект backend-приложения с реализацией CRUD операций для пользователей.

### Используемые технологии

- **ASP.NET Core Web API**
- **Entity Framework Core** + SQL Server
- **AutoMapper**
- **Swagger (OpenAPI)**
- **BCrypt.Net-Next** — хэширование паролей
- **Clean Architecture** элементы (DTO, Service Layer, Mapping)

---

## Структура проекта

```
MyBackend/
├── Controllers/          # API контроллеры
├── DTOs/                 # Data Transfer Objects
├── Data/                 # DbContext + конфигурация
├── Models/               # Сущности базы данных (Entities)
├── Mappings/             # AutoMapper профили
├── Services/             # Бизнес-логика (интерфейсы + реализации)
├── appsettings.json
├── Program.cs
└── README.md
```

---

## Как запустить проект локально

### 1. Клонирование

```bash
git clone https://github.com/твойusername/MyBackend.git
cd MyBackend
```

### 2. Восстановление пакетов

```bash
dotnet restore
```

### 3. Настройка подключения к базе

Отредактируй строку подключения в `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MyBackendDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

### 4. Применение миграций и создание базы

```bash
dotnet ef database update
```

### 5. Запуск

```bash
dotnet run
```

После запуска перейдите по ссылке:  
**`https://localhost:7117/swagger`** (порт может отличаться)

---

## Доступные эндпоинты

| Метод   | Эндпоинт                  | Описание                        |
|---------|---------------------------|---------------------------------|
| GET     | `/api/Users`              | Получить всех пользователей     |
| GET     | `/api/Users/{id}`         | Получить пользователя по ID     |
| POST    | `/api/Users`              | Создать нового пользователя     |
| PUT     | `/api/Users/{id}`         | Обновить данные пользователя    |
| DELETE  | `/api/Users/{id}`         | Удалить пользователя (soft delete) |

---

## Пример создания пользователя (POST)

```json
{
  "name": "Алексей Петров",
  "email": "alex@example.com",
  "password": "StrongPass123"
}
```

---

## Основные возможности

- Полное разделение Entity и DTO
- Soft Delete (не удаляет из базы, а помечает как неактивного)
- Автоматическое маппирование через AutoMapper
- Валидация и Swagger-документация
- Готов к расширению (добавление новых сущностей)

---

## Как добавить миграцию (при изменении моделей)

```bash
dotnet ef migrations add НазваниеМиграции
dotnet ef database update
```

---

## Технологический стек

- .NET 10
- Microsoft.EntityFrameworkCore.SqlServer 10.0.9
- AutoMapper
- BCrypt.Net-Next

---

**Готов к развитию** — можно добавлять аутентификацию (JWT), роли, другие сущности и т.д.

---

Если есть вопросы или предложения по улучшению проекта — создавай Issue.

---

**Создано:** Июль 2026
```

---

Скопируй весь текст выше и создай файл `README.md` в корне проекта.

Хочешь добавить что-то ещё (например, скриншоты, раздел "TODO", информацию о лицензии и т.д.)?
