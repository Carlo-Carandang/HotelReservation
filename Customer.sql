USE [HotelReserv]
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 2017-10-29 8:23:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[StreetNumber] [varchar](10) NOT NULL,
	[StreetName] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Province] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[PostalCode] [varchar](10) NOT NULL,
	[PhoneNumber] [varchar](10) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[CreditCardType] [varchar](50) NOT NULL,
	[CreditCardNumber] [varchar](50) NOT NULL,
	[CreditCardName] [varchar](50) NOT NULL,
	[ExpirationDate] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

