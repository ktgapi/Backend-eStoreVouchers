CREATE TABLE [dbo].[Orders]
(
	[OrderId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RecipientName] NVARCHAR(50) NOT NULL, 
    [RecipientEmail] NVARCHAR(50) NOT NULL, 
    [SenderName] NVARCHAR(50) NOT NULL, 
    [SenderEmail] NVARCHAR(50) NOT NULL, 
    [Dedication] NVARCHAR(MAX) NULL, 
    [Voucher] NVARCHAR(50) NOT NULL, 
    [OrderDate] DATETIME NOT NULL
)
