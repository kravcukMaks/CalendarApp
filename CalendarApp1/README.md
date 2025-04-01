# CalendarApp1

## Опис
**CalendarApp1** — це веб-додаток для керування подіями та календарем.

## Встановлення  
Щоб запустити проєкт, виконайте наступні команди:

\`\`\`sh
git clone https://github.com/kravcukMaks/CalendarApp.git
cd CalendarApp1
dotnet restore
dotnet run
\`\`\`

## Документація  
Документацію можна згенерувати за допомогою \`DocFX\`:

\`\`\`sh
docfx build
docfx serve _site
\`\`\`

## Конфігурація  
Основний файл конфігурації: \`docfx.json\`.  
Він містить налаштування генерації документації та структуру файлів.

## Файлова структура  

\`\`\`
CalendarApp1/ │-- wwwroot/
│ ├── css/
│ ├── js/
│ │ ├── cookie-consent.js │ │ ├── site.js │ ├── lib/
│ ├── favicon.ico
│-- Controllers/
│ ├── CalendarApiController.cs │ ├── CalendarController.cs │ ├── HomeController.cs │-- Migrations/
│-- Models/
│ ├── ApplicationDbContext.cs
│ ├── CalendarEvent.cs
│ ├── ErrorViewModel.cs
│ ├── EventCategory.cs
│ ├── EventComment.cs
│ ├── EventParticipant.cs
│ ├── RecurringEvent.cs
│ ├── Reminder.cs
│-- Views/
│-- appsettings.json
│-- licenses.txt
│-- Program.cs
│-- README.md
\`\`\`

## Ліцензія  
Цей проєкт розповсюджується під ліцензією MIT. Детальніше дивіться у файлі [LICENSE.md](LICENSE.md).

## Автор  
**Кравчук Максим**  
[GitHub](https://github.com/kravcukMaks)
"@