USE GuildCars;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'StatesSelectAll')
		DROP PROCEDURE StatesSelectAll;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarMakesSelectAll')
		DROP PROCEDURE CarMakesSelectAll;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarModelsSelectAll')
		DROP PROCEDURE CarModelsSelectAll;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DepartmentsSelectAll')
		DROP PROCEDURE DepartmentsSelectAll;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'TransmissionTypesSelectAll')
		DROP PROCEDURE TransmissionTypesSelectAll;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'BodyStylesSelectAll')
		DROP PROCEDURE BodyStylesSelectAll;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleTypesSelectAll')
		DROP PROCEDURE VehicleTypesSelectAll;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ColorsSelectAll')
		DROP PROCEDURE ColorsSelectAll;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'InteriorColorsSelectAll')
		DROP PROCEDURE InteriorColorsSelectAll;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'PurchaseTypesSelectAll')
		DROP PROCEDURE PurchaseTypesSelectAll;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialsSelectAll')
		DROP PROCEDURE SpecialsSelectAll;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'EmployeesSelectAll')
		DROP PROCEDURE EmployeesSelectAll;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'AddressesSelectAll')
		DROP PROCEDURE AddressesSelectAll;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CustomersSelectAll')
		DROP PROCEDURE CustomersSelectAll;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ContactsSelectAll')
		DROP PROCEDURE ContactsSelectAll;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesSelectAll')
		DROP PROCEDURE VehiclesSelectAll;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'PurchasesSelectAll')
		DROP PROCEDURE PurchasesSelectAll;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'PurchasesSelectById')
		DROP PROCEDURE PurchasesSelectById;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesSelectById')
		DROP PROCEDURE VehiclesSelectById;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ContactsSelectById')
		DROP PROCEDURE ContactsSelectById;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CustomersSelectById')
		DROP PROCEDURE CustomersSelectById;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'AddressesSelectById')
		DROP PROCEDURE AddressesSelectById;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'EmployeesSelectById')
		DROP PROCEDURE EmployeesSelectById;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialsSelectById')
		DROP PROCEDURE SpecialsSelectById;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleTypesSelectById')
		DROP PROCEDURE VehicleTypesSelectById;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'TransmissionTypesSelectById')
		DROP PROCEDURE TransmissionTypesSelectById;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'StatesSelectById')
		DROP PROCEDURE StatesSelectById;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'PurchaseTypesSelectById')
		DROP PROCEDURE PurchaseTypesSelectById;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'InteriorColorsSelectById')
		DROP PROCEDURE InteriorColorsSelectById;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ColorsSelectById')
		DROP PROCEDURE ColorsSelectById;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DepartmentsSelectById')
		DROP PROCEDURE DepartmentsSelectById;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarModelsSelectById')
		DROP PROCEDURE CarModelsSelectById;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarMakesSelectById')
		DROP PROCEDURE CarMakesSelectById;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'BodyStylesSelectById')
		DROP PROCEDURE BodyStylesSelectById;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesSelectAllDetailsByIsSold')
		DROP PROCEDURE VehiclesSelectAllDetailsByIsSold;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesSelectAllDetailsByVehicleTypeId')
		DROP PROCEDURE VehiclesSelectAllDetailsByVehicleTypeId;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'PurchasesSelectAllByEmployeeId')
		DROP PROCEDURE PurchasesSelectAllByEmployeeId;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesSelectAllDetails')
		DROP PROCEDURE VehiclesSelectAllDetails;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SalesReportSelectAllDetails')
		DROP PROCEDURE SalesReportSelectAllDetails;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarModelsInStockSelectAllDetails')
		DROP PROCEDURE CarModelsInStockSelectAllDetails;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarMakesInStockSelectAllDetails')
		DROP PROCEDURE CarMakesInStockSelectAllDetails;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'FeaturedVehicleSelectAllDetails')
		DROP PROCEDURE FeaturedVehicleSelectAllDetails;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'InventoryReportSelectAllDetails')
		DROP PROCEDURE InventoryReportSelectAllDetails;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialsInsert')
		DROP PROCEDURE SpecialsInsert;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CustomersInsert')
		DROP PROCEDURE CustomersInsert;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'EmployeesInsert')
		DROP PROCEDURE EmployeesInsert;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ContactsInsert')
		DROP PROCEDURE ContactsInsert;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CustomersUpdate')
		DROP PROCEDURE CustomersUpdate;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'AddressesInsert')
		DROP PROCEDURE AddressesInsert;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'PurchasesInsert')
		DROP PROCEDURE PurchasesInsert;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarMakesInsert')
		DROP PROCEDURE CarMakesInsert;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarModelsInsert')
		DROP PROCEDURE CarModelsInsert;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesDelete')
		DROP PROCEDURE VehiclesDelete;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesSelectAllDetailsById')
		DROP PROCEDURE VehiclesSelectAllDetailsById;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesInsert')
		DROP PROCEDURE VehiclesInsert;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialsDelete')
		DROP PROCEDURE SpecialsDelete;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UsersSelectAllDetails')
		DROP PROCEDURE UsersSelectAllDetails;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarModelsSelectAllDetails')
		DROP PROCEDURE CarModelsSelectAllDetails;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesUpdate')
		DROP PROCEDURE VehiclesUpdate;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UsersUpdate')
		DROP PROCEDURE UsersUpdate;
