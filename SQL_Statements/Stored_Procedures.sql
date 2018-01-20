--Procedures for table OFFICE_SUPPLIES

GO
CREATE PROCEDURE AddOfficeSupply
(
	@SupplyName NVARCHAR(50),
	@SupplyDescription NVARCHAR(250),
	@SupplyAmount INT,
	@SupplyUnit NVARCHAR(30),
	@Building NVARCHAR(30),
	@CategoryTitle NVARCHAR(30)
)
AS
BEGIN
	INSERT INTO OFFICE_SUPPLIES(SupplyName, SupplyDescription, SupplyAmount, SupplyUnit, Building, CategoryTitle)
	VALUES (@SupplyName, @SupplyDescription, @SupplyAmount, @SupplyUnit, @Building, @CategoryTitle) 
END

GO
CREATE PROCEDURE DeleteOfficeSupply
(
	@SupplyID INT,
)
AS
BEGIN
	DELETE FROM OFFICE_SUPPLIES
	WHERE SupplyID = @SupplyID
END

GO
CREATE PROCEDURE EditOfficeSupply
(
	@SupplyID INT,
	@SupplyName NVARCHAR(50),
	@SupplyDescription NVARCHAR(250),
	@SupplyAmount INT,
	@SupplyUnit NVARCHAR(30),
	@Building NVARCHAR(30),
	@CategoryTitle NVARCHAR(30)
)
AS
UPDATE
OFFICE_SUPPLIES 
SET SupplyName = LTRIM(RTRIM(@SupplyName)), SupplyDescription = @SupplyDescription, SupplyAmount = @SupplyAmount, SupplyUnit = @SupplyUnit, Building = @Building, CategoryTitle = @CategoryTitle
WHERE SupplyID = @SupplyID

GO
CREATE PROCEDURE SeeOfficeSupplies
AS
BEGIN
	SELECT * FROM OFFICE_SUPPLIES
END

--Procedures for table OFFICE_SUPPLIES_COUNT

GO
CREATE PROCEDURE CountSupply
(
	@CountAmount INT,
	@CountMonth NVARCHAR(20),
	@CountYear NVARCHAR(10),
	@SupplyID INT
)
AS
BEGIN
	INSERT INTO OFFICE_SUPPLIES_COUNT (CountAmount, CountMonth, CountYear, SupplyID)
	VALUES (@CountAmount, @CountMonth, @CountYear, @SupplyID)
END

--Procedures for table OFFICE_SUPPLIES_REPOSITORY

GO
CREATE PROCEDURE AddCategoryTitle
(
	@CategoryTitle NVARCHAR(30)
)
AS
BEGIN
	INSERT INTO OFFICE_SUPPLIES_REPOSITORY (CategoryTitle)
	VALUES (@CategoryTitle)
END

GO
CREATE PROCEDURE DeleteCategory
(
	@CategoryTitle NVARCHAR(50)
)
AS
BEGIN
	DELETE FROM OFFICE_SUPPLIES_REPOSITORY
	WHERE @CategoryTitle = CategoryTitle
END

GO
CREATE PROCEDURE SeeSupplyCategory
AS
BEGIN
	SELECT * FROM OFFICE_SUPPLIES_REPOSITORY
END