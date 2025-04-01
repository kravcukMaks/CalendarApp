CREATE DATABASE CalendarApp1;

USE CalendarApp1;

CREATE TABLE CalendarEvents (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Date DATE NOT NULL,
    EventDescription VARCHAR(500) NOT NULL
);

-- Додавання категорій подій
CREATE TABLE EventCategories (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL
);

-- Оновлення таблиці подій для додавання категорії
ALTER TABLE CalendarEvents ADD COLUMN CategoryId INT;
ALTER TABLE CalendarEvents ADD CONSTRAINT FK_CalendarEvents_Categories 
FOREIGN KEY (CategoryId) REFERENCES EventCategories(Id);

-- Таблиця нагадувань
CREATE TABLE Reminders (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    EventId INT NOT NULL,
    ReminderTime DATETIME NOT NULL,
    FOREIGN KEY (EventId) REFERENCES CalendarEvents(Id) ON DELETE CASCADE
);

-- Таблиця запрошень на події
CREATE TABLE EventParticipants (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    EventId INT NOT NULL,
    UserId INT NOT NULL,
    Status ENUM('Pending', 'Accepted', 'Declined') DEFAULT 'Pending',
    FOREIGN KEY (EventId) REFERENCES CalendarEvents(Id) ON DELETE CASCADE
);

-- Таблиця коментарів до подій
CREATE TABLE EventComments (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    EventId INT NOT NULL,
    UserId INT NOT NULL,
    CommentText TEXT NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (EventId) REFERENCES CalendarEvents(Id) ON DELETE CASCADE
);

-- Таблиця повторюваних подій
CREATE TABLE RecurringEvents (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    EventId INT NOT NULL,
    RecurrencePattern ENUM('Daily', 'Weekly', 'Monthly', 'Yearly') NOT NULL,
    EndDate DATETIME NULL,
    FOREIGN KEY (EventId) REFERENCES CalendarEvents(Id) ON DELETE CASCADE
);

SHOW TABLES LIKE 'EventCategories';
SELECT * FROM EventCategories;
INSERT INTO EventCategories (Name) VALUES ('Робота'), ('Навчання'), ('Відпочинок');
SHOW CREATE TABLE CalendarEvents;
DESC CalendarEvents;

ALTER TABLE CalendarEvents 
ADD CONSTRAINT FK_CalendarEvents_Categories 
FOREIGN KEY (CategoryId) REFERENCES EventCategories(Id) 
ON DELETE CASCADE;
ALTER TABLE CalendarEvents ADD COLUMN CategoryId INT NULL;
SELECT * FROM CalendarEvents;

SELECT * FROM EventComments;

INSERT INTO CalendarEvents (Date, EventDescription, Title, Description, EventDate, CategoryId)
VALUES 
('2025-02-01 10:00:00', 'Ділова зустріч', 'Зустріч з партнерами', 'Обговорення нових умов співпраці', '2025-02-01 14:00:00', 1),
('2025-02-05 08:30:00', 'Лекція з програмування', 'Заняття в університеті', 'Тема: Основи ASP.NET Core', '2025-02-05 09:00:00', 2),
('2025-02-10 18:00:00', 'Кіно з друзями', 'Перегляд нового фільму', 'Йдемо в кінотеатр на премʼєру', '2025-02-10 19:30:00', 3),
('2025-02-14 19:00:00', 'Романтична вечеря', 'День Святого Валентина', 'Вечеря у ресторані з коханою людиною', '2025-02-14 20:00:00', 1),
('2025-02-20 07:00:00', 'Ранкове тренування', 'Фітнес', 'Заняття у спортзалі', '2025-02-20 07:30:00', 3);
