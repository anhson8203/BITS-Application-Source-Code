CREATE DATABASE [RestaurantManagement]
GO

USE RestaurantManagement
GO

CREATE USER [user] FOR LOGIN [user] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [user]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [user]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [user]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [user]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [user]
GO
ALTER ROLE [db_datareader] ADD MEMBER [user]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [user]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[UserName] [nvarchar](100) NOT NULL,
	[Display_Name] [nvarchar](100) NOT NULL,
	[PassWord] [nvarchar](1000) NOT NULL,
	[type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Table_ID] [int] NOT NULL,
	[Date_In] [datetime] NOT NULL,
	[Date_Out] [datetime] NULL,
	[status] [int] NOT NULL,
	[discount] [int] NULL,
	[Total_Cost] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill_Info](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Bill_ID] [int] NOT NULL,
	[Items_ID] [int] NOT NULL,
	[quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer_Table](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[status] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Category_ID] [int] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[price] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items_Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT [dbo].[Account] ([UserName], [Display_Name], [PassWord], [type]) VALUES (N'admin', N'Admin', N'1962026656160185351301320480154111117132155', 1)
GO
SET IDENTITY_INSERT [dbo].[Customer_Table] ON 

INSERT [dbo].[Customer_Table] ([ID], [name], [status]) VALUES (1, N'Table 1', N'Empty')
INSERT [dbo].[Customer_Table] ([ID], [name], [status]) VALUES (2, N'Table 2', N'Empty')
INSERT [dbo].[Customer_Table] ([ID], [name], [status]) VALUES (3, N'Table 3', N'Empty')
INSERT [dbo].[Customer_Table] ([ID], [name], [status]) VALUES (4, N'Table 4', N'Empty')
INSERT [dbo].[Customer_Table] ([ID], [name], [status]) VALUES (5, N'Table 5', N'Empty')
INSERT [dbo].[Customer_Table] ([ID], [name], [status]) VALUES (6, N'Table 6', N'Empty')
INSERT [dbo].[Customer_Table] ([ID], [name], [status]) VALUES (7, N'Table 7', N'Empty')
INSERT [dbo].[Customer_Table] ([ID], [name], [status]) VALUES (8, N'Table 8', N'Empty')
INSERT [dbo].[Customer_Table] ([ID], [name], [status]) VALUES (9, N'Table 9', N'Empty')
INSERT [dbo].[Customer_Table] ([ID], [name], [status]) VALUES (10, N'Table 10', N'Empty')
INSERT [dbo].[Customer_Table] ([ID], [name], [status]) VALUES (11, N'Table 11', N'Empty')
INSERT [dbo].[Customer_Table] ([ID], [name], [status]) VALUES (12, N'Table 12', N'Empty')
INSERT [dbo].[Customer_Table] ([ID], [name], [status]) VALUES (13, N'Table 13', N'Empty')
INSERT [dbo].[Customer_Table] ([ID], [name], [status]) VALUES (14, N'Table 14', N'Empty')
INSERT [dbo].[Customer_Table] ([ID], [name], [status]) VALUES (15, N'Table 15', N'Empty')
INSERT [dbo].[Customer_Table] ([ID], [name], [status]) VALUES (16, N'Table 16', N'Empty')
INSERT [dbo].[Customer_Table] ([ID], [name], [status]) VALUES (17, N'Table 17', N'Empty')
INSERT [dbo].[Customer_Table] ([ID], [name], [status]) VALUES (18, N'Table 18', N'Empty')
INSERT [dbo].[Customer_Table] ([ID], [name], [status]) VALUES (19, N'Table 19', N'Empty')
INSERT [dbo].[Customer_Table] ([ID], [name], [status]) VALUES (20, N'Table 20', N'Empty')
INSERT [dbo].[Customer_Table] ([ID], [name], [status]) VALUES (21, N'Table 21', N'Empty')
INSERT [dbo].[Customer_Table] ([ID], [name], [status]) VALUES (22, N'Table 22', N'Empty')
INSERT [dbo].[Customer_Table] ([ID], [name], [status]) VALUES (23, N'Table 23', N'Empty')
INSERT [dbo].[Customer_Table] ([ID], [name], [status]) VALUES (24, N'Table 24', N'Empty')
SET IDENTITY_INSERT [dbo].[Customer_Table] OFF
GO
SET IDENTITY_INSERT [dbo].[Items] ON 

