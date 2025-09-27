using System.Runtime.InteropServices.JavaScript;

namespace _1x1_Trainer;

public class Profile
{
    public string Name { get; set; }
    public int Correct { get; set; }
    public int Wrong { get; set; }

    public int[]CorrectRow = new int[10];
    public int[]WrongRow = new int[10];
    public int[]TotalRow = new int[10];
    public int[]RatioRow = new int[10];
    
    //public int LowestRow;
    //public int LowestRatioRow;
    //public int Reccomendation;

    
    public Profile(string name,int correct, int wrong)
        
        {
        Name = name;
        
        Correct = correct;
        Wrong = wrong;

        for (int i = 0; i < 10; i++)
        {
            CorrectRow[i] = 0;
            WrongRow[i] = 0;
            TotalRow[i] = 0;
            RatioRow[i] = 0;
            //LowestRow = 0;
            //LowestRatioRow = 0;
            //Reccomendation = 0;
        }
        
        }
}