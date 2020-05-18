using System;

namespace TheLudoGameApp.Classes
{
    internal class MainMenu
    {
        public static void Menu()
        {
            GameMenu menu = new GameMenu();

            bool menuRunning = true;
            while (menuRunning)
            {
                Console.Clear();

                Welcome();

                Console.WriteLine("---- Main Menu -----");
                Console.WriteLine("[0] Create New Game");
                Console.WriteLine("[1] Load Game");
                Console.WriteLine("[2] See previous games");
                Console.WriteLine("[3] Exit");

                string option = Console.ReadLine();

                Console.Clear();

                switch (option)
                {
                    case "0":
                        menu.MenuNewGame();
                        break;

                    case "1":
                        menu.MenuLoadGameFromDataBase();
                        break;

                    case "2":
                        menu.ShowPreviousGamesFromDataBase();
                        break;

                    case "3":
                        Console.WriteLine("Exit program");
                        menuRunning = false;
                        break;
                }
            }
        }

        public static void Welcome()
        {
            Console.WriteLine(@"

████████╗██╗░░██╗███████╗  ██╗░░░░░██╗░░░██╗██████╗░░█████╗░░██████╗░░█████╗░███╗░░░███╗███████╗
╚══██╔══╝██║░░██║██╔════╝  ██║░░░░░██║░░░██║██╔══██╗██╔══██╗██╔════╝░██╔══██╗████╗░████║██╔════╝
░░░██║░░░███████║█████╗░░  ██║░░░░░██║░░░██║██║░░██║██║░░██║██║░░██╗░███████║██╔████╔██║█████╗░░
░░░██║░░░██╔══██║██╔══╝░░  ██║░░░░░██║░░░██║██║░░██║██║░░██║██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░
░░░██║░░░██║░░██║███████╗  ███████╗╚██████╔╝██████╔╝╚█████╔╝╚██████╔╝██║░░██║██║░╚═╝░██║███████╗
░░░╚═╝░░░╚═╝░░╚═╝╚══════╝  ╚══════╝░╚═════╝░╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝

");
        }
    }
}