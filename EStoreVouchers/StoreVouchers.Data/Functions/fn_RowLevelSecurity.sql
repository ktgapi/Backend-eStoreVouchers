CREATE FUNCTION [dbo].[fn_RowLevelSecurity](@SenderEmail AS sysname)
	RETURNS TABLE
WITH SCHEMABINDING
AS
	RETURN SELECT 1 as fn_RowLevelSecurity_result
WHERE @SenderEmail = user_name(); 
