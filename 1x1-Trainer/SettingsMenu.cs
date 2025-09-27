using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1x1_Trainer
{
    internal class SettingsMenu : BaseMenu
    {
        public override void DisplayMenu()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("=== Einstellungen ========================");
            Console.WriteLine("==========================================");
            Console.WriteLine();
            Console.WriteLine("Wähle eine Option:");
            Console.WriteLine("1. Profilpfad ändern");
            Console.WriteLine("2. Info");
            Console.WriteLine("3. Zurück zum Hauptmenü");
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
                        //nextMenu = new ChangePathMenu();
                        break;
                    case '2':
                        nextMenu = new AboutMenu();
                        break;
                    case '3':
                        nextMenu = new StartMenu();
                        break;
                    /*case '4':
                        nextMenu = new SettingsMenu();
                        break;
                    case '5':
                        Environment.Exit(0);
                        break;
                        */
                    default:
                        Console.WriteLine("Ungültige Eingabe.");
                        //DisplayMenu();
                        continue;
                }
            }
            
        }
    }
  
}
