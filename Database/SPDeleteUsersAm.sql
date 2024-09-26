-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Wilson Camacho>
-- Create date: <25/09/2024>
-- Description:	<Delete users by ID of Amadeus Airline>
-- =============================================
CREATE PROCEDURE [dbo].[SPDeleteUsersAm]
	-- Add the parameters for the stored procedure here
	@IDIdentifier BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM UsersAmadeus
	WHERE USAMIDIdentifier = @IDIdentifier
END

