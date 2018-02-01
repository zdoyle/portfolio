USE GuildCars;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Purchases')
DROP TABLE Purchases;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Contacts')
DROP TABLE Contacts;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Customers')
DROP TABLE Customers;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Vehicles')
DROP TABLE Vehicles;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='CarModels')
DROP TABLE CarModels;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='CarMakes')
DROP TABLE CarMakes;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Addresses')
DROP TABLE Addresses;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Employees')
DROP TABLE Employees;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Departments')
DROP TABLE Departments;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='VehicleTypes')
DROP TABLE VehicleTypes;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='BodyStyles')
DROP TABLE BodyStyles;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='TransmissionTypes')
DROP TABLE TransmissionTypes;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='InteriorColors')
DROP TABLE InteriorColors;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Colors')
DROP TABLE Colors;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Specials')
DROP TABLE Specials;
GO


IF EXISTS(SELECT * FROM sys.tables WHERE name='PurchaseTypes')
DROP TABLE PurchaseTypes;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='States')
DROP TABLE States;
GO

CREATE TABLE States (
	StateId TINYINT IDENTITY(1,1) PRIMARY KEY,
	Abbreviation NCHAR(2) UNIQUE NOT NULL,
	[Name] NVARCHAR(25) NOT NULL
);
GO

CREATE TABLE PurchaseTypes (
	PurchaseTypeId TINYINT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(15) NOT NULL
);
GO

CREATE TABLE Specials (
	SpecialId INT IDENTITY(1,1) PRIMARY KEY,
	Title NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(500) NOT NULL,
	DateCreated DATETIME2 NOT NULL DEFAULT GETDATE()
);
GO

CREATE TABLE Colors (
	ColorId TINYINT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(25) UNIQUE NOT NULL,
	ColorCode NVARCHAR(25) UNIQUE NOT NULL
);
GO

CREATE TABLE InteriorColors (
	InteriorColorId TINYINT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(25) UNIQUE NOT NULL,
	ColorCode VARCHAR(25) NOT NULL
);
GO

CREATE TABLE TransmissionTypes (
	TransmissionTypeId TINYINT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(15) NOT NULL
);
GO

CREATE TABLE BodyStyles (
	BodyStyleId TINYINT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(15) NOT NULL
);
GO

CREATE TABLE VehicleTypes (
	VehicleTypeId TINYINT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(10) NOT NULL
);
GO

CREATE TABLE Departments (
	DepartmentId TINYINT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(25) NOT NULL
);
GO

CREATE TABLE Employees (
	EmployeeId INT IDENTITY(1,1) PRIMARY KEY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	DepartmentID TINYINT FOREIGN KEY REFERENCES Departments(DepartmentId) NOT NULL
);
GO

CREATE TABLE Addresses (
	AddressId INT IDENTITY(1,1) PRIMARY KEY,
	StreetAddress1 NVARCHAR(100) NOT NULL,
	StreetAddress2 NVARCHAR(100) NULL,
	City NVARCHAR(25) NOT NULL,
	StateId TINYINT FOREIGN KEY REFERENCES States(StateId) NOT NULL,
	ZipCode INT NOT NULL
);
GO

CREATE TABLE CarMakes (
	MakeId SMALLINT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(20) NOT NULL,
);
GO

CREATE TABLE CarModels (
	ModelId INT IDENTITY(1,1) PRIMARY KEY,
	MakeId SMALLINT FOREIGN KEY REFERENCES CarMakes(MakeId) NOT NULL,
	[Name] NVARCHAR(25) NOT NULL,
);
GO

