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

            restService.Get<Lens>("api/Lens").ToProcess("this");
            restService.Get<Manufacturer>("api/Manufacturer").ToProcess("this");
            restService.Get<LensMount>("api/LensMount").ToProcess("this");


            

        }
        public static void GetAllLenses(RestService restService)
        {
            var Lenses = restService.Get<Lens>("Lenses");
            foreach (Lens lense in Lenses)
            {
                Console.WriteLine(lense.ToString());
            }
        }

       

    }
    
    static class Extension
    {
        public static void ToProcess<T>(this IEnumerable<T> query, string title)
        {
            Console.WriteLine(title);
            foreach (var item in query)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}