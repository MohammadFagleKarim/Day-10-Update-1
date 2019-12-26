Create database CustomerDetailsInfo
USE CustomerDetailsInfo

CREATE TABLE Customers(
CustomerId INT IDENTITY(1,1) PRIMARY KEY,
CustomerCode VARCHAR(50),
CustomerName VARCHAR(50),
[Address] VARCHAR(100),
Contact VARCHAR(50),
DistrictId INT REFERENCES District(DisId)
)

CREATE TABLE District
(
DisId INT IDENTITY(1,1) PRIMARY KEY,
DistrictName VARCHAR(50),
)

SELECT * FROM Customers
drop table Customers