# 🎬 MovieCollection — ASP.NET Core MVC приложение

MovieCollection е уеб приложение, създадено с ASP.NET Core MVC, което позволява управление на филми и жанрове. Проектът включва CRUD операции, валидиране на данни, Entity Framework Core и SQL база данни.

---

## 🚀 Функционалности

### ✔ Управление на филми (Movies)
- Добавяне на нов филм  
- Редактиране на съществуващ филм  
- Изтриване на филм  
- Преглед на детайли  
- Списък с всички филми  

### ✔ Полета на филма
- **Title** — заглавие  
- **Description** — описание  
- **ReleaseYear** — година на излизане  
- **Rating** — оценка (dropdown от 1 до 10)  
- **Genre** — жанр (dropdown)  
- **Director** — име на режисьора (текстово поле)

### ✔ Управление на жанрове (Genres)
- CRUD операции за жанрове  
- Използват се като dropdown при създаване/редакция на филм  

---

## 🛠 Технологии

- **ASP.NET Core MVC**
- **Entity Framework Core**
- **SQL Server**
- **Razor Views**
- **Dependency Injection**
- **Service слой (MovieService)**
- **Bootstrap 5**

---

## 📁 Структура на проекта

MovieCollection/
│
├── Controllers/
│   └── MoviesController.cs
│
├── Models/
│   ├── Movie.cs
│   └── Genre.cs
│
├── Services/
│   ├── IMovieService.cs
│   └── MovieService.cs
│
├── Views/
│   └── Movies/
│       ├── Index.cshtml
│       ├── Create.cshtml
│       ├── Edit.cshtml
│       ├── Details.cshtml
│       └── Delete.cshtml
│
└── Data/
    └── ApplicationDbContext.cs


---

## 🗄 База данни и миграции

След промени в моделите се използват командите:

Add-Migration 
Update-Database


---

## 🔧 Основни промени в проекта

- Премахната е таблицата **Directors**
- Полето **Director** вече е обикновен `string`
- Обновени са всички Razor изгледи
- Обновен е **MoviesController**
- Обновен е **MovieService**
- Добавен е dropdown за **Rating (1–10)**
- Dropdown за жанрове използва `SelectList`
- Премахнат е MovieFormViewModel
- Моделът Movie е изчистен и синхронизиран с базата

---

## 📌 Автор
Проектът е разработен от **Цветомир **.

