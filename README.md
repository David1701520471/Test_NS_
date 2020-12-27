# Test_NS_

La base de datos es creada con codeFirst por lo cual primero abrir la consola de administrador de paquetes y usar los comandos Enable-Migration luego Add-Migration y por ultimo Update-Database con esto se crearía la base de datos local para almacenar los vuelos. 

Pasos de uso
1- Compilar la solución (nunca esta de más) 
2- Correr el ISS Express
3- Selección del botón Search Flights

El único problema fue la validación de datos enviados para la búsqueda desde la vista, por lo cual es mejor si solo se usan datos válidos para ver la funcionalidad y una vez almacenado un vuelo este no se podrá volver a ingresar.
