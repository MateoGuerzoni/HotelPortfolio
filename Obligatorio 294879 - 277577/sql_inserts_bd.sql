USE HotelObligatorio
GO

INSERT INTO Usuarios (Email, Password)
VALUES	('diego@ort.com', 'diego123'),
		('mateo@prueba.com', 'mateo123');
GO

INSERT INTO Tipos (Nombre, Descripcion, CostoPorHuesped)
VALUES	('Deluxe', 'Cabanias mas costosas', 200),
		('Clasica', 'Cabanias clasicas', 150),
		('Economica', 'Cabanias mas economicas', 50),
		('Renovada', 'Cabanias hechas a nuevas', 120);
GO

INSERT INTO Cabanias (numHabitacion, Nombre, Descripcion, TieneJacuzzi, Estado, MaxHuespedes, Foto, TipoId)
VALUES				(1, 'Cabania extra deluxe', 'Cabania de muy alta gama', 1 , 1, 8, 'foto1', 1), 
					(2, 'Cabania deluxe', 'Cabania alta gama', 1, 1, 6, 'foto1', 1),   
					(3, 'Cabania clasica', 'Cabania clasica', 0, 0, 5, 'foto1', 2),
					(4, 'Cabania eco', 'Cabania economica pero bonita', 1, 0, 2, 'foto1', 3),
					(5, 'Cabania super eco', 'Cabania economica extrema', 0, 0, 2, 'foto1', 3),
					(6, 'Cabania clase media', 'Cabania intermedia', 1, 1, 5, 'foto1', 2);
GO
INSERT INTO Mantenimientos (Fecha, Descripcion, Costo, NombreFuncionario, CabaniaId)
VALUES	('2023-06-22', 'Reparacion de tuberias', 500, 'Messi', 1),
		('2023-06-22', 'Reparacion de puertas', 200, 'Messi', 1),
		('2023-06-22', 'Reparacion de electricidad', 500, 'Messi', 1),
		('2023-06-17', 'Reparacion de techo', 800, 'Messi', 2),
		('2023-06-17', 'Reparacion de electricidad', 200, 'Messi', 2),
		('2023-06-17', 'Reparacion de pisos', 300, 'Messi', 3),
		('2023-06-12', 'Reparacion de pisos', 300, 'Don Ramon', 4),
		('2023-06-12', 'Reparacion de techo', 340, 'Don Ramon', 4),
		('2023-06-07', 'Reparacion de electricdad', 400, 'Zombo', 4),
		('2023-06-07', 'Reparacion de mesas', 300, 'Zombo', 4),
		('2023-06-02', 'Reparacion de sillas', 340, 'Zombo', 4),
		('2023-05-28', 'Reparacion de internet', 400, 'Zombo', 4),
		('2023-05-28', 'Reparacion de tuberias', 500, 'Ibra', 1),
		('2023-05-28', 'Reparacion de puertas', 200, 'Ibra', 1),
		('2023-05-23', 'Reparacion de tuberias', 500, 'Ibra', 1),
		('2023-05-23', 'Reparacion de tuberias', 700, 'Forlan', 5),
		('2023-05-23', 'Reparacion de puertas', 400, 'Forlan', 6);
GO