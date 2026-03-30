CREATE DATABASE Vehicle_Service_Db;
GO;

CREATE TABLE Vehicle
(
	VehicleId INT PRIMARY KEY,
	[Name] VARCHAR(100),
	Make VARCHAR(50),
	Model VARCHAR(50),
	[Year] INT,
	VIN VARCHAR(50),
	LicensePlate VARCHAR(20),
	CurrentMilage INT,
	ImagePath VARCHAR,
	DateAdded DATETIME
);

CREATE TABLE ServiceHistory
(
	ServiceHistoryId INT PRIMARY KEY,
	VehicleId INT,
	ServiceType VARCHAR(100),
	ServiceDate DATE,
	MileageAtService INT,
	Cost INT,
	ServiceProvider VARCHAR(100),
	[Description] VARCHAR,
	DateRecorded DATE,
	FOREIGN KEY(VehicleId) REFERENCES Vehicle(VehicleId)
);