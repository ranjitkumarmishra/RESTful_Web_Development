USE [project1]
GO

/****** Object:  Table [dbo].[reservation]    Script Date: 2018-03-08 5:22:10 PM ******/
DROP TABLE [dbo].[reservation]
GO

/****** Object:  Table [dbo].[reservation]    Script Date: 2018-03-08 5:22:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[reservation](
	[bId] [int] IDENTITY(1,1) NOT NULL,
	[checkInDate] [date] NOT NULL,
	[checkOutDate] [date] NOT NULL,
	[noOfGuest] [int] NOT NULL,
	[noOfRooms] [int] NOT NULL,
 CONSTRAINT [PK_reservation] PRIMARY KEY CLUSTERED 
(
	[bId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


