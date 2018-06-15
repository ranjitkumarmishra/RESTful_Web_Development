USE [project1]
GO

ALTER TABLE [dbo].[creditinfo] DROP CONSTRAINT [FK_creditinfo_reservation]
GO

ALTER TABLE [dbo].[creditinfo] DROP CONSTRAINT [FK_creditinfo_contact]
GO

/****** Object:  Table [dbo].[creditinfo]    Script Date: 2018-03-08 5:22:00 PM ******/
DROP TABLE [dbo].[creditinfo]
GO

/****** Object:  Table [dbo].[creditinfo]    Script Date: 2018-03-08 5:22:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[creditinfo](
	[cId] [int] NOT NULL,
	[creditId] [int] IDENTITY(1,1) NOT NULL,
	[bId] [int] NOT NULL,
	[cardType] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[cardNumber] [varchar](50) NOT NULL,
	[expDate] [date] NOT NULL,
 CONSTRAINT [PK_creditinfo] PRIMARY KEY CLUSTERED 
(
	[creditId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[creditinfo]  WITH CHECK ADD  CONSTRAINT [FK_creditinfo_contact] FOREIGN KEY([cId])
REFERENCES [dbo].[contact] ([cId])
GO

ALTER TABLE [dbo].[creditinfo] CHECK CONSTRAINT [FK_creditinfo_contact]
GO

ALTER TABLE [dbo].[creditinfo]  WITH CHECK ADD  CONSTRAINT [FK_creditinfo_reservation] FOREIGN KEY([bId])
REFERENCES [dbo].[reservation] ([bId])
GO

ALTER TABLE [dbo].[creditinfo] CHECK CONSTRAINT [FK_creditinfo_reservation]
GO


