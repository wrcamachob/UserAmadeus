USE [UsersAmadeusAirline]
GO
/****** Object:  StoredProcedure [dbo].[SPUpdateUsersAm]    Script Date: 26/09/2024 12:11:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Wilson Camacho>
-- Create date: <25/09/2024>
-- Description:	<Modify users by ID of Amadeus Airline>
-- =============================================
ALTER PROCEDURE [dbo].[SPUpdateUsersAm]
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

    -- Insert statements for procedure here
	UPDATE UsersAmadeus
	SET USAMName = @Name,
	    USAMLastName = @LastName,
		USAMEmail = @Email,
		USAMPhoneNumber = @PhoneNumber,
		USAMDateOfBirthday = @DateOfBirthday,
		USAMSalary = @Salary
	WHERE USAMIDIdentifier = @IDIdentifier
END
