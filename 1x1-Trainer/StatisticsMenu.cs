namespace _1x1_Trainer;

class StatisticsMenu : BaseMenu
{
    public override void DisplayMenu()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("=== Statistik ============================");
        Console.WriteLine("==========================================");
        Console.WriteLine();
        Console.WriteLine($"Daten von {ProfileManager.CurrentProfile.Name}");

        ShowData();
        Console.ReadKey();
        BaseMenu nextMenu = new ModeSelectionMenu();
    }

    private void ShowData()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Reihe {i+1}: ");
            Console.Write("Richtige: ");
            Console.Write(ProfileManager.CurrentProfile.CorrectRow[i]);
            Console.Write("  |  Falsche: ");
            Console.Write(ProfileManager.CurrentProfile.WrongRow[i]);
            Console.Write("  |  Gesamt: ");
            Console.Write(ProfileManager.CurrentProfile.TotalRow[i]);
            Console.Write($"  |  Anteil Richtige:  {ProfileManager.CurrentProfile.RatioRow[i]}%");
            Console.WriteLine();
            
        }
        
    }
}