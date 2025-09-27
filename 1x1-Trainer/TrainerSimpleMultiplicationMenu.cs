using System.ComponentModel.Design;

namespace _1x1_Trainer;

internal class TrainerSimpleMultiplicationMenu : BaseMenu
{
    private int correct;
    private int wrong;
    private byte reihe;
    private int multiplikator;
    private int correctAnswer;
    private int answer;
    
    public override void DisplayMenu()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("=== Trainer = Einfache Multiplikation ====");
        Console.WriteLine("==========================================");
        Console.WriteLine();
        reihe = InputRow();
        Abfrage(reihe);
        ShowResult();
        //Console.ReadLine();
        BaseMenu nextMenu = new ModeSelectionMenu();
    }
        
    private byte InputRow()
    {
        string input;
        
        while (true)
        {
            int recommendation = CalculateReccomendation();
            Console.WriteLine($"Empfohlene Reihe: {recommendation}");
            Console.Write("Welche Reihe möchtest Du lernen (1-10)? ");
            
            
            switch (Console.ReadLine())
            {
                case "1":
                    return reihe = 1;
                case "2":
                    return reihe = 2;
                case "3":
                    return reihe = 3;
                case "4":
                    return reihe = 4;
                case "5":
                    return reihe = 5;
                case "6":
                    return reihe = 6;
                case "7":
                    return reihe = 7;
                case "8":
                    return reihe = 8;
                case "9":
                    return reihe = 9;
                case "10":
                    return reihe = 10;
                default:
                    return (byte)recommendation;
                    break;
            }
        }

        
    }

    private void Abfrage(byte reihe)
    {
        Console.Clear();
        Console.WriteLine("==========================================");
        Console.WriteLine($"=== {reihe}er-Reihe ============================");
        Console.WriteLine("==========================================");
        Console.WriteLine();


        while (true)
        {
            Random zahl = new Random();
            correct = 0;
            wrong = 0;
            for (int i = 0; i < 10; i++)
            {
                multiplikator = zahl.Next(2, 10);
                Console.Clear();
                
                
                Console.WriteLine("==========================================");
                Console.WriteLine($"=== {reihe}er-Reihe ============================");
                Console.WriteLine("==========================================");
                Console.WriteLine();
                QuestionAndAnswer(i);
                
            }

            Console.WriteLine("Fertig");
            Console.ReadKey();
            
            //Console.Clear();

            
            //new ModeSelectionMenu();
            
            break;

            
        }
    }

    private void ShowResult()
    {
        Console.Clear();
        Console.WriteLine("==========================================");
        Console.WriteLine($"=== {reihe}er-Reihe ============================");
        Console.WriteLine("==========================================");
        Console.WriteLine();
        Console.WriteLine("Fertig!");
        Console.WriteLine($"Richtig: {correct}");
        Console.WriteLine($"Falsch: {wrong}");
        int thisRatio = (int)((double)correct / (correct + wrong) * 100);
        Console.WriteLine();

        Console.WriteLine($"Richtige Antworten im Profil für Reihe {reihe} davor: {ProfileManager.CurrentProfile.CorrectRow[reihe-1]}");
        ProfileManager.CurrentProfile.CorrectRow[reihe-1] += correct;
        Console.WriteLine($"Richtige Antworten im Profil für Reihe {reihe} danach: {ProfileManager.CurrentProfile.CorrectRow[reihe-1]}");

        ProfileManager.CurrentProfile.WrongRow[reihe-1] += wrong;
        int totalRatio = (int)(((double)ProfileManager.CurrentProfile.CorrectRow[reihe-1] 
                                / (ProfileManager.CurrentProfile.CorrectRow[reihe-1]
                                   + ProfileManager.CurrentProfile.WrongRow[reihe-1])) * 100);
        ProfileManager.CurrentProfile.TotalRow[reihe-1] += wrong;
        ProfileManager.CurrentProfile.TotalRow[reihe-1] += correct;
        ProfileManager.CurrentProfile.RatioRow[reihe-1] = totalRatio;
        ProfileManager.SaveProfile(ProfileManager.CurrentProfile.Name);
        Console.WriteLine($"Diese Runde: {thisRatio}% richtig");
        Console.WriteLine($"     Gesamt: {totalRatio}% richtig");
        //Console.WriteLine(totalRatio);
        Console.ReadKey();
        Console.Clear(); 
        
    }

    private void QuestionAndAnswer(int i)
    {
        while (true)
        {
            Console.WriteLine($"{i+1}.");
            Console.Write($"{multiplikator} x {reihe} = ");
            if (!int.TryParse(Console.ReadLine(), out answer))
            {
                Console.WriteLine("Ungültige Eingabe");
            }
            else
            {
                break;
            }
        }
        
        correctAnswer = multiplikator * reihe;
        if (correctAnswer == answer)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Richtig!");
            Console.ResetColor();
            correct++; 
        }
                   
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{multiplikator} x {reihe} = {correctAnswer}");
            wrong++;
            Console.ResetColor();
        }
        Console.ReadKey();

    }

    private int CalculateReccomendation()
    {
        double[] abilityIndex = new double[10];
        Console.WriteLine();
        abilityIndex[0] = 9999999;
        abilityIndex[9] = 9999999;
        for (int i = 1; i < 9; i++)
        {
            double accurateRatio = ProfileManager.CurrentProfile.CorrectRow[i] / ((double)ProfileManager.CurrentProfile.CorrectRow[i] +
                ProfileManager.CurrentProfile.WrongRow[i]);
            //Console.WriteLine(accurateRatio);
            //abilityIndex[i] = ProfileManager.CurrentProfile.TotalRow[i] * ((double)ProfileManager.CurrentProfile.RatioRow[i] / 100);
            abilityIndex[i] = ProfileManager.CurrentProfile.TotalRow[i] * accurateRatio;
            //Console.WriteLine($"Ability Index für Reihe {i+1} {abilityIndex[i]}={ProfileManager.CurrentProfile.TotalRow[i]} * {accurateRatio}");
        }

        double lowestAbilityIndex = abilityIndex.Min();
        return Array.IndexOf(abilityIndex, lowestAbilityIndex) + 1;
        
    }
}
    

    
