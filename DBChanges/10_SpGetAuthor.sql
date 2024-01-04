USE [RSS ]
GO

/****** Object:  StoredProcedure [dbo].[SpGetAuthor]    Script Date: 04-01-2024 19:19:04 ******/
DROP PROCEDURE [dbo].[SpGetAuthor]
GO

/****** Object:  StoredProcedure [dbo].[SpGetAuthor]    Script Date: 04-01-2024 19:19:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROC [dbo].[SpGetAuthor]
(
@sortColumn varchar(100),
@sortOrder varchar(5)
)
AS
DECLARE @SQL NVARCHAR(max) 
if(@sortColumn is not null and @sortOrder is not null and len(@sortOrder) >=3)
begin    
DECLARE @sortColumnMap varchar(100)
DECLARE @sortOrderMap varchar(5) 
	SET @sortColumnMap = @sortColumn
	SET @sortOrderMap = case when @sortOrder = 'asc' then 'asc' else 'desc' end
	SET @SQL= N'SELECT
	AuthorFirstName +'', ''+ AuthorLastName + ''. "'' + Title + ''" <i>''+ ContentTitle +''</i>, '' +  Publisher +'', '' + Convert(varchar,Year(PublicationDate)) + '', pp. '' + PageRange + ''.'' As [Values]
	FROM [dbo].[Books] b WITH(NOLOCK) 
	Inner join [dbo].[BooksContents] bc With(nolock) on bc.BookId = b.BookId 
	Group by b.BookId,Publisher,AuthorLastName,AuthorFirstName,Title,PublicationDate,PageRange,ContentTitle
	order by case  when '''+ @sortColumnMap +'''=''Author'' then AuthorLastName +'',''+ AuthorFirstName   
		when '''+ @sortColumnMap +'''=''Title'' then Title end  '+ @sortOrderMap +''
end
else
begin
SET @SQL= N'SELECT
	AuthorFirstName +'', ''+ AuthorLastName + ''. "'' + Title + ''" <i>''+ ContentTitle +''</i>, ''+  Publisher +'', '' + Convert(varchar,Year(PublicationDate)) + '', pp. '' + PageRange + ''.'' As [Values]
	FROM [dbo].[Books] b WITH(NOLOCK) 
	Inner join [dbo].[BooksContents] bc With(nolock) on bc.BookId = b.BookId 
	Group by b.BookId,Publisher,AuthorLastName,AuthorFirstName,Title,PublicationDate,PageRange,ContentTitle
	order by AuthorLastName +  AuthorFirstName  asc,Title asc'
End
print @SQL
EXEC sp_executesql @SQL
GO