GO

CREATE PROCEDURE UsersUpdate (
	@EmployeeId INT,
	@EmailAddress NVARCHAR(256),
	@FirstName NVARCHAR(20),
	@LastName NVARCHAR(20),
	@DepartmentId TINYINT,
	@IsDisabled BIT
) AS
BEGIN
	UPDATE AspNetUsers SET
	Email = @EmailAddress,
	EmailConfirmed = 1,
	UserName = @EmailAddress,
	IsDisabled = @IsDisabled
	WHERE EmployeeId = @EmployeeId;

	UPDATE Employees SET
	FirstName = @FirstName,
	LastName = @LastName,
	DepartmentId = @DepartmentId
	WHERE EmployeeId = @EmployeeId;

	DECLARE @UserId NVARCHAR(128);
	SET @UserId = (SELECT Id FROM AspNetUsers WHERE EmployeeId = @EmployeeId);

	DECLARE @DepartmentName VARCHAR(25);
	SET @DepartmentName = (SELECT [Name] FROM Departments WHERE DepartmentId = @DepartmentId);

	DECLARE @RoleId NVARCHAR(128);
	SET @RoleId = (SELECT Id FROM AspNetRoles WHERE [Name] = @DepartmentName);

	UPDATE AspNetUserRoles SET
	RoleId = @RoleId
	WHERE UserId = @UserId;
END
GO

CREATE PROCEDURE VehiclesUpdate (
	@VehicleId INT,
	@VIN CHAR(17),
	@ModelId INT,
	@ModelYear SMALLINT,
	@Mileage INT,
	@TransmissionTypeId TINYINT,
	@BodyStyleId TINYINT,
	@ColorId TINYINT,
	@InteriorColorId TINYINT,
	@VehicleTypeId TINYINT,
	@Description NVARCHAR(500),
	@ImageFileName NVARCHAR(200),
	@MSRP DECIMAL(8,2),
	@SalePrice DECIMAL(8,2),
	@EmployeeId INT,
	@IsFeatured BIT
) AS
BEGIN
	UPDATE Vehicles SET
	VIN = @VIN,
	ModelId = @ModelId,
	ModelYear = @ModelYear,
	Mileage = @Mileage,
	TransmissionTypeId = @TransmissionTypeId,
	BodyStyleId = @BodyStyleId,
	ColorId = @ColorId,
	InteriorColorId = @InteriorColorId,
	VehicleTypeId = @VehicleTypeId,
	[Description] = @Description,
	ImageFileName = @ImageFileName,
	MSRP = @MSRP,
	SalePrice = @SalePrice,
	EmployeeId = @EmployeeId,
	IsFeatured = @IsFeatured
	WHERE VehicleId = @VehicleId;
END
GO

CREATE PROCEDURE CarModelsSelectAllDetails AS
BEGIN
	SELECT cmak.[Name] AS Make, cmod.[Name] AS Model
	FROM CarModels cmod
		INNER JOIN CarMakes cmak
			ON cmod.MakeId = cmak.MakeId
	ORDER BY Make, Model
END
GO

CREATE PROCEDURE UsersSelectAllDetails AS
BEGIN
	SELECT u.Id AS UserId, e.EmployeeId, e.LastName AS LastName, e.FirstName AS FirstName, u.Email, r.Id AS RoleId, r.[Name] AS [Role]
	FROM AspNetUsers u
		INNER JOIN Employees e
			ON u.EmployeeId = e.EmployeeId
		INNER JOIN AspNetUserRoles ur
			ON u.Id = ur.UserId
		INNER JOIN AspNetRoles r
			ON r.Id = ur.RoleId
	ORDER BY LastName, FirstName
END
GO

CREATE PROCEDURE SpecialsDelete (
	@SpecialId INT
) AS
BEGIN
	DELETE FROM Specials WHERE SpecialId = @SpecialId;
END
GO

