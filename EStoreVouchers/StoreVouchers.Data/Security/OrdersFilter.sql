CREATE SECURITY POLICY [OrdersFilter]
ADD FILTER PREDICATE [dbo].[fn_RowLevelSecurity]([SenderEmail]) 
ON [dbo].[Orders]
WITH (STATE = ON);