USE [RSS ]
GO

/****** Object:  StoredProcedure [dbo].[SpGetPublisher]    Script Date: 29-12-2023 11:48:15 ******/
DROP PROCEDURE [dbo].[SpGetPublisher]
GO

/****** Object:  StoredProcedure [dbo].[SpGetPublisher]    Script Date: 29-12-2023 11:48:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROC [dbo].[SpGetPublisher]
AS
SELECT BookId, 
Title,
Publisher,
AuthorFirstName,
AuthorLastName 
FROM [dbo].[Books] WITH(NOLOCK) 
GO


