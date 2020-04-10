using System;

namespace TheLudoGameApp.Classes
{
    internal class MainMenu
    {
        public static void Menu()
        {
            GameMenu menu = new GameMenu();

            bool mainMenu = true;
            while (mainMenu)
            {
                Console.Clear();

                Welcome();

                Console.WriteLine("---- Main Menu -----");
                Console.WriteLine("[0] Create New Game");
                Console.WriteLine("[1] Load Game");
                Console.WriteLine("[2] Exit");

                string option = Console.ReadLine();

                Console.Clear();

                switch (option)
                {
                    case "0":
                        menu.MenuNewGame();
                        break;

                    case "1":
                        menu.MenuLoadGame();
                        mainMenu = false;
                        break;

                    case "2":
                        Console.WriteLine("Exit program");
                        mainMenu = false;
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