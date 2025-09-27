namespace _1x1_Trainer;

class ExerciseSelectorMenu : BaseMenu
{
    public override void DisplayMenu()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("=== Übung auswählen ======================");
        Console.WriteLine("==========================================");
        Console.WriteLine();
        Console.WriteLine("Wähle eine Option:");
        Console.WriteLine("1. Einfache Übung Multiplikation");
        Console.WriteLine("2. Einfache Übung Division");
        Console.WriteLine("3. KrissKross");
        Console.WriteLine("   Challange Multiplikation");
        Console.WriteLine("   Challange Division");
        Console.WriteLine("   Challange KrissKross");
        Console.WriteLine("7. Zurück zur Modusauswahl");
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
                    nextMenu = new TrainerSimpleMultiplicationMenu();
                    break;
                case '2':
                    nextMenu = new TrainerSimpleDivisionMenu();
                    break;
                case '3':
                    nextMenu = new KrissKrossMenu();
                    break;
                /*case '4':
                    nextMenu = new ChallangeMultiplicationMenu();
                    break;
                case '5':
                    nextMenu = new ChallangeDivisionMenu();
                    break;

                case '6':
                    nextMenu = new KrissKrossChallangeMenu();
                    break;*/
                case '7':
                    nextMenu = new ModeSelectionMenu();
                    break;
                default:
                    Console.WriteLine("Ungültige Eingabe.");
                    //DisplayMenu();
                    continue;
            }
        }
            
    }
}