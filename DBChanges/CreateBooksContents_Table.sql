USE [RSS ]
GO

ALTER TABLE [dbo].[BooksContents] DROP CONSTRAINT [FK_BookId]
GO

/****** Object:  Table [dbo].[BooksContents]    Script Date: 28-12-2023 11:24:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BooksContents]') AND type in (N'U'))
DROP TABLE [dbo].[BooksContents]
GO

/****** Object:  Table [dbo].[BooksContents]    Script Date: 28-12-2023 11:24:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BooksContents](
	[BookId] [uniqueidentifier] NULL,
	[ContentOrder] [int] NOT NULL,
	[ContentTitle] [varchar](100) NOT NULL,
	[ContentTitleUrl] [varchar](200) NOT NULL,
	[PageRange] [varchar](20) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BooksContents]  WITH CHECK ADD  CONSTRAINT [FK_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([BookId])
GO

ALTER TABLE [dbo].[BooksContents] CHECK CONSTRAINT [FK_BookId]
GO