INSERT [dbo].[Items] ([ID], [Category_ID], [name], [price]) VALUES (2, 1, N'Oysters Rockefeller', 59.99)
INSERT [dbo].[Items] ([ID], [Category_ID], [name], [price]) VALUES (3, 1, N'Clam Chowder', 34.99)
INSERT [dbo].[Items] ([ID], [Category_ID], [name], [price]) VALUES (4, 1, N'Eggplant Lasagne', 44.99)
INSERT [dbo].[Items] ([ID], [Category_ID], [name], [price]) VALUES (5, 1, N'Grilled Salmon', 54.99)
INSERT [dbo].[Items] ([ID], [Category_ID], [name], [price]) VALUES (6, 1, N'Eggplant Lasagne', 29.99)
INSERT [dbo].[Items] ([ID], [Category_ID], [name], [price]) VALUES (7, 3, N'Chips', 9.99)
INSERT [dbo].[Items] ([ID], [Category_ID], [name], [price]) VALUES (8, 3, N'Mixed Green Salad', 9.99)
INSERT [dbo].[Items] ([ID], [Category_ID], [name], [price]) VALUES (9, 3, N'Garlac Bread', 9.99)
INSERT [dbo].[Items] ([ID], [Category_ID], [name], [price]) VALUES (10, 2, N'Sprite', 2.99)
INSERT [dbo].[Items] ([ID], [Category_ID], [name], [price]) VALUES (11, 2, N'Coke', 2.99)
INSERT [dbo].[Items] ([ID], [Category_ID], [name], [price]) VALUES (12, 2, N'Redbull', 2.99)
INSERT [dbo].[Items] ([ID], [Category_ID], [name], [price]) VALUES (13, 2, N'Aquafina', 1.99)
INSERT [dbo].[Items] ([ID], [Category_ID], [name], [price]) VALUES (14, 2, N'Chivas', 59.99)
INSERT [dbo].[Items] ([ID], [Category_ID], [name], [price]) VALUES (15, 2, N'Johnnie Walker', 59.99)
INSERT [dbo].[Items] ([ID], [Category_ID], [name], [price]) VALUES (16, 2, N'Ballantine’s Scotch Whisky', 59.99)
INSERT [dbo].[Items] ([ID], [Category_ID], [name], [price]) VALUES (17, 4, N'Apple Pie', 14.99)
INSERT [dbo].[Items] ([ID], [Category_ID], [name], [price]) VALUES (18, 4, N'Ice Cream', 3.99)
INSERT [dbo].[Items] ([ID], [Category_ID], [name], [price]) VALUES (20, 2, N'Pepsi', 2.99)
INSERT [dbo].[Items] ([ID], [Category_ID], [name], [price]) VALUES (23, 1, N'Palak Paneer', 19.99)
INSERT [dbo].[Items] ([ID], [Category_ID], [name], [price]) VALUES (24, 3, N'Mushroom Salad', 4.99)
INSERT [dbo].[Items] ([ID], [Category_ID], [name], [price]) VALUES (26, 3, N'Mushroom Soup', 19.99)
INSERT [dbo].[Items] ([ID], [Category_ID], [name], [price]) VALUES (28, 1, N'Crab Cakes', 29.99)
SET IDENTITY_INSERT [dbo].[Items] OFF
GO
SET IDENTITY_INSERT [dbo].[Items_Category] ON 

