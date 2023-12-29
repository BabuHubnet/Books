USE [RSS ]
GO

/****** Object:  StoredProcedure [dbo].[SpGetBooks]    Script Date: 29-12-2023 11:44:30 ******/
DROP PROCEDURE [dbo].[SpGetBooks]
GO

/****** Object:  StoredProcedure [dbo].[SpGetBooks]    Script Date: 29-12-2023 11:44:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROC [dbo].[SpGetBooks]
AS
SELECT BookId,
Publisher,
Title,
AuthorFirstName,
AuthorLastName,
PublicationDate,
Price 
FROM [dbo].[Books] WITH(NOLOCK) 
GO