CREATE PROCEDURE VehiclesInsert (
	@VehicleId INT OUTPUT,
	@VIN CHAR(17),
	@ModelId INT,
	@ModelYear SMALLINT,
	@Mileage INT,
	@TransmissionTypeId TINYINT,
	@BodyStyleId TINYINT,
	@ColorId TINYINT,
	@InteriorColorId TINYINT,
	@VehicleTypeId TINYINT,
	@Description NVARCHAR(500),
	@ImageFileName NVARCHAR(200),
	@MSRP DECIMAL(8,2),
	@SalePrice DECIMAL(8,2),
	@EmployeeId INT
) AS
BEGIN
	INSERT INTO Vehicles (VIN, ModelId, ModelYear, Mileage, TransmissionTypeId, BodyStyleId, ColorId, InteriorColorId,
				VehicleTypeId, [Description], ImageFileName, MSRP, SalePrice, EmployeeId)
	VALUES (@VIN, @ModelId, @ModelYear, @Mileage, @TransmissionTypeId, @BodyStyleId, @ColorId, @InteriorColorId,
			@VehicleTypeId, @Description, @ImageFileName, @MSRP, @SalePrice, @EmployeeId)

	SET @VehicleId = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE VehiclesSelectAllDetailsById (
	@VehicleId int
)AS
BEGIN
	SELECT VehicleId, VIN, cmak.[Name] AS Make, cmod.[Name] AS Model, ModelYear, vt.[Name] AS VehicleType,
			Mileage, tt.[Name] AS TransmissionType, bs.[Name] AS BodyStyle, c.[Name] AS Color, c.ColorCode,
			ic.[Name] AS InteriorColor, ic.ColorCode AS InteriorColorCode, [Description], ImageFileName, MSRP, SalePrice, IsSold
	FROM Vehicles v
		INNER JOIN CarModels cmod
			ON v.ModelId = cmod.ModelId
		INNER JOIN CarMakes cmak
			ON cmak.MakeId = cmod.MakeId
		INNER JOIN TransmissionTypes tt
			ON v.TransmissionTypeId = tt.TransmissionTypeId
		INNER JOIN BodyStyles bs
			ON v.BodyStyleId = bs.BodyStyleId
		INNER JOIN Colors c
			ON v.ColorId = c.ColorId
		INNER JOIN InteriorColors ic
			ON v.InteriorColorId = ic.InteriorColorId
		INNER JOIN VehicleTypes vt
			ON v.VehicleTypeId = vt.VehicleTypeId
		INNER JOIN Employees e
			ON v.EmployeeId = e.EmployeeId
	WHERE v.VehicleId = @VehicleId;
END
GO

CREATE PROCEDURE VehiclesDelete (
	@VehicleId INT
) AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Purchases
		WHERE VehicleId = @VehicleId)
			DELETE FROM Vehicles WHERE VehicleId = @VehicleId;
END
GO

CREATE PROCEDURE CarModelsInsert (
	@ModelId INT OUTPUT,
	@MakeId SMALLINT,
    @Name VARCHAR(20)
) AS
BEGIN
	INSERT INTO CarModels (MakeId, [Name])
	VALUES (@MakeId, @Name)

	SET @ModelId = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE CarMakesInsert (
	@MakeId SMALLINT OUTPUT,
    @Name VARCHAR(20)
) AS
BEGIN
	INSERT INTO CarMakes ([Name])
	VALUES (@Name)

	SET @MakeId = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE PurchasesInsert (
	@PurchaseId INT OUTPUT,
    @CustomerId INT,
    @VehicleId INT,
	@PurchaseDate DATETIME2,
    @PurchasePrice decimal(8,2),
    @PurchaseTypeId TINYINT,
    @EmployeeId INT
) AS
BEGIN
	INSERT INTO Purchases (CustomerId, VehicleId, PurchaseDate, PurchasePrice, PurchaseTypeId, EmployeeId)
	VALUES (@CustomerId, @VehicleId, @PurchaseDate, @PurchasePrice, @PurchaseTypeId, @EmployeeId)

	SET @PurchaseId = SCOPE_IDENTITY();

	UPDATE Vehicles SET
	IsSold = 1,
	IsFeatured = 0
	WHERE VehicleId = @VehicleId;
END
GO

