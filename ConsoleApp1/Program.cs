using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Definir la matriz de caracteres
        var matrix = new List<string>
        {
            "coldw",
            "hilla",
            "illni",
            "lndch",
            "dwind"
        };

        // Definir las palabras a buscar
        var wordStream = new List<string>
        {
            "chill", "cold", "wind", "hot", "rain"
        };

        // Instanciar la clase WordFinder
        var wordFinder = new WordFinder(matrix);

        // Buscar las palabras
        var foundWords = wordFinder.Find(wordStream);

        // Mostrar los resultados
        Console.WriteLine("Palabras encontradas en la matriz:");
        foreach (var word in foundWords)
        {
            Console.WriteLine(word);
        }
    }
}
