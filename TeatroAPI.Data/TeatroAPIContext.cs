using Microsoft.EntityFrameworkCore;
using TeatroAPI.Model;
namespace TeatroAPI.Data;
public class TeatroAPIContext : DbContext
{
    public TeatroAPIContext(DbContextOptions<TeatroAPIContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>()
            .Property(u => u.UserID)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Sesion>()
           .Property(s => s.SessionID)
           .ValueGeneratedOnAdd();

        modelBuilder.Entity<Obra>()
           .Property(o => o.ObraID)
           .ValueGeneratedOnAdd();

        modelBuilder.Entity<Sala>()
           .Property(s => s.SalaID)
           .ValueGeneratedOnAdd();

        modelBuilder.Entity<Funcion>()
           .Property(f => f.FuncionID)
           .ValueGeneratedOnAdd();

        modelBuilder.Entity<Reserva>()
           .Property(r => r.ReservaID)
           .ValueGeneratedOnAdd();

        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Sesiones)
            .WithOne(s => s.Usuario)
            .HasForeignKey(s => s.UserID);

        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Reservas)
            .WithOne(r => r.Usuario)
            .HasForeignKey(r => r.UserID);

        modelBuilder.Entity<Obra>()
            .HasMany(o => o.Funciones)
            .WithOne(f => f.Obra)
            .HasForeignKey(f => f.ObraID);

        modelBuilder.Entity<Sala>()
            .HasMany(s => s.Funciones)
            .WithOne(f => f.Sala)
            .HasForeignKey(f => f.SalaID);

        modelBuilder.Entity<Funcion>()
            .HasOne(f => f.Obra)
            .WithMany(o => o.Funciones)
            .HasForeignKey(f => f.ObraID);

        modelBuilder.Entity<Funcion>()
            .HasOne(f => f.Sala)
            .WithMany(s => s.Funciones)
            .HasForeignKey(f => f.SalaID);

        modelBuilder.Entity<Reserva>()
            .HasOne(r => r.Funcion)
            .WithMany(f => f.Reservas)
            .HasForeignKey(r => r.FuncionID);

        modelBuilder.Entity<Obra>().HasData(
            new Obra { ObraID = 1, Titulo = "Adictos con Lola Herrera", Descripcion = "¿Hasta que punto nos somete la tecnología? ¿Somos libres? ¿Qué tipo de sociedad hemos construido entre todos? ¿Cómo se nos plantea el futuro? ¿Nos merecemos el calificativo de \"seres humanos\"? \r\n\r\nAdictos trata de dar respuesta a estos interrogantes que abordan problemáticas que nos afectan a todos. Cuestiones que no acostumbramos a ver subidas en un escenario que ahora se confrontan con el público contemporáneo. \r\n\r\nLas personas solemos asumir ciertos paradigmas y cuestiones como válidos y ciertos sin siquiera plantearnos las mentiras y distorsiones que pueden esconder detrás. En un mundo en el que la desinformación se expande, el personaje de Estela y su transformación constituirá una metáfora de la disposición del ser humano para cambiar de actitud. Un texto que reivindica y reflexiona sobre la capacidad de reacción de las personas y que enseña que un punto de rebeldía es necesario cuando queremos cambiar algo. \r\n\r\nLola Herrera, Ana Labordeta y Lola Baldrich protagonizan un espectáculo que grita... ¡Adictos somos todos!", CategoriaID = 1, Imagen = "https://cd1.taquilla.com/data/images/t/de/adictos-con-lola-herrera__330x275.jpg" },
            new Obra { ObraID = 2, Titulo = "Laponia", Descripcion = "Mentiras, verdades, ilusiones y la educación que recibimos desde pequeños... \r\n\r\nLaponia es una comedia de Cristina Clemente y Marc Angelet que convierte una velada de fiesta e ilusión en una batalla entre hermanas, parejas y cuñados. Una obra que nos hará pensar y reír a la vez que nos planteará diferentes situaciones éticas y morales que nos podrían pasar a todos. ¿La verdad es tan buena como dicen y la mentira tan mala?\r\n\r\nLaponia es el lugar en el que dos familias se encuentran con la intención de celebrar la Nochebuena y la llegada de Papá Noel. Todo parece ir bien hasta que una de las criaturas explica al otro que Papá Noel no existe, y que es un personaje que ha sido creado para que los padres puedan controlar a sus hijos y hacer que se comporten bien.\r\n\r\nA partir de aquí, las dos parejas se enzarzan en una discusión sobre la verdad y la mentira, las costumbres y los valores familiares, y comienzan a salir a la luz varias verdades ocultas. ¿Qué secreto inconfesable tiene cada uno de ellos? ¡Descúbrelo tú mismo!", CategoriaID = 1, Imagen = "https://cd1.taquilla.com/data/images/t/8e/laponia__330x275.jpg" },
            new Obra { ObraID = 3, Titulo = "Nada es Imposible - el Mago pop", Descripcion = "Tras el éxito cosechado con La Gran Ilusión, uno de los mayores espectáculos de magia de nuestro país, el Mago Pop llega de nuevo para mostrarnos los mejores trucos de ilusionismo en su nuevo espectáculo Nada es imposible. Y es que es innegable que Antonio Díaz ha sabido sacarle partido a lo que mejor sabe hacer, y no ha dudado en demostrar que el arte de la magia puede ser exhibido tanto en los teatros como en televisión.\r\n\r\nNada es Imposible es un espectáculo en el que magia y humor se fusionan para hacernos pasar una velada de lo más original. Con el único objetivo de sorprender al público, este experto en magia ha preparado entre un gran secretismo  unos de sus shows más creativos hasta el momento, en el que no dudará en hacer uso de la innovación y la fantasía. Antonio Díaz nos invita a un así a hacer un recorrido por lo extraordinario, donde el asombro, la diversión y las sorpresas no terminarán nunca.\r\n\r\nLa historia de Antonio Díaz es la historia de la sorpresa, de la ilusión. De la pequeña pantalla pasó al teatro, para convertirse en el mago más taquillero de toda Europa. Conocido internacionalmente, este Premio Nacional de Magia llega dispuesto a repetir el éxito de sus anteriores espectáculos y demostrarnos que verdaderamente, nada es imposible.", CategoriaID = 0, Imagen = "https://cd1.taquilla.com/data/images/t/78/nada-es-imposible-el-mago-pop__330x275.jpg" },
            new Obra { ObraID = 4, Titulo = "Una Terapia Integral Madrid", Descripcion = "Cristina Clemente y Marc Angelet son los autores de 'Una Terapia Integral', la comedia que trata de retratar a una sociedad que parece estar eliminando la religión, pero que a su vez tiene una gran necesidad de creer, tener fe en algo que nos ayude a encontrar sentido a nuestras vidas y a poner orden en ellas. Un curso intensivo con cuatro magníficos intérpretes Antonio Molero, Angy Fernández, Esther Ortega y César Camino.\r\n\r\n¿Una corteza poco crujiente? Problemas laborales ¿Una miga demasiado densa? Crisis de pareja ¿Un pan soso? Una vida sexual insatisfactoria.\r\n\r\nTodos quieren apuntarse a los cursos de hacer pan que imparte Toni Roca. Sus diez años de experiencia y las pocas plazas ofertadas hacen que la gente haga cola para apuntarse. Para el maestro, \"somos el pan que hacemos\" y su curso garantiza que, después de unas cuantas sesiones, el alumno será capaz de hacer un pan excelente. Lo curioso de su sistema de aprendizaje es que los alumnos no solo tendrán que amasar o controlar la temperatura del horno: también deberán sincerarse, llorar, reír, gritar... y liberarse. \r\n\r\nToni Roca tiene clara su premisa: “Para hacer un buen pan, no hace falta la mejor harina o la levadura más fresca, para hacer un buen pan solo es necesario estar bien con uno mismo”. ", CategoriaID = 2, Imagen = "https://cd1.taquilla.com/data/images/t/18/una-terapia-integral-madrid__330x275.jpg" },
            new Obra { ObraID = 5, Titulo = "Estrella Sublime", Descripcion = "Lola es una camarera Sevillana, cansada, frustrada y enfadada con la vida. Periodista frustrada y portadora de la mala suerte, aguanta cada día a los borrachos del trabajo con resignación y todo el sentido del humor que puede. Sin embargo, de tanto recordar su mala suerte y de tanto blasfemar, un día en un arrebato se acuerda hasta de la mísmisima virgen.\r\n\r\nHasta que La Virgen se le aparece. Y descubre que no son mujeres tan diferentes.\r\n\r\nEsta comedia arrolladora e incesante es un auténtico símbolo del teatro de humor en nuestro país: más de diez años de programación a sus espaldas lo corroboran. Interpretada por Lola Marmolejo en el papel de La Virgen y Rocío Galán como camarera, de la compañía Bastarda Española, es una apuesta segura si lo que estás buscando es una tarde de carcajadas.\r\n\r\n¡No te la pierdas!", CategoriaID = 2, Imagen = "https://cd1.taquilla.com/data/images/t/f8/estrella-sublime__330x275.jpeg" },
            new Obra { ObraID = 6, Titulo = "La Función que Sale mal", Descripcion = "Una compañía de teatro amateur quiere presentar al público su primera obra: una función de misterio al más puro estilo Agatha Christie, y estamos todos invitados. Sin embargo, montar un gran espectáculo es más complicado, y todo lo que podría salir mal parece que hoy está dispuesto a fallar.\r\n\r\nY es que los actores que hacen de muertos se mueven más de lo debido, el atrezzo se cae a cachos, el guión se les olvida, la dirección es un desastre, la iluminación falla... Una consecución de desaciertos que convierten el estreno en una hilarante comedia con reminiscencias al estilo Monthy Python.\r\n\r\nLa función que sale mal ha hecho partirse de risa a más de 8 millones de espectadores desde su estreno en el West End en Londres (2012), acumulando los mayores premios en su categoría, y sigue agotando localidades cada día. También ha triunfado en Broadway y ha sido presentada en 30 países. ¡Ahora puedes disfrutar de ella en Madrid!", CategoriaID = 1, Imagen = "https://cd1.taquilla.com/data/images/t/3d/la-funcion-que-sale-mal__330x275.jpg" },
            new Obra { ObraID = 7, Titulo = "Escenas de la Vida Conyugal", Descripcion = "Norma Aleandro dirige Escenas de la vida conyugal, una versión teatral de la película homónima de Ingmar Bergman, que desde su presentación cosechó varios e importantísimos premios como el Golden Globe y el BAFTA. En 1981, Bergman estrenó la primera adaptación teatral en el teatro Marstall de Munich (Alemania) y desde entonces ha sido un éxito en numerosos países.\r\n\r\nRicardo Darín y Andrea Pietra dan vida respectivamente a Juan y Marina, una pareja que representa sobre el escenario momentos clave en su matrimonio. A lo largo de la obra, se exploran temas como el amor, la comunicación, la infidelidad, la rutina y el paso del tiempo. La historia sigue la evolución de la relación desde los primeros días de amor apasionado hasta las dificultades y desafíos que enfrenta la pareja a medida que transcurren los años.\r\n\r\nLa narrativa atemporal y la sinergia entre actores y personajes rompen la cuarta pared, sumergiendo a la audiencia en un juego emotivo y reflexivo sobre el matrimonio y la vida: situaciones aparentemente divertidas que dentro ocultan un profundo dramatismo. Escenas de la vida conyugal ha sido elogiada por su profundidad psicológica y su capacidad para conectar con el público a través de la identificación con los personajes. Así, ha recibido 4 premios Estrella de Mar y el prestigioso Premio José María Vilches, una distinción que honra a las obras que destacan por su contribución a la dignidad humana y los valores sociales.", CategoriaID = 0, Imagen = "https://cd1.taquilla.com/data/images/t/c5/escenas-de-la-vida-conyugal__330x275.jpg" },
            new Obra { ObraID = 8, Titulo = "Rafael Álvarez, El Brujo", Descripcion = "Rafael Álvarez es un actor y dramaturgo español de origen cordobés, más conocido por su sobrenombre artístico El Brujo.\r\n\r\nTitulado por la Real Escuela Superior de Arte Dramático, su actividad comenzó cuando tenía sólo 20 años con el \"El juego de los Insectos\", estrenada en 1970. Desde entonces, Rafael Álvarez se ha dedicado a la actuación, la producción y el mundo del teatro en general.\r\n\r\nEn 1988 funda la compañía Pentación S.A. junto a nombres como José Luis Alonso de Santos, Gerardo Malla y  Jesús Cimarro, y también su propia productora, El Brujo, S.L., cuyas obras se mantienen programadas con mucha asiduidad.\r\n\r\nEste actor y productor también ha participado en diversas películas (Juncal, Brigada Central...) y ha recibido premios tan destacados como el Premio Canal Sur al Mejor Espectáculo teatral 2000 y XIII Premio Nacional de Teatro Pepe Isbert, entre muchos otros.", CategoriaID = 0, Imagen = "https://cd1.taquilla.com/data/images/t/0f/el-brujo-rafael-alvarez__330x275.jpg" }
        );

        modelBuilder.Entity<Sala>().HasData(
            new Sala { SalaID = 1, Nombre = "Sala Principal", Capacidad = 100 },
            new Sala { SalaID = 2, Nombre = "Sala Secundaria", Capacidad = 50 }
        );

        modelBuilder.Entity<Funcion>().HasData(
            new Funcion { FuncionID = 1, ObraID = 3, SalaID = 1, FechaHora = new DateTime(2024, 3, 26, 19, 0, 0), Precio = 15 },
            new Funcion { FuncionID = 2, ObraID = 5, SalaID = 2, FechaHora = new DateTime(2024, 3, 27, 21, 0, 0), Precio = 25 },
            new Funcion { FuncionID = 3, ObraID = 2, SalaID = 1, FechaHora = new DateTime(2024, 3, 28, 20, 30, 0), Precio = 18 },
            new Funcion { FuncionID = 4, ObraID = 8, SalaID = 2, FechaHora = new DateTime(2024, 3, 29, 22, 15, 0), Precio = 20 },
            new Funcion { FuncionID = 5, ObraID = 1, SalaID = 1, FechaHora = new DateTime(2024, 3, 30, 19, 45, 0), Precio = 10 },
            new Funcion { FuncionID = 6, ObraID = 4, SalaID = 2, FechaHora = new DateTime(2024, 3, 31, 23, 0, 0), Precio = 29 },
            new Funcion { FuncionID = 7, ObraID = 6, SalaID = 1, FechaHora = new DateTime(2024, 4, 1, 20, 0, 0), Precio = 22 },
            new Funcion { FuncionID = 8, ObraID = 7, SalaID = 2, FechaHora = new DateTime(2024, 3, 26, 22, 30, 0), Precio = 14 },
            new Funcion { FuncionID = 9, ObraID = 3, SalaID = 1, FechaHora = new DateTime(2024, 3, 27, 19, 15, 0), Precio = 17 },
            new Funcion { FuncionID = 10, ObraID = 5, SalaID = 2, FechaHora = new DateTime(2024, 3, 28, 21, 45, 0), Precio = 26 },
            new Funcion { FuncionID = 11, ObraID = 1, SalaID = 1, FechaHora = new DateTime(2024, 3, 29, 19, 30, 0), Precio = 12 },
            new Funcion { FuncionID = 12, ObraID = 8, SalaID = 2, FechaHora = new DateTime(2024, 3, 30, 22, 0, 0), Precio = 27 },
            new Funcion { FuncionID = 13, ObraID = 2, SalaID = 1, FechaHora = new DateTime(2024, 3, 31, 20, 15, 0), Precio = 16 },
            new Funcion { FuncionID = 14, ObraID = 4, SalaID = 2, FechaHora = new DateTime(2024, 4, 1, 19, 0, 0), Precio = 30 },
            new Funcion { FuncionID = 15, ObraID = 7, SalaID = 1, FechaHora = new DateTime(2024, 3, 26, 21, 30, 0), Precio = 13 },
            new Funcion { FuncionID = 16, ObraID = 6, SalaID = 2, FechaHora = new DateTime(2024, 3, 27, 23, 0, 0), Precio = 24 },
            new Funcion { FuncionID = 17, ObraID = 3, SalaID = 1, FechaHora = new DateTime(2024, 3, 28, 19, 45, 0), Precio = 11 },
            new Funcion { FuncionID = 18, ObraID = 5, SalaID = 2, FechaHora = new DateTime(2024, 3, 29, 21, 15, 0), Precio = 28 },
            new Funcion { FuncionID = 19, ObraID = 1, SalaID = 1, FechaHora = new DateTime(2024, 3, 30, 20, 30, 0), Precio = 14 },
            new Funcion { FuncionID = 20, ObraID = 8, SalaID = 2, FechaHora = new DateTime(2024, 3, 31, 22, 45, 0), Precio = 19 },
            new Funcion { FuncionID = 21, ObraID = 2, SalaID = 1, FechaHora = new DateTime(2024, 4, 1, 19, 15, 0), Precio = 23 },
            new Funcion { FuncionID = 22, ObraID = 7, SalaID = 2, FechaHora = new DateTime(2024, 3, 26, 23, 0, 0), Precio = 17 },
            new Funcion { FuncionID = 23, ObraID = 4, SalaID = 1, FechaHora = new DateTime(2024, 3, 27, 20, 45, 0), Precio = 40 },
            new Funcion { FuncionID = 24, ObraID = 6, SalaID = 2, FechaHora = new DateTime(2024, 3, 28, 22, 30, 0), Precio = 25 }
        );

        modelBuilder.Entity<Usuario>().HasData(
            new Usuario { UserID = 1, Nombre = "Carlos", Apellido = "Gomez", Email = "carlosgomez@mail.com", Telefono = "650600001", Contra = "pass01" },
            new Usuario { UserID = 2, Nombre = "Ana", Apellido = "Lopez", Email = "analopez@mail.com", Telefono = "650600002", Contra = "pass02" },
            new Usuario { UserID = 3, Nombre = "Luis", Apellido = "Martinez", Email = "luismartinez@mail.com", Telefono = "650600003", Contra = "pass03" },
            new Usuario { UserID = 4, Nombre = "Sofia", Apellido = "Hernandez", Email = "sofiahernandez@mail.com", Telefono = "650600004", Contra = "pass04" },
            new Usuario { UserID = 5, Nombre = "Mario", Apellido = "Ramirez", Email = "marioramirez@mail.com", Telefono = "650600005", Contra = "pass05" },
            new Usuario { UserID = 6, Nombre = "Laura", Apellido = "Fernandez", Email = "laurafernandez@mail.com", Telefono = "650600006", Contra = "pass06" },
            new Usuario { UserID = 7, Nombre = "David", Apellido = "Gonzalez", Email = "davidgonzalez@mail.com", Telefono = "650600007", Contra = "pass07" },
            new Usuario { UserID = 8, Nombre = "Monica", Apellido = "Ruiz", Email = "monicaruiz@mail.com", Telefono = "650600008", Contra = "pass08" },
            new Usuario { UserID = 9, Nombre = "Jorge", Apellido = "Diaz", Email = "jorgediaz@mail.com", Telefono = "650600009", Contra = "pass09" },
            new Usuario { UserID = 10, Nombre = "Carmen", Apellido = "Moreno", Email = "carmenmoreno@mail.com", Telefono = "650600010", Contra = "pass10" },
            new Usuario { UserID = 11, Nombre = "Fernando", Apellido = "Alvarez", Email = "fernandoalvarez@mail.com", Telefono = "650600011", Contra = "pass11" },
            new Usuario { UserID = 12, Nombre = "Beatriz", Apellido = "Perez", Email = "beatrizperez@mail.com", Telefono = "650600012", Contra = "pass12" },
            new Usuario { UserID = 13, Nombre = "Roberto", Apellido = "Jimenez", Email = "robertojimenez@mail.com", Telefono = "650600013", Contra = "pass13" },
            new Usuario { UserID = 14, Nombre = "Patricia", Apellido = "Lopez", Email = "patricialopez@mail.com", Telefono = "650600014", Contra = "pass14" },
            new Usuario { UserID = 15, Nombre = "Manuel", Apellido = "Sanchez", Email = "manuelsanchez@mail.com", Telefono = "650600015", Contra = "pass15" },
            new Usuario { UserID = 16, Nombre = "Silvia", Apellido = "Morales", Email = "silviamorales@mail.com", Telefono = "650600016", Contra = "pass16" },
            new Usuario { UserID = 17, Nombre = "Oscar", Apellido = "Navarro", Email = "oscarnavarro@mail.com", Telefono = "650600017", Contra = "pass17" },
            new Usuario { UserID = 18, Nombre = "Teresa", Apellido = "Gutierrez", Email = "teresagutierrez@mail.com", Telefono = "650600018", Contra = "pass18" },
            new Usuario { UserID = 19, Nombre = "Alberto", Apellido = "Romero", Email = "albertoromero@mail.com", Telefono = "650600019", Contra = "pass19" },
            new Usuario { UserID = 20, Nombre = "Lucia", Apellido = "Torres", Email = "luciatorres@mail.com", Telefono = "650600020", Contra = "pass20" },
            new Usuario { UserID = 21, Nombre = "Elena", Apellido = "Molina", Email = "elenamolina@mail.com", Telefono = "650600021", Contra = "pass21" },
            new Usuario { UserID = 22, Nombre = "Pablo", Apellido = "Vidal", Email = "pablovidal@mail.com", Telefono = "650600022", Contra = "pass22" },
            new Usuario { UserID = 23, Nombre = "Sandra", Apellido = "Ortega", Email = "sandraortega@mail.com", Telefono = "650600023", Contra = "pass23" },
            new Usuario { UserID = 24, Nombre = "Sergio", Apellido = "Pascual", Email = "sergiopascual@mail.com", Telefono = "650600024", Contra = "pass24" },
            new Usuario { UserID = 25, Nombre = "Raquel", Apellido = "Ibañez", Email = "raquelibanez@mail.com", Telefono = "650600025", Contra = "pass25" },
            new Usuario { UserID = 26, Nombre = "Juan", Apellido = "Mendez", Email = "juanmendez@mail.com", Telefono = "650600026", Contra = "pass26" },
            new Usuario { UserID = 27, Nombre = "Marta", Apellido = "Dominguez", Email = "martadominguez@mail.com", Telefono = "650600027", Contra = "pass27" },
            new Usuario { UserID = 28, Nombre = "Antonio", Apellido = "Gil", Email = "antoniogil@mail.com", Telefono = "650600028", Contra = "pass28" },
            new Usuario { UserID = 29, Nombre = "Isabel", Apellido = "Vargas", Email = "isabelvargas@mail.com", Telefono = "650600029", Contra = "pass29" },
            new Usuario { UserID = 30, Nombre = "José", Apellido = "Blanco", Email = "joseblanco@mail.com", Telefono = "650600030", Contra = "pass30" },
            new Usuario { UserID = 31, Nombre = "Cristina", Apellido = "Santos", Email = "cristinasantos@mail.com", Telefono = "650600031", Contra = "pass31" },
            new Usuario { UserID = 32, Nombre = "Francisco", Apellido = "Marin", Email = "franciscomarin@mail.com", Telefono = "650600032", Contra = "pass32" },
            new Usuario { UserID = 33, Nombre = "Laura", Apellido = "Lozano", Email = "lauralozano@mail.com", Telefono = "650600033", Contra = "pass33" },
            new Usuario { UserID = 34, Nombre = "Victor", Apellido = "Sanchez", Email = "victorsanchez@mail.com", Telefono = "650600034", Contra = "pass34" },
            new Usuario { UserID = 35, Nombre = "Maria", Apellido = "Garcia", Email = "mariagarcia@mail.com", Telefono = "650600035", Contra = "pass35" },
            new Usuario { UserID = 36, Nombre = "Javier", Apellido = "Morales", Email = "javiermorales@mail.com", Telefono = "650600036", Contra = "pass36" },
            new Usuario { UserID = 37, Nombre = "Diana", Apellido = "Herrera", Email = "dianaherrera@mail.com", Telefono = "650600037", Contra = "pass37" },
            new Usuario { UserID = 38, Nombre = "Marcos", Apellido = "Garrido", Email = "marcosgarrido@mail.com", Telefono = "650600038", Contra = "pass38" },
            new Usuario { UserID = 39, Nombre = "Yolanda", Apellido = "Priet}", Email = "yolandapriet@mail.com", Telefono = "650600039", Contra = "pass39" },
            new Usuario { UserID = 40, Nombre = "Luis", Apellido = "Cano", Email = "luiscano@mail.com", Telefono = "650600040", Contra = "pass40" },
            new Usuario { UserID = 41, Nombre = "Daniel", Apellido = "Vidal", Email = "danielvidal@mail.com", Telefono = "650600041", Contra = "pass41" },
            new Usuario { UserID = 42, Nombre = "Sara", Apellido = "Moya", Email = "saramoya@mail.com", Telefono = "650600042", Contra = "pass42" },
            new Usuario { UserID = 43, Nombre = "Alex", Apellido = "Ortega", Email = "alexortega@mail.com", Telefono = "650600043", Contra = "pass43" },
            new Usuario { UserID = 44, Nombre = "Marina", Apellido = "Prieto", Email = "marinaprieto@mail.com", Telefono = "650600044", Contra = "pass44" },
            new Usuario { UserID = 45, Nombre = "Pablo", Apellido = "Mendez", Email = "pablomendez@mail.com", Telefono = "650600045", Contra = "pass45" },
            new Usuario { UserID = 46, Nombre = "Clara", Apellido = "Herrero", Email = "claraherrero@mail.com", Telefono = "650600046", Contra = "pass46" },
            new Usuario { UserID = 47, Nombre = "Ivan", Apellido = "Sancho", Email = "ivansancho@mail.com", Telefono = "650600047", Contra = "pass47" },
            new Usuario { UserID = 48, Nombre = "Julia", Apellido = "Domenech", Email = "juliadomenech@mail.com", Telefono = "650600048", Contra = "pass48" },
            new Usuario { UserID = 49, Nombre = "Sergio", Apellido = "Vega", Email = "sergiovega@mail.com", Telefono = "650600049", Contra = "pass49" },
            new Usuario { UserID = 50, Nombre = "Rosa", Apellido = "Lorenzo", Email = "rosalorenzo@mail.com", Telefono = "650600050", Contra = "pass50" },
            new Usuario { UserID = 51, Nombre = "Raul", Apellido = "Costa", Email = "raulcosta@mail.com", Telefono = "650600051", Contra = "pass51" },
            new Usuario { UserID = 52, Nombre = "Elena", Apellido = "Gallego", Email = "elenagallego@mail.com", Telefono = "650600052", Contra = "pass52" },
            new Usuario { UserID = 53, Nombre = "Adrian", Apellido = "Pascual", Email = "adrianpascual@mail.com", Telefono = "650600053", Contra = "pass53" },
            new Usuario { UserID = 54, Nombre = "Nuria", Apellido = "Iglesias", Email = "nuriaiglesias@mail.com", Telefono = "650600054", Contra = "pass54" },
            new Usuario { UserID = 55, Nombre = "Jaime", Apellido = "Serrano", Email = "jaimeserrano@mail.com", Telefono = "650600055", Contra = "pass55" },
            new Usuario { UserID = 56, Nombre = "Cristina", Apellido = "Garrido", Email = "cristinagarrido@mail.com", Telefono = "650600056", Contra = "pass56" },
            new Usuario { UserID = 57, Nombre = "Ruben", Apellido = "Merino", Email = "rubenmerino@mail.com", Telefono = "650600057", Contra = "pass57" },
            new Usuario { UserID = 58, Nombre = "Lorena", Apellido = "Redondo", Email = "lorenaredondo@mail.com", Telefono = "650600058", Contra = "pass58" },
            new Usuario { UserID = 59, Nombre = "Hector", Apellido = "Molina", Email = "hectormolina@mail.com", Telefono = "650600059", Contra = "pass59" },
            new Usuario { UserID = 60, Nombre = "Marta", Apellido = "Benitez", Email = "martabenitez@mail.com", Telefono = "650600060", Contra = "pass60" },
            new Usuario { UserID = 61, Nombre = "Albert", Apellido = "Nieto", Email = "albertnieto@mail.com", Telefono = "650600061", Contra = "pass61" },
            new Usuario { UserID = 62, Nombre = "Sonia", Apellido = "Campos", Email = "soniacampos@mail.com", Telefono = "650600062", Contra = "pass62" },
            new Usuario { UserID = 63, Nombre = "Gonzalo", Apellido = "Blanco", Email = "gonzaloblanco@mail.com", Telefono = "650600063", Contra = "pass63" },
            new Usuario { UserID = 64, Nombre = "Alicia", Apellido = "Sanchez", Email = "aliciasanchez@mail.com", Telefono = "650600064", Contra = "pass64" },
            new Usuario { UserID = 65, Nombre = "Omar", Apellido = "Leon", Email = "omarleon@mail.com", Telefono = "650600065", Contra = "pass65" },
            new Usuario { UserID = 66, Nombre = "Lidia", Apellido = "Marquez", Email = "lidiamarquez@mail.com", Telefono = "650600066", Contra = "pass66" },
            new Usuario { UserID = 67, Nombre = "Juan", Apellido = "Herrera", Email = "juanherrera@mail.com", Telefono = "650600067", Contra = "pass67" },
            new Usuario { UserID = 68, Nombre = "Lucia", Apellido = "Cortes", Email = "luciacortes@mail.com", Telefono = "650600068", Contra = "pass68" },
            new Usuario { UserID = 69, Nombre = "Nacho", Apellido = "Vidal", Email = "nachovidal@mail.com", Telefono = "650600069", Contra = "pass69" },
            new Usuario { UserID = 70, Nombre = "Belen", Apellido = "Cabrera", Email = "belencabrera@mail.com", Telefono = "650600070", Contra = "pass70" },
            new Usuario { UserID = 71, Nombre = "Carlos", Apellido = "Vega", Email = "carlosvega@mail.com", Telefono = "650600071", Contra = "pass71" },
            new Usuario { UserID = 72, Nombre = "Ines", Apellido = "Moreno", Email = "inesmoreno@mail.com", Telefono = "650600072", Contra = "pass72" },
            new Usuario { UserID = 73, Nombre = "Andres", Apellido = "Ruiz", Email = "andresruiz@mail.com", Telefono = "650600073", Contra = "pass73" },
            new Usuario { UserID = 74, Nombre = "Carmen", Apellido = "Saez", Email = "carmensaez@mail.com", Telefono = "650600074", Contra = "pass74" },
            new Usuario { UserID = 75, Nombre = "Javier", Apellido = "Molina", Email = "javiermolina@mail.com", Telefono = "650600075", Contra = "pass75" },
            new Usuario { UserID = 76, Nombre = "Sara", Apellido = "Herrera", Email = "saraherrera@mail.com", Telefono = "650600076", Contra = "pass76" },
            new Usuario { UserID = 77, Nombre = "Esteban", Apellido = "Dominguez", Email = "estebandominguez@mail.com", Telefono = "650600077", Contra = "pass77" },
            new Usuario { UserID = 78, Nombre = "Clara", Apellido = "Lopez", Email = "claralopez@mail.com", Telefono = "650600078", Contra = "pass78" },
            new Usuario { UserID = 79, Nombre = "Ruben", Apellido = "Garcia", Email = "rubengarcia@mail.com", Telefono = "650600079", Contra = "pass79" },
            new Usuario { UserID = 80, Nombre = "Marta", Apellido = "Fernandez", Email = "martafernandez@mail.com", Telefono = "650600080", Contra = "pass80" },
            new Usuario { UserID = 81, Nombre = "Luis", Apellido = "Gomez", Email = "luisgomez@mail.com", Telefono = "650600081", Contra = "pass81" },
            new Usuario { UserID = 82, Nombre = "Ana", Apellido = "Martinez", Email = "anamartinez@mail.com", Telefono = "650600082", Contra = "pass82" },
            new Usuario { UserID = 83, Nombre = "David", Apellido = "Jimenez", Email = "davidjimenez@mail.com", Telefono = "650600083", Contra = "pass83" },
            new Usuario { UserID = 84, Nombre = "Patricia", Apellido = "Sanchez", Email = "patriciasanchez@mail.com", Telefono = "650600084", Contra = "pass84" },
            new Usuario { UserID = 85, Nombre = "Oscar", Apellido = "Lorenzo", Email = "oscarlorenzo@mail.com", Telefono = "650600085", Contra = "pass85" },
            new Usuario { UserID = 86, Nombre = "Laura", Apellido = "Mora", Email = "lauramora@mail.com", Telefono = "650600086", Contra = "pass86" },
            new Usuario { UserID = 87, Nombre = "Ivan", Apellido = "Alonso", Email = "ivanalonso@mail.com", Telefono = "650600087", Contra = "pass87" },
            new Usuario { UserID = 88, Nombre = "Monica", Apellido = "Vidal", Email = "monicavidal@mail.com", Telefono = "650600088", Contra = "pass88" },
            new Usuario { UserID = 89, Nombre = "Jorge", Apellido = "Prieto", Email = "jorgeprieto@mail.com", Telefono = "650600089", Contra = "pass89" },
            new Usuario { UserID = 90, Nombre = "Teresa", Apellido = "Campos", Email = "teresacampos@mail.com", Telefono = "650600090", Contra = "pass90" },
            new Usuario { UserID = 91, Nombre = "Manuel", Apellido = "Gil", Email = "manuelgil@mail.com", Telefono = "650600091", Contra = "pass91" },
            new Usuario { UserID = 92, Nombre = "Silvia", Apellido = "Mendez", Email = "silviamendez@mail.com", Telefono = "650600092", Contra = "pass92" },
            new Usuario { UserID = 93, Nombre = "Antonio", Apellido = "Herrero", Email = "antonioherrero@mail.com", Telefono = "650600093", Contra = "pass93" },
            new Usuario { UserID = 94, Nombre = "Lucia", Apellido = "Sancho", Email = "luciasancho@mail.com", Telefono = "650600094", Contra = "pass94" },
            new Usuario { UserID = 95, Nombre = "Miguel", Apellido = "Dominguez", Email = "migueldominguez@mail.com", Telefono = "650600095", Contra = "pass95" },
            new Usuario { UserID = 96, Nombre = "Nuria", Apellido = "Vega", Email = "nuriavega@mail.com", Telefono = "650600096", Contra = "pass96" },
            new Usuario { UserID = 97, Nombre = "Alberto", Apellido = "Cabrera", Email = "albertocabrera@mail.com", Telefono = "650600097", Contra = "pass97" },
            new Usuario { UserID = 98, Nombre = "Rocio", Apellido = "Lorenzo", Email = "rociolorenzo@mail.com", Telefono = "650600098", Contra = "pass98" },
            new Usuario { UserID = 99, Nombre = "Felipe", Apellido = "Sanchez", Email = "felipesanchez@mail.com", Telefono = "650600099", Contra = "pass99" },
            new Usuario { UserID = 100, Nombre = "Beatriz", Apellido = "Morales", Email = "beatrizmorales@mail.com", Telefono = "650600100", Contra = "pass100" }
        );

        modelBuilder.Entity<Reserva>().HasData(
            new Reserva { ReservaID = 1, FuncionID = 5, UserID = 34, Asiento = 2 },
            new Reserva { ReservaID = 2, FuncionID = 1, UserID = 87, Asiento = 45 },
            new Reserva { ReservaID = 3, FuncionID = 15, UserID = 56, Asiento = 32 },
            new Reserva { ReservaID = 4, FuncionID = 8, UserID = 22, Asiento = 18 },
            new Reserva { ReservaID = 5, FuncionID = 24, UserID = 3, Asiento = 50 },
            new Reserva { ReservaID = 6, FuncionID = 13, UserID = 77, Asiento = 5 },
            new Reserva { ReservaID = 7, FuncionID = 7, UserID = 15, Asiento = 27 },
            new Reserva { ReservaID = 8, FuncionID = 19, UserID = 89, Asiento = 11 },
            new Reserva { ReservaID = 9, FuncionID = 2, UserID = 47, Asiento = 40 },
            new Reserva { ReservaID = 10, FuncionID = 22, UserID = 9, Asiento = 29 },
            new Reserva { ReservaID = 11, FuncionID = 10, UserID = 67, Asiento = 15 },
            new Reserva { ReservaID = 12, FuncionID = 4, UserID = 98, Asiento = 36 },
            new Reserva { ReservaID = 13, FuncionID = 11, UserID = 52, Asiento = 22 },
            new Reserva { ReservaID = 14, FuncionID = 6, UserID = 33, Asiento = 48 },
            new Reserva { ReservaID = 15, FuncionID = 16, UserID = 41, Asiento = 14 },
            new Reserva { ReservaID = 16, FuncionID = 14, UserID = 29, Asiento = 31 },
            new Reserva { ReservaID = 17, FuncionID = 21, UserID = 72, Asiento = 9 },
            new Reserva { ReservaID = 18, FuncionID = 9, UserID = 18, Asiento = 23 },
            new Reserva { ReservaID = 19, FuncionID = 3, UserID = 64, Asiento = 47 },
            new Reserva { ReservaID = 20, FuncionID = 17, UserID = 55, Asiento = 28 },
            new Reserva { ReservaID = 21, FuncionID = 23, UserID = 46, Asiento = 8 },
            new Reserva { ReservaID = 22, FuncionID = 18, UserID = 19, Asiento = 33 },
            new Reserva { ReservaID = 23, FuncionID = 20, UserID = 85, Asiento = 12 },
            new Reserva { ReservaID = 24, FuncionID = 12, UserID = 74, Asiento = 38 },
            new Reserva { ReservaID = 25, FuncionID = 5, UserID = 63, Asiento = 21 },
            new Reserva { ReservaID = 26, FuncionID = 8, UserID = 27, Asiento = 6 },
            new Reserva { ReservaID = 27, FuncionID = 16, UserID = 39, Asiento = 49 },
            new Reserva { ReservaID = 28, FuncionID = 24, UserID = 10, Asiento = 34 },
            new Reserva { ReservaID = 29, FuncionID = 13, UserID = 91, Asiento = 7 },
            new Reserva { ReservaID = 30, FuncionID = 11, UserID = 58, Asiento = 26 },
            new Reserva { ReservaID = 31, FuncionID = 9, UserID = 17, Asiento = 19 },
            new Reserva { ReservaID = 32, FuncionID = 20, UserID = 80, Asiento = 44 },
            new Reserva { ReservaID = 33, FuncionID = 2, UserID = 42, Asiento = 3 },
            new Reserva { ReservaID = 34, FuncionID = 17, UserID = 24, Asiento = 37 },
            new Reserva { ReservaID = 35, FuncionID = 6, UserID = 79, Asiento = 16 },
            new Reserva { ReservaID = 36, FuncionID = 21, UserID = 95, Asiento = 30 },
            new Reserva { ReservaID = 37, FuncionID = 15, UserID = 68, Asiento = 43 },
            new Reserva { ReservaID = 38, FuncionID = 10, UserID = 60, Asiento = 24 },
            new Reserva { ReservaID = 39, FuncionID = 7, UserID = 36, Asiento = 10 },
            new Reserva { ReservaID = 40, FuncionID = 14, UserID = 83, Asiento = 35 },
            new Reserva { ReservaID = 41, FuncionID = 3, UserID = 50, Asiento = 46 },
            new Reserva { ReservaID = 42, FuncionID = 19, UserID = 13, Asiento = 1 },
            new Reserva { ReservaID = 43, FuncionID = 22, UserID = 96, Asiento = 4 },
            new Reserva { ReservaID = 44, FuncionID = 12, UserID = 70, Asiento = 41 },
            new Reserva { ReservaID = 45, FuncionID = 18, UserID = 31, Asiento = 25 },
            new Reserva { ReservaID = 46, FuncionID = 23, UserID = 88, Asiento = 13 },
            new Reserva { ReservaID = 47, FuncionID = 1, UserID = 23, Asiento = 39 },
            new Reserva { ReservaID = 48, FuncionID = 4, UserID = 78, Asiento = 2 },
            new Reserva { ReservaID = 49, FuncionID = 8, UserID = 65, Asiento = 17 },
            new Reserva { ReservaID = 50, FuncionID = 5, UserID = 90, Asiento = 42 },
            new Reserva { ReservaID = 51, FuncionID = 7, UserID = 53, Asiento = 20 },
            new Reserva { ReservaID = 52, FuncionID = 10, UserID = 44, Asiento = 31 },
            new Reserva { ReservaID = 53, FuncionID = 13, UserID = 26, Asiento = 14 },
            new Reserva { ReservaID = 54, FuncionID = 16, UserID = 8, Asiento = 48 },
            new Reserva { ReservaID = 55, FuncionID = 19, UserID = 11, Asiento = 37 },
            new Reserva { ReservaID = 56, FuncionID = 21, UserID = 32, Asiento = 23 },
            new Reserva { ReservaID = 57, FuncionID = 24, UserID = 94, Asiento = 12 },
            new Reserva { ReservaID = 58, FuncionID = 2, UserID = 49, Asiento = 29 },
            new Reserva { ReservaID = 59, FuncionID = 14, UserID = 66, Asiento = 7 },
            new Reserva { ReservaID = 60, FuncionID = 17, UserID = 100, Asiento = 50 }
        );
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Sesion> Sesiones { get; set; }
    public DbSet<Obra> Obras { get; set; }
    public DbSet<Sala> Salas { get; set; }
    public DbSet<Funcion> Funciones { get; set; }
    public DbSet<Reserva> Reservas { get; set; }

}