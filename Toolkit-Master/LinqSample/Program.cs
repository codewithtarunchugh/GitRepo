// See https://aka.ms/new-console-template for more information

// 1) Given an array of integers, write a LINQ query to find all the even numbers.
// 2) Given a list of names, write a LINQ query to find all the names that start with the letter 'A'.
// 3) Given a list of students with their grades, write a LINQ query to find the average grade of all the 
// 4) Given a list of products with their price, write a LINQ query to find the most expensive product.
// 5) Given a list of dates, write a LINQ query to find all the dates that are in the past week.
// 6) Given a list of customers with their orders, write a LINQ query to find the total amount spent by
// 7) Given a list of products with their categories, write a LINQ query to find the number of products
// 8) Given a list of strings, write a LINQ query to find all the strings that contain the substring "
// 9) Given a list of integers, write a LINQ query to find the second smallest number in the list.
// 10) Given a list of employees with their salaries, write a LINQ query to find the top 5 earners.
//11
int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var even = from i in a where i % 2 == 0 select i;
var odd = from i in a where i % 2 == 1 select i;

var even1 = a.Where(n => n % 2 == 0);
var odd1 = a.Where(n => n % 2 == 1);

Console.WriteLine("Even Numbers");
foreach (var item in even1)
{
    Console.Write(item + ", ");
}
Console.WriteLine();
Console.WriteLine("Odd numbers");
foreach (var item in odd1)
{
    Console.Write(item + ", ");
}


