/*

Database: BooksDB
Schema and data taken from "pubs" database

*/


/****** Object: Table [Authors] ******/

CREATE TABLE [Authors](
	[AuthorID] [int] IDENTITY (1, 1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](20) NULL,
	[Address] [nvarchar](40) NULL,
	[City] [nvarchar](20) NULL,
	[State] [nvarchar](2) NULL, 
    CONSTRAINT [PK_Authors] PRIMARY KEY ([AuthorID])
)
GO

INSERT [Authors] VALUES (N'Johnson', N'White', N'408-496-7223', N'10932 Bigge Rd.', N'Menlo Park', N'CA')
INSERT [Authors] VALUES (N'Marjorie', N'Green', N'415-986-7020', N'309 63rd St. #411', N'Oakland', N'CA')
INSERT [Authors] VALUES (N'Cheryl', N'Carson', N'415-548-7723', N'589 Darwin Ln.', N'Berkeley', N'CA')
INSERT [Authors] VALUES (N'Michael', N'O''Leary', N'408-286-2428', N'22 Cleveland Av. #14', N'San Jose', N'CA')
INSERT [Authors] VALUES (N'Dean', N'Straight', N'415-834-2919', N'5420 College Av.', N'Oakland', N'CA')
INSERT [Authors] VALUES (N'Meander', N'Smith', N'913-843-0462', N'10 Mississippi Dr.', N'Lawrence', N'KS')
INSERT [Authors] VALUES (N'Abraham', N'Bennet', N'415-658-9932', N'6223 Bateman St.', N'Berkeley', N'CA')
INSERT [Authors] VALUES (N'Ann', N'Dull', N'415-836-7128', N'3410 Blonde St.', N'Palo Alto', N'CA')
INSERT [Authors] VALUES (N'Burt', N'Gringlesby', N'707-938-6445', N'PO Box 792', N'Covelo', N'CA')
INSERT [Authors] VALUES (N'Charlene', N'Locksley', N'415-585-4620', N'18 Broadway Av.', N'San Francisco', N'CA')
INSERT [Authors] VALUES (N'Morningstar', N'Greene', N'615-297-2723', N'22 Graybar House Rd.', N'Nashville', N'TN')
INSERT [Authors] VALUES (N'Reginald', N'Blotchet-Halls', N'503-745-6402', N'55 Hillsdale Bl.', N'Corvallis', N'OR')
GO



/****** Object: Table [Publishers] ******/

