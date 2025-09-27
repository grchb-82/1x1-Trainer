using Newtonsoft.Json;

namespace _1x1_Trainer;

static class ProfileManager
{
    public static Profile CurrentProfile { get; private set; }

    public static void CreateProfile(string profileName)
    {
        CurrentProfile = new Profile(profileName,0,0);
        SaveProfile(profileName);
    }

    public static void SaveProfile(string profileName)
    {
        string json = JsonConvert.SerializeObject(CurrentProfile, Formatting.Indented);
        //Console.WriteLine(json);
        
        using (StreamWriter sw = new StreamWriter(@$"{Settings.ProfilePath}\{profileName}.prof"))
        {
            sw.Write(json);
        }
    }

    public static void LoadProfile(string selectedFilePath)
    {
        BaseMenu nextMenu;
        try
        {
            string json = File.ReadAllText(selectedFilePath);
            CurrentProfile = JsonConvert.DeserializeObject<Profile>(json);
            if (CurrentProfile == null)
            {
                Console.WriteLine("Fehler: Profil konnte nicht geladen werden (null).");
                Console.ReadKey();
                nextMenu = new LoadProfileMenu();
            }
            //Console.WriteLine("Drücke eine Taste, um fortzufahren...");
            //Console.ReadKey();
            nextMenu = new ModeSelectionMenu();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Fehler beim Laden des Profils:");
            Console.WriteLine(ex.Message);
            Console.ReadKey();
            nextMenu = new LoadProfileMenu();
        }
    }

    public static void DeleteProfile(string selectedFilePath)
    {
        Console.WriteLine($"Profil {selectedFilePath} wirklich löschen (j/n)");
        
        Console.WriteLine();
        BaseMenu nextMenu;
        while (true)
        {
            var input = Console.ReadKey(true).KeyChar;
            switch (input)
            {
                case 'j':
                {
                    File.Delete(selectedFilePath);
                    Console.WriteLine("Profil gelöscht.");
                    Console.WriteLine("Drücke eine Taste, um fortzufahren...");
                    Console.ReadKey();
                    nextMenu = new StartMenu();
                    break;
                }
                case 'n':
                {
                    Console.WriteLine("Abbruch");
                    Console.WriteLine("Drücke eine Taste, um fortzufahren...");
                    Console.ReadKey();
                    nextMenu = new StartMenu();
                    break;
                }
                default:
                {
                    Console.WriteLine("Ungültige Eingabe");
                    continue;
                }
            }
            
        }
        
    }
}