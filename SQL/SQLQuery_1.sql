USE TestDB;
CREATE TABLE Departures (
    DepartureID NVARCHAR(255) NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    PRIMARY KEY (DepartureID)
);
CREATE TABLE Employees (
    EmployeeID INT NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    Age INT NOT NULL,
    DepartureID INT,
    PRIMARY KEY (EmployeeID),
    CONSTRAINT FK_DepartureEmployee FOREIGN KEY (DepartureID)
    REFERENCES Departures(DepartureID) 
);
