CREATE DATABASE MGarciaTurboPac
------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE Empleado(IdEmpleado INT PRIMARY KEY IDENTITY(1,1),
                      Email VARCHAR(100),
					  Password VARCHAR(50),
                      Nombre VARCHAR(50),
					  ApellidoPaterno VARCHAR(50),
					  ApellidoMaterno VARCHAR(50),
					  Status INT)
------------------------------------------------------------------------------------------------------------------------------		
------------------------------------------------------------------------------------------------------------------------------ 
ALTER PROCEDURE EmpleadoAdd 'mgarcia@gmail.com', '12345','Miguel','Garcia','Alcantara',1
     @Email VARCHAR(100),
	 @Password VARCHAR(50),
     @Nombre VARCHAR(50),
     @ApellidoPaterno VARCHAR(50),
     @ApellidoMaterno VARCHAR(50),
     @Status INT
	  AS
		INSERT INTO Empleado(Email,Password,Nombre,ApellidoPaterno,ApellidoMaterno,Status)
			VALUES(@Email,@Password,@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Status)
------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE EmpleadoUpdate 
     @IdEmpleado INT,
	 @Email VARCHAR(100),
	 @Password VARCHAR(50),
     @Nombre VARCHAR(50),
     @ApellidoPaterno VARCHAR(50),
     @ApellidoMaterno VARCHAR(50),
     @Status INT
	 AS	
		UPDATE Empleado SET 
		                    Email=@Email,
							Password=@Password,
							Nombre=@Nombre,
							ApellidoPaterno=@ApellidoPaterno,
							ApellidoMaterno=@ApellidoMaterno,
							Status=@Status
							
								WHERE IdEmpleado=@IdEmpleado
	
------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE EmpleadoDelete 
@IdEmpleado INT
AS
 DELETE FROM Empleado WHERE IdEmpleado=@IdEmpleado		
------------------------------------------------------------------------------------------------------------------------------ 
------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE EmpleadoGetAll
AS
	SELECT  Email,Password,Nombre,ApellidoPaterno,ApellidoMaterno,Status FROM Empleado			

------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE EmpleadoGetById
@IdEmpleado INT
AS
	SELECT  Email,Password,Nombre,ApellidoPaterno,ApellidoMaterno,Status FROM Empleado			

		WHERE IdEmpleado=@IdEmpleado