INSERT [dbo].[Items_Category] ([ID], [name]) VALUES (1, N'Main Course')
INSERT [dbo].[Items_Category] ([ID], [name]) VALUES (2, N'Beverages')
INSERT [dbo].[Items_Category] ([ID], [name]) VALUES (3, N'Appetizers')
INSERT [dbo].[Items_Category] ([ID], [name]) VALUES (4, N'Dessert')
SET IDENTITY_INSERT [dbo].[Items_Category] OFF
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT (N'User') FOR [Display_Name]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((1)) FOR [PassWord]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [type]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT (getdate()) FOR [Date_In]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[Bill_Info] ADD  DEFAULT ((0)) FOR [quantity]
GO
ALTER TABLE [dbo].[Customer_Table] ADD  DEFAULT (N'Not Named Yet') FOR [name]
GO
ALTER TABLE [dbo].[Customer_Table] ADD  DEFAULT (N'Empty') FOR [status]
GO
ALTER TABLE [dbo].[Items] ADD  DEFAULT (N'Not Named Yet') FOR [name]
GO
ALTER TABLE [dbo].[Items] ADD  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[Items_Category] ADD  DEFAULT (N'Not Named Yet') FOR [name]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([Table_ID])
REFERENCES [dbo].[Customer_Table] ([ID])
GO
ALTER TABLE [dbo].[Bill_Info]  WITH CHECK ADD FOREIGN KEY([Bill_ID])
REFERENCES [dbo].[Bill] ([ID])
GO
ALTER TABLE [dbo].[Bill_Info]  WITH CHECK ADD FOREIGN KEY([Items_ID])
REFERENCES [dbo].[Items] ([ID])
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD FOREIGN KEY([Category_ID])
REFERENCES [dbo].[Items_Category] ([ID])
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetAccountByUserName]
@userName nvarchar(100)
AS
BEGIN
	SELECT * FROM Account WHERE UserName = @userName
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetBillByDateAndPage]
@checkIn datetime, @checkOut datetime, @page INT
AS
BEGIN
	DECLARE @pageRows INT = 10
	DECLARE @selectedRows INT = @pageRows
	DECLARE @exceptedRows INT = (@page - 1) * @pageRows

	;WITH Show_Bill AS (SELECT Bill.ID, Customer_Table.name AS [Table], Bill.Total_Cost AS [Total Cost], Date_In AS [Date In], Date_Out AS [Date Out], discount AS [Discount]
	FROM Bill, Customer_Table
	WHERE Date_In >= @checkIn AND Date_Out <= @checkOut AND Bill.status = 1 AND Customer_Table.ID = Bill.Table_ID AND Bill.Total_Cost > 0)

	SELECT TOP (@selectedRows) * FROM Show_Bill WHERE ID NOT IN (SELECT TOP (@exceptedRows) ID FROM Show_Bill)
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetNumByDate]
@checkIn datetime, @checkOut datetime
AS
BEGIN
	SELECT COUNT(*)
	FROM Bill, Customer_Table
	WHERE Date_In >= @checkIn AND Date_Out <= @checkOut AND Bill.status = 1 AND Customer_Table.ID = Bill.Table_ID AND Bill.Total_Cost > 0
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetTableList]
AS SELECT * FROM Customer_Table
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertBill]
@Table_ID INT
AS
BEGIN
	INSERT Bill (Date_In, Date_Out, Table_ID, status, DISCOUNT) VALUES (GETDATE(), NULL, @Table_ID, 0, 0)
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertBillInfo]
@Bill_ID INT, @Items_ID INT, @quantity INT
AS
BEGIN
	DECLARE @isBillInfoExist INT
	DECLARE @itemCount INT

	SELECT @isBillInfoExist = ID, @itemCount = quantity FROM Bill_Info WHERE Bill_ID = @Bill_ID AND Items_ID = @Items_ID

	IF (@isBillInfoExist > 0)
	BEGIN
		DECLARE @newCount INT = @itemCount + @quantity
		IF (@newCount > 0)
			UPDATE Bill_Info SET quantity = @itemCount + @quantity WHERE Items_ID = @Items_ID
		ELSE
			DELETE Bill_Info WHERE Bill_ID = @Bill_ID AND Items_ID = @Items_ID
	END
	ELSE
	BEGIN
		INSERT Bill_Info (Bill_ID, Items_ID, quantity) VALUES (@Bill_ID, @Items_ID, @quantity)
	END
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_Login]
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM Account WHERE UserName = @userName AND PassWord = @passWord
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_SwitchTable]
@firstTableId INT, @secondTableId INT
AS
BEGIN
	DECLARE @firstBillId INT
	DECLARE @secondBillId INT

	DECLARE @isFirstTableEmpty INT = 1
	DECLARE @isSecondTableEmpty INT = 1

	SELECT @secondBillId = ID FROM Bill WHERE Table_ID = @secondTableId AND status = 0
	SELECT @firstBillId = ID FROM Bill WHERE Table_ID = @firstTableId AND status = 0

	IF (@firstBillId IS NULL)
	BEGIN
		INSERT Bill (Date_In, Date_Out, Table_ID, status) VALUES (GETDATE(), NULL, @firstTableId, 0)
		SELECT @firstBillId = MAX(ID) FROM Bill WHERE Table_ID = @firstTableId AND status = 0
	END

	SELECT @isFirstTableEmpty = COUNT(*) FROM Bill_Info WHERE Bill_ID = @firstBillId

	IF (@secondBillId IS NULL)
	BEGIN
		INSERT Bill (Date_In, Date_Out, Table_ID, status) VALUES (GETDATE(), NULL, @secondTableId, 0)
		SELECT @secondBillId = MAX(ID) FROM Bill WHERE Table_ID = @secondTableId AND status = 0
	END

	SELECT @isSecondTableEmpty = COUNT(*) FROM Bill_Info WHERE Bill_ID = @secondBillId

	SELECT ID INTO Bill_ID_Info FROM Bill_Info WHERE Bill_ID = @secondBillId

	UPDATE Bill_Info SET Bill_ID = @secondBillId WHERE Bill_ID = @firstBillId
	UPDATE Bill_Info SET Bill_ID = @firstBillId WHERE ID IN (SELECT * FROM Bill_ID_Info)

	DROP TABLE Bill_ID_Info

	IF (@isFirstTableEmpty = 0)
		UPDATE Customer_Table SET status = N'Empty' WHERE ID = @secondTableId
	IF (@isSecondTableEmpty = 0)
		UPDATE Customer_Table SET status = N'Empty' WHERE ID = @firstTableId
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_UpdateAccountInfo]
@userName NVARCHAR(100), @displayName NVARCHAR(100), @passWord NVARCHAR(100), @newPassWord NVARCHAR(100)
AS
BEGIN
	DECLARE @isCorrectPass INT

	SELECT @isCorrectPass = COUNT(*) FROM Account WHERE UserName = @userName AND PassWord = @passWord

	IF (@isCorrectPass = 1)
	BEGIN
		IF (@newPassWord = NULL OR @newPassWord = '')
		BEGIN
			UPDATE Account SET Display_Name = @displayName WHERE UserName = @userName
		END
		ELSE
			UPDATE Account SET Display_Name = @displayName, PassWord = @newPassWord WHERE UserName = @userName
	END
