﻿using System;
using DustInTheWind.ConsoleTools;
using DustInTheWind.ConsoleTools.Controls.Menus;
using VTLP1J_ADT_2022_23_1.V2.Models;

namespace VTLP1J_ADT_23_1_V2.Client
{
    class Program
    {
        public static void Main(String[] args)
        {
            RestService restService = new RestService("https://localhost:5000");
            
            GetAllLenses(restService);



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
}