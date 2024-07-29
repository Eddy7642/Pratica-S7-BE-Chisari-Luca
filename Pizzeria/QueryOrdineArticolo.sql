INSERT INTO OrdineArticoli (OrdineId, ArticoloId, Quantita)
VALUES 
((SELECT TOP 1 Id FROM Ordini ORDER BY Id DESC), (SELECT Id FROM Articoli WHERE Nome = 'Margherita'), 2),
((SELECT TOP 1 Id FROM Ordini ORDER BY Id DESC), (SELECT Id FROM Articoli WHERE Nome = 'Diavola'), 1);