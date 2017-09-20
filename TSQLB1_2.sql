USE ONLINE_SHOP
GO

/*
 * Câu 1: Viết stored-procedure tính tổng 2 số a, b và in kết quả
 */
IF OBJECT_ID('uspCau1', 'P') IS NOT NULL
	DROP PROC uspCau1
GO
 
CREATE PROC uspCau1
	@a float = 0, -- default
	@b float = 0,
	@tong float OUT -- OUTPUT
AS
	--RETURN (@a + @b)
	SET @tong = @a + @b;
GO

-- Gọi
DECLARE @x float = 3.2, @y float = 5.4, @tong float = 0
EXEC uspCau1 @x, @y, @tong OUT
PRINT CAST(@x AS varchar) + ' + ' +
	CAST(@y AS varchar) + ' = ' +
	CAST(@tong AS varchar) 


/* 
 * Cau 2
 */
 CREATE PROC uspCau2
 
 AS
	-- ...
 GO
