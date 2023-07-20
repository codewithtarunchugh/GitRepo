using System;
using System.ComponentModel.Design;

namespace OCP
{
    //OCP: Class should be open for extention and closed for modification/change. once testing done it should follow the OCP
    //Use Interitance and virtual function for extended the funcationality.
    public class Membership
    {
        public int MembershipType { get; set; }
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
        public virtual int GetTraining()
        {
            return 2;
            //if (MembershipType == 1) //Plus
            //{
            //    return 5;
            //}
            //else if (MembershipType == 2) //Pro
            //{
            //    return 10;
            //}
            //else if (MembershipType == 3) //Premium
            //{
            //    return 20;
            //}
            //else
            //{
            //    return 2;
            //}
        }
    }
    public class PlusMembership : Membership
    {
        public override int GetTraining()
        {
            return 5;
        }
    }
    public class ProMembership : Membership
    {
        public override int GetTraining()
        {
            return 10;
        }
    }
    public class PremiumMembership : Membership
    {
        public override int GetTraining()
        {
            return 20;
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