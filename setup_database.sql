-- ==============================================================
-- Library Management System - Database Tables & Seed Data Script
-- ==============================================================

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Authors')
BEGIN
    CREATE TABLE [Authors] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NOT NULL,
        [Biography] nvarchar(max) NULL,
        [Country] nvarchar(max) NOT NULL,
        [BooksCount] int NOT NULL,
        [PopularGenre] nvarchar(max) NOT NULL,
        [AvatarUrl] nvarchar(max) NULL,
        CONSTRAINT [PK_Authors] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Books')
BEGIN
    CREATE TABLE [Books] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(150) NOT NULL,
        [AlternateTitle] nvarchar(150) NULL,
        [Author] nvarchar(100) NOT NULL,
        [Category] nvarchar(80) NOT NULL,
        [Publisher] nvarchar(100) NULL,
        [Language] nvarchar(50) NULL,
        [CopiesAvailable] int NOT NULL,
        [Price] decimal(18,2) NOT NULL,
        [Status] nvarchar(max) NOT NULL,
        [IsActive] bit NOT NULL,
        [Description] nvarchar(1000) NULL,
        [CoverImageUrl] nvarchar(max) NULL,
        [CreatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_Books] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Members')
BEGIN
    CREATE TABLE [Members] (
        [Id] int NOT NULL IDENTITY,
        [FullName] nvarchar(100) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Phone] nvarchar(max) NOT NULL,
        [MembershipType] nvarchar(max) NOT NULL,
        [BooksBorrowed] int NOT NULL,
        [Status] nvarchar(max) NOT NULL,
        [JoinedDate] datetime2 NOT NULL,
        [AvatarUrl] nvarchar(max) NULL,
        CONSTRAINT [PK_Members] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Publishers')
BEGIN
    CREATE TABLE [Publishers] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NOT NULL,
        [Country] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        [Address] nvarchar(max) NULL,
        [TotalBooks] int NOT NULL,
        [EstablishedYear] int NOT NULL,
        CONSTRAINT [PK_Publishers] PRIMARY KEY ([Id])
    );
END;

-- ==============================================================
-- Seed Data
-- ==============================================================

IF NOT EXISTS (SELECT * FROM [Authors])
BEGIN
    SET IDENTITY_INSERT [Authors] ON;
    INSERT INTO [Authors] ([Id], [Name], [Biography], [Country], [BooksCount], [PopularGenre], [AvatarUrl])
    VALUES 
    (1, N'Elizabeth Hailey', N'American journalist and author known for compelling character-driven personal narratives.', N'United States', 1, N'Self development', N'/images/avatars/avatar1.svg'),
    (2, N'Joseph Kirland', N'British author renowned for fast-paced contemporary adventure and speculative fiction.', N'United Kingdom', 1, N'Novels', N'/images/avatars/avatar2.svg'),
    (3, N'Lauren Willig', N'Bestselling novelist recognized for historical fiction, engaging dialogue, and wit.', N'United States', 1, N'Comedy', N'/images/avatars/avatar3.svg'),
    (4, N'J. K. Rowling', N'British author renowned worldwide for the acclaimed Harry Potter fantasy series.', N'United Kingdom', 1, N'Novels', N'/images/avatars/avatar4.svg'),
    (5, N'Colleen Hoover', N'Number one New York Times bestselling author of contemporary romance and poignant psychological fiction.', N'United States', 3, N'Drama & Romance', N'/images/avatars/avatar5.svg'),
    (6, N'Paul Grewal', N'Physician and internal medicine specialist focused on functional wellness, nutrition, and metabolic health.', N'Canada', 1, N'Health, Fitness & Dieting', N'/images/avatars/avatar6.svg');
    SET IDENTITY_INSERT [Authors] OFF;
END;

