USE [DataPipeline]
GO
/****** Object:  Table [dbo].[AccountData]    Script Date: 7/15/2022 12:55:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ChargingPartyID] [int] NULL,
	[SortCode] [int] NULL,
	[AccountNumber] [varchar](50) NULL,
	[TINorGHCard] [varchar](50) NULL,
	[PhoneNumber] [varchar](max) NULL,
	[ShortID] [varchar](50) NULL,
	[Unique_Id_Name] [varchar](50) NULL,
 CONSTRAINT [PK_AccountData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerData]    Script Date: 7/15/2022 12:55:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ChargingPartyID] [int] NULL,
	[SortCode] [int] NULL,
	[AccountNumber] [varchar](50) NULL,
	[TINorGHCard] [varchar](50) NULL,
	[PhoneNumber] [varchar](max) NULL,
	[ShortID] [varchar](50) NULL,
	[Unique_Id_Name] [varchar](50) NULL,
 CONSTRAINT [PK_CustomerData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
