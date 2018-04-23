# Hackerrank
.NET Cube Summation problem


Capas de la aplicación.
1. Presentación

Index.cshtml
bootstrap.css
Site.css
bootstrap.min.css

2. Servicio (orquestador)
CubeSummationController.cs

3.Negocio (entidades con sus metodos)
Update.cs (Su funcionalidad es ejecutar la operación Update que contiene la secuencia de datos de entrada del sistema.)
Query.cs (Su funcionalidad es ejecutar la operación Query que contiene la secuencia de datos de entrada del sistema.)
Operacion.cs (Su funcionalidad orquestar la ejecución de las secuencias de operación ingresadas y dirigirlas a las responsables QUERY o UPDATE.)
Matriz.cs (Su funcionalidad es construir una matriz 3D con capacidad definida como parametro.)
InformacionSecuenciaOperacion.cs (Su funcionalidad es establecer o obtener la secuencia de datos entrados por medio de un objeto tipo lista)
InformacionProceso.cs (Obtiene o establece los datos de ingreso del usuario a traves de la interación con la aplicación)
IOperacion.cs (Interfase que defina la operación base que van a contener las operaciones QUERY y UPDATE y nos ayuda a implementar el patron STATE para poder ampliar las operaciones en caso de que se desea agregar una diferente a UPDATE y QUERY)

4.  Pruebas
UnitTest1.cs (Contiene las pruebas a mfuncionalidades mas relevantes del proceso.)


¿En qué consiste el principio de responsabilidad única? ¿Cuál es su propósito?

Consiste en que cada clase, modulo o función tengan una unica razón, tengan una sola labor, un solo fin, y la meta final de este principio es  ayudarnos con la cohesion de nuestro código, que verdaderamente esten unidas las funcionalidades que tengan relación entre ellas y lograr mantener un bajo acoplamiento para que el código sea facilmente mantenible, se pueda extender y tambien sea facil realizarle pruebas.

¿Qué características tiene según tu opinión “buen” código o código limpio?

1. Tener un buen nombramiento general en el código, en clases, metodos, variables, etc.
2. Que al leer el código sea entendible, se pueda entender su proposito.
3. Que exista versionamiento del código fuente.
4. Que contengan pruebas que validen el funcionamiento del código.
5. Que la base del desarrollo del código se hayan tenido en cuenta los principios SOLID, KISS, DRY.
6. Que en el plan de desarrollo se incluyan revisiones pares por medio de personas lideres.
7. Definicion de la arquitectura: es importante que contenga este documento para evitar violaciones de arquitectura (una integracion o un diseño visual que no este acorde a los lineamientos iniciales) en desarrollos nuevos o evolucion del código.