CREATE TABLE [Publishers](
	[PublisherID] [int] IDENTITY (1, 1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[City] [nvarchar](20) NULL,
	[State] [nvarchar](2) NULL, 
    CONSTRAINT [PK_Publishers] PRIMARY KEY ([PublisherID])
)
GO

INSERT [Publishers] VALUES (N'New Moon Books', N'Boston', N'MA')
INSERT [Publishers] VALUES (N'Binnet & Hardley', N'Washington', N'DC')
INSERT [Publishers] VALUES (N'Algodata Infosystems', N'Berkeley', N'CA')
INSERT [Publishers] VALUES (N'Five Lakes Publishing', N'Chicago', N'IL')
INSERT [Publishers] VALUES (N'Ramona Publishers', N'Dallas', N'TX')
INSERT [Publishers] VALUES (N'Scootney Books', N'New York', N'NY')
GO



/****** Object: Table [Titles] ******/

CREATE TABLE [Titles](
	[TitleID] [int] IDENTITY (1, 1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[PublisherID] [int] NULL,
	[Price] [money] NULL,
    CONSTRAINT [PK_Titles] PRIMARY KEY CLUSTERED ([TitleID] ASC), 
    CONSTRAINT [FK_Titles_Publishers] FOREIGN KEY ([PublisherID]) REFERENCES [Publishers]([PublisherID])
)
GO

INSERT [Titles] VALUES (N'The Busy Executive''s Database Guide', 1, 19.9900)
INSERT [Titles] VALUES (N'Cooking with Computers: Surreptitious Balance Sheets', 1, 11.9500)
INSERT [Titles] VALUES (N'You Can Combat Computer Stress!', 2, 2.9900)
INSERT [Titles] VALUES (N'Straight Talk About Computers', 1, 19.9900)
INSERT [Titles] VALUES (N'Silicon Valley Gastronomic Treats', 3, 19.9900)
INSERT [Titles] VALUES (N'The Gourmet Microwave', 4, 2.9900)
INSERT [Titles] VALUES (N'The Psychology of Computer Cooking', 2, 15.9900)
INSERT [Titles] VALUES (N'But Is It User Friendly?', 1, 22.9500)
INSERT [Titles] VALUES (N'Secrets of Silicon Valley', 5, 20.0000)
INSERT [Titles] VALUES (N'Net Etiquette', 6, 29.9900)
INSERT [Titles] VALUES (N'Computer Phobic AND Non-Phobic Individuals: Behavior Variations', 5, 21.5900)
INSERT [Titles] VALUES (N'Is Anger the Enemy?', 3, 10.9500)
INSERT [Titles] VALUES (N'Life Without Fear', 3, 7.0000)
INSERT [Titles] VALUES (N'Prolonged Data Deprivation: Four Case Studies', 4, 19.9900)
INSERT [Titles] VALUES (N'Emotional Security: A New Algorithm', 2, 7.9900)
INSERT [Titles] VALUES (N'Onions, Leeks, and Garlic: Cooking Secrets of the Mediterranean', 1, 20.9500)
INSERT [Titles] VALUES (N'Fifty Years in Buckingham Palace Kitchens', 4, 11.9500)
INSERT [Titles] VALUES (N'Sushi, Anyone?', 6, 14.9900)
GO



/****** Object: Table [TitleAuthor] ******/

CREATE TABLE [TitleAuthor](
	[TitleID] [int] NOT NULL,
	[AuthorID] [int] NOT NULL,
	CONSTRAINT [PK_TitleAuthor] PRIMARY KEY CLUSTERED 
	(
		[TitleID] ASC,
		[AuthorID] ASC
	),
	CONSTRAINT [FK_TitleAuthor_Titles] FOREIGN KEY([TitleID])
REFERENCES [Titles]([TitleID]),
	CONSTRAINT [FK_TitleAuthor_Authors] FOREIGN KEY([AuthorID])
REFERENCES [Authors]([AuthorID])
)
GO

INSERT [TitleAuthor] VALUES (1, 1)
INSERT [TitleAuthor] VALUES (2, 2)
INSERT [TitleAuthor] VALUES (3, 2)
INSERT [TitleAuthor] VALUES (4, 3)
INSERT [TitleAuthor] VALUES (5, 4)
INSERT [TitleAuthor] VALUES (6, 4)
INSERT [TitleAuthor] VALUES (7, 5)
INSERT [TitleAuthor] VALUES (2, 6)
INSERT [TitleAuthor] VALUES (8, 7)
INSERT [TitleAuthor] VALUES (6, 8)
INSERT [TitleAuthor] VALUES (9, 9)
INSERT [TitleAuthor] VALUES (10, 9)
INSERT [TitleAuthor] VALUES (11, 10)
INSERT [TitleAuthor] VALUES (6, 11)
INSERT [TitleAuthor] VALUES (12, 12)
INSERT [TitleAuthor] VALUES (13, 12)
INSERT [TitleAuthor] VALUES (5, 5)
INSERT [TitleAuthor] VALUES (14, 5)
INSERT [TitleAuthor] VALUES (14, 1)
INSERT [TitleAuthor] VALUES (15, 2)
INSERT [TitleAuthor] VALUES (8, 3)
INSERT [TitleAuthor] VALUES (13, 8)
INSERT [TitleAuthor] VALUES (16, 8)
INSERT [TitleAuthor] VALUES (17, 6)
INSERT [TitleAuthor] VALUES (18, 6)
GO
