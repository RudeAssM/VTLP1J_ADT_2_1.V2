using System;
using System.Collections.Generic;
using DustInTheWind.ConsoleTools;
using DustInTheWind.ConsoleTools.Controls.Menus;
using VTLP1J_ADT_2022_23_1.V2.Models;

namespace VTLP1J_ADT_23_1_V2.Client
{
    class Program
    {
        public static void Main(String[] args)
        {
            RestService restService = new RestService("http://localhost:5000");

            ICollection<ILens> Lenses = restService.Get<ILens>("api/Lens");

            foreach (ILens lens in Lenses)
            {
                Console.WriteLine(lens.ToString());
            }
        }
        public static void GetAllLenses(RestService restService)
        {
            var Lenses = restService.Get<ILens>("Lenses");
            foreach (ILens lense in Lenses)
            {
                Console.WriteLine(lense.ToString());
            }
        }

       

    }
    
    static class Extension
    {
        public static void ToProcess<T>(this IEnumerable<T> query, string headline)
        {
            Console.WriteLine($"\n:: {headline} ::\n");

            foreach (var item in query)
                Console.WriteLine("\t" + item);

            Console.WriteLine("\n\n");
        }
    }
}