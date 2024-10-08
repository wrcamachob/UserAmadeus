USE [UsersAmadeusAirline]
GO
/****** Object:  StoredProcedure [dbo].[SPInsertUsersAm]    Script Date: 26/09/2024 12:10:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Wilson Camacho>
-- Create date: <25/09/2024>
-- Description:	<Insert users of Amadeus Airline>
-- =============================================
ALTER PROCEDURE [dbo].[SPInsertUsersAm] 
	-- Add the parameters for the stored procedure here
	@IDIdentifier BIGINT, 
	@Name VARCHAR(50),
	@LastName VARCHAR(50),
	@Email VARCHAR(200),
	@PhoneNumber BIGINT,
	@DateOfBirthday DATE,
	@Salary NUMERIC(18,0)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO UsersAmadeus(USAMIDIdentifier, USAMName, USAMLastName, USAMEmail, USAMPhoneNumber, USAMDateOfBirthday, USAMSalary)
	VALUES(@IDIdentifier, @Name, @LastName, @Email, @PhoneNumber, @DateOfBirthday, @Salary)
END
