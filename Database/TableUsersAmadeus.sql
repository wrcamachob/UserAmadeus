USE [UsersAmadeusAirline]
GO

/****** Object:  Table [dbo].[UsersAmadeus]    Script Date: 26/09/2024 5:04:16 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UsersAmadeus](
	[USAMIDIdentifier] [bigint] NOT NULL,
	[USAMName] [varchar](50) NOT NULL,
	[USAMLastName] [varchar](50) NOT NULL,
	[USAMEmail] [varchar](200) NULL,
	[USAMPhoneNumber] [bigint] NULL,
	[USAMDateOfBirthday] [date] NULL,
	[USAMSalary] [numeric](18, 0) NULL,
 CONSTRAINT [PK_UsersAmadeus] PRIMARY KEY CLUSTERED 
(
	[USAMIDIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


