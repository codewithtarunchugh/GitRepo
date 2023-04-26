// 1) Given an array of integers, write a LINQ query to find all the even numbers.
using LinQCode;
using System.Diagnostics.CodeAnalysis;

int[] a = {
  1,
  2,
  3,
  4,
  5,
  6,
  7,
  8,
  9,
  10
};
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
// 2) Given a list of names, write a LINQ query to find all the names that start with the letter 'T'.
Console.WriteLine();
var names = new List<string> {
  "Tarun",
  "Darsh",
  "Gulshan",
  "Lalita",
  "Priyanka",
  "Ashu",
  "Poonam"
};
var name = from n in names where n.StartsWith('T') select n;
var name1 = names.Where(n => n.StartsWith('T'));
Console.WriteLine("Print names start with T");
foreach (var item in name)
{
    Console.WriteLine(item);
}

// 3) Given a list of products with their price, write a LINQ query to find the most expensive product.
var objProduct = new List<Product>() {
  new Product() {
      Name = "Book", Price = 10
    },
    new Product() {
      Name = "Book c#", Price = 20
    },
    new Product() {
      Name = "Book SQL", Price = 30
    },
};

Console.WriteLine("Most Expensive Product");
var expensiveProduct = objProduct.OrderByDescending(p => p.Price).FirstOrDefault();
Console.WriteLine($"{expensiveProduct.Name} {expensiveProduct.Price}");

// 4) Given a list of students with their grades, write a LINQ query to find the average grade of all the students.
Console.WriteLine();
Console.WriteLine("Average Grade of all students");
var students = new List<Student>() {
  new Student() {
      Name = "Tarun", Grade = 100
    },
    new Student() {
      Name = "Darsh", Grade = 80
    },
    new Student() {
      Name = "Gulshan", Grade = 69
    },
    new Student() {
      Name = "Priyanka", Grade = 83
    },
    new Student() {
      Name = "Lalita", Grade = 99
    },
};
var AverageStudent = students.Average(s => s.Grade);

Console.WriteLine(AverageStudent);

Console.WriteLine();
Console.WriteLine("Program to find last week dates from date list.");
// 5) Given a list of dates, write a LINQ query to find all the dates that are in the past week.
var Dates = new List<DateTime>() {
  new DateTime(2023, 4, 10),
    new DateTime(2023, 4, 12),
    new DateTime(2023, 4, 15),
    new DateTime(2023, 4, 22),
    new DateTime(2023, 4, 20),
};
var lastweekDates = Dates.Where(d => d >= DateTime.Today.AddDays(-7) && d <= DateTime.Today).OrderBy(d => d);
foreach (var item in lastweekDates)
{
    Console.WriteLine(item);
}
Console.WriteLine();
// 6) Given a list of customers with their orders, write a LINQ query to find the total amount spent by customer
Console.WriteLine("Program to find total amount spent");
var customers = new List<Customer> {
  new Customer {
    Name = "Tarun",
      Orders = new List < Order > {
        new Order {
          Product = "Keyboarad", Price = 20.99m
        },
        new Order {
          Product = "Monitor", Price = 30.99m
        },
        new Order {
          Product = "Mouse", Price = 15.99m
        }
      }
  },
  new Customer {
    Name = "Poonam",
      Orders = new List < Order > {
        new Order {
          Product = "Keyboarad", Price = 20.99m
        },
        new Order {
          Product = "Mouse", Price = 25.99m
        }
      }
  },
  new Customer {
    Name = "Darsh",
      Orders = new List < Order > {
        new Order {
          Product = "Keyboarad", Price = 20.99m
        },
        new Order {
          Product = "Monitor", Price = 340.99m
        },
        new Order {
          Product = "Mouse", Price = 115.99m
        }
      }
  },
  new Customer {
    Name = "Gulshan",
      Orders = new List < Order > {
        new Order {
          Product = "Keyboarad", Price = 220.99m
        },
        new Order {
          Product = "Monitor", Price = 310.99m
        }
      }
  }
};

var result = customers.Select(c => new
{
    Name = c.Name,
    Total = c.Orders.Sum(p => p.Price)
}).ToList();

foreach (var item in result)
{
    Console.WriteLine(item.Name + " " + item.Total);

}
Console.WriteLine();
Console.WriteLine("Program to find the number of products");
// 7) Given a list of products with their categories, write a LINQ query to find the number of products in each category
var products = new List<Product> {
  new Product {
    Name = "Product A", Category = "Category 1"
  },
  new Product {
    Name = "Product B", Category = "Category 1"
  },
  new Product {
    Name = "Product C", Category = "Category 2"
  },
  new Product {
    Name = "Product D", Category = "Category 2"
  },
  new Product {
    Name = "Product E", Category = "Category 2"
  },
  new Product {
    Name = "Product F", Category = "Category 3"
  }
};

// LINQ query to find the number of products in each category
var productList = products.GroupBy(p => p.Category)
  .Select(g => new
  {
      Category = g.Key,
      Count = g.Count()
  });

// Print the result
foreach (var item in productList)
{
    Console.WriteLine("Category: {0}, Count: {1}", item.Category, item.Count);
}

Console.WriteLine();
Console.WriteLine("Program to find the second smallest number in the list");
// 8) Given a list of integers, write a LINQ query to find the second smallest number in the list.
var numbers = new List<int>() {
  4,
  2,
  8,
  1,
  9,
  5,
  7,
  3
};

int secondSmallest = numbers.OrderBy(n => n).Skip(1).FirstOrDefault();

Console.WriteLine("The second smallest number in the list is: " + secondSmallest);

Console.WriteLine();
Console.WriteLine("Program to find the second smallest number in the list");
// 9) Given a list of employees with their salaries, write a LINQ query to find the top 5 earners.
List<Employee> employees = new List<Employee>() {
  new Employee("John", 75000),
    new Employee("Jane", 80000),
    new Employee("Bob", 90000),
    new Employee("Alice", 85000),
    new Employee("Dave", 95000),
    new Employee("Mary", 82000),
    new Employee("Tom", 87000),
    new Employee("Sue", 92000),
    new Employee("Joe", 89000),
    new Employee("Kate", 98000)
};

var topEarners = employees.OrderByDescending(e => e.Salary).Take(5);

Console.WriteLine("Top 5 earners:");
foreach (var employee in topEarners)
{
    Console.WriteLine(employee.Name + " - $" + employee.Salary);
}