USE TestDB;
CREATE TABLE Departures (
    DepartureID UNIQUEIDENTIFIER NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    PRIMARY KEY (DepartureID)
);
CREATE TABLE Employees (
    EmployeeID UNIQUEIDENTIFIER NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    Age INT NOT NULL,
    DepartureID UNIQUEIDENTIFIER,
    PRIMARY KEY (EmployeeID),
    CONSTRAINT FK_DepartureEmployee FOREIGN KEY (DepartureID)
    REFERENCES Departures(DepartureID) 
);
