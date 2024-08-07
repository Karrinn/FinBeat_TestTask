  
-- Запросы к БД

--	Написать запрос, который возвращает наименование клиентов и кол-во контактов клиентов
select 
	c.Id [ClientId], 
	c.ClientName [ClientName],
	COUNT (cc.ContactValue) as [ClientContactsCount]
from dbo.[ClientContacts] as cc
	inner join dbo.Clients as c 
		on c.Id = cc.ClientId
group by c.Id, c.ClientName, cc.ClientId

-- Написать запрос, который возвращает список клиентов, у которых есть более 2 контактов
select 
	c.Id [ClientId],
	c.ClientName [ClientName]
from dbo.[ClientContacts] as cc
	inner join dbo.Clients as c 
		on c.Id = cc.ClientId
group by c.Id, c.ClientName, cc.ContactValue
having COUNT(cc.ContactValue) > 2

-- Написать запрос, который возвращает интервалы для одинаковых Id.
-- Результатом выполнения запроса должен быть такой набор данных:
-- Id Sd         Ed
-- 1  01.01.2021 10.01.202

SELECT 
    T.Id, 
    min(T.Dt) [Sd],
    max(T.Dt) [Ed]
from 
(
Select 
   Id,
   Dt,
   ROW_NUMBER() OVER(PARTITION BY Id ORDER BY Dt ASC) AS RN
FROM Dates
) T
GROUP BY T.Id

-- Создание Таблиц и заполенение данных

IF OBJECT_ID(N'dbo.ClientContacts', N'U') IS NOT NULL  
   DROP TABLE [dbo].[ClientContacts];  
GO

IF OBJECT_ID(N'dbo.Clients', N'U') IS NOT NULL  
   DROP TABLE [dbo].[Clients];  
GO

CREATE TABLE [dbo].[Clients](
	[Id] [bigint] NOT NULL,
	[ClientName] [nvarchar](200) NOT NULL,
	 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Clients] ADD  CONSTRAINT [DF_Clients_Id]  DEFAULT ((0)) FOR [Id]
GO

CREATE TABLE [dbo].[ClientContacts](
	[Id] [bigint] NOT NULL,
	[ClientId] [bigint] NOT NULL,
	[ContactType] [nvarchar](255) NULL,
	[ContactValue] [nvarchar](255) NULL,
	 CONSTRAINT [PK_ClientContacts] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[ClientContacts]  WITH CHECK ADD  CONSTRAINT [FK_Clients_ClientContacts] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([Id])
GO

ALTER TABLE [dbo].[ClientContacts] CHECK CONSTRAINT [FK_Clients_ClientContacts]
GO

CREATE TABLE [dbo].[Dates](
	[Id] [bigint] NOT NULL,
	[Dt] [date] NOT NULL
)

INSERT INTO [dbo].[Clients]
           ([Id],[ClientName])
     VALUES
           (1,'client_1'),
           (2,'client_2'),
           (3,'client_3'),
           (4,'client_4'),
           (5,'client_5')

INSERT INTO [dbo].[ClientContacts]
           ([Id]
           ,[ClientId]
           ,[ContactType]
           ,[ContactValue])
     VALUES
           (1,1,'Client Type 1','Client Contact Type 1'),
           (2,1,'Client Type 1','Client Contact Type 1'),
           (3,1,'Client Type 1','Client Contact Type 1'),
           (4,1,'Client Type 1','Client Contact Type 1'),
           (5,1,'Client Type 1','Client Contact Type 1'),
           (6,2,'Client Type 2','Client Contact Type 2'),
           (7,2,'Client Type 2','Client Contact Type 2'),
           (8,2,'Client Type 2','Client Contact Type 2'),
           (9,2,'Client Type 2','Client Contact Type 2'),
           (10,3,'Client Type 3','Client Contact Type 3'),
           (11,3,'Client Type 3','Client Contact Type 3'),
           (12,3,'Client Type 3','Client Contact Type 3'),
           (13,4,'Client Type 4','Client Contact Type 4'),
           (14,4,'Client Type 4','Client Contact Type 4'),
           (15,5,'Client Type 5','Client Contact Type 5')
       
       
INSERT INTO [dbo].[Dates]
           ([Id]
           ,[Dt])
     VALUES
           (1,'01.01.2021'),
           (1,'10.01.2021'),
           (1,'30.01.2021'),
           (2,'15.01.2021'),
           (2,'30.01.2021')     
       
