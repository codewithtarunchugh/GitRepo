﻿using System;
using System.ComponentModel.Design;

namespace LSP
{
    //LSP: Object of a Parent class can be replaced with object of its derived classed without breaking the code.


    public interface ITraining
    {
        int GetTraining();
    }
    public interface IMembership : ITraining
    {
        void Add();
    }
    public class Membership : IMembership
    {
        public int MembershipType { get; set; }
        public virtual void Add()
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
    public class TrialMembership : ITraining
    {
       //"Trial MemberShip User can't be save into database");
       
        public int GetTraining()
        {
            return 2;
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
            List<Membership> list = new List<Membership>();
            list.Add(new PlusMembership());
            list.Add(new ProMembership());
            list.Add(new PremiumMembership());
            //list.Add(new TrialMembership());
            foreach (var item in list)
            {
                item.Add();
            }
            Console.WriteLine("Hello World");
        }
    }
}