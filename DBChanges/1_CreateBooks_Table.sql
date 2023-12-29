USE [RSS ]
GO

/****** Object:  Table [dbo].[Books]    Script Date: 28-12-2023 10:26:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Books]') AND type in (N'U'))
DROP TABLE [dbo].[Books]
GO

/****** Object:  Table [dbo].[Books]    Script Date: 28-12-2023 10:26:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Books](
	[BookId] [uniqueidentifier] NOT NULL,
	[Publisher] [varchar](200) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[AuthorFirstName] [varchar](100) NOT NULL,
	[AuthorLastName] [varchar](100) NOT NULL,
	[PublicationDate] DateTime NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO 
