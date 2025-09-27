using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1x1_Trainer
{
    internal class ModeSelectionMenu : BaseMenu
    {
        private Profile _Profile {get; set;}
        public ModeSelectionMenu()
        {
      
        }

        public override void DisplayMenu()
        {
            Console.WriteLine($"=== Hallo {ProfileManager.CurrentProfile.Name} =======================");
            Console.WriteLine("=== Modus Auswählen ======================");
            Console.WriteLine("==========================================");
            Console.WriteLine();
            Console.WriteLine("1. Üben");
            Console.WriteLine("2. Statistik");
            Console.WriteLine("3. Hauptmenü");

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
                        nextMenu = new ExerciseSelectorMenu();
                        break;
                    case '2':
                        nextMenu = new StatisticsMenu();
                        break;
                    case '3':
                        nextMenu = new StartMenu();
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe.");
                        continue;
                }
            }
        }
    }
}

