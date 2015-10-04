
INSERT INTO dbo.Item 
VALUES('af881f06-c3dd-4c74-94d6-58358fb1a8ea',
'Black and Gold',
'Ashley 13"',
'A Black and Gold Ashley Style 13" Wig');
GO

INSERT INTO ItemVariation ([VariationId],[ItemId],[VariationSku],[VariationName],[VariationOrdinal],[VariationPrice])
VALUES ('760bce54-d2fe-43d9-a802-8a73bed87aa1', 
'af881f06-c3dd-4c74-94d6-58358fb1a8ea', '728658041724', 'Color 1', 7, 25.99)
GO
