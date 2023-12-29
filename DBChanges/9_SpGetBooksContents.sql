USE [RSS ]
GO

/****** Object:  StoredProcedure [dbo].[SpGetBooksContents]    Script Date: 29-12-2023 11:48:27 ******/
DROP PROCEDURE [dbo].[SpGetBooksContents]
GO

/****** Object:  StoredProcedure [dbo].[SpGetBooksContents]    Script Date: 29-12-2023 11:48:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROC [dbo].[SpGetBooksContents]
AS
SELECT bc.BookId,
bc.ContentOrder,
bc.ContentTitle,
bc.ContentTitleUrl,
bc.PageRange 
FROM [dbo].[BooksContents] AS bc WITH(NOLOCK) 
JOIN [dbo].[Books] As b  WITH(NOLOCK) ON b.BookId = bc.BookId
GO


