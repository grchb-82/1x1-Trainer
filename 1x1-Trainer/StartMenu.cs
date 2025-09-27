using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _1x1_Trainer
{
    internal class StartMenu : BaseMenu
    {
        public override void DisplayMenu()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("=== Wilkommen zum 1x1 Trainer! ===========");
            Console.WriteLine("==========================================");
            Console.WriteLine();
            Console.WriteLine("Wähle eine Option:");
            Console.WriteLine("1. Profil Erstellen");
            Console.WriteLine("2. Profil Laden");
            Console.WriteLine("3. Profil Löschen");
            Console.WriteLine("4. Einstellungen");
            Console.WriteLine("5. Beenden");
            Console.WriteLine();
            
            InputOption();
            
        }

        private void InputOption()
        {
            BaseMenu nextMenu;

            while (true)
            {
                var input = Console.ReadKey(true).KeyChar;
                switch (input)
                {
                    case '1':
                        nextMenu = new CreateProfileMenu();
                        break;
                    case '2':
                        nextMenu = new LoadProfileMenu();
                        break;
                    case '3':
                        nextMenu = new DeleteProfileMenu();
                        break;
                    case '4':
                        nextMenu = new SettingsMenu();
                        break;
                    case '5':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe.");
                        //DisplayMenu();
                        continue;
                }
            }
            
        }
    }
}
