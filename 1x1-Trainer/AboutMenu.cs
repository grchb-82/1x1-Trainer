namespace _1x1_Trainer;

class AboutMenu : BaseMenu
{
    public override void DisplayMenu()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("=== About / Info =========================");
        Console.WriteLine("==========================================");
        Console.WriteLine();
        Console.WriteLine("Programmiert 2025 - BGS");
        Console.WriteLine("von Gottfried Blumensath");
        Console.WriteLine("v0.2");
        Console.WriteLine();
        Console.WriteLine("für meine Kinder");
        Console.WriteLine("Lukas, Simon und Sophie");
        Console.WriteLine();
        Console.WriteLine("<3");
        Console.ReadKey();
        BaseMenu nextMenu = new SettingsMenu();
    }
}