using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contador_en_Hilos;

class Program
{
    private static List<Contador> _contadores = new List<Contador>();

    static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Menu de contadores");
            Console.WriteLine("1. Iniciar un nuevo contador");
            Console.WriteLine("2. Detener un contador");
            Console.WriteLine("3. Ver estado de los contadores");
            Console.WriteLine("4. Salir");

            Console.Write("Seleccione una opción: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    StartCounter();
                    break;

                case "2":
                    StopCounter();
                    break;

                case "3":
                    ShowStateCounter();
                    break;

                case "4":
                    StopAllCunter();
                    break;

                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }
        }
    }

    private static void StartCounter()
    {
        Console.Write("Ingrese el intervalo detiempo en miliseguntos");
        int range = int.Parse(Console.ReadLine());

        Contador Counter = new Contador(range);
        Counter.start();
        _contadores.Add(Counter);

        Console.WriteLine("Contador Iniciado");
    }

    private static void StopCounter()
    {
        Console.Write("Ingrese el indice del contador a deterner");
        int CounterIndex = int.Parse(Console.ReadLine());

        if (CounterIndex >= 0 && CounterIndex < _contadores.Count)
        {
            _contadores[CounterIndex].stop();
            Console.WriteLine("Contador detenido.");
        }
        else
        {
            Console.WriteLine("Índice no válido.");
        }
    }

    private static void ShowStateCounter()
    {
        for (int i = 0; i < _contadores.Count; i++)
        {
            Console.WriteLine($"Contador {i}: {_contadores[i].GetValue()}");
        }
    }

    private static void StopAllCunter() { 
        foreach ( var contador in _contadores)
        {
            contador.stop();
        }
        Console.WriteLine("Todos los contadores se han detenido.");
    }
}
