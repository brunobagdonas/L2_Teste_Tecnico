CREATE DATABASE PackingDb;
GO
USE PackingDb;
GO

CREATE TABLE Box (
    BoxId NVARCHAR(50) PRIMARY KEY,
    [Length] DECIMAL(10,2),
    Width DECIMAL(10,2),
    Height DECIMAL(10,2)
);

CREATE TABLE Orders (
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    OrderDate DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE OrderItems (
    OrderItemId INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL,
    ProductId NVARCHAR(100) NOT NULL,
    BoxId NVARCHAR(50) NULL,
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (BoxId) REFERENCES Box(BoxId)
);


INSERT INTO Box (BoxId,  [Length], Width, Height) VALUES ('Box 1', 80, 40, 30); -- Box 1
INSERT INTO Box (BoxId, [Length], Width, Height) VALUES  ('Box 2', 40, 50, 80); -- Box 2
INSERT INTO Box (BoxId,  [Length], Width, Height) VALUES  ( 'Box 3' , 60, 80, 50); -- Box 3