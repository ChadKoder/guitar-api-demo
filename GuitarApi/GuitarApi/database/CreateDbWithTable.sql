
USE master;
GO

--Delete the TestData database if it exists.
IF EXISTS(SELECT * from sys.databases WHERE name='GuitarDB')
BEGIN
    DROP DATABASE GuitarDB;
END

--Create a new database called TestData.
CREATE DATABASE GuitarDB;
--Press the F5 key to execute the code and create the database


USE GuitarDB;
CREATE TABLE dbo.Products
   (ProductID int PRIMARY KEY NOT NULL,
    Company varchar(25) NOT NULL,
	Model varchar(50) NOT NULL,
	Description varchar(1000) NULL,
	BodyType varchar(50) NULL,
	TotalFrets int NULL,
	FinishTop varchar(50) NULL,
	FinishNeck varchar(50) NULL,
	FinishBackSides varchar(50) NULL,
    Price money NULL,
	Url varchar(500) NULL
	)
--GO

--CREATE LOGIN  [NT AUTHORITY\LOCAL SERVICE] WITH PASSWORD=''
--USE GuitarDB

--IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'NT AUTHORITY\LOCAL SERVICE')
--BEGIN
--	CREATE USER ['NT AUTHORITY\LOCAL SERVICE] FOR LOGIN [NT AUTHORITY\LOCAL SERVICE] 
--	EXEC sp_addrolemember N'db_owner', N'NT AUTHORITY\LOCAL SERVICE'
--END;
GO

--MARTIN GUITARS
 insert into Products (ProductID, Company, Model, Description, BodyType, TotalFrets, FinishTop, FinishNeck, FinishBackSides, Price, Url)
 values(1, 'Martin', 'Steel String Backpacker Guitar',
 'The sky’s the limit for portability! The steel-string Backpacker travel guitar is lightweight, durable, easy to play (and tune) and is shaped to fit into the smallest places. Constructed of solid tonewoods.',
 'Unique To Backpacker', 15, 'Hand Rubbed Finish', 'Hand Rubbed Finish', 'Hand Rubbed Finish', '359.00', 'https://www.martinguitar.com/model/item/216-steel-string-backpacker-guitar.html')

 insert into Products (ProductID, Company, Model, Description, BodyType, TotalFrets, FinishTop, FinishNeck, FinishBackSides, Price, Url)
 values(2, 'Martin', 'DC-16GTE',
 'The DC-16GTE acoustic-electric guitar features a D-14 platform and a Dreadnought cutaway body design equipped with balanced tonewoods that produce a rich acoustic tone for recording or live performance. The sapele back and sides complement the solid Sitka spruce top finished in a polished gloss. Plug in at your next performance, and you will appreciate the electronics that reproduce your every playing nuance. When it is time to step up your sound, choose the DC-16GTE. One strum and you will be swept away!',
 'D-14 Fret Cutaway', 20, 'Polished Gloss', 'Satin', 'Satin', '2399.00', 'https://www.martinguitar.com/component/k2/item/143-dc-16gte.html?Itemid=6')

 insert into Products (ProductID, Company, Model, Description, BodyType, TotalFrets, FinishTop, FinishNeck, FinishBackSides, Price, Url)
 values(3, 'Martin', 'OMCPA4',
 'The OMCPA4 Rosewood adds tonal color and variety. The model features a 14-fret cutaway with fast and comfortable Performing Artist profile necks, and Fishman''s F1 Analog onboard electronics. Perfect for all performing artists.',
 ' 000-14 Fret Cutaway', 20, 'Polished Gloss', 'Satin', 'Satin', '1999.00', 'https://www.martinguitar.com/component/k2/item/161-omcpa4.html?Itemid=6')

 
 insert into Products (ProductID, Company, Model, Description, BodyType, TotalFrets, FinishTop, FinishNeck, FinishBackSides, Price, Url)
 values(4, 'Martin', 'GPCPA4',
 'The GPCPA4 Rosewood adds tonal color and variety. The model features a 14-fret cutaway with fast and comfortable Performing Artist profile necks, and Fishman''s F1 Analog onboard electronics. Perfect for all performing artists.',
 'Grand Performance 14-Fret Cutaway',
 20, 'Polished Gloss', 'Satin', 'Satin', '1999.00', 'https://www.martinguitar.com/component/k2/item/171-gpcpa4.html?Itemid=6')

 insert into Products (ProductID, Company, Model, Description, BodyType, TotalFrets, FinishTop, FinishNeck, FinishBackSides, Price, Url)
 values(5, 'Martin', 'SS-GP42-15',
 '2015 Winter NAMM Show Special – the SS-GP42-15 – is a spectacular stage performance guitar. With Martin’s new Vintage Tone System (VTS) Adirondack spruce soundboard and highly flamed Hawaiian koa back and sides, this Grand Performance acoustic-electric offers premium Style 42 appointments, state-of-the-art onboard Fishman Aura VT electronics, Madagascar rosewood bindings, and a polished gloss lacquer finish with “toasted sunburst” top shading. Personally signed by C. F. Martin IV and numbered in sequence, no more than fifty of these special guitars will be offered.',
 'Grand Performance 14 Fret Non-Cutaway',  20, 'Polished Gloss w/ Toasted Burst', 'Polished Gloss', ' Polished Gloss', '10999.00','https://www.martinguitar.com/new/item/3758-ss-gp42-15.html?Itemid=6')


 --Carvin Guitars
 insert into Products (ProductID, Company, Model, Description, BodyType, TotalFrets, FinishTop, FinishNeck, FinishBackSides, Price, Url)
 values(6, 'Carvin', 'JB200C Jason Becker Tribute Guitar',
 'In response to Jason Becker''s still-strong legions of fans around the world, Carvin Guitars has created the Jason Becker Tribute JB200C electric guitar. The Custom Shop worked with Jason to design this instrument as closely as possible to his original DC200. The JB200C is loaded with many upgraded standard features, combined with our state-of-the art modern manufacturing processes. With many available options, you can order your JB200C the way you want it, while maintaining the looks, playability and spirit of Jason''s original instrument. The JB200C is built in the USA, and is an instrument that you''ll be proud to play and own for years to come.',
 'alder with standard 4A flamed maple top',  24, 'flamed maple top', 'tung-oiled', null, '1699.00', 'http://www.carvinguitars.com/catalog/guitars/jb200c')

  --Carvin Guitars
 insert into Products (ProductID, Company, Model, Description, BodyType, TotalFrets, FinishTop, FinishNeck, FinishBackSides, Price, Url)
 values(7, 'Carvin', 'CT324C',
 'The mahogany set-neck of the CT324 features our "Rapid Play" low action neck, which assures effortless playability throughout the entire fingerboard, while the sleek set-in neck heel and lower body cutout allow easy uninhibited access at the 24th fret. The standard 25" scale, 14" radius fingerboard is ebony with abalone dot inlays, and other fingerboard woods, such as rosewood, maple, birdseye maple, flamed maple and zebrawood are available. You also can choose from an assortment of inlays made from genuine abalone or mother-of-pearl, in diamonds, blocks or our signature design. Standard frets are medium-jumbo nickel, with stainless steel, jumbo and low-wide frets optional.',
 'Honduras mahogany',  24, 'cutomizable', 'cutomizable', null, '1199.00','http://www.carvinguitars.com/guitars-in-stock/120560')





select * from Products