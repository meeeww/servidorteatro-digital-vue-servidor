using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeatroAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreacionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Obras",
                columns: table => new
                {
                    ObraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaID = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => x.ObraID);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    FuncionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObraID = table.Column<int>(type: "int", nullable: false),
                    SalaID = table.Column<int>(type: "int", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.FuncionID);
                    table.ForeignKey(
                        name: "FK_Funciones_Obras_ObraID",
                        column: x => x.ObraID,
                        principalTable: "Obras",
                        principalColumn: "ObraID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Salas",
                        principalColumn: "SalaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sesiones",
                columns: table => new
                {
                    SessionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesiones", x => x.SessionID);
                    table.ForeignKey(
                        name: "FK_Sesiones_Usuarios_UserID",
                        column: x => x.UserID,
                        principalTable: "Usuarios",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ReservaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Asiento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ReservaID);
                    table.ForeignKey(
                        name: "FK_Reservas_Funciones_FuncionID",
                        column: x => x.FuncionID,
                        principalTable: "Funciones",
                        principalColumn: "FuncionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_UserID",
                        column: x => x.UserID,
                        principalTable: "Usuarios",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Obras",
                columns: new[] { "ObraID", "CategoriaID", "Descripcion", "Imagen", "Titulo" },
                values: new object[,]
                {
                    { 1, 1, "¿Hasta que punto nos somete la tecnología? ¿Somos libres? ¿Qué tipo de sociedad hemos construido entre todos? ¿Cómo se nos plantea el futuro? ¿Nos merecemos el calificativo de \"seres humanos\"? \r\n\r\nAdictos trata de dar respuesta a estos interrogantes que abordan problemáticas que nos afectan a todos. Cuestiones que no acostumbramos a ver subidas en un escenario que ahora se confrontan con el público contemporáneo. \r\n\r\nLas personas solemos asumir ciertos paradigmas y cuestiones como válidos y ciertos sin siquiera plantearnos las mentiras y distorsiones que pueden esconder detrás. En un mundo en el que la desinformación se expande, el personaje de Estela y su transformación constituirá una metáfora de la disposición del ser humano para cambiar de actitud. Un texto que reivindica y reflexiona sobre la capacidad de reacción de las personas y que enseña que un punto de rebeldía es necesario cuando queremos cambiar algo. \r\n\r\nLola Herrera, Ana Labordeta y Lola Baldrich protagonizan un espectáculo que grita... ¡Adictos somos todos!", "https://cd1.taquilla.com/data/images/t/de/adictos-con-lola-herrera__330x275.jpg", "Adictos con Lola Herrera" },
                    { 2, 1, "Mentiras, verdades, ilusiones y la educación que recibimos desde pequeños... \r\n\r\nLaponia es una comedia de Cristina Clemente y Marc Angelet que convierte una velada de fiesta e ilusión en una batalla entre hermanas, parejas y cuñados. Una obra que nos hará pensar y reír a la vez que nos planteará diferentes situaciones éticas y morales que nos podrían pasar a todos. ¿La verdad es tan buena como dicen y la mentira tan mala?\r\n\r\nLaponia es el lugar en el que dos familias se encuentran con la intención de celebrar la Nochebuena y la llegada de Papá Noel. Todo parece ir bien hasta que una de las criaturas explica al otro que Papá Noel no existe, y que es un personaje que ha sido creado para que los padres puedan controlar a sus hijos y hacer que se comporten bien.\r\n\r\nA partir de aquí, las dos parejas se enzarzan en una discusión sobre la verdad y la mentira, las costumbres y los valores familiares, y comienzan a salir a la luz varias verdades ocultas. ¿Qué secreto inconfesable tiene cada uno de ellos? ¡Descúbrelo tú mismo!", "https://cd1.taquilla.com/data/images/t/8e/laponia__330x275.jpg", "Laponia" },
                    { 3, 0, "Tras el éxito cosechado con La Gran Ilusión, uno de los mayores espectáculos de magia de nuestro país, el Mago Pop llega de nuevo para mostrarnos los mejores trucos de ilusionismo en su nuevo espectáculo Nada es imposible. Y es que es innegable que Antonio Díaz ha sabido sacarle partido a lo que mejor sabe hacer, y no ha dudado en demostrar que el arte de la magia puede ser exhibido tanto en los teatros como en televisión.\r\n\r\nNada es Imposible es un espectáculo en el que magia y humor se fusionan para hacernos pasar una velada de lo más original. Con el único objetivo de sorprender al público, este experto en magia ha preparado entre un gran secretismo  unos de sus shows más creativos hasta el momento, en el que no dudará en hacer uso de la innovación y la fantasía. Antonio Díaz nos invita a un así a hacer un recorrido por lo extraordinario, donde el asombro, la diversión y las sorpresas no terminarán nunca.\r\n\r\nLa historia de Antonio Díaz es la historia de la sorpresa, de la ilusión. De la pequeña pantalla pasó al teatro, para convertirse en el mago más taquillero de toda Europa. Conocido internacionalmente, este Premio Nacional de Magia llega dispuesto a repetir el éxito de sus anteriores espectáculos y demostrarnos que verdaderamente, nada es imposible.", "https://cd1.taquilla.com/data/images/t/78/nada-es-imposible-el-mago-pop__330x275.jpg", "Nada es Imposible - el Mago pop" },
                    { 4, 2, "Cristina Clemente y Marc Angelet son los autores de 'Una Terapia Integral', la comedia que trata de retratar a una sociedad que parece estar eliminando la religión, pero que a su vez tiene una gran necesidad de creer, tener fe en algo que nos ayude a encontrar sentido a nuestras vidas y a poner orden en ellas. Un curso intensivo con cuatro magníficos intérpretes Antonio Molero, Angy Fernández, Esther Ortega y César Camino.\r\n\r\n¿Una corteza poco crujiente? Problemas laborales ¿Una miga demasiado densa? Crisis de pareja ¿Un pan soso? Una vida sexual insatisfactoria.\r\n\r\nTodos quieren apuntarse a los cursos de hacer pan que imparte Toni Roca. Sus diez años de experiencia y las pocas plazas ofertadas hacen que la gente haga cola para apuntarse. Para el maestro, \"somos el pan que hacemos\" y su curso garantiza que, después de unas cuantas sesiones, el alumno será capaz de hacer un pan excelente. Lo curioso de su sistema de aprendizaje es que los alumnos no solo tendrán que amasar o controlar la temperatura del horno: también deberán sincerarse, llorar, reír, gritar... y liberarse. \r\n\r\nToni Roca tiene clara su premisa: “Para hacer un buen pan, no hace falta la mejor harina o la levadura más fresca, para hacer un buen pan solo es necesario estar bien con uno mismo”. ", "https://cd1.taquilla.com/data/images/t/18/una-terapia-integral-madrid__330x275.jpg", "Una Terapia Integral Madrid" },
                    { 5, 2, "Lola es una camarera Sevillana, cansada, frustrada y enfadada con la vida. Periodista frustrada y portadora de la mala suerte, aguanta cada día a los borrachos del trabajo con resignación y todo el sentido del humor que puede. Sin embargo, de tanto recordar su mala suerte y de tanto blasfemar, un día en un arrebato se acuerda hasta de la mísmisima virgen.\r\n\r\nHasta que La Virgen se le aparece. Y descubre que no son mujeres tan diferentes.\r\n\r\nEsta comedia arrolladora e incesante es un auténtico símbolo del teatro de humor en nuestro país: más de diez años de programación a sus espaldas lo corroboran. Interpretada por Lola Marmolejo en el papel de La Virgen y Rocío Galán como camarera, de la compañía Bastarda Española, es una apuesta segura si lo que estás buscando es una tarde de carcajadas.\r\n\r\n¡No te la pierdas!", "https://cd1.taquilla.com/data/images/t/f8/estrella-sublime__330x275.jpeg", "Estrella Sublime" },
                    { 6, 1, "Una compañía de teatro amateur quiere presentar al público su primera obra: una función de misterio al más puro estilo Agatha Christie, y estamos todos invitados. Sin embargo, montar un gran espectáculo es más complicado, y todo lo que podría salir mal parece que hoy está dispuesto a fallar.\r\n\r\nY es que los actores que hacen de muertos se mueven más de lo debido, el atrezzo se cae a cachos, el guión se les olvida, la dirección es un desastre, la iluminación falla... Una consecución de desaciertos que convierten el estreno en una hilarante comedia con reminiscencias al estilo Monthy Python.\r\n\r\nLa función que sale mal ha hecho partirse de risa a más de 8 millones de espectadores desde su estreno en el West End en Londres (2012), acumulando los mayores premios en su categoría, y sigue agotando localidades cada día. También ha triunfado en Broadway y ha sido presentada en 30 países. ¡Ahora puedes disfrutar de ella en Madrid!", "https://cd1.taquilla.com/data/images/t/3d/la-funcion-que-sale-mal__330x275.jpg", "La Función que Sale mal" },
                    { 7, 0, "Norma Aleandro dirige Escenas de la vida conyugal, una versión teatral de la película homónima de Ingmar Bergman, que desde su presentación cosechó varios e importantísimos premios como el Golden Globe y el BAFTA. En 1981, Bergman estrenó la primera adaptación teatral en el teatro Marstall de Munich (Alemania) y desde entonces ha sido un éxito en numerosos países.\r\n\r\nRicardo Darín y Andrea Pietra dan vida respectivamente a Juan y Marina, una pareja que representa sobre el escenario momentos clave en su matrimonio. A lo largo de la obra, se exploran temas como el amor, la comunicación, la infidelidad, la rutina y el paso del tiempo. La historia sigue la evolución de la relación desde los primeros días de amor apasionado hasta las dificultades y desafíos que enfrenta la pareja a medida que transcurren los años.\r\n\r\nLa narrativa atemporal y la sinergia entre actores y personajes rompen la cuarta pared, sumergiendo a la audiencia en un juego emotivo y reflexivo sobre el matrimonio y la vida: situaciones aparentemente divertidas que dentro ocultan un profundo dramatismo. Escenas de la vida conyugal ha sido elogiada por su profundidad psicológica y su capacidad para conectar con el público a través de la identificación con los personajes. Así, ha recibido 4 premios Estrella de Mar y el prestigioso Premio José María Vilches, una distinción que honra a las obras que destacan por su contribución a la dignidad humana y los valores sociales.", "https://cd1.taquilla.com/data/images/t/c5/escenas-de-la-vida-conyugal__330x275.jpg", "Escenas de la Vida Conyugal" },
                    { 8, 0, "Rafael Álvarez es un actor y dramaturgo español de origen cordobés, más conocido por su sobrenombre artístico El Brujo.\r\n\r\nTitulado por la Real Escuela Superior de Arte Dramático, su actividad comenzó cuando tenía sólo 20 años con el \"El juego de los Insectos\", estrenada en 1970. Desde entonces, Rafael Álvarez se ha dedicado a la actuación, la producción y el mundo del teatro en general.\r\n\r\nEn 1988 funda la compañía Pentación S.A. junto a nombres como José Luis Alonso de Santos, Gerardo Malla y  Jesús Cimarro, y también su propia productora, El Brujo, S.L., cuyas obras se mantienen programadas con mucha asiduidad.\r\n\r\nEste actor y productor también ha participado en diversas películas (Juncal, Brigada Central...) y ha recibido premios tan destacados como el Premio Canal Sur al Mejor Espectáculo teatral 2000 y XIII Premio Nacional de Teatro Pepe Isbert, entre muchos otros.", "https://cd1.taquilla.com/data/images/t/0f/el-brujo-rafael-alvarez__330x275.jpg", "Rafael Álvarez, El Brujo" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "SalaID", "Capacidad", "Nombre" },
                values: new object[,]
                {
                    { 1, 100, "Sala Principal" },
                    { 2, 50, "Sala Secundaria" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UserID", "Apellido", "Contra", "Email", "Nombre", "Rol", "Telefono" },
                values: new object[,]
                {
                    { 1, "Gomez", "pass01", "carlosgomez@mail.com", "Carlos", 0, "650600001" },
                    { 2, "Lopez", "pass02", "analopez@mail.com", "Ana", 0, "650600002" },
                    { 3, "Martinez", "pass03", "luismartinez@mail.com", "Luis", 0, "650600003" },
                    { 4, "Hernandez", "pass04", "sofiahernandez@mail.com", "Sofia", 0, "650600004" },
                    { 5, "Ramirez", "pass05", "marioramirez@mail.com", "Mario", 0, "650600005" },
                    { 6, "Fernandez", "pass06", "laurafernandez@mail.com", "Laura", 0, "650600006" },
                    { 7, "Gonzalez", "pass07", "davidgonzalez@mail.com", "David", 0, "650600007" },
                    { 8, "Ruiz", "pass08", "monicaruiz@mail.com", "Monica", 0, "650600008" },
                    { 9, "Diaz", "pass09", "jorgediaz@mail.com", "Jorge", 0, "650600009" },
                    { 10, "Moreno", "pass10", "carmenmoreno@mail.com", "Carmen", 0, "650600010" },
                    { 11, "Alvarez", "pass11", "fernandoalvarez@mail.com", "Fernando", 0, "650600011" },
                    { 12, "Perez", "pass12", "beatrizperez@mail.com", "Beatriz", 0, "650600012" },
                    { 13, "Jimenez", "pass13", "robertojimenez@mail.com", "Roberto", 0, "650600013" },
                    { 14, "Lopez", "pass14", "patricialopez@mail.com", "Patricia", 0, "650600014" },
                    { 15, "Sanchez", "pass15", "manuelsanchez@mail.com", "Manuel", 0, "650600015" },
                    { 16, "Morales", "pass16", "silviamorales@mail.com", "Silvia", 0, "650600016" },
                    { 17, "Navarro", "pass17", "oscarnavarro@mail.com", "Oscar", 0, "650600017" },
                    { 18, "Gutierrez", "pass18", "teresagutierrez@mail.com", "Teresa", 0, "650600018" },
                    { 19, "Romero", "pass19", "albertoromero@mail.com", "Alberto", 0, "650600019" },
                    { 20, "Torres", "pass20", "luciatorres@mail.com", "Lucia", 0, "650600020" },
                    { 21, "Molina", "pass21", "elenamolina@mail.com", "Elena", 0, "650600021" },
                    { 22, "Vidal", "pass22", "pablovidal@mail.com", "Pablo", 0, "650600022" },
                    { 23, "Ortega", "pass23", "sandraortega@mail.com", "Sandra", 0, "650600023" },
                    { 24, "Pascual", "pass24", "sergiopascual@mail.com", "Sergio", 0, "650600024" },
                    { 25, "Ibañez", "pass25", "raquelibanez@mail.com", "Raquel", 0, "650600025" },
                    { 26, "Mendez", "pass26", "juanmendez@mail.com", "Juan", 0, "650600026" },
                    { 27, "Dominguez", "pass27", "martadominguez@mail.com", "Marta", 0, "650600027" },
                    { 28, "Gil", "pass28", "antoniogil@mail.com", "Antonio", 0, "650600028" },
                    { 29, "Vargas", "pass29", "isabelvargas@mail.com", "Isabel", 0, "650600029" },
                    { 30, "Blanco", "pass30", "joseblanco@mail.com", "José", 0, "650600030" },
                    { 31, "Santos", "pass31", "cristinasantos@mail.com", "Cristina", 0, "650600031" },
                    { 32, "Marin", "pass32", "franciscomarin@mail.com", "Francisco", 0, "650600032" },
                    { 33, "Lozano", "pass33", "lauralozano@mail.com", "Laura", 0, "650600033" },
                    { 34, "Sanchez", "pass34", "victorsanchez@mail.com", "Victor", 0, "650600034" },
                    { 35, "Garcia", "pass35", "mariagarcia@mail.com", "Maria", 0, "650600035" },
                    { 36, "Morales", "pass36", "javiermorales@mail.com", "Javier", 0, "650600036" },
                    { 37, "Herrera", "pass37", "dianaherrera@mail.com", "Diana", 0, "650600037" },
                    { 38, "Garrido", "pass38", "marcosgarrido@mail.com", "Marcos", 0, "650600038" },
                    { 39, "Priet}", "pass39", "yolandapriet@mail.com", "Yolanda", 0, "650600039" },
                    { 40, "Cano", "pass40", "luiscano@mail.com", "Luis", 0, "650600040" },
                    { 41, "Vidal", "pass41", "danielvidal@mail.com", "Daniel", 0, "650600041" },
                    { 42, "Moya", "pass42", "saramoya@mail.com", "Sara", 0, "650600042" },
                    { 43, "Ortega", "pass43", "alexortega@mail.com", "Alex", 0, "650600043" },
                    { 44, "Prieto", "pass44", "marinaprieto@mail.com", "Marina", 0, "650600044" },
                    { 45, "Mendez", "pass45", "pablomendez@mail.com", "Pablo", 0, "650600045" },
                    { 46, "Herrero", "pass46", "claraherrero@mail.com", "Clara", 0, "650600046" },
                    { 47, "Sancho", "pass47", "ivansancho@mail.com", "Ivan", 0, "650600047" },
                    { 48, "Domenech", "pass48", "juliadomenech@mail.com", "Julia", 0, "650600048" },
                    { 49, "Vega", "pass49", "sergiovega@mail.com", "Sergio", 0, "650600049" },
                    { 50, "Lorenzo", "pass50", "rosalorenzo@mail.com", "Rosa", 0, "650600050" },
                    { 51, "Costa", "pass51", "raulcosta@mail.com", "Raul", 0, "650600051" },
                    { 52, "Gallego", "pass52", "elenagallego@mail.com", "Elena", 0, "650600052" },
                    { 53, "Pascual", "pass53", "adrianpascual@mail.com", "Adrian", 0, "650600053" },
                    { 54, "Iglesias", "pass54", "nuriaiglesias@mail.com", "Nuria", 0, "650600054" },
                    { 55, "Serrano", "pass55", "jaimeserrano@mail.com", "Jaime", 0, "650600055" },
                    { 56, "Garrido", "pass56", "cristinagarrido@mail.com", "Cristina", 0, "650600056" },
                    { 57, "Merino", "pass57", "rubenmerino@mail.com", "Ruben", 0, "650600057" },
                    { 58, "Redondo", "pass58", "lorenaredondo@mail.com", "Lorena", 0, "650600058" },
                    { 59, "Molina", "pass59", "hectormolina@mail.com", "Hector", 0, "650600059" },
                    { 60, "Benitez", "pass60", "martabenitez@mail.com", "Marta", 0, "650600060" },
                    { 61, "Nieto", "pass61", "albertnieto@mail.com", "Albert", 0, "650600061" },
                    { 62, "Campos", "pass62", "soniacampos@mail.com", "Sonia", 0, "650600062" },
                    { 63, "Blanco", "pass63", "gonzaloblanco@mail.com", "Gonzalo", 0, "650600063" },
                    { 64, "Sanchez", "pass64", "aliciasanchez@mail.com", "Alicia", 0, "650600064" },
                    { 65, "Leon", "pass65", "omarleon@mail.com", "Omar", 0, "650600065" },
                    { 66, "Marquez", "pass66", "lidiamarquez@mail.com", "Lidia", 0, "650600066" },
                    { 67, "Herrera", "pass67", "juanherrera@mail.com", "Juan", 0, "650600067" },
                    { 68, "Cortes", "pass68", "luciacortes@mail.com", "Lucia", 0, "650600068" },
                    { 69, "Vidal", "pass69", "nachovidal@mail.com", "Nacho", 0, "650600069" },
                    { 70, "Cabrera", "pass70", "belencabrera@mail.com", "Belen", 0, "650600070" },
                    { 71, "Vega", "pass71", "carlosvega@mail.com", "Carlos", 0, "650600071" },
                    { 72, "Moreno", "pass72", "inesmoreno@mail.com", "Ines", 0, "650600072" },
                    { 73, "Ruiz", "pass73", "andresruiz@mail.com", "Andres", 0, "650600073" },
                    { 74, "Saez", "pass74", "carmensaez@mail.com", "Carmen", 0, "650600074" },
                    { 75, "Molina", "pass75", "javiermolina@mail.com", "Javier", 0, "650600075" },
                    { 76, "Herrera", "pass76", "saraherrera@mail.com", "Sara", 0, "650600076" },
                    { 77, "Dominguez", "pass77", "estebandominguez@mail.com", "Esteban", 0, "650600077" },
                    { 78, "Lopez", "pass78", "claralopez@mail.com", "Clara", 0, "650600078" },
                    { 79, "Garcia", "pass79", "rubengarcia@mail.com", "Ruben", 0, "650600079" },
                    { 80, "Fernandez", "pass80", "martafernandez@mail.com", "Marta", 0, "650600080" },
                    { 81, "Gomez", "pass81", "luisgomez@mail.com", "Luis", 0, "650600081" },
                    { 82, "Martinez", "pass82", "anamartinez@mail.com", "Ana", 0, "650600082" },
                    { 83, "Jimenez", "pass83", "davidjimenez@mail.com", "David", 0, "650600083" },
                    { 84, "Sanchez", "pass84", "patriciasanchez@mail.com", "Patricia", 0, "650600084" },
                    { 85, "Lorenzo", "pass85", "oscarlorenzo@mail.com", "Oscar", 0, "650600085" },
                    { 86, "Mora", "pass86", "lauramora@mail.com", "Laura", 0, "650600086" },
                    { 87, "Alonso", "pass87", "ivanalonso@mail.com", "Ivan", 0, "650600087" },
                    { 88, "Vidal", "pass88", "monicavidal@mail.com", "Monica", 0, "650600088" },
                    { 89, "Prieto", "pass89", "jorgeprieto@mail.com", "Jorge", 0, "650600089" },
                    { 90, "Campos", "pass90", "teresacampos@mail.com", "Teresa", 0, "650600090" },
                    { 91, "Gil", "pass91", "manuelgil@mail.com", "Manuel", 0, "650600091" },
                    { 92, "Mendez", "pass92", "silviamendez@mail.com", "Silvia", 0, "650600092" },
                    { 93, "Herrero", "pass93", "antonioherrero@mail.com", "Antonio", 0, "650600093" },
                    { 94, "Sancho", "pass94", "luciasancho@mail.com", "Lucia", 0, "650600094" },
                    { 95, "Dominguez", "pass95", "migueldominguez@mail.com", "Miguel", 0, "650600095" },
                    { 96, "Vega", "pass96", "nuriavega@mail.com", "Nuria", 0, "650600096" },
                    { 97, "Cabrera", "pass97", "albertocabrera@mail.com", "Alberto", 0, "650600097" },
                    { 98, "Lorenzo", "pass98", "rociolorenzo@mail.com", "Rocio", 0, "650600098" },
                    { 99, "Sanchez", "pass99", "felipesanchez@mail.com", "Felipe", 0, "650600099" },
                    { 100, "Morales", "pass100", "beatrizmorales@mail.com", "Beatriz", 0, "650600100" }
                });

            migrationBuilder.InsertData(
                table: "Funciones",
                columns: new[] { "FuncionID", "FechaHora", "ObraID", "Precio", "SalaID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 26, 19, 0, 0, 0, DateTimeKind.Unspecified), 3, 15, 1 },
                    { 2, new DateTime(2024, 3, 27, 21, 0, 0, 0, DateTimeKind.Unspecified), 5, 25, 2 },
                    { 3, new DateTime(2024, 3, 28, 20, 30, 0, 0, DateTimeKind.Unspecified), 2, 18, 1 },
                    { 4, new DateTime(2024, 3, 29, 22, 15, 0, 0, DateTimeKind.Unspecified), 8, 20, 2 },
                    { 5, new DateTime(2024, 3, 30, 19, 45, 0, 0, DateTimeKind.Unspecified), 1, 10, 1 },
                    { 6, new DateTime(2024, 3, 31, 23, 0, 0, 0, DateTimeKind.Unspecified), 4, 29, 2 },
                    { 7, new DateTime(2024, 4, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), 6, 22, 1 },
                    { 8, new DateTime(2024, 3, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), 7, 14, 2 },
                    { 9, new DateTime(2024, 3, 27, 19, 15, 0, 0, DateTimeKind.Unspecified), 3, 17, 1 },
                    { 10, new DateTime(2024, 3, 28, 21, 45, 0, 0, DateTimeKind.Unspecified), 5, 26, 2 },
                    { 11, new DateTime(2024, 3, 29, 19, 30, 0, 0, DateTimeKind.Unspecified), 1, 12, 1 },
                    { 12, new DateTime(2024, 3, 30, 22, 0, 0, 0, DateTimeKind.Unspecified), 8, 27, 2 },
                    { 13, new DateTime(2024, 3, 31, 20, 15, 0, 0, DateTimeKind.Unspecified), 2, 16, 1 },
                    { 14, new DateTime(2024, 4, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), 4, 30, 2 },
                    { 15, new DateTime(2024, 3, 26, 21, 30, 0, 0, DateTimeKind.Unspecified), 7, 13, 1 },
                    { 16, new DateTime(2024, 3, 27, 23, 0, 0, 0, DateTimeKind.Unspecified), 6, 24, 2 },
                    { 17, new DateTime(2024, 3, 28, 19, 45, 0, 0, DateTimeKind.Unspecified), 3, 11, 1 },
                    { 18, new DateTime(2024, 3, 29, 21, 15, 0, 0, DateTimeKind.Unspecified), 5, 28, 2 },
                    { 19, new DateTime(2024, 3, 30, 20, 30, 0, 0, DateTimeKind.Unspecified), 1, 14, 1 },
                    { 20, new DateTime(2024, 3, 31, 22, 45, 0, 0, DateTimeKind.Unspecified), 8, 19, 2 },
                    { 21, new DateTime(2024, 4, 1, 19, 15, 0, 0, DateTimeKind.Unspecified), 2, 23, 1 },
                    { 22, new DateTime(2024, 3, 26, 23, 0, 0, 0, DateTimeKind.Unspecified), 7, 17, 2 },
                    { 23, new DateTime(2024, 3, 27, 20, 45, 0, 0, DateTimeKind.Unspecified), 4, 40, 1 },
                    { 24, new DateTime(2024, 3, 28, 22, 30, 0, 0, DateTimeKind.Unspecified), 6, 25, 2 }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "ReservaID", "Asiento", "FuncionID", "UserID" },
                values: new object[,]
                {
                    { 1, 2, 5, 34 },
                    { 2, 45, 1, 87 },
                    { 3, 32, 15, 56 },
                    { 4, 18, 8, 22 },
                    { 5, 50, 24, 3 },
                    { 6, 5, 13, 77 },
                    { 7, 27, 7, 15 },
                    { 8, 11, 19, 89 },
                    { 9, 40, 2, 47 },
                    { 10, 29, 22, 9 },
                    { 11, 15, 10, 67 },
                    { 12, 36, 4, 98 },
                    { 13, 22, 11, 52 },
                    { 14, 48, 6, 33 },
                    { 15, 14, 16, 41 },
                    { 16, 31, 14, 29 },
                    { 17, 9, 21, 72 },
                    { 18, 23, 9, 18 },
                    { 19, 47, 3, 64 },
                    { 20, 28, 17, 55 },
                    { 21, 8, 23, 46 },
                    { 22, 33, 18, 19 },
                    { 23, 12, 20, 85 },
                    { 24, 38, 12, 74 },
                    { 25, 21, 5, 63 },
                    { 26, 6, 8, 27 },
                    { 27, 49, 16, 39 },
                    { 28, 34, 24, 10 },
                    { 29, 7, 13, 91 },
                    { 30, 26, 11, 58 },
                    { 31, 19, 9, 17 },
                    { 32, 44, 20, 80 },
                    { 33, 3, 2, 42 },
                    { 34, 37, 17, 24 },
                    { 35, 16, 6, 79 },
                    { 36, 30, 21, 95 },
                    { 37, 43, 15, 68 },
                    { 38, 24, 10, 60 },
                    { 39, 10, 7, 36 },
                    { 40, 35, 14, 83 },
                    { 41, 46, 3, 50 },
                    { 42, 1, 19, 13 },
                    { 43, 4, 22, 96 },
                    { 44, 41, 12, 70 },
                    { 45, 25, 18, 31 },
                    { 46, 13, 23, 88 },
                    { 47, 39, 1, 23 },
                    { 48, 2, 4, 78 },
                    { 49, 17, 8, 65 },
                    { 50, 42, 5, 90 },
                    { 51, 20, 7, 53 },
                    { 52, 31, 10, 44 },
                    { 53, 14, 13, 26 },
                    { 54, 48, 16, 8 },
                    { 55, 37, 19, 11 },
                    { 56, 23, 21, 32 },
                    { 57, 12, 24, 94 },
                    { 58, 29, 2, 49 },
                    { 59, 7, 14, 66 },
                    { 60, 50, 17, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_ObraID",
                table: "Funciones",
                column: "ObraID");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_SalaID",
                table: "Funciones",
                column: "SalaID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_FuncionID",
                table: "Reservas",
                column: "FuncionID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_UserID",
                table: "Reservas",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_UserID",
                table: "Sesiones",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Sesiones");

            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Obras");

            migrationBuilder.DropTable(
                name: "Salas");
        }
    }
}
