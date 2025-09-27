using System.ComponentModel.Design;

namespace _1x1_Trainer;

internal class KrissKrossMenu : BaseMenu
{
    private int correct;
    private int wrong;
    private byte reihe;
    private int divisor;
    private int multiplicator;
    private int correctAnswer;
    private int answer;
    int result;
    
    public override void DisplayMenu()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("=== Trainer = Kriss Kross ================");
        Console.WriteLine("==========================================");
        Console.WriteLine();
        reihe = InputRow();
        Abfrage(reihe);
        ShowResult();
        //Console.ReadLine();
        BaseMenu nextMenu = new ModeSelectionMenu();
    }

    private void Abfrage(byte reihe)
    {
        correct = 0;
        wrong = 0;
        for (int i = 0; i < 14; i++)
        {
            Random zahl = new Random();
            int x = zahl.Next(1, 3);
            if (x % 2 == 0)
                AbfrageMultiplication(reihe, i);
            else AbfrageDivision(reihe,i);
        }
        Console.WriteLine("Fertig");
        Console.ReadKey();
            
        //Console.Clear();

            
        //new ModeSelectionMenu();
            
        //break;


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

    private void AbfrageDivision(byte reihe,int i)
    {
        Console.Clear();
        Console.WriteLine("==========================================");
        Console.WriteLine($"=== {reihe}er-Reihe = Kross ====================");
        Console.WriteLine("==========================================");
        Console.WriteLine();


        while (true)
        {
            Random zahl = new Random();
            divisor = zahl.Next(2, 10);
            Console.Clear();
            
            
            Console.WriteLine("==========================================");
            Console.WriteLine($"=== {reihe}er-Reihe = Kross ====================");
            Console.WriteLine("==========================================");
            Console.WriteLine();
            QuestionAndAnswerDivision(i);
            break;
        }

 
    }
    private void ShowResult()
    {
        Console.Clear();
        Console.WriteLine("==========================================");
        Console.WriteLine($"= {reihe}er-Reihe - Kriss Kross");
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

    private void QuestionAndAnswerDivision(int i)
    {
        result = divisor * reihe;
        while (true)
        {
            Console.WriteLine($"{i+1}.");

            
            Console.Write($"{result} : {reihe} = ");
            if (!int.TryParse(Console.ReadLine(), out answer))
            {
                Console.WriteLine("Ungültige Eingabe");
            }
            else
            {
                break;
            }
        }
        
        correctAnswer = divisor;
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
            Console.WriteLine($"{result} : {reihe} = {divisor}");
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
    private void QuestionAndAnswerMultiplication(int i)
    {
        while (true)
        {
            Console.WriteLine($"{i+1}.");
            Console.Write($"{multiplicator} x {reihe} = ");
            if (!int.TryParse(Console.ReadLine(), out answer))
            {
                Console.WriteLine("Ungültige Eingabe");
            }
            else
            {
                break;
            }
        }
        
        correctAnswer = multiplicator * reihe;
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
            Console.WriteLine($"{multiplicator} x {reihe} = {correctAnswer}");
            wrong++;
            Console.ResetColor();
        }
        Console.ReadKey();

    }
    private void AbfrageMultiplication(byte reihe, int i)
    {
        Console.Clear();
        Console.WriteLine("==========================================");
        Console.WriteLine($"=== {reihe}er-Reihe = Kriss ====================");
        Console.WriteLine("==========================================");
        Console.WriteLine();


        while (true)
        {
            Random zahl = new Random();
            multiplicator = zahl.Next(2, 10);
            Console.Clear();
            
            
            Console.WriteLine("==========================================");
            Console.WriteLine($"=== {reihe}er-Reihe = Kriss ====================");
            Console.WriteLine("==========================================");
            Console.WriteLine();
            QuestionAndAnswerMultiplication(i);
            break;
        }
    }
}
    

    
