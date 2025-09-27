using Newtonsoft.Json;
namespace _1x1_Trainer
{
    internal class LoadProfileMenu : BaseMenu
    {
        string[] profiles;
        //private const string ProfileDirectory = @"C:\temp";
        private int index;
        public override void DisplayMenu()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("=== Profil Laden =========================");
            Console.WriteLine("==========================================");
            Console.WriteLine();

            ShowExistingProfiles();
            
            Console.WriteLine();

            InputOption();
            
            string selectedFilePath = profiles[index - 1];
            ProfileManager.LoadProfile(selectedFilePath);
            
        }

        private void ShowExistingProfiles()
        {
            CheckProfilePathAvailable();
            CheckProfilesAvailable();
            for (int i = 0; i < profiles.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Path.GetFileNameWithoutExtension(profiles[i])}");
            }
        }

        private void CheckProfilePathAvailable()
        {
            if (!Directory.Exists(Settings.ProfilePath))
            {
                Console.WriteLine("Fehler: Profilverzeichnis nicht gefunden.");
                Console.WriteLine("Drücke eine Taste, um zum Hauptmenü zurückzukehren.");
                Console.ReadKey();
                return;
            }
        }

        private void CheckProfilesAvailable()
        {
            profiles = Directory.GetFiles(Settings.ProfilePath, "*.prof");
            if (profiles.Length == 0)
            {
                Console.WriteLine("Keine Profile gefunden.");
                Console.WriteLine("Drücke eine Taste, um zum Hauptmenü zurückzukehren.");
                Console.ReadKey();
                return;
            }
        }

        private void InputOption()
        {
            while (true)
            {
                Console.Write("Wähle ein Profil (Zahl): ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out index) || index < 1 || index > profiles.Length)
                {
                    Console.WriteLine("Ungültige Eingabe.");
                    continue;
                }
                else
                {
                    break;
                }
            }
        }
    }
   
}
