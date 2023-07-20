using System;
namespace SRP
{
    //SRP: Class should have only one or funcitonality related to the class only.
    //Membership class will handle funcationality related to membership only for logging diff class.
    public class Membership
    {
        public void Add()
        {
            try
            {
                // TO DO:
            }
            catch (Exception ex)
            {
                FileLogging.LogError(ex.Message);
            }
        }
    }
    public static class FileLogging
    {
        public static void LogError(string error)
        {
            File.WriteAllText(@"C:\Error.txt", error);
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World");
        }
    }
}