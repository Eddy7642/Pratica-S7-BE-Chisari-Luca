INSERT INTO Ordini (UtenteId, IndirizzoSpedizione, Note, DataOrdine)
VALUES 
((SELECT Id FROM Utenti WHERE Email = 'user1@pizzeria.com'), 'Via Roma 123', 'Nessuna nota', GETDATE());
