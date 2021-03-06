USE [DocManagement]
GO
/****** Object:  Table [dbo].[Document]    Script Date: 5/30/2022 7:10:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Keyword]    Script Date: 5/30/2022 7:10:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Keyword](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Keyword] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mapping]    Script Date: 5/30/2022 7:10:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mapping](
	[MappingID] [int] IDENTITY(1,1) NOT NULL,
	[DocumentID] [int] NOT NULL,
	[KeywordID] [int] NOT NULL,
 CONSTRAINT [PK_Mapping_1] PRIMARY KEY CLUSTERED 
(
	[MappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Document] ON 

INSERT [dbo].[Document] ([ID], [Name]) VALUES (1, N'Document 1')
INSERT [dbo].[Document] ([ID], [Name]) VALUES (2, N'Document 2')
INSERT [dbo].[Document] ([ID], [Name]) VALUES (3, N'Document 3')
INSERT [dbo].[Document] ([ID], [Name]) VALUES (4, N'Document 4')
INSERT [dbo].[Document] ([ID], [Name]) VALUES (5, N'Document 5')
INSERT [dbo].[Document] ([ID], [Name]) VALUES (6, N'Document 6')
INSERT [dbo].[Document] ([ID], [Name]) VALUES (7, N'Document 7')
INSERT [dbo].[Document] ([ID], [Name]) VALUES (8, N'Document 8')
INSERT [dbo].[Document] ([ID], [Name]) VALUES (9, N'Document 9')
SET IDENTITY_INSERT [dbo].[Document] OFF
GO
SET IDENTITY_INSERT [dbo].[Keyword] ON 

INSERT [dbo].[Keyword] ([ID], [Name]) VALUES (1, N'Products')
INSERT [dbo].[Keyword] ([ID], [Name]) VALUES (2, N'Accessories')
INSERT [dbo].[Keyword] ([ID], [Name]) VALUES (3, N'Promoted documents')
SET IDENTITY_INSERT [dbo].[Keyword] OFF
GO
SET IDENTITY_INSERT [dbo].[Mapping] ON 

INSERT [dbo].[Mapping] ([MappingID], [DocumentID], [KeywordID]) VALUES (4, 1, 1)
INSERT [dbo].[Mapping] ([MappingID], [DocumentID], [KeywordID]) VALUES (5, 2, 3)
INSERT [dbo].[Mapping] ([MappingID], [DocumentID], [KeywordID]) VALUES (6, 3, 3)
INSERT [dbo].[Mapping] ([MappingID], [DocumentID], [KeywordID]) VALUES (7, 3, 1)
INSERT [dbo].[Mapping] ([MappingID], [DocumentID], [KeywordID]) VALUES (8, 2, 1)
SET IDENTITY_INSERT [dbo].[Mapping] OFF
GO
ALTER TABLE [dbo].[Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Mapping_Document] FOREIGN KEY([DocumentID])
REFERENCES [dbo].[Document] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Mapping] CHECK CONSTRAINT [FK_Mapping_Document]
GO
ALTER TABLE [dbo].[Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Mapping_Keyword] FOREIGN KEY([KeywordID])
REFERENCES [dbo].[Keyword] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Mapping] CHECK CONSTRAINT [FK_Mapping_Keyword]
GO
/****** Object:  StoredProcedure [dbo].[DocManagment_SP_Delete_Mapping]    Script Date: 5/30/2022 7:10:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[DocManagment_SP_Delete_Mapping]
@MappingID int
as

Delete from Mapping
Where
MappingID=@MappingID
exec DocManagment_SP_Select_Mappings
GO
/****** Object:  StoredProcedure [dbo].[DocManagment_SP_Insert_Keyword]    Script Date: 5/30/2022 7:10:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DocManagment_SP_Insert_Keyword]
@Name nvarchar(50)
as
Insert into keyword
(name) 
values
(@Name)

select * from Keyword
GO
/****** Object:  StoredProcedure [dbo].[DocManagment_SP_Insert_Mapping]    Script Date: 5/30/2022 7:10:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DocManagment_SP_Insert_Mapping]
 
@DocumentID int,
@KeywordID int
as

insert into Mapping
(DocumentID,KeywordID)
values
(@DocumentID,@KeywordID)
exec DocManagment_SP_Select_Mappings
GO
/****** Object:  StoredProcedure [dbo].[DocManagment_SP_Select_Documents]    Script Date: 5/30/2022 7:10:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DocManagment_SP_Select_Documents]
as
Select * From [dbo].[Document]
order by 
name
GO
/****** Object:  StoredProcedure [dbo].[DocManagment_SP_Select_Keywords]    Script Date: 5/30/2022 7:10:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DocManagment_SP_Select_Keywords]
as
Select * From [dbo].[Keyword]
order by 
name
GO
/****** Object:  StoredProcedure [dbo].[DocManagment_SP_Select_Mappings]    Script Date: 5/30/2022 7:10:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DocManagment_SP_Select_Mappings]
as
Select mapping.DocumentID,Mapping.KeywordID,Mapping.MappingID, Document.Name as DocumentName, Keyword.Name as KeywordName
from
Mapping mapping
inner join
Keyword on Keyword.ID=Mapping.KeywordID
inner join 
Document Document
on
Document.ID = mapping.DocumentID
GO
/****** Object:  StoredProcedure [dbo].[DocManagment_SP_Select_Mappings_By_Keyword]    Script Date: 5/30/2022 7:10:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DocManagment_SP_Select_Mappings_By_Keyword]
@KeywordID int
as
Select mapping.DocumentID,Mapping.KeywordID,Mapping.MappingID, Document.Name as DocumentName, Keyword.Name as KeywordName
from
Mapping mapping
inner join
Keyword on Keyword.ID=Mapping.KeywordID
inner join 
Document Document
on
Document.ID = mapping.DocumentID
Where
Keyword.ID=@KeywordID
GO
/****** Object:  StoredProcedure [dbo].[DocManagment_SP_Update_Mapping]    Script Date: 5/30/2022 7:10:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DocManagment_SP_Update_Mapping]
@MappingID int,
@DocumentID int,
@KeywordID int
as
update
[dbo].[Mapping]
set
DocumentID=@DocumentID,
KeywordID=@KeywordID
Where
MappingID=@MappingID

exec DocManagment_SP_Select_Mappings
GO
