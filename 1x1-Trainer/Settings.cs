namespace _1x1_Trainer;

public static class Settings
{
    public static string ProfilePath { get; set; }

    static Settings()
    {
        //AppContext.BaseDirectory.
        ProfilePath = @"C:\temp";
    }
    
}