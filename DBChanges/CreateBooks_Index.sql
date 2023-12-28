USE [RSS ]
GO

SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_Publisher_Title_Author]    Script Date: 28-12-2023 10:27:10 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Publisher_Title_Author] ON [dbo].[Books]
(
	[Publisher] ASC,
	[Title] ASC,
	[AuthorFirstName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

/****** Object:  Index [IX_Title_Author]    Script Date: 28-12-2023 10:27:10 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Title_Author] ON [dbo].[Books]
( 
	[Title] ASC,
	[AuthorFirstName] ASC,
	[AuthorLastName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

