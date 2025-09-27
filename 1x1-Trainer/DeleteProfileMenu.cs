namespace _1x1_Trainer;

class DeleteProfileMenu : BaseMenu
{
    
    private const string ProfileDirectory = @"C:\temp";
    private string[] profiles;
    int index;
    public override void DisplayMenu()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("=== Profil Löschen =======================");
        Console.WriteLine("==========================================");
        Console.WriteLine();
        CheckProfileDirectoryExists();
        CheckProfilesExists();
        ShowProfiles();
        InputOption();
        string selectedFilePath = profiles[index - 1];
        ProfileManager.DeleteProfile(selectedFilePath);


        
    }

    private void CheckProfileDirectoryExists()
    {
        if (!Directory.Exists(ProfileDirectory))
        {
            Console.WriteLine("Fehler: Profilverzeichnis nicht gefunden.");
            Console.WriteLine("Drücke eine Taste, um zum Hauptmenü zurückzukehren.");
            Console.ReadKey();
            BaseMenu nextMenu = new StartMenu();
        }
    }

    private void CheckProfilesExists()
    {
        profiles = Directory.GetFiles(ProfileDirectory, "*.prof");
        if (profiles.Length == 0)
        {
            Console.WriteLine("Keine Profile gefunden.");
            Console.WriteLine("Drücke eine Taste, um zum Hauptmenü zurückzukehren.");
            Console.ReadKey();
            BaseMenu nextMenu = new StartMenu();
        }
    }

    private void ShowProfiles()
    {
        for (int i = 0; i < profiles.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Path.GetFileNameWithoutExtension(profiles[i])}");
        }
    }

    private void InputOption()
    {
        Console.WriteLine();
        
        while (true)
        {
            Console.Write("Wähle ein Profil (Zahl): ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out index) || index < 1 || index > profiles.Length)
            {
                Console.WriteLine("Ungültige Eingabe.");
                Console.WriteLine("Drücke eine Taste, um es erneut zu versuchen.");
                Console.ReadKey();
                continue;
            }
            else
            {
                break;
            }
            
        }
        string selectedFilePath = profiles[index - 1];
        
    }
}