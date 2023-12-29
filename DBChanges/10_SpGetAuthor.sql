USE [RSS ]
GO

/****** Object:  StoredProcedure [dbo].[SpGetAuthor]    Script Date: 29-12-2023 11:48:36 ******/
DROP PROCEDURE [dbo].[SpGetAuthor]
GO

/****** Object:  StoredProcedure [dbo].[SpGetAuthor]    Script Date: 29-12-2023 11:48:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[SpGetAuthor]
AS
SELECT BookId, 
Title,
AuthorFirstName,
AuthorLastName 
FROM [dbo].[Books] WITH(NOLOCK) 
GO


