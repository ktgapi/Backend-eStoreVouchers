CREATE PROCEDURE [dbo].[sp_InsertOrder]
	@recipientName NVARCHAR(50),
	@recipientEmail NVARCHAR(50),
	@senderName NVARCHAR(50),
	@senderEmail NVARCHAR(50),
	@dedication NVARCHAR(MAX) = NULL,
	@voucher NVARCHAR(50),
	@orderDate DATETIME
AS
	INSERT INTO
		[dbo].[Orders] ([RecipientName], [RecipientEmail], [SenderName], [SenderEmail], [Dedication], [Voucher], [OrderDate])
	VALUES
		(@recipientName, @recipientEmail, @senderName, @senderEmail, @dedication, @voucher, @orderDate)

	IF DATABASE_PRINCIPAL_ID(@senderEmail) IS NULL
	BEGIN
		DECLARE @QUERY NVARCHAR(MAX);

		SET @QUERY = 'CREATE USER "' + @senderEmail + '" WITHOUT LOGIN;' +
						'GRANT SELECT ON [dbo].[Orders] TO "' + @senderEmail + '";' +
						'GRANT SELECT ON [dbo].[fn_RowLevelSecurity] TO "' + @senderEmail + '";';

		EXEC(@QUERY);
	END

RETURN 0
