using System.Collections.Generic;

public class Pelicula
{
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public string Plataforma { get; set; }

    public Pelicula(string titulo, string genero, string plataforma)
    {
        Titulo = titulo;
        Genero = genero;
        Plataforma = plataforma;
    }
}
