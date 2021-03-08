CREATE PROCEDURE [dbo].[sp_GetOrdersBySenderEmail]
	@senderEmail NVARCHAR(50)
AS
	EXECUTE AS USER = @senderEmail;
	SELECT * FROM [dbo].[Orders]
	WHERE SenderEmail = @senderEmail
RETURN 0
