USE [UsersAmadeusAirline]
GO
/****** Object:  StoredProcedure [dbo].[SPGetUserByIDAm]    Script Date: 26/09/2024 12:08:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Wilson Camacho>
-- Create date: <25/09/2024>
-- Description:	<Get users of Amadeus Airline by ID>
-- =============================================
ALTER PROCEDURE [dbo].[SPGetUserByIDAm]
	-- Add the parameters for the stored procedure here	
	@IDIdentifier BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT USAMIDIdentifier, USAMName, USAMLastName, USAMEmail, USAMPhoneNumber, USAMDateOfBirthday, USAMSalary
	FROM UsersAmadeus
	WHERE USAMIDIdentifier = @IDIdentifier
END