IF NOT EXISTS (SELECT * FROM [Books])
BEGIN
    SET IDENTITY_INSERT [Books] ON;
    INSERT INTO [Books] ([Id], [Title], [AlternateTitle], [Author], [Category], [Publisher], [Language], [CopiesAvailable], [Price], [Status], [IsActive], [Description], [CoverImageUrl], [CreatedAt])
    VALUES 
    (1001, N'Independent Women', N'A Tale of Courage', N'Elizabeth Hailey', N'Self development', N'Dar al-shorouk', N'English', 15, 1000.0, N'Available', 1, N'An inspiring novel exploring resilience, personal growth, and self-discovery.', N'/images/covers/book1001.svg', '2024-01-10T10:00:00'),
    (1002, N'Never Ending Sky', N'Endless Horizons', N'Joseph Kirland', N'Novels', N'Dar dawen', N'English', 8, 800.0, N'Issued', 1, N'A modern adventure novel traversing uncharted horizons and life discoveries.', N'/images/covers/book1002.svg', '2024-01-15T11:30:00'),
    (1003, N'Bands Of Sisters', N'Together We Stand', N'Lauren Willig', N'Comedy', N'Aseer alktob', N'English', 12, 1000.0, N'Available', 1, N'A witty and heartwarming tale of sisterhood, humor, and wartime solidarity.', N'/images/covers/book1003.svg', '2024-02-01T14:20:00'),
    (1004, N'Harry Potter', N'The Sorcerer''s Stone', N'J. K. Rowling', N'Novels', N'Dar al-shorouk', N'English', 30, 5000.0, N'Reserved', 0, N'The legendary beginning of Harry Potter''s journey at Hogwarts School of Witchcraft and Wizardry.', N'/images/covers/book1004.svg', '2024-02-10T09:15:00'),
    (1005, N'It Ends With Us', N'Breaking the Cycle', N'Colleen Hoover', N'Drama & Romance', N'Dar dawen', N'English', 25, 5000.0, N'Issued', 1, N'A deeply moving story of love, difficult choices, and breaking painful cycles.', N'/images/covers/book1005.svg', '2024-02-18T16:45:00'),
    (1006, N'Genius Foods', N'Become Smarter, Happier', N'Paul Grewal', N'Health, Fitness & Dieting', N'Aseer alktob', N'English', 18, 5000.0, N'Available', 0, N'A practical guide exploring the connection between nutritious diet, cognitive health, and mental clarity.', N'/images/covers/book1006.svg', '2024-02-25T12:00:00'),
    (1007, N'Heart Bones', N'Ocean Whispers', N'Colleen Hoover', N'Drama & Romance', N'Dar dawen', N'English', 10, 5000.0, N'Overdue', 1, N'A poignant summer romance unraveling secrets from the past on the Texas coast.', N'/images/covers/book1007.svg', '2024-03-02T15:30:00'),
    (1008, N'Reminders of Him', N'Letters to the Past', N'Colleen Hoover', N'Novels', N'Dar al-shorouk', N'English', 14, 1000.0, N'Available', 0, N'A gripping and emotional journey of redemption, motherhood, and finding hope against all odds.', N'/images/covers/book1008.svg', '2024-03-10T18:00:00');
    SET IDENTITY_INSERT [Books] OFF;
END;

IF NOT EXISTS (SELECT * FROM [Members])
BEGIN
    SET IDENTITY_INSERT [Members] ON;
    INSERT INTO [Members] ([Id], [FullName], [Email], [Phone], [MembershipType], [BooksBorrowed], [Status], [JoinedDate], [AvatarUrl])
    VALUES 
    (1, N'Karim Jannat', N'karim.j@gmail.com', N'+1 (555) 123-4567', N'Student', 2, N'Active', '2023-09-01T00:00:00', N'/images/avatars/avatar1.svg'),
    (2, N'Abdul Samad', N'abdul.s@yahoo.com', N'+1 (555) 234-5678', N'Faculty', 3, N'Active', '2023-10-12T00:00:00', N'/images/avatars/avatar2.svg'),
    (3, N'Will Sameed', N'will.sameed@outlook.com', N'+1 (555) 345-6789', N'Student', 1, N'Active', '2023-11-05T00:00:00', N'/images/avatars/avatar3.svg'),
    (4, N'Azaduzamman Mia', N'azad.mia@mail.com', N'+1 (555) 456-7890', N'Premium', 4, N'Active', '2023-11-20T00:00:00', N'/images/avatars/avatar4.svg'),
    (5, N'Hosneyara Gulbahar', N'gulbahar.h@gmail.com', N'+1 (555) 567-8901', N'Standard', 0, N'Active', '2024-01-15T00:00:00', N'/images/avatars/avatar5.svg'),
    (6, N'Asif Mahmud', N'asif.mahmud@library.edu', N'+1 (555) 678-9012', N'Student', 2, N'Suspended', '2024-02-01T00:00:00', N'/images/avatars/avatar6.svg');
    SET IDENTITY_INSERT [Members] OFF;
END;

IF NOT EXISTS (SELECT * FROM [Publishers])
BEGIN
    SET IDENTITY_INSERT [Publishers] ON;
    INSERT INTO [Publishers] ([Id], [Name], [Country], [Email], [Phone], [Address], [TotalBooks], [EstablishedYear])
    VALUES 
    (1, N'Dar al-shorouk', N'Egypt', N'info@shorouk.com', N'+20 2 24023399', N'Cairo, Egypt', 3, 1968),
    (2, N'Dar dawen', N'Egypt', N'contact@dawen.net', N'+20 2 27951122', N'Cairo, Egypt', 3, 2008),
    (3, N'Aseer alktob', N'Saudi Arabia', N'help@aseeralktob.com', N'+966 11 4056789', N'Riyadh, Saudi Arabia', 2, 2012),
    (4, N'Pajeri Publication', N'Turkey', N'info@pajeri.com.tr', N'+90 212 555 1234', N'Istanbul, Turkey', 4, 1995),
    (5, N'Haque Publications', N'United Kingdom', N'info@haque.co.uk', N'+44 20 7946 0912', N'London, UK', 2, 2005),
    (6, N'Crown Publishing', N'United States', N'contact@crownpublishing.com', N'+1 (212) 555-0145', N'New York, NY', 5, 1992);
    SET IDENTITY_INSERT [Publishers] OFF;
END;
