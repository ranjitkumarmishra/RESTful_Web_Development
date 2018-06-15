USE [project1]
GO

ALTER TABLE [dbo].[contact] DROP CONSTRAINT [FK_contact_reservation]
GO

/****** Object:  Table [dbo].[contact]    Script Date: 2018-03-08 5:21:18 PM ******/
DROP TABLE [dbo].[contact]
GO

/****** Object:  Table [dbo].[contact]    Script Date: 2018-03-08 5:21:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[contact](
	[cId] [int] IDENTITY(1,1) NOT NULL,
	[bId] [int] NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[StreetNumber] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Province] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[PostalCode] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_contact] PRIMARY KEY CLUSTERED 
(
	[cId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[contact]  WITH CHECK ADD  CONSTRAINT [FK_contact_reservation] FOREIGN KEY([bId])
REFERENCES [dbo].[reservation] ([bId])
GO

ALTER TABLE [dbo].[contact] CHECK CONSTRAINT [FK_contact_reservation]
GO


