/*
	=====================================================================================
	TO ENABLE THE DEMONSTRATION OF THE FRAMEWORK, CREATE THE DATABASE NAME OF YOUR CHOICE
			THEN EXECUTE THE SCRIPT BELOW TO CREATE THE DEMO CUSTOMERS TABLE
	=====================================================================================
*/

CREATE SCHEMA Demo
	AUTHORIZATION dbo;
GO

CREATE TABLE [Demo].[Customers](
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] [VARCHAR](50) NOT NULL,
	[IsActive] [BIT] NOT NULL
)
GO
