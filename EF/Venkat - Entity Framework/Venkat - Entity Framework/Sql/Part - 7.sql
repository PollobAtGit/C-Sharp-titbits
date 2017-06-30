
CREATE PROCEDURE InsertEmployee

	-- POI: Third bracket doesn't work in stored procedure variable names
	@FirstName NVARCHAR(255),
	@LastName NVARCHAR(255),
	@Gender NVARCHAR(10),
	@Salary DECIMAL(18, 2)

AS
BEGIN

	INSERT INTO dbo.Employee VALUES (@FirstName, @LastName, @Gender, @Salary);

END
GO

CREATE PROCEDURE UpdateEmployee
	@ID INT,
	@FirstName NVARCHAR(255),
	@LastName NVARCHAR(255),
	@Gender NVARCHAR(50),
	@Salary DECIMAL(18, 2)
AS
BEGIN

	UPDATE dbo.Employee 
	SET 
		[First Name] = @FirstName
		, [Last Name] = @LastName
		, [Gender] = @Gender
		, [Salary] = @Salary 
	WHERE ID = @ID;

END
GO

CREATE PROCEDURE DeleteEmployee
	@ID INT
AS
BEGIN
     DELETE FROM dbo.Employee WHERE ID = @ID;
END
GO

-- TODO: How to drop table in SQL Server?
-- TODO: What's the difference between VARCHAR & NVARCHAR?

CREATE TABLE [dbo].[Employee]
(
	[Id] INT PRIMARY KEY IDENTITY

	-- POI: In DB First approach model class will be created from this definition in which case
	-- space in between words will be replaced with underscore (_)

	, [First Name] NVARCHAR(255)
	, [Last Name] NVARCHAR(255)
	, [Gender] VARCHAR(10)
	, [Salary] DECIMAL(18, 2)
);

INSERT INTO Employee VALUES ('Mark', 'Hastings', 'Male', 60000);
INSERT INTO Employee VALUES ('Steve', 'Pound', 'Male', 45000);
INSERT INTO Employee VALUES ('Ben', 'Hoskins', 'Male', 70000);
INSERT INTO Employee VALUES ('Philip', 'Hastings', 'Male', 45000);
INSERT INTO Employee VALUES ('Mary', 'Lambeth', 'Female', 30000);
INSERT INTO Employee VALUES ('Valarie', 'Vikings', 'Female', 35000);
INSERT INTO Employee VALUES ('John', 'Stanmore', 'Male', 80000);