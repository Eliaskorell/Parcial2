using AccesoDatos.Entities;
using AccesoDatos.Models;
using AccesoDatos.Repositories;

var artistaRepo = new ArtistaRepository();
var cancionRepo = new CancionRepository();

bool salir = false;

while (!salir)
{
    Console.WriteLine();
    Console.WriteLine("===== MENU =====");
    Console.WriteLine("1. Alta artista");
    Console.WriteLine("2. Alta cancion");
    Console.WriteLine("3. Ver canciones");
    Console.WriteLine("4. Mostrar canciones mas largas");
    Console.WriteLine("5. Cantidad total de canciones");
    Console.WriteLine("6. Mostrar canciones ordenadas por titulo");
    Console.WriteLine("7. Verificar si existen canciones");
    Console.WriteLine("0. Salir");
    Console.Write("Elegi una opcion: ");

    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            AltaArtista();
            break;

        case "2":
            AltaCancion();
            break;

        case "3":
            VerCanciones();
            break;

        case "4":
            MostrarMasLargas();
            break;

        case "5":
            MostrarCantidad();
            break;

        case "6":
            MostrarOrdenadasPorTitulo();
            break;

        case "7":
            VerificarSiHayCanciones();
            break;

        case "0":
            salir = true;
            Console.WriteLine("Saliendo...");
            break;

        default:
            Console.WriteLine("Opcion invalida, intenta de nuevo.");
            break;
    }
}

void AltaArtista()
{
    Console.Write("Nombre del artista: ");
    string nombre = Console.ReadLine();

    artistaRepo.Agregar(new Artista { Nombre = nombre });
    Console.WriteLine("Artista registrado con exito.");
}

void AltaCancion()
{
    var artistas = artistaRepo.ObtenerTodos();
    if (artistas.Count == 0)
    {
        Console.WriteLine("Primero registra un artista.");
        return;
    }

    foreach (var a in artistas)
        Console.WriteLine($"{a.Id} - {a.Nombre}");

    Console.Write("Id del artista: ");
    int artistaId = int.Parse(Console.ReadLine());

    if (!artistaRepo.Existe(artistaId))
    {
        Console.WriteLine("No se encontro un artista con ese Id.");
        return;
    }

    Console.Write("Titulo: ");
    string titulo = Console.ReadLine();
    Console.Write("Duracion (segundos): ");
    int duracion = int.Parse(Console.ReadLine());

    cancionRepo.Agregar(new Cancion
    {
        Titulo = titulo,
        DuracionSegundos = duracion,
        ArtistaId = artistaId
    });
    Console.WriteLine("Cancion registrada con exito.");
}

void VerCanciones()
{
    Mostrar(cancionRepo.ObtenerConArtista());
}

void MostrarMasLargas()
{
    Mostrar(cancionRepo.ObtenerMasLargas());
}

void MostrarCantidad()
{
    Console.WriteLine($"Cantidad total de canciones: {cancionRepo.ObtenerCantidad()}");
}

void MostrarOrdenadasPorTitulo()
{
    Mostrar(cancionRepo.ObtenerOrdenadasPorTitulo());
}

void VerificarSiHayCanciones()
{
    if (cancionRepo.HayCanciones())
        Console.WriteLine("Existen canciones registradas.");
    else
        Console.WriteLine("No hay canciones registradas.");
}

void Mostrar(List<Cancion> canciones)
{
    if (canciones.Count == 0)
    {
        Console.WriteLine("No hay canciones.");
        return;
    }

    foreach (var c in canciones)
        Console.WriteLine($"{c.Titulo} - {c.DuracionSegundos} seg - {c.Artista.Nombre}");
}