CREATE PROCEDURE AddressesInsert (
	@AddressId INT OUTPUT,
    @StreetAddress1 NVARCHAR(100),
    @StreetAddress2 NVARCHAR(100),
    @City NVARCHAR(25),
    @StateId TINYINT,
    @ZipCode INT
) AS
BEGIN
	INSERT INTO Addresses (StreetAddress1, StreetAddress2, City, StateId, ZipCode)
	VALUES (@StreetAddress1, @StreetAddress2, @City, @StateId, @ZipCode)

	SET @AddressId = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE CustomersUpdate (
	@CustomerId int,
	@Email NVARCHAR(100),
	@Phone VARCHAR(10),
	@AddressId INT
) AS
BEGIN
	CREATE TABLE #SelectedCustomer (
			Email NVARCHAR(100) NULL,
			Phone VARCHAR(10) NULL
		);

	INSERT INTO #SelectedCustomer (Email, Phone) SELECT Email, Phone
	FROM Customers
	WHERE CustomerId = @CustomerId

	IF NOT EXISTS (SELECT * FROM #SelectedCustomer c where LOWER(c.Email) = LOWER(@Email)) AND @Email IS NOT NULL
	BEGIN
		UPDATE Customers SET
		Email = @Email
		WHERE CustomerId = @CustomerId
	END

	IF NOT EXISTS (SELECT * FROM #SelectedCustomer c where c.Phone = @Phone) AND @Phone IS NOT NULL
	BEGIN
		UPDATE Customers SET
		Phone = @Phone
		WHERE CustomerId = @CustomerId
	END

	IF (@AddressId IS NOT NULL)
	BEGIN
		UPDATE Customers SET
		AddressId = @AddressId
		WHERE CustomerId = @CustomerId
	END
END
GO

CREATE PROCEDURE ContactsInsert (
	@ContactId int output,
	@CustomerId INT,
	@Message NVARCHAR(1000)
) AS
BEGIN
	INSERT INTO Contacts (CustomerId,[Message])
	VALUES (@CustomerId, @Message)

	SET @ContactId = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE EmployeesInsert (
	@EmployeeId int output,
	@FirstName NVARCHAR(20),
	@LastName NVARCHAR(20),
	@DepartmentId TINYINT
) AS
BEGIN
	INSERT INTO Employees (FirstName, LastName, DepartmentID)
	VALUES (@FirstName, @LastName, @DepartmentID)

	SET @EmployeeId = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE CustomersInsert (
	@CustomerId INT OUTPUT,
	@FirstName NVARCHAR(20),
    @LastName NVARCHAR(20),
    @Email NVARCHAR(100),
    @Phone VARCHAR(10),
	@AddressId INT = null OUTPUT,
    @StreetAddress1 NVARCHAR(100),
    @StreetAddress2 NVARCHAR(100),
    @City NVARCHAR(25),
    @StateId TINYINT,
    @ZipCode INT
) AS
BEGIN
	
IF( @StreetAddress1 IS NOT NULL )
BEGIN
	CREATE TABLE #CustomerAddress (
			AddressId INT NOT NULL
		);
	
	IF (@StreetAddress2 IS NOT NULL)
	BEGIN
		INSERT INTO #CustomerAddress (AddressId)
		SELECT AddressId FROM Addresses
		WHERE LOWER(Addresses.StreetAddress1) = LOWER(@StreetAddress1) AND
				LOWER(Addresses.StreetAddress2) = LOWER(@StreetAddress2) AND
				LOWER(Addresses.City) = LOWER(@City) AND
				Addresses.StateId = @StateId AND
				Addresses.ZipCode = @ZipCode
	END

	ELSE
	BEGIN
		INSERT INTO #CustomerAddress (AddressId)
		SELECT AddressId FROM Addresses
		WHERE LOWER(Addresses.StreetAddress1) = LOWER(@StreetAddress1) AND
				LOWER(Addresses.City) = LOWER(@City) AND
				Addresses.StateId = @StateId AND
				Addresses.ZipCode = @ZipCode
	END

	IF (SELECT COUNT(AddressId) FROM #CustomerAddress) = 0
	BEGIN
		INSERT INTO Addresses (StreetAddress1, StreetAddress2, City, StateId, ZipCode)
		VALUES (@StreetAddress1, @StreetAddress2, @City, @StateId, @ZipCode)

		SET @AddressId = SCOPE_IDENTITY();
	END

	ELSE
	BEGIN
		SET @AddressId = (SELECT AddressId FROM #CustomerAddress);
	END
END

	INSERT into Customers (FirstName, LastName, Email, Phone, AddressId)
	VALUES (@FirstName, @LastName, @Email, @Phone, @AddressId)

	SET @CustomerId = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE SpecialsInsert (
	@SpecialId int output,
	@Title NVARCHAR(50),
	@Description NVARCHAR(500)
) AS
BEGIN
	INSERT INTO Specials (Title, [Description])
	VALUES (@Title, @Description)

	SET @SpecialId = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE InventoryReportSelectAllDetails AS
BEGIN
	SELECT v.ModelYear, cmak.MakeId, cmak.[Name] AS MakeName, cmod.ModelId, cmod.[Name] AS ModelName, vt.VehicleTypeId,
			COUNT(v.VehicleId) AS VehiclesInStock, SUM(v.MSRP) AS StockValue
	FROM Vehicles v
		INNER JOIN CarModels cmod ON cmod.ModelId = v.ModelId
		INNER JOIN CarMakes cmak ON cmod.MakeId = cmak.MakeId
		INNER JOIN VehicleTypes vt ON vt.VehicleTypeId = v.VehicleTypeId
	WHERE v.IsSold = 0
	GROUP BY v.ModelYear, cmak.MakeId, cmak.[Name], cmod.ModelId, cmod.[Name], vt.VehicleTypeId
	ORDER BY vt.VehicleTypeId, v.ModelYear, MakeName, ModelName;
	
END
GO

CREATE PROCEDURE FeaturedVehicleSelectAllDetails AS
BEGIN
	SELECT v.VehicleId, v.ModelYear, cmak.MakeId, v.ModelYear, cmak.[Name] AS MakeName, cmod.ModelId,
			cmod.[Name] AS ModelName, v.ImageFileName, v.SalePrice
	FROM Vehicles v
		INNER JOIN CarModels cmod ON v.ModelId = cmod.ModelId
		INNER JOIN CarMakes cmak ON cmod.MakeId = cmak.MakeId
	WHERE v.IsFeatured = 1
	ORDER BY v.ModelYear DESC, v.Mileage;
END
GO

CREATE PROCEDURE CarMakesInStockSelectAllDetails AS
BEGIN
	SELECT cmak.[Name] AS Make, v.DateAdded, u.Email as Employee
	FROM Vehicles v
		INNER JOIN CarModels cmod ON v.ModelId = cmod.ModelId
		INNER JOIN CarMakes cmak ON cmod.MakeId = cmak.MakeId
		INNER JOIN AspNetUsers u ON v.EmployeeId = u.EmployeeId
	WHERE v.IsSold = 0
	ORDER BY Make;
END
GO

CREATE PROCEDURE CarModelsInStockSelectAllDetails AS
BEGIN
	SELECT cmak.[Name] AS Make, cmod.[Name] AS Model, v.DateAdded, u.Email as Employee
	FROM Vehicles v
		INNER JOIN CarModels cmod
			ON v.ModelId = cmod.ModelId
		INNER JOIN CarMakes cmak
			ON cmod.MakeId = cmak.MakeId
		INNER JOIN AspNetUsers u
			ON v.EmployeeId = u.EmployeeId
	WHERE v.IsSold = 0
	ORDER BY Make, Model;
END
GO

CREATE PROCEDURE SalesReportSelectAllDetails (
	@EmployeeFirstName NVARCHAR(20),
	@EmployeeLastName NVARCHAR(20),
	@FromDate DATETIME2,
	@ToDate DATETIME2
	
)AS
BEGIN
	DECLARE @SqlQuery NVARCHAR(MAX);
	
	SET @SqlQuery = 'SELECT e.EmployeeId,
						CONCAT(e.FirstName, '' '', e.LastName) AS EmployeeName,
						SUM(p.PurchasePrice) AS TotalSales,
						COUNT(p.PurchaseId) AS TotalVehicles
					FROM Purchases p
						INNER JOIN Employees e ON p.EmployeeId = e.EmployeeId ';

	DECLARE @WhereClause NVARCHAR(MAX);

	SET @WhereClause = 'WHERE (1 = 1) ';

	IF (@EmployeeFirstName != 'No' AND @EmployeeLastName != 'Name')
		SET @WhereClause += 'AND (e.FirstName = @EmployeeFirstName AND e.LastName = @EmployeeLastName) ';

	IF (@FromDate != '1900-01-01')
		SET @WhereClause += 'AND (p.PurchaseDate >= @FromDate) ';

	IF (@ToDate != '3000-01-01')
		SET @WhereClause += 'AND (p.PurchaseDate <= @ToDate) ';

	SET @SqlQuery += @WhereClause

	SET @SqlQuery += 'GROUP BY p.EmployeeId, e.FirstName, e.LastName, e.EmployeeId
						ORDER BY TotalSales DESC;';
		
	EXEC sp_executesql @SqlQuery, N'@EmployeeFirstName NVARCHAR(20),
	@EmployeeLastName NVARCHAR(20),
	@FromDate DATETIME2,
	@ToDate DATETIME', @EmployeeFirstName, @EmployeeLastName, @FromDate, @ToDate;
END
GO

CREATE PROCEDURE VehiclesSelectAllDetails (
	@SearchQuery NVARCHAR(75),
	@MinPrice DECIMAL(8,2),
	@MaxPrice DECIMAL(8,2), 
	@MinYear SMALLINT,
	@MaxYear SMALLINT
) AS
BEGIN
	DECLARE @SqlQuery NVARCHAR(MAX);
	
	SET @SqlQuery = 'SELECT VehicleId, VIN, cmak.[Name] AS Make, cmod.[Name] AS Model, ModelYear, vt.[Name] AS VehicleType,
			Mileage, tt.[Name] AS TransmissionType, bs.[Name] AS BodyStyle, c.[Name] AS Color, c.ColorCode,
			ic.[Name] AS InteriorColor, ic.ColorCode AS InteriorColorCode, [Description], ImageFileName, MSRP, SalePrice, IsSold
	FROM Vehicles v
		INNER JOIN CarModels cmod
			ON v.ModelId = cmod.ModelId
		INNER JOIN CarMakes cmak
			ON cmak.MakeId = cmod.MakeId
		INNER JOIN TransmissionTypes tt
			ON v.TransmissionTypeId = tt.TransmissionTypeId
		INNER JOIN BodyStyles bs
			ON v.BodyStyleId = bs.BodyStyleId
		INNER JOIN Colors c
			ON v.ColorId = c.ColorId
		INNER JOIN InteriorColors ic
			ON v.InteriorColorId = ic.InteriorColorId
		INNER JOIN VehicleTypes vt
			ON v.VehicleTypeId = vt.VehicleTypeId
		INNER JOIN Employees e
			ON v.EmployeeId = e.EmployeeId ';

	DECLARE @WhereClause NVARCHAR(MAX);

	SET @WhereClause = 'WHERE (v.IsSold = 0) '

	IF (@SearchQuery != 'No Search')
		SET @WhereClause += 'AND (cmak.[Name] LIKE ''%'  + @SearchQuery + '%'' OR
		cmod.[Name] LIKE ''%'  + @SearchQuery + '%'' OR
		v.ModelYear LIKE ''%'  + @SearchQuery + '%'') '

	IF (@MinPrice != 0)
		SET @WhereClause += 'AND (v.SalePrice >= @MinPrice) '

	IF (@MaxPrice != 150000)
		SET @WhereClause += 'AND (v.SalePrice <= @MaxPrice) '

	IF (@MinYear != 1900)
		SET @WhereClause += 'AND (v.ModelYear >= @MinYear) '

	IF (@MaxYear != 3000)
		SET @WhereClause += 'AND (v.ModelYear <= @MaxYear)'

	SET @SqlQuery += @WhereClause;

	SET @SqlQuery += 'ORDER BY v.SalePrice, Make, Model, v.ModelYear DESC, v.Mileage;';
		
	EXEC sp_executesql @SqlQuery, N'@SearchQuery NVARCHAR(75),
	@MinPrice INT,
	@MaxPrice INT, 
	@MinYear INT,
	@MaxYear INT', @SearchQuery, @MinPrice, @MaxPrice, @MinYear, @MaxYear;
END
GO

CREATE PROCEDURE PurchasesSelectAllByEmployeeId (
	@EmployeeId int
) AS
BEGIN
	SELECT PurchaseId, CustomerId, VehicleId, PurchaseDate, PurchasePrice, PurchaseTypeId, EmployeeId
	FROM Purchases
	WHERE EmployeeId = @EmployeeId;
END
GO

CREATE PROCEDURE VehiclesSelectAllDetailsByVehicleTypeId (
	@VehicleTypeId TINYINT,
	@SearchQuery NVARCHAR(75),
	@MinPrice DECIMAL(8,2),
	@MaxPrice DECIMAL(8,2), 
	@MinYear SMALLINT,
	@MaxYear SMALLINT
) AS
BEGIN
	DECLARE @SqlQuery NVARCHAR(MAX);
	
	SET @SqlQuery = 'SELECT VehicleId, VIN, cmak.[Name] AS Make, cmod.[Name] AS Model, ModelYear, vt.[Name] AS VehicleType,
			Mileage, tt.[Name] AS TransmissionType, bs.[Name] AS BodyStyle, c.[Name] AS Color, c.ColorCode,
			ic.[Name] AS InteriorColor, ic.ColorCode AS InteriorColorCode, [Description], ImageFileName, MSRP, SalePrice, IsSold
	FROM Vehicles v
		INNER JOIN CarModels cmod
			ON v.ModelId = cmod.ModelId
		INNER JOIN CarMakes cmak
			ON cmak.MakeId = cmod.MakeId
		INNER JOIN TransmissionTypes tt
			ON v.TransmissionTypeId = tt.TransmissionTypeId
		INNER JOIN BodyStyles bs
			ON v.BodyStyleId = bs.BodyStyleId
		INNER JOIN Colors c
			ON v.ColorId = c.ColorId
		INNER JOIN InteriorColors ic
			ON v.InteriorColorId = ic.InteriorColorId
		INNER JOIN VehicleTypes vt
			ON v.VehicleTypeId = vt.VehicleTypeId
		INNER JOIN Employees e
			ON v.EmployeeId = e.EmployeeId ';

	DECLARE @WhereClause NVARCHAR(MAX);

	SET @WhereClause = 'WHERE (v.IsSold = 0) AND (vt.VehicleTypeId = @VehicleTypeId) '

	IF (@SearchQuery != 'No Search')
		SET @WhereClause += 'AND (cmak.[Name] LIKE ''%'  + @SearchQuery + '%'' OR
		cmod.[Name] LIKE ''%'  + @SearchQuery + '%'' OR
		v.ModelYear LIKE ''%'  + @SearchQuery + '%'') '

	IF (@MinPrice != 0)
		SET @WhereClause += 'AND (v.SalePrice >= @MinPrice) '

	IF (@MaxPrice != 150000)
		SET @WhereClause += 'AND (v.SalePrice <= @MaxPrice) '

	IF (@MinYear != 1900)
		SET @WhereClause += 'AND (v.ModelYear >= @MinYear) '

	IF (@MaxYear != 3000)
		SET @WhereClause += 'AND (v.ModelYear <= @MaxYear)'

	SET @SqlQuery += @WhereClause;

	SET @SqlQuery += 'ORDER BY v.SalePrice, Make, Model, v.ModelYear DESC, v.Mileage;';
		
	EXEC sp_executesql @SqlQuery, N'@VehicleTypeId TINYINT,
	@SearchQuery NVARCHAR(75),
	@MinPrice INT,
	@MaxPrice INT, 
	@MinYear INT,
	@MaxYear INT', @VehicleTypeId, @SearchQuery, @MinPrice, @MaxPrice, @MinYear, @MaxYear;
END
GO

CREATE PROCEDURE VehiclesSelectAllDetailsByIsSold (
	@IsSold BIT
) AS
BEGIN
	SELECT VehicleId, VIN, cmak.[Name] AS Make, cmod.[Name] AS Model, ModelYear, vt.[Name] AS VehicleType,
			Mileage, tt.[Name] AS TransmissionType, bs.[Name] AS BodyStyle, c.[Name] AS Color, c.ColorCode,
			ic.[Name] AS InteriorColor, ic.ColorCode AS InteriorColorCode, [Description], ImageFileName, MSRP, SalePrice, IsSold
	FROM Vehicles v
		INNER JOIN CarModels cmod
			ON v.ModelId = cmod.ModelId
		INNER JOIN CarMakes cmak
			ON cmak.MakeId = cmod.MakeId
		INNER JOIN TransmissionTypes tt
			ON v.TransmissionTypeId = tt.TransmissionTypeId
		INNER JOIN BodyStyles bs
			ON v.BodyStyleId = bs.BodyStyleId
		INNER JOIN Colors c
			ON v.ColorId = c.ColorId
		INNER JOIN InteriorColors ic
			ON v.InteriorColorId = ic.InteriorColorId
		INNER JOIN VehicleTypes vt
			ON v.VehicleTypeId = vt.VehicleTypeId
		INNER JOIN Employees e
			ON v.EmployeeId = e.EmployeeId
	Where IsSold = @IsSold;
END
GO

CREATE PROCEDURE BodyStylesSelectById (
	@BodyStyleId TINYINT
) AS
BEGIN
	SELECT BodyStyleId, [Name]
	FROM BodyStyles
	WHERE BodyStyleId = @BodyStyleId;
END
GO

CREATE PROCEDURE CarMakesSelectById (
	@MakeId SMALLINT
) AS
BEGIN
	SELECT MakeId, [Name]
	FROM CarMakes
	WHERE MakeId = @MakeId;
END
GO

CREATE PROCEDURE CarModelsSelectById (
	@ModelId INT
) AS
BEGIN
	SELECT ModelId, MakeId, [Name]
	FROM CarModels
	WHERE ModelId = @ModelId;
END
GO

CREATE PROCEDURE DepartmentsSelectById (
	@DepartmentId TINYINT
) AS
BEGIN
	SELECT DepartmentId, [Name]
	FROM Departments
	WHERE DepartmentId = @DepartmentId;
END
GO

CREATE PROCEDURE ColorsSelectById (
	@ColorId TINYINT
) AS
BEGIN
	SELECT ColorId, [Name], ColorCode
	FROM Colors
	WHERE ColorId = @ColorId;
END
GO

CREATE PROCEDURE InteriorColorsSelectById (
	@InteriorColorId TINYINT
) AS
BEGIN
	SELECT InteriorColorId, [Name], ColorCode
	FROM InteriorColors
	WHERE InteriorColorId = @InteriorColorId;
END
GO

CREATE PROCEDURE PurchaseTypesSelectById (
	@PurchaseTypeId TINYINT
) AS
BEGIN
	SELECT PurchaseTypeId, [Name]
	FROM PurchaseTypes
	WHERE PurchaseTypeId = @PurchaseTypeId;
END
GO

CREATE PROCEDURE StatesSelectById (
	@StateId TINYINT
) AS
BEGIN
	SELECT StateId, Abbreviation, [Name]
	FROM States
	WHERE StateId = @StateId;
END
GO

CREATE PROCEDURE TransmissionTypesSelectById (
	@TransmissionTypeId TINYINT
) AS
BEGIN
	SELECT TransmissionTypeId, [Name]
	FROM TransmissionTypes
	WHERE TransmissionTypeId = @TransmissionTypeId;
END
GO

CREATE PROCEDURE VehicleTypesSelectById (
	@VehicleTypeId TINYINT
) AS
BEGIN
	SELECT VehicleTypeId, [Name]
	FROM VehicleTypes
	WHERE VehicleTypeId = @VehicleTypeId;
END
GO

CREATE PROCEDURE SpecialsSelectById (
	@SpecialId int
) AS
BEGIN
	SELECT SpecialId, Title, [Description]
	FROM Specials
	WHERE SpecialId = @SpecialId
END
GO

CREATE PROCEDURE EmployeesSelectById (
	@EmployeeId int
) AS
BEGIN
	SELECT EmployeeId, FirstName, LastName, DepartmentId
	FROM Employees
	WHERE EmployeeId = @EmployeeId;
END
GO

CREATE PROCEDURE AddressesSelectById (
	@AddressId int
) AS
BEGIN
	SELECT AddressId, StreetAddress1, StreetAddress2, City, StateId, ZipCode
	FROM Addresses
	WHERE AddressId = @AddressId;
END
GO

CREATE PROCEDURE CustomersSelectById (
	@CustomerId int
) AS
BEGIN
	SELECT CustomerId, FirstName, LastName, Email, Phone, AddressId
	FROM Customers
	WHERE CustomerId = @CustomerId;
END
GO

CREATE PROCEDURE ContactsSelectById (
	@ContactId int
) AS
BEGIN
	SELECT ContactId, CustomerId, [Message], ContactDate
	FROM Contacts
	WHERE ContactId = @ContactId;
END
GO

CREATE PROCEDURE VehiclesSelectById (
	@VehicleId int
) AS
BEGIN
	SELECT VehicleId, VIN, ModelYear, ModelId, Mileage, TransmissionTypeId, BodyStyleId, ColorId, InteriorColorId, VehicleTypeId, [Description], ImageFileName, MSRP, SalePrice, EmployeeId, DateAdded, IsFeatured, IsSold
	FROM Vehicles
	WHERE VehicleId = @VehicleId
END
GO

CREATE PROCEDURE PurchasesSelectById (
	@PurchaseId int
) AS
BEGIN
	SELECT PurchaseId, CustomerId, VehicleId, PurchaseDate, PurchasePrice, PurchaseTypeId, EmployeeId
	FROM Purchases
	WHERE PurchaseId = @PurchaseId
END
GO

CREATE PROCEDURE PurchasesSelectAll AS
BEGIN
	SELECT PurchaseId, CustomerId, VehicleId, PurchaseDate, PurchasePrice, PurchaseTypeId, EmployeeId
	FROM Purchases;
END
GO

CREATE PROCEDURE VehiclesSelectAll AS
BEGIN
	SELECT VehicleId, VIN, ModelYear, ModelId, Mileage, TransmissionTypeId, BodyStyleId, ColorId, InteriorColorId, VehicleTypeId, [Description], ImageFileName, MSRP, SalePrice, EmployeeId, DateAdded, IsFeatured, IsSold
	FROM Vehicles
	ORDER BY IsSold, VehicleTypeId, ModelYear DESC, BodyStyleId, ColorId, Mileage;
END
GO

CREATE PROCEDURE ContactsSelectAll AS
BEGIN
	SELECT ContactId, CustomerId, [Message], ContactDate
	FROM Contacts;
END
GO

CREATE PROCEDURE CustomersSelectAll AS
BEGIN
	SELECT CustomerId, FirstName, LastName, Email, Phone, AddressId
	FROM Customers
	ORDER BY LastName, Firstname, CustomerId;
END
GO

CREATE PROCEDURE AddressesSelectAll AS
BEGIN
	SELECT AddressId, StreetAddress1, StreetAddress2, City, StateId, ZipCode
	FROM Addresses;
END
GO

CREATE PROCEDURE EmployeesSelectAll AS
BEGIN
	SELECT EmployeeId, FirstName, LastName, DepartmentId
	FROM Employees
	ORDER BY LastName, FirstName, EmployeeId;
END
GO

CREATE PROCEDURE SpecialsSelectAll AS
BEGIN
	SELECT SpecialId, Title, [Description]
	FROM Specials
	ORDER BY DateCreated DESC;
END
GO

CREATE PROCEDURE PurchaseTypesSelectAll AS
BEGIN
	SELECT PurchaseTypeId, [Name]
	FROM PurchaseTypes
	ORDER BY [Name];
END
GO

CREATE PROCEDURE InteriorColorsSelectAll AS
BEGIN
	SELECT InteriorColorId, [Name], ColorCode
	FROM InteriorColors
	ORDER BY [Name];
END
GO

CREATE PROCEDURE ColorsSelectAll AS
BEGIN
	SELECT ColorId, [Name], ColorCode
	FROM Colors
	ORDER BY [Name];
END
GO

CREATE PROCEDURE VehicleTypesSelectAll AS
BEGIN
	SELECT VehicleTypeId, [Name]
	FROM VehicleTypes
	ORDER BY [Name];
END
GO

CREATE PROCEDURE BodyStylesSelectAll AS
BEGIN
	SELECT BodyStyleId, [Name]
	FROM BodyStyles
	ORDER BY [Name];
END
GO

CREATE PROCEDURE TransmissionTypesSelectAll AS
BEGIN
	SELECT TransmissionTypeId, [Name]
	FROM TransmissionTypes
	ORDER BY [Name];
END
GO

CREATE PROCEDURE DepartmentsSelectAll AS
BEGIN
	SELECT DepartmentId, [Name]
	FROM Departments
	ORDER BY [Name];
END
GO

CREATE PROCEDURE CarModelsSelectAll AS
BEGIN
	SELECT ModelId, MakeId, [Name]
	FROM CarModels
	ORDER BY MakeId, [Name];
END
GO

CREATE PROCEDURE CarMakesSelectAll AS
BEGIN
	SELECT MakeId, [Name]
	FROM CarMakes
	ORDER BY [Name];
END
GO

CREATE PROCEDURE StatesSelectAll AS
BEGIN
	SELECT StateId, Abbreviation, [Name]
	FROM States
	ORDER BY [Name];
END
GO