END
GO

CREATE TRIGGER [dbo].[UTG_UpdateBill]
ON [dbo].[Bill] FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT
	
	SELECT @idBill = id FROM Inserted	
	
	DECLARE @idTable INT
	
	SELECT @idTable = Table_ID FROM dbo.Bill WHERE id = @idBill
	
	DECLARE @count INT = 0
	
	SELECT @count = COUNT(*) FROM dbo.Bill WHERE Table_ID = @idTable AND status = 0
	
	IF (@count = 0)
		UPDATE dbo.Customer_Table SET status = N'Empty' WHERE id = @idTable
END
GO

ALTER TRIGGER [dbo].[UTG_DeleteBillInfo]
ON [dbo].[Bill_Info] FOR DELETE
AS
BEGIN
	DECLARE @BillInfo_ID INT
	DECLARE @Bill_ID INT
	SELECT @BillInfo_ID = ID, @Bill_ID = deleted.Bill_ID FROM deleted

	DECLARE @Table_ID INT
	SELECT @Table_ID = Table_ID FROM Bill WHERE ID = @Bill_ID

	DECLARE @count INT = 0
	SELECT @count = COUNT(*) FROM Bill_Info, Bill WHERE Bill.ID = Bill_Info.Bill_ID AND Bill.ID = @Bill_ID AND Bill.status = 0

	IF (@count = 0)
		UPDATE Customer_Table SET status = N'Empty' WHERE ID = @Table_ID
END
GO

ALTER TRIGGER [dbo].[UTG_UpdateBillInfo]
ON [dbo].[Bill_Info] FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @Bill_ID INT
	SELECT @Bill_ID = Bill_ID FROM Inserted
	
	DECLARE @Table_ID INT
	SELECT @Table_ID = Table_ID FROM dbo.Bill WHERE ID = @Bill_ID AND status = 0

	DECLARE @countBilInfo INT
	SELECT @countBilInfo = COUNT(*) FROM Bill_Info WHERE Bill_ID = @Bill_ID

	IF (@countBilInfo > 0)
		UPDATE dbo.Customer_Table SET status = N'Occupied' WHERE ID = @Table_ID
	ELSE
		UPDATE dbo.Customer_Table SET status = N'Empty' WHERE ID = @Table_ID
END
GO