CREATE TABLE Vehicles (
	VehicleId INT IDENTITY(1,1) PRIMARY KEY,
	VIN CHAR(17) UNIQUE NOT NULL,
	ModelId INT FOREIGN KEY REFERENCES CarModels(ModelId) NOT NULL,
	ModelYear SMALLINT NOT NULL,
	Mileage INT NOT NULL,
	TransmissionTypeId TINYINT FOREIGN KEY REFERENCES TransmissionTypes(TransmissionTypeId) NOT NULL,
	BodyStyleId TINYINT FOREIGN KEY REFERENCES BodyStyles(BodyStyleId) NOT NULL,
	ColorId TINYINT FOREIGN KEY REFERENCES Colors(ColorId) NOT NULL,
	InteriorColorId TINYINT FOREIGN KEY REFERENCES InteriorColors(InteriorColorId) NOT NULL,
	VehicleTypeId TINYINT FOREIGN KEY REFERENCES VehicleTypes(VehicleTypeId) NOT NULL,
	[Description] NVARCHAR(500) NOT NULL,
	ImageFileName NVARCHAR(200) NOT NULL,
	MSRP DECIMAL(8,2) NOT NULL,
	SalePrice DECIMAL(8,2) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(EmployeeId) NOT NULL,
	DateAdded DATETIME2 NOT NULL DEFAULT GETDATE(),
	IsFeatured BIT NOT NULL DEFAULT 0,
	IsSold BIT NOT NULL DEFAULT 0
);
GO

CREATE TABLE Customers (
	CustomerId INT IDENTITY(1,1) PRIMARY KEY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Email NVARCHAR(100) NULL,
	Phone VARCHAR(10) NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(AddressId) NULL
);
GO

CREATE TABLE Contacts (
	ContactId INT IDENTITY(1,1) PRIMARY KEY,
	CustomerId INT FOREIGN KEY REFERENCES Customers(CustomerId) NOT NULL,
	[Message] NVARCHAR(1000) NOT NULL,
	ContactDate DATETIME2 NOT NULL DEFAULT GETDATE()
);
GO

CREATE TABLE Purchases (
	PurchaseId INT IDENTITY(1,1) PRIMARY KEY,
	CustomerId INT FOREIGN KEY REFERENCES Customers(CustomerId) NOT NULL,
	VehicleId INT FOREIGN KEY REFERENCES Vehicles(VehicleId) NOT NULL UNIQUE,
	PurchaseDate DATETIME2 NOT NULL DEFAULT GETDATE(),
	PurchasePrice DECIMAL(8,2) NOT NULL,
	PurchaseTypeId TINYINT FOREIGN KEY REFERENCES PurchaseTypes(PurchaseTypeId) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(EmployeeId) NOT NULL
);
GO

--Populate Lookup Tables

INSERT INTO States
VALUES ('AL', 'Alabama'),
('AK', 'Alaska'),
('AZ', 'Arizona'),
('AR', 'Arkansas'),
('CA', 'California'),
('CO', 'Colorado'),
('CT', 'Connecticut'),
('DE', 'Delaware'),
('DC', 'District of Columbia'),
('FL', 'Florida'),
('GA', 'Georgia'),
('HI', 'Hawaii'),
('ID', 'Idaho'),
('IL', 'Illinois'),
('IN', 'Indiana'),
('IA', 'Iowa'),
('KS', 'Kansas'),
('KY', 'Kentucky'),
('LA', 'Louisiana'),
('ME', 'Maine'),
('MD', 'Maryland'),
('MA', 'Massachusetts'),
('MI', 'Michigan'),
('MN', 'Minnesota'),
('MS', 'Mississippi'),
('MO', 'Missouri'),
('MT', 'Montana'),
('NE', 'Nebraska'),
('NV', 'Nevada'),
('NH', 'New Hampshire'),
('NJ', 'New Jersey'),
('NM', 'New Mexico'),
('NY', 'New York'),
('NC', 'North Carolina'),
('ND', 'North Dakota'),
('OH', 'Ohio'),
('OK', 'Oklahoma'),
('OR', 'Oregon'),
('PA', 'Pennsylvania'),
('PR', 'Puerto Rico'),
('RI', 'Rhode Island'),
('SC', 'South Carolina'),
('SD', 'South Dakota'),
('TN', 'Tennessee'),
('TX', 'Texas'),
('UT', 'Utah'),
('VT', 'Vermont'),
('VA', 'Virginia'),
('WA', 'Washington'),
('WV', 'West Virginia'),
('WI', 'Wisconsin'),
('WY', 'Wyoming');
GO

