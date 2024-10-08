USE [UsersAmadeusAirline]
GO
/****** Object:  StoredProcedure [dbo].[SPGetAllUsersAm]    Script Date: 26/09/2024 12:09:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Wilson Camacho>
-- Create date: <25/09/2024>
-- Description:	<Get all users of Amadeus Airline>
-- =============================================
ALTER PROCEDURE [dbo].[SPGetAllUsersAm]
	-- Add the parameters for the stored procedure here	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT USAMIDIdentifier, USAMName, USAMLastName, USAMEmail, USAMPhoneNumber, USAMDateOfBirthday, USAMSalary
	FROM UsersAmadeus
END
