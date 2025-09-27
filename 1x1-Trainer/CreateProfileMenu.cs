namespace _1x1_Trainer
{

    internal class CreateProfileMenu : BaseMenu

    {
        string profileName;
        byte _age;
        //private const string ProfileDirectory = @"C:\temp";
        
        public override void DisplayMenu()
        {

            Console.WriteLine("==========================================");
            Console.WriteLine("=== Profil Erstellen =====================");
            Console.WriteLine("==========================================");
            Console.WriteLine();
            profileName = InputName();
            //_age = InputAge();
            ProfileManager.CreateProfile(profileName);
            
            BaseMenu nextMenu = new ModeSelectionMenu();

        }

        private string InputName()
        {
            Console.Write("Profilname eingeben: ");
            string input = Console.ReadLine();
            CheckCancel(input);
            if (!CheckProfileExists(input))
            {
                InputName();
            }
            return input;
        }

        private void CheckCancel(string input)
        {
            if (input == "cancel")
            {
                BaseMenu nextMenu = new StartMenu();
            }
        }

        private  bool CheckProfileExists(string input) 
        {
            // Console.WriteLine("Hier wird geprüft ob schon vorhanden");
            Console.WriteLine();
            var profiles = Directory.GetFiles(Settings.ProfilePath, "*.prof");
            foreach (var profile in profiles)
                if (input == Path.GetFileNameWithoutExtension(profile))
                {
                    Console.WriteLine("Profil bereist vorhanden");
                    Console.ReadKey();
                    BaseMenu nextMenu = new CreateProfileMenu();
                    return false;
                } 
            return true;
        }

        private byte InputAge()
        {
            while (true)
            {
                Console.Write("Alter: ");
                if (!byte.TryParse(Console.ReadLine(), out byte b))
                {
                    Console.WriteLine("Ungültige Eingabe");
                }
                else
                {
                    return b;
                }
            }
        }
    }
}