INSERT INTO Departments
VALUES ('Admin'),
('Sales');
GO

INSERT INTO CarMakes ([Name])
VALUES ('Acura'),
('Aptera'),
('Aston Martin'),
('Audi'),
('Bentley'),
('BMW'),
('Bugatti'),
('Buick'),
('Cadillac'),
('Chevrolet'),
('Chrysler'),
('Corbin'),
('Daewoo'),
('Dodge'),
('Ferrari'),
('FIAT'),
('Foose'),
('Ford'),
('GMC'),
('Holden'),
('Honda'),
('HUMMER'),
('Hyundai'),
('Infiniti'),
('Isuzu'),
('Jaguar'),
('Jeep'),
('Kia'),
('Lamborghini'),
('Land Rover'),
('Lexus'),
('Lincoln'),
('Lotus'),
('Maserati'),
('Maybach'),
('Mazda'),
('McLaren'),
('Mercedes-Benz'),
('Mercury'),
('MINI'),
('Mitsubishi'),
('Morgan'),
('Nissan'),
('Oldsmobile'),
('Panoz'),
('Peugeot'),
('Plymouth'),
('Pontiac'),
('Porsche'),
('Ram'),
('Rolls-Royce'),
('Saab'),
('Saturn'),
('Scion'),
('Smart'),
('Spyker'),
('Subaru'),
('Suzuki'),
('Tesla'),
('Toyota'),
('Volkswagen'),
('Volvo');
GO

INSERT INTO CarModels (MakeId, [Name])
VALUES (1, 'Integra'),
(1, 'NSX'),
(1, 'RL'),
(1, 'TL'),
(10, '2500'),
(10, '3500'),
(10, 'Astro'),
(10, 'Blazer'),
(10, 'Camaro'),
(10, 'Cavalier'),
(10, 'Corvette'),
(10, 'Express 1500'),
(10, 'Express 2500'),
(10, 'Express 3500'),
(10, 'Impala'),
(10, 'Lumina'),
(10, 'Malibu'),
(10, 'Metro'),
(10, 'Monte Carlo'),
(10, 'Prizm'),
(10, 'S10'),
(10, 'Silverado 1500'),
(10, 'Silverado 2500'),
(10, 'Suburban 1500'),
(10, 'Suburban 2500'),
(10, 'Tahoe'),
(10, 'Tracker'),
(10, 'Venture'),
(11, '300M'),
(11, 'Cirrus'),
(11, 'Concorde'),
(11, 'Grand Voyager'),
(11, 'LHS'),
(11, 'Sebring'),
(11, 'Town & Country'),
(11, 'Voyager'),
(13, 'Lanos'),
(13, 'Leganza'),
(13, 'Nubira'),
(14, 'Avenger'),
(14, 'Caravan'),
(14, 'Dakota'),
(14, 'Dakota Club'),
(14, 'Durango'),
(14, 'Grand Caravan'),
(14, 'Intrepid'),
(14, 'Neon'),
(14, 'Ram 1500'),
(14, 'Ram 1500 Club'),
(14, 'Ram 2500'),
(14, 'Ram 3500'),
(14, 'Ram Van 1500'),
(14, 'Ram Van 2500'),
(14, 'Ram Van 3500'),
(14, 'Stratus'),
(14, 'Viper'),
(18, 'Contour'),
(18, 'Crown Victoria'),
(18, 'Econoline E150'),
(18, 'Econoline E250'),
(18, 'Econoline E350'),
(18, 'Escape'),
(18, 'Escort'),
(18, 'Excursion'),
(18, 'Expedition'),
(18, 'Explorer'),
(18, 'Explorer Sport'),
(18, 'Explorer Sport Trac'),
(18, 'F150'),
(18, 'F250'),
(18, 'F350'),
(18, 'Focus'),
(18, 'Mustang'),
(18, 'Ranger'),
(18, 'Taurus'),
(18, 'Th!nk'),
(18, 'Windstar'),
(19, 'Envoy'),
(19, 'Jimmy'),
(19, 'Safari'),
(19, 'Savana 1500'),
(19, 'Savana 2500'),
(19, 'Savana 3500'),
(19, 'Sierra 1500'),
(19, 'Sierra 2500'),
(19, 'Sierra 3500'),
(19, 'Sonoma'),
(19, 'Yukon'),
(19, 'Yukon Denali'),
(19, 'Yukon XL 1500'),
(19, 'Yukon XL 2500'),
(21, 'Accord'),
(21, 'Civic'),
(21, 'CR-V'),
(21, 'Insight'),
(21, 'Odyssey'),
(21, 'Passport'),
(21, 'Prelude'),
(21, 'S2000'),
(22, 'H1'),
(23, 'Accent'),
(23, 'Elantra'),
(23, 'Sonata'),
(23, 'Tiburon'),
(24, 'G'),
(24, 'I'),
(24, 'Q'),
(24, 'QX'),
(25, 'Amigo'),
(25, 'Hombre'),
(25, 'Hombre Space'),
(25, 'Rodeo'),
(25, 'Trooper'),
(25, 'VehiCROSS'),
(26, 'S-Type'),
(26, 'XJ Series'),
(26, 'XK Series'),
(27, 'Cherokee'),
(27, 'Grand Cherokee'),
(27, 'Wrangler'),
(28, 'Sephia'),
(28, 'Spectra'),
(28, 'Sportage'),
(29, 'Diablo'),
(30, 'Discovery'),
(30, 'Discovery Series II'),
(30, 'Range Rover'),
(31, 'ES'),
(31, 'GS'),
(31, 'LS'),
(31, 'LX'),
(31, 'RX'),
(31, 'SC'),
(32, 'Continental'),
(32, 'Navigator'),
(32, 'Town Car'),
(33, 'Esprit'),
(36, '626'),
(36, 'B-Series'),
(36, 'B-Series Plus'),
(36, 'Miata MX-5'),
(36, 'Millenia'),
(36, 'MPV'),
(36, 'MX-5'),
(36, 'Protege'),
(38, 'C-Class'),
(38, 'CL-Class'),
(38, 'CLK-Class'),
(38, 'E-Class'),
(38, 'M-Class'),
(38, 'S-Class'),
(38, 'SL-Class'),
(38, 'SLK-Class'),
(39, 'Cougar'),
(39, 'Grand Marquis'),
(39, 'Mountaineer'),
(39, 'Mystique'),
(39, 'Sable'),
(39, 'Villager'),
(4, 'A4'),
(4, 'A6'),
(4, 'A8'),
(4, 'S4'),
(4, 'TT'),
(41, 'Challenger'),
(41, 'Diamante'),
(41, 'Eclipse'),
(41, 'Galant'),
(41, 'Mirage'),
(41, 'Montero'),
(41, 'Montero Sport'),
(41, 'Pajero'),
(43, 'Altima'),
(43, 'Frontier'),
(43, 'Maxima'),
(43, 'Pathfinder'),
(43, 'Quest'),
(43, 'Sentra'),
(43, 'Xterra'),
(44, 'Alero'),
(44, 'Bravada'),
(44, 'Intrigue'),
(44, 'Silhouette'),
(47, 'Breeze'),
(47, 'Prowler'),
(48, 'Bonneville'),
(48, 'Firebird'),
(48, 'Grand Am'),
(48, 'Grand Prix'),
(48, 'Montana'),
(48, 'Sunfire'),
(49, '911'),
(49, 'Boxster'),
(52, '9-3'),
(52, '9-5'),
(53, 'L-Series'),
(53, 'S-Series'),
(57, 'Forester'),
(57, 'Impreza'),
(57, 'Legacy'),
(57, 'Outback'),
(58, 'Esteem'),
(58, 'Grand Vitara'),
(58, 'Swift'),
(58, 'Vitara'),
(6, '3 Series'),
(6, '5 Series'),
(6, '7 Series'),
(6, 'M'),
(6, 'M5'),
(6, 'X5'),
(6, 'Z3'),
(6, 'Z8'),
(60, '4Runner'),
(60, 'Avalon'),
(60, 'Camry'),
(60, 'Celica'),
(60, 'Corolla'),
(60, 'Echo'),
(60, 'Ipsum'),
(60, 'Land Cruiser'),
(60, 'MR2'),
(60, 'RAV4'),
(60, 'Sienna'),
(60, 'Solara'),
(60, 'Tacoma'),
(60, 'Tacoma Xtra'),
(60, 'Tundra'),
(61, 'Cabriolet'),
(61, 'Eurovan'),
(61, 'Golf'),
(61, 'GTI'),
(61, 'Jetta'),
(61, 'New Beetle'),
(61, 'Passat'),
(61, 'rio'),
(62, 'C70'),
(62, 'S40'),
(62, 'S70'),
(62, 'S80'),
(62, 'V40'),
(62, 'V70'),
(8, 'Century'),
(8, 'LeSabre'),
(8, 'Park Avenue'),
(8, 'Regal'),
(9, 'Catera'),
(9, 'DeVille'),
(9, 'Eldorado'),
(9, 'Escalade'),
(9, 'Seville'),
(1, 'CL'),
(1, 'MDX'),
(10, 'Silverado'),
(10, 'Silverado 3500'),
(11, 'PT Cruiser'),
(18, 'E-Series'),
(18, 'Fiesta'),
(18, 'F-Series'),
(18, 'ZX2'),
(23, 'Santa Fe'),
(23, 'XG300'),
(25, 'Rodeo Sport'),
(28, 'Optima'),
(30, 'Freelander'),
(31, 'IS'),
(36, 'B2500'),
(36, 'Tribute'),
(4, 'Allroad'),
(4, 'S8'),
(41, 'Lancer'),
(44, 'Aurora'),
(48, 'Aztek'),
(58, 'XL-7'),
(6, '525'),
(6, '530'),
(6, 'M3'),
(60, 'Highlander'),
(60, 'Prius'),
(60, 'Sequoia'),
(62, 'S60'),
(1, 'RSX'),
(10, 'Avalanche'),
(10, 'Avalanche 1500'),
(10, 'Avalanche 2500'),
(10, 'Trailblazer'),
(18, 'Thunderbird'),
(19, 'Envoy XL'),
(21, 'Pilot'),
(23, 'XG350'),
(25, 'Axiom'),
(26, 'X-Type'),
(27, 'Liberty'),
(28, 'Sedona'),
(29, 'Murci�lago'),
(32, 'Blackwood'),
(34, 'Spyder'),
(36, 'Protege5'),
(38, 'G-Class'),
(4, 'S6'),
(40, 'Cooper'),
(40, 'MINI'),
(41, 'Lancer Evolution'),
(53, 'VUE'),
(57, 'Outback Sport'),
(58, 'Aerio'),
(6, '745'),
(8, 'Rendezvous'),
(9, 'Escalade EXT'),
(10, 'SSR'),
(14, 'Ram'),
(18, 'E150'),
(18, 'E250'),
(18, 'E350'),
(18, 'Escort ZX2'),
(18, 'Freestar'),
(21, 'Civic GX'),
(21, 'Civic Si'),
(21, 'Element'),
(22, 'H2'),
(24, 'FX'),
(24, 'G35'),
(25, 'Ascender'),
(28, 'Sorento'),
(29, 'Gallardo'),
(31, 'GX'),
(32, 'Aviator'),
(35, '57'),
(35, '62'),
(36, 'Mazda6'),
(39, 'Marauder'),
(4, 'RS 6'),
(4, 'RS6'),
(41, 'Outlander'),
(43, '350Z'),
(43, 'Murano'),
(48, 'Vibe'),
(49, 'Cayenne'),
(53, 'Ion'),
(57, 'Baja'),
(6, '760'),
(6, 'Z4'),
(60, 'Matrix'),
(61, 'Touareg'),
(62, 'XC70'),
(62, 'XC90'),
(9, 'CTS'),
(9, 'Escalade ESV'),
(1, 'TSX'),
(10, 'Aveo'),
(10, 'Classic'),
(10, 'Colorado'),
(11, 'Crossfire'),
(11, 'Pacifica'),
(12, 'Sparrow'),
(19, 'Canyon'),
(19, 'Envoy XUV'),
(20, 'Monaro'),
(28, 'Amanti'),
(33, 'Elise'),
(33, 'Exige'),
(36, 'Mazda3'),
(36, 'RX-8'),
(39, 'Monterey'),
(41, 'Endeavor'),
(43, 'Pathfinder Armada'),
(43, 'Titan'),
(48, 'GTO'),
(49, 'Carrera GT'),
(54, 'xA'),
(54, 'xB'),
(56, 'C8 Laviolette'),
(56, 'C8 Spyder'),
(56, 'C8 Spyder Wide Body'),
(58, 'Daewoo Lacetti'),
(58, 'Daewoo Magnus'),
(58, 'Forenza'),
(58, 'Verona'),
(6, '325'),
(6, '545'),
(6, '645'),
(6, '6 Series'),
(6, 'X3'),
(61, 'Phaeton'),
(61, 'R32'),
(8, 'Rainier'),
(9, 'SRX'),
(9, 'XLR'),
(10, 'Cobalt'),
(10, 'Equinox'),
(10, 'Uplander'),
(11, '300'),
(11, '300C'),
(14, 'Magnum'),
(18, 'Five Hundred'),
(18, 'Freestyle'),
(18, 'GT'),
(23, 'Tucson'),
(3, 'DB9'),
(3, 'Vanquish S'),
(30, 'LR3'),
(34, 'Coupe'),
(34, 'Gran Sport'),
(34, 'GranSport'),
(34, 'Quattroporte'),
(35, '57S'),
(38, 'SLR McLaren'),
(39, 'Mariner'),
(39, 'Montego'),
(43, 'Armada'),
(45, 'Esperante'),
(48, 'Daewoo Kalos'),
(48, 'G6'),
(48, 'Montana SV6'),
(5, 'Arnage'),
(51, 'Phantom'),
(52, '9-2X'),
(52, '9-7X'),
(53, 'Relay'),
(54, 'tC'),
(56, 'C8'),
(58, 'Reno'),
(6, '330'),
(62, 'V50'),
(8, 'LaCrosse'),
(8, 'Terraza'),
(9, 'STS'),
(10, 'Express'),
(10, 'HHR'),
(10, 'HHR Panel'),
(10, 'Malibu Maxx'),
(10, 'Silverado 3500HD'),
(10, 'Silverado Hybrid'),
(10, 'Suburban'),
(11, 'Crossfire Roadster'),
(14, 'Charger'),
(14, 'Sprinter'),
(15, '612 Scaglietti'),
(15, 'F430'),
(15, 'F430 Spider'),
(18, 'E-350 Super Duty'),
(18, 'E-350 Super Duty Van'),
(18, 'F-250 Super Duty'),
(18, 'F-350 Super Duty'),
(18, 'Fusion'),
(19, 'Savana'),
(19, 'Savana Cargo Van'),
(19, 'Sierra 2500HD'),
(19, 'Sierra 3500HD'),
(19, 'Sierra Denali'),
(19, 'Sierra Hybrid'),
(19, 'Yukon XL'),
(21, 'Ridgeline'),
(22, 'H2 SUT'),
(22, 'H2 SUV'),
(22, 'H3'),
(23, 'Azera'),
(25, 'i-280'),
(25, 'i-350'),
(25, 'i-Series'),
(26, 'XJ'),
(26, 'XK'),
(27, 'Commander'),
(28, 'Spectra5'),
(3, 'DB9 Volante'),
(3, 'V8 Vantage'),
(3, 'Vantage'),
(30, 'Range Rover Sport'),
(31, 'RX Hybrid'),
(32, 'Mark LT'),
(32, 'Zephyr'),
(36, 'Mazda5'),
(36, 'Mazda6 5-Door'),
(36, 'Mazda6 Sport'),
(36, 'Mazdaspeed6'),
(38, 'CLS-Class'),
(38, 'G55 AMG'),
(38, 'R-Class'),
(38, 'SL65 AMG'),
(39, 'Milan'),
(4, 'A3'),
(41, 'Raider'),
(42, 'Aero 8'),
(43, '350Z Roadster'),
(46, '207'),
(48, 'Solstice'),
(48, 'Torrent'),
(49, 'Cayman'),
(5, 'Azure'),
(5, 'Continental Flying Spur'),
(5, 'Continental GT'),
(56, 'C8 Double 12 S'),
(57, 'B9 Tribeca'),
(57, 'Tribeca'),
(58, 'XL7'),
(6, '550'),
(6, '650'),
(6, '750'),
(6, 'M Roadster'),
(6, 'M6'),
(6, 'Z4 M'),
(60, 'Camry Solara'),
(60, 'Yaris'),
(61, 'Rabbit'),
(8, 'Lucerne'),
(9, 'CTS-V'),
(9, 'DTS'),
(9, 'STS-V'),
(9, 'XLR-V'),
(1, 'RDX'),
(10, 'Cobalt SS'),
(11, 'Aspen'),
(14, 'Caliber'),
(14, 'Nitro'),
(15, '599 GTB Fiorano'),
(17, 'Hemisfear'),
(18, 'Edge'),
(18, 'Expedition EL'),
(18, 'F-Series Super Duty'),
(18, 'GT500'),
(19, 'Acadia'),
(19, 'Sierra'),
(21, 'Fit'),
(23, 'Entourage'),
(23, 'Veracruz'),
(24, 'QX56'),
(25, 'i-290'),
(25, 'i-370'),
(27, 'Compass'),
(27, 'Patriot'),
(28, 'Carens'),
(28, 'Rondo'),
(32, 'MKX'),
(32, 'MKZ'),
(32, 'Navigator L'),
(36, 'CX-7'),
(36, 'CX-9'),
(36, 'Mazdaspeed 3'),
(38, 'GL-Class'),
(4, 'Q7'),
(4, 'RS 4'),
(4, 'RS4'),
(43, 'Versa'),
(48, 'G5'),
(5, 'Continental GTC'),
(53, 'Aura'),
(53, 'Outlook'),
(53, 'Sky'),
(58, 'SX4'),
(6, 'Alpina B7'),
(60, 'Camry Hybrid'),
(60, 'FJ Cruiser'),
(60, 'Highlander Hybrid'),
(60, 'TundraMax'),
(61, 'Eos'),
(15, '430 Scuderia'),
(18, 'F450'),
(18, 'Taurus X'),
(2, 'Typ-1'),
(24, 'EX'),
(24, 'G37'),
(28, 'Rio5'),
(29, 'Murci�lago LP640'),
(29, 'Revent�n'),
(3, 'DBS'),
(30, 'LR2'),
(31, 'IS F'),
(31, 'IS-F'),
(34, 'GranTurismo'),
(4, 'A5'),
(4, 'R8'),
(4, 'S5'),
(40, 'Clubman'),
(40, 'Cooper Clubman'),
(43, 'Rogue'),
(48, 'G8'),
(53, 'Astra'),
(54, 'xD'),
(55, 'Fortwo'),
(6, '1 Series'),
(6, 'X6'),
(61, 'GLI'),
(61, 'Touareg 2'),
(62, 'C30'),
(8, 'Enclave'),
(10, 'Traverse'),
(14, 'Journey'),
(15, 'California'),
(18, 'Flex'),
(2, '2e'),
(22, 'H3T'),
(23, 'Genesis'),
(26, 'XF'),
(28, 'Borrego'),
(28, 'Mohave/Borrego'),
(32, 'MKS'),
(35, 'Landaulet'),
(38, 'CL65 AMG'),
(38, 'SLK55 AMG'),
(4, 'Q5'),
(43, '370Z'),
(43, 'Cube'),
(43, 'GT-R'),
(48, 'G3'),
(5, 'Brooklands'),
(58, 'Equator'),
(6, 'Z4 M Roadster'),
(60, 'Venza'),
(61, 'CC'),
(61, 'Routan'),
(61, 'Tiguan'),
(62, 'XC60'),
(7, 'Veyron'),
(1, 'ZDX'),
(15, '458 Italia'),
(18, 'Transit Connect'),
(19, 'Terrain'),
(2, 'Type-1h'),
(21, 'Accord Crosstour'),
(23, 'Genesis Coupe'),
(28, 'Forte'),
(28, 'Soul'),
(3, 'Rapide'),
(30, 'Defender Ice Edition'),
(30, 'LR4'),
(31, 'HS'),
(31, 'LS Hybrid'),
(32, 'MKT'),
(33, 'Evora'),
(38, 'GLK-Class'),
(49, 'Panamera'),
(5, 'Azure T'),
(5, 'Continental Super'),
(51, 'Ghost'),
(57, 'Impreza WRX'),
(58, 'Kizashi'),
(59, 'Roadster'),
(6, 'X5 M'),
(6, 'X6 M'),
(10, 'Cruze'),
(10, 'Volt'),
(11, '200'),
(21, 'CR-Z'),
(23, 'Equus'),
(24, 'G25'),
(24, 'IPL G'),
(3, 'V12 Vantage'),
(3, 'V8 Vantage S'),
(3, 'Virage'),
(31, 'CT'),
(36, 'Mazda2'),
(38, 'SLS AMG'),
(38, 'SLS-Class'),
(38, 'Sprinter 2500'),
(38, 'Sprinter 3500'),
(40, 'Cooper Countryman'),
(40, 'Countryman'),
(41, 'Outlander Sport'),
(43, 'JUKE'),
(43, 'Leaf'),
(5, 'Mulsanne'),
(50, '1500'),
(52, '9-4X'),
(10, 'Sonic'),
(15, 'FF'),
(16, '500'),
(16, 'Nuova 500'),
(21, 'Crosstour'),
(21, 'FCX Clarity'),
(23, 'HED-5'),
(23, 'Veloster'),
(29, 'Aventador'),
(30, 'Range Rover Evoque'),
(31, 'LFA'),
(37, 'MP4-12C'),
(4, 'A7'),
(41, 'i-MiEV'),
(43, 'NV1500'),
(43, 'NV2500'),
(43, 'NV3500'),
(50, 'C/V'),
(54, 'iQ'),
(59, 'Model S'),
(60, 'Prius c'),
(60, 'Prius Plug-in'),
(60, 'Prius Plug-in Hybrid'),
(60, 'Prius v'),
(8, 'Verano');
GO

INSERT INTO TransmissionTypes
VALUES ('Automatic'),
('Manual');
GO

INSERT INTO BodyStyles
VALUES ('Car'),
('SUV'),
('Truck'),
('Van');
GO

INSERT INTO VehicleTypes
VALUES ('New'),
('Used');
GO

INSERT INTO Colors
VALUES ('Black', '#000'),
('Blue', '#1470b7'),
('Gray', '#8f8f94'),
('Green', '#01a350'),
('Red', '#ea1c28'),
('Silver', '#a2a3a6'),
('Tan', '#c4c59e'),
('White', '#f0f0f2');
GO

INSERT INTO InteriorColors
VALUES ('Black', '#000'),
('Cream', '#eaebcb'),
('Gray', '#8f8f94'),
('Tan', '#c4c59e');
GO

INSERT INTO PurchaseTypes
VALUES ('Bank Finance'),
('Cash'),
('Dealer Finance');
GO