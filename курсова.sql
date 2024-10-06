USE [master]
GO
/****** Object:  Database [курсовая]    Script Date: 24.04.2024 23:17:39 ******/
CREATE DATABASE [курсовая]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'курсовая', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\курсовая.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'курсовая_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\курсовая_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [курсовая] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [курсовая].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [курсовая] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [курсовая] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [курсовая] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [курсовая] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [курсовая] SET ARITHABORT OFF 
GO
ALTER DATABASE [курсовая] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [курсовая] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [курсовая] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [курсовая] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [курсовая] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [курсовая] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [курсовая] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [курсовая] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [курсовая] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [курсовая] SET  DISABLE_BROKER 
GO
ALTER DATABASE [курсовая] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [курсовая] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [курсовая] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [курсовая] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [курсовая] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [курсовая] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [курсовая] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [курсовая] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [курсовая] SET  MULTI_USER 
GO
ALTER DATABASE [курсовая] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [курсовая] SET DB_CHAINING OFF 
GO
ALTER DATABASE [курсовая] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [курсовая] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [курсовая] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [курсовая] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [курсовая] SET QUERY_STORE = OFF
GO
USE [курсовая]
GO
/****** Object:  Table [dbo].[карты]    Script Date: 24.04.2024 23:17:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[карты](
	[id] [int] NOT NULL,
	[номер_карты] [varchar](16) NULL,
	[срок_действия] [date] NULL,
	[имя_на_карте] [varchar](100) NULL,
	[тариф_id] [int] NULL,
	[дизайн_id] [int] NULL,
	[статус_карты_id] [int] NULL,
	[номер_счета] [varchar](50) NULL,
 CONSTRAINT [PK__карты__3213E83F38282E68] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[счета]    Script Date: 24.04.2024 23:17:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[счета](
	[номер_счета] [varchar](50) NOT NULL,
	[валюта] [varchar](3) NULL,
	[дата_открытия_счета] [date] NULL,
 CONSTRAINT [PK__счета__3213E83F5BC7EF0F] PRIMARY KEY CLUSTERED 
(
	[номер_счета] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[клиент]    Script Date: 24.04.2024 23:17:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[клиент](
	[id_клиента] [int] NOT NULL,
	[адрес] [varchar](255) NULL,
	[фио] [varchar](100) NULL,
	[пол] [varchar](10) NULL,
	[дата_рождения] [date] NULL,
	[категория_клиента_id] [int] NULL,
	[номер_счета] [varchar](50) NULL,
 CONSTRAINT [PK__клиент__3213E83F99A3082C] PRIMARY KEY CLUSTERED 
(
	[id_клиента] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_1]    Script Date: 24.04.2024 23:17:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_1]
AS
SELECT dbo.клиент.фио, dbo.счета.номер_счета, dbo.карты.номер_карты, dbo.карты.срок_действия
FROM     dbo.клиент INNER JOIN
                  dbo.счета ON dbo.клиент.номер_счета = dbo.счета.номер_счета INNER JOIN
                  dbo.карты ON dbo.счета.номер_счета = dbo.карты.номер_счета
GO
/****** Object:  Table [dbo].[дизайн]    Script Date: 24.04.2024 23:17:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[дизайн](
	[id] [int] NOT NULL,
	[дизайны] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Заказы]    Script Date: 24.04.2024 23:17:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Заказы](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[клиент_id] [int] NULL,
	[офисы_id] [int] NULL,
	[условия_выпуска_id] [int] NULL,
	[дизайн_id] [int] NULL,
	[тариф_id] [int] NULL,
 CONSTRAINT [PK__Заказы__3213E83F44FB3FE2] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[категория_клиента]    Script Date: 24.04.2024 23:17:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[категория_клиента](
	[id] [int] NOT NULL,
	[категория] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[офисы]    Script Date: 24.04.2024 23:17:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[офисы](
	[id] [int] NOT NULL,
	[офис] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[статус_карты]    Script Date: 24.04.2024 23:17:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[статус_карты](
	[id] [int] NOT NULL,
	[статус] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[тариф]    Script Date: 24.04.2024 23:17:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[тариф](
	[id] [int] NOT NULL,
	[тарифы] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[условия_выпуска]    Script Date: 24.04.2024 23:17:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[условия_выпуска](
	[id] [int] NOT NULL,
	[сроки_выпуска] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[дизайн] ([id], [дизайны]) VALUES (1, N'Дебетовая карта Мир #МожноВСЁ')
INSERT [dbo].[дизайн] ([id], [дизайны]) VALUES (2, N'Mir Supreme Премиальная')
INSERT [dbo].[дизайн] ([id], [дизайны]) VALUES (3, N'Mir Supreme Премиальная Online')
INSERT [dbo].[дизайн] ([id], [дизайны]) VALUES (4, N'взРОСлая карта')
INSERT [dbo].[дизайн] ([id], [дизайны]) VALUES (5, N'Пенсионная карта «Мир»')
INSERT [dbo].[дизайн] ([id], [дизайны]) VALUES (6, N'Росбанк Мини')
INSERT [dbo].[дизайн] ([id], [дизайны]) VALUES (7, N'Дебетовая цифровая карта Мир #МожноВСЁ')
INSERT [dbo].[дизайн] ([id], [дизайны]) VALUES (8, N'Дебетовая карта О’КЕЙ-Росбанк')
INSERT [dbo].[дизайн] ([id], [дизайны]) VALUES (9, N'Классическая дебетовая неименная карта')
INSERT [dbo].[дизайн] ([id], [дизайны]) VALUES (10, N'Дебетовая классическая карта РЖД, кобрендовая, индивидуальный дизайн')
INSERT [dbo].[дизайн] ([id], [дизайны]) VALUES (11, N'Индивидуальный дизанй')
GO
SET IDENTITY_INSERT [dbo].[Заказы] ON 

INSERT [dbo].[Заказы] ([id], [клиент_id], [офисы_id], [условия_выпуска_id], [дизайн_id], [тариф_id]) VALUES (1, 3, 3, 1, 1, 2)
INSERT [dbo].[Заказы] ([id], [клиент_id], [офисы_id], [условия_выпуска_id], [дизайн_id], [тариф_id]) VALUES (2, 2, 6, 2, 2, 2)
INSERT [dbo].[Заказы] ([id], [клиент_id], [офисы_id], [условия_выпуска_id], [дизайн_id], [тариф_id]) VALUES (3, 6, 1, 2, 1, 2)
INSERT [dbo].[Заказы] ([id], [клиент_id], [офисы_id], [условия_выпуска_id], [дизайн_id], [тариф_id]) VALUES (4, 4, 7, 2, 2, 3)
INSERT [dbo].[Заказы] ([id], [клиент_id], [офисы_id], [условия_выпуска_id], [дизайн_id], [тариф_id]) VALUES (5, 7, 5, 1, 3, 1)
INSERT [dbo].[Заказы] ([id], [клиент_id], [офисы_id], [условия_выпуска_id], [дизайн_id], [тариф_id]) VALUES (6, 5, 2, 2, 1, 3)
INSERT [dbo].[Заказы] ([id], [клиент_id], [офисы_id], [условия_выпуска_id], [дизайн_id], [тариф_id]) VALUES (7, 1, 1, 1, 1, 1)
INSERT [dbo].[Заказы] ([id], [клиент_id], [офисы_id], [условия_выпуска_id], [дизайн_id], [тариф_id]) VALUES (8, 3, 2, 1, 2, 2)
INSERT [dbo].[Заказы] ([id], [клиент_id], [офисы_id], [условия_выпуска_id], [дизайн_id], [тариф_id]) VALUES (9, 2, 3, 1, 1, 2)
INSERT [dbo].[Заказы] ([id], [клиент_id], [офисы_id], [условия_выпуска_id], [дизайн_id], [тариф_id]) VALUES (10, 2, 1, 1, 4, 2)
SET IDENTITY_INSERT [dbo].[Заказы] OFF
GO
INSERT [dbo].[карты] ([id], [номер_карты], [срок_действия], [имя_на_карте], [тариф_id], [дизайн_id], [статус_карты_id], [номер_счета]) VALUES (1, N'5201281234567', CAST(N'2026-10-10' AS Date), N'Ivanov Ivan Ivanovich', 5, 6, 3, N'325262168390576')
INSERT [dbo].[карты] ([id], [номер_карты], [срок_действия], [имя_на_карте], [тариф_id], [дизайн_id], [статус_карты_id], [номер_счета]) VALUES (2, N'5501435467890312', CAST(N'2027-01-30' AS Date), N'Pirogova Sole Proprietor', 7, 2, 2, N'274439820304501')
INSERT [dbo].[карты] ([id], [номер_карты], [срок_действия], [имя_на_карте], [тариф_id], [дизайн_id], [статус_карты_id], [номер_счета]) VALUES (3, N'5498650987654321', CAST(N'2030-04-12' AS Date), N'-', 5, 5, 1, N'205333796548065')
INSERT [dbo].[карты] ([id], [номер_карты], [срок_действия], [имя_на_карте], [тариф_id], [дизайн_id], [статус_карты_id], [номер_счета]) VALUES (4, N'5494780987654321', CAST(N'2028-10-25' AS Date), N'Tarasova Aglaya Dmitrievna', 4, 11, 2, N'186882617014827')
INSERT [dbo].[карты] ([id], [номер_карты], [срок_действия], [имя_на_карте], [тариф_id], [дизайн_id], [статус_карты_id], [номер_счета]) VALUES (5, N'5484090956743111', CAST(N'2030-12-12' AS Date), N'groshev sergey', 4, 2, 1, N'141072495873262')
INSERT [dbo].[карты] ([id], [номер_карты], [срок_действия], [имя_на_карте], [тариф_id], [дизайн_id], [статус_карты_id], [номер_счета]) VALUES (6, N'6770761234090909', CAST(N'2029-12-12' AS Date), N'-', 1, 6, 1, N'47064251667911')
INSERT [dbo].[карты] ([id], [номер_карты], [срок_действия], [имя_на_карте], [тариф_id], [дизайн_id], [статус_карты_id], [номер_счета]) VALUES (7, N'4779860000888888', CAST(N'2025-09-12' AS Date), N'miteeva miroslava ', 1, 1, 1, N'252002911165643')
INSERT [dbo].[карты] ([id], [номер_карты], [срок_действия], [имя_на_карте], [тариф_id], [дизайн_id], [статус_карты_id], [номер_счета]) VALUES (8, N'4048633333333333', CAST(N'2030-12-12' AS Date), N'-', 5, 1, 2, N'312660734312979')
INSERT [dbo].[карты] ([id], [номер_карты], [срок_действия], [имя_на_карте], [тариф_id], [дизайн_id], [статус_карты_id], [номер_счета]) VALUES (9, N'4048620000000000', CAST(N'2025-12-09' AS Date), N'-', 6, 9, 3, N'172580375977572')
INSERT [dbo].[карты] ([id], [номер_карты], [срок_действия], [имя_на_карте], [тариф_id], [дизайн_id], [статус_карты_id], [номер_счета]) VALUES (10, N'4048634444444444', CAST(N'2030-12-12' AS Date), N'-', 7, 1, 2, N'313708706315492')
INSERT [dbo].[карты] ([id], [номер_карты], [срок_действия], [имя_на_карте], [тариф_id], [дизайн_id], [статус_карты_id], [номер_счета]) VALUES (11, N'4048635555555555', CAST(N'2027-12-10' AS Date), N'-', 4, 2, 3, N'199943612557874')
INSERT [dbo].[карты] ([id], [номер_карты], [срок_действия], [имя_на_карте], [тариф_id], [дизайн_id], [статус_карты_id], [номер_счета]) VALUES (12, N'4048622222222222', CAST(N'2029-09-09' AS Date), N'AOA', 5, 2, 1, N'160386963829237')
GO
INSERT [dbo].[категория_клиента] ([id], [категория]) VALUES (1, N'VIP_клиент')
INSERT [dbo].[категория_клиента] ([id], [категория]) VALUES (2, N'Корпоративные клиенты ')
INSERT [dbo].[категория_клиента] ([id], [категория]) VALUES (3, N'Крупный бизнес и государственные структуры')
INSERT [dbo].[категория_клиента] ([id], [категория]) VALUES (4, N'Малый и средний бизнес')
INSERT [dbo].[категория_клиента] ([id], [категория]) VALUES (5, N'Партнеры банка ')
INSERT [dbo].[категория_клиента] ([id], [категория]) VALUES (6, N'Физическое лицо')
GO
INSERT [dbo].[клиент] ([id_клиента], [адрес], [фио], [пол], [дата_рождения], [категория_клиента_id], [номер_счета]) VALUES (1, N'ул. Пушкина, д. 10.2222', N'Иванов Иван Михайлович', N'мужской', CAST(N'1990-05-15' AS Date), 6, N'325262168390576')
INSERT [dbo].[клиент] ([id_клиента], [адрес], [фио], [пол], [дата_рождения], [категория_клиента_id], [номер_счета]) VALUES (2, N'пр. Ленина, д. 5', N'ИП Пирогова', N'-', CAST(N'2000-11-20' AS Date), 4, N'274439820304501')
INSERT [dbo].[клиент] ([id_клиента], [адрес], [фио], [пол], [дата_рождения], [категория_клиента_id], [номер_счета]) VALUES (3, N'ул. Гагарина, д. 25', N'ЗАО Парк', N'-', CAST(N'2001-08-30' AS Date), 3, N'205333796548065')
INSERT [dbo].[клиент] ([id_клиента], [адрес], [фио], [пол], [дата_рождения], [категория_клиента_id], [номер_счета]) VALUES (4, N'ул. Изумрудная, д. 5', N'ООО АОА', N'-', CAST(N'2013-03-13' AS Date), 2, N'9876543216')
INSERT [dbo].[клиент] ([id_клиента], [адрес], [фио], [пол], [дата_рождения], [категория_клиента_id], [номер_счета]) VALUES (5, N'ул. Пришвина, д. 7', N'Тарасова Аглаяя Дмитриевна', N'женский', CAST(N'1994-04-18' AS Date), 1, N'186882617014827')
INSERT [dbo].[клиент] ([id_клиента], [адрес], [фио], [пол], [дата_рождения], [категория_клиента_id], [номер_счета]) VALUES (6, N'Пресненская наб., 10, стр. 1', N'ВТБ', N'-', CAST(N'1990-10-10' AS Date), 5, N'808080888')
INSERT [dbo].[клиент] ([id_клиента], [адрес], [фио], [пол], [дата_рождения], [категория_клиента_id], [номер_счета]) VALUES (7, N'нижний новгород', N'грошев сергей Анатольевич', N'м', CAST(N'2000-11-09' AS Date), 1, N'274439820304501')
INSERT [dbo].[клиент] ([id_клиента], [адрес], [фио], [пол], [дата_рождения], [категория_клиента_id], [номер_счета]) VALUES (8, N'кузьминки, д. 9', N'Инеева Глафира Петровна', N'ж', CAST(N'1899-09-09' AS Date), 6, N'142957986515116')
INSERT [dbo].[клиент] ([id_клиента], [адрес], [фио], [пол], [дата_рождения], [категория_клиента_id], [номер_счета]) VALUES (9, N'новый арбат, д. 3', N'Митяева Мирослава Львовна', N'ж', CAST(N'2010-08-08' AS Date), 6, N'325262168390576')
INSERT [dbo].[клиент] ([id_клиента], [адрес], [фио], [пол], [дата_рождения], [категория_клиента_id], [номер_счета]) VALUES (10, N'Изумрудная, д12', N'ООО "Абрикос"', N'-', CAST(N'2020-09-10' AS Date), 4, N'185791695366044')
INSERT [dbo].[клиент] ([id_клиента], [адрес], [фио], [пол], [дата_рождения], [категория_клиента_id], [номер_счета]) VALUES (11, N'ул северная, д.6', N'OAO "Медведи"', N'-', CAST(N'2021-12-07' AS Date), 4, N'186882617014827')
INSERT [dbo].[клиент] ([id_клиента], [адрес], [фио], [пол], [дата_рождения], [категория_клиента_id], [номер_счета]) VALUES (12, N'москва, кипфин', N'Жуков Константин Павлович', N'м', CAST(N'1992-02-02' AS Date), 1, N'49052821514701')
GO
INSERT [dbo].[офисы] ([id], [офис]) VALUES (1, N'Красные ворота')
INSERT [dbo].[офисы] ([id], [офис]) VALUES (2, N'Бульвар Дмитрия Донского')
INSERT [dbo].[офисы] ([id], [офис]) VALUES (3, N'Красная Пресня')
INSERT [dbo].[офисы] ([id], [офис]) VALUES (4, N'Ленинская Слобода')
INSERT [dbo].[офисы] ([id], [офис]) VALUES (5, N'Москва-Сити')
INSERT [dbo].[офисы] ([id], [офис]) VALUES (6, N'Павелецкий')
INSERT [dbo].[офисы] ([id], [офис]) VALUES (7, N'Проспект Мира')
GO
INSERT [dbo].[статус_карты] ([id], [статус]) VALUES (1, N'В процессе')
INSERT [dbo].[статус_карты] ([id], [статус]) VALUES (2, N'Готова к вручению')
INSERT [dbo].[статус_карты] ([id], [статус]) VALUES (3, N'Принято в обработку')
GO
INSERT [dbo].[счета] ([номер_счета], [валюта], [дата_открытия_счета]) VALUES (N'114533892954620', N'RUB', CAST(N'2024-04-21' AS Date))
INSERT [dbo].[счета] ([номер_счета], [валюта], [дата_открытия_счета]) VALUES (N'1234567896', N'RUB', CAST(N'2020-01-15' AS Date))
INSERT [dbo].[счета] ([номер_счета], [валюта], [дата_открытия_счета]) VALUES (N'141072495873262', N'RUB', CAST(N'2024-04-22' AS Date))
INSERT [dbo].[счета] ([номер_счета], [валюта], [дата_открытия_счета]) VALUES (N'142957986515116', N'RUB', CAST(N'2024-04-21' AS Date))
INSERT [dbo].[счета] ([номер_счета], [валюта], [дата_открытия_счета]) VALUES (N'160386963829237', N'RUB', CAST(N'2024-04-23' AS Date))
INSERT [dbo].[счета] ([номер_счета], [валюта], [дата_открытия_счета]) VALUES (N'172580375977572', N'RUB', CAST(N'2024-04-22' AS Date))
INSERT [dbo].[счета] ([номер_счета], [валюта], [дата_открытия_счета]) VALUES (N'185791695366044', N'RUB', CAST(N'2024-04-21' AS Date))
INSERT [dbo].[счета] ([номер_счета], [валюта], [дата_открытия_счета]) VALUES (N'186882617014827', N'RUB', CAST(N'2024-04-21' AS Date))
INSERT [dbo].[счета] ([номер_счета], [валюта], [дата_открытия_счета]) VALUES (N'199943612557874', N'RUB', CAST(N'2024-04-23' AS Date))
INSERT [dbo].[счета] ([номер_счета], [валюта], [дата_открытия_счета]) VALUES (N'205333796548065', N'RUB', CAST(N'2024-04-21' AS Date))
INSERT [dbo].[счета] ([номер_счета], [валюта], [дата_открытия_счета]) VALUES (N'252002911165643', N'RUB', CAST(N'2024-04-22' AS Date))
INSERT [dbo].[счета] ([номер_счета], [валюта], [дата_открытия_счета]) VALUES (N'274439820304501', N'RUB', CAST(N'2024-04-21' AS Date))
INSERT [dbo].[счета] ([номер_счета], [валюта], [дата_открытия_счета]) VALUES (N'312660734312979', N'RUB', CAST(N'2024-04-22' AS Date))
INSERT [dbo].[счета] ([номер_счета], [валюта], [дата_открытия_счета]) VALUES (N'313708706315492', N'RUB', CAST(N'2024-04-23' AS Date))
INSERT [dbo].[счета] ([номер_счета], [валюта], [дата_открытия_счета]) VALUES (N'325262168390576', N'RUB', CAST(N'2024-04-21' AS Date))
INSERT [dbo].[счета] ([номер_счета], [валюта], [дата_открытия_счета]) VALUES (N'435276891', N'RUB', CAST(N'2000-03-10' AS Date))
INSERT [dbo].[счета] ([номер_счета], [валюта], [дата_открытия_счета]) VALUES (N'47064251667911', N'RUB', CAST(N'2024-04-22' AS Date))
INSERT [dbo].[счета] ([номер_счета], [валюта], [дата_открытия_счета]) VALUES (N'49052821514701', N'RUB', CAST(N'2024-04-23' AS Date))
INSERT [dbo].[счета] ([номер_счета], [валюта], [дата_открытия_счета]) VALUES (N'6551242847', N'RUB', CAST(N'2000-03-10' AS Date))
INSERT [dbo].[счета] ([номер_счета], [валюта], [дата_открытия_счета]) VALUES (N'68504728451558', NULL, NULL)
INSERT [dbo].[счета] ([номер_счета], [валюта], [дата_открытия_счета]) VALUES (N'808080888', N'RUB', CAST(N'2012-01-01' AS Date))
INSERT [dbo].[счета] ([номер_счета], [валюта], [дата_открытия_счета]) VALUES (N'9876543216', N'EUR', CAST(N'2013-02-28' AS Date))
GO
INSERT [dbo].[тариф] ([id], [тарифы]) VALUES (1, N'Авансовый')
INSERT [dbo].[тариф] ([id], [тарифы]) VALUES (2, N'Бюджетный')
INSERT [dbo].[тариф] ([id], [тарифы]) VALUES (3, N'Зарплатный')
INSERT [dbo].[тариф] ([id], [тарифы]) VALUES (4, N'Золотой')
INSERT [dbo].[тариф] ([id], [тарифы]) VALUES (5, N'Индивидуальный')
INSERT [dbo].[тариф] ([id], [тарифы]) VALUES (6, N'Классический')
INSERT [dbo].[тариф] ([id], [тарифы]) VALUES (7, N'Корпоративный')
INSERT [dbo].[тариф] ([id], [тарифы]) VALUES (8, N'Онлайн')
INSERT [dbo].[тариф] ([id], [тарифы]) VALUES (9, N'Пенсионный')
INSERT [dbo].[тариф] ([id], [тарифы]) VALUES (10, N'Премиальный')
GO
INSERT [dbo].[условия_выпуска] ([id], [сроки_выпуска]) VALUES (1, N'срочно')
INSERT [dbo].[условия_выпуска] ([id], [сроки_выпуска]) VALUES (2, N'не срочно')
GO
ALTER TABLE [dbo].[Заказы]  WITH CHECK ADD  CONSTRAINT [FK__Заказы__офисы_id__412EB0B6] FOREIGN KEY([офисы_id])
REFERENCES [dbo].[офисы] ([id])
GO
ALTER TABLE [dbo].[Заказы] CHECK CONSTRAINT [FK__Заказы__офисы_id__412EB0B6]
GO
ALTER TABLE [dbo].[Заказы]  WITH CHECK ADD  CONSTRAINT [FK__Заказы__условия___4222D4EF] FOREIGN KEY([условия_выпуска_id])
REFERENCES [dbo].[условия_выпуска] ([id])
GO
ALTER TABLE [dbo].[Заказы] CHECK CONSTRAINT [FK__Заказы__условия___4222D4EF]
GO
ALTER TABLE [dbo].[Заказы]  WITH CHECK ADD  CONSTRAINT [FK_Заказы_дизайн] FOREIGN KEY([дизайн_id])
REFERENCES [dbo].[дизайн] ([id])
GO
ALTER TABLE [dbo].[Заказы] CHECK CONSTRAINT [FK_Заказы_дизайн]
GO
ALTER TABLE [dbo].[Заказы]  WITH CHECK ADD  CONSTRAINT [FK_Заказы_клиент1] FOREIGN KEY([клиент_id])
REFERENCES [dbo].[клиент] ([id_клиента])
GO
ALTER TABLE [dbo].[Заказы] CHECK CONSTRAINT [FK_Заказы_клиент1]
GO
ALTER TABLE [dbo].[Заказы]  WITH CHECK ADD  CONSTRAINT [FK_Заказы_тариф] FOREIGN KEY([тариф_id])
REFERENCES [dbo].[тариф] ([id])
GO
ALTER TABLE [dbo].[Заказы] CHECK CONSTRAINT [FK_Заказы_тариф]
GO
ALTER TABLE [dbo].[карты]  WITH CHECK ADD  CONSTRAINT [FK__карты__статус_ка__36B12243] FOREIGN KEY([статус_карты_id])
REFERENCES [dbo].[статус_карты] ([id])
GO
ALTER TABLE [dbo].[карты] CHECK CONSTRAINT [FK__карты__статус_ка__36B12243]
GO
ALTER TABLE [dbo].[карты]  WITH CHECK ADD  CONSTRAINT [FK__карты__тариф_id__34C8D9D1] FOREIGN KEY([тариф_id])
REFERENCES [dbo].[тариф] ([id])
GO
ALTER TABLE [dbo].[карты] CHECK CONSTRAINT [FK__карты__тариф_id__34C8D9D1]
GO
ALTER TABLE [dbo].[карты]  WITH CHECK ADD  CONSTRAINT [FK_карты_дизайн] FOREIGN KEY([дизайн_id])
REFERENCES [dbo].[дизайн] ([id])
GO
ALTER TABLE [dbo].[карты] CHECK CONSTRAINT [FK_карты_дизайн]
GO
ALTER TABLE [dbo].[карты]  WITH CHECK ADD  CONSTRAINT [FK_карты_счета] FOREIGN KEY([номер_счета])
REFERENCES [dbo].[счета] ([номер_счета])
GO
ALTER TABLE [dbo].[карты] CHECK CONSTRAINT [FK_карты_счета]
GO
ALTER TABLE [dbo].[клиент]  WITH CHECK ADD  CONSTRAINT [FK_клиент_категория_клиента] FOREIGN KEY([категория_клиента_id])
REFERENCES [dbo].[категория_клиента] ([id])
GO
ALTER TABLE [dbo].[клиент] CHECK CONSTRAINT [FK_клиент_категория_клиента]
GO
ALTER TABLE [dbo].[клиент]  WITH CHECK ADD  CONSTRAINT [FK_клиент_счета] FOREIGN KEY([номер_счета])
REFERENCES [dbo].[счета] ([номер_счета])
GO
ALTER TABLE [dbo].[клиент] CHECK CONSTRAINT [FK_клиент_счета]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "клиент"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 293
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "карты"
            Begin Extent = 
               Top = 0
               Left = 697
               Bottom = 163
               Right = 899
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "счета"
            Begin Extent = 
               Top = 65
               Left = 391
               Bottom = 206
               Right = 630
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
USE [master]
GO
ALTER DATABASE [курсовая] SET  READ_WRITE 
GO
