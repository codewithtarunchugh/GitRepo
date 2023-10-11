CREATE TABLE customer
(
CustID int PRIMARY KEY,
CustName varchar(50) NOT NULL,
Age int NOT NULL,
City char(50),
Salary numeric
);select * from customerINSERT INTO customer
(CustID, CustName, Age, City, Salary)
VALUES
(1, 'Sam', 26, 'Delhi', 9000),
(2, 'Ram', 19, 'Bangalore', 11000),
(3, 'Pam', 31, 'Mumbai', 6000),
(4, 'Jam', 42, 'Pune', 10000);
UPDATE customer
SET CustName = 'Xam', Age= 32
WHERE CustID = 4;ALTER TABLE Customer
ADD Gender varchar(10);

ALTER TABLE customer
ALTER COLUMN Gender char(10);

ALTER TABLE customer
DROP COLUMN Gender;

DELETE FROM customer
WHERE CustID = 3;

DROP TABLE customer;

TRUNCATE TABLE table_name;


CREATE TABLE classroom
(
rollno int PRIMARY KEY,
name varchar(50) NOT NULL,
house char(12) NOT NULL,
grade char(1)
);INSERT INTO classroom
(rollno, [name], house, grade)
VALUES
(1, 'Sam', 'Akash', 'B'),
(2, 'Ram', 'Agni', 'A'),
(3, 'Shyam', 'Jal', 'B'),
(4, 'Sundar', 'Agni', 'A'),
(5, 'Ram', 'Yayu', 'B')

select * from classroom

SELECT name FROM classroom
WHERE grade='A';

SELECT DISTINCT grade FROM classroom; 

--1. Arithmetic operators : arithmetic operations on numeric values
--Example: Addition (+), Subtraction (-), Multiplication (*), Division (/), Modulus (%)
--2. Comparison operators: compare two different data of SQL table
--• Example: Equal (=), Not Equal (!=), Greater Than (>), Greater Than Equals to (>=)
--3. Logical operators: perform the Boolean operations
--• Example: ALL, IN, BETWEEN, LIKE, AND, OR, NOT, ANY
--4. Bitwise operators: perform the bit operations on the Integer values
--• Example: Bitwise AND (&), Bitwise OR(|)

SELECT * FROM classroom
WHERE grade='A' and rollno>3;

SELECT TOP 5 * FROM classroom;

SELECT * FROM classroom
ORDER BY [name]  ASC; 


CREATE TABLE customer
(
customer_id int PRIMARY KEY,
first_name varchar(50),
last_name varchar(50),
email varchar(100),
address_id int
);select * from customerBULK INSERT customer
FROM 'F:\CodeRepository\Samples\SQL\customer.csv'
WITH (
    FIELDTERMINATOR = ',',
    FIRSTROW = 2,  -- Skip the header row if it exists
    ROWTERMINATOR = '\n',
    CODEPAGE = 'ACP'  -- Specify the appropriate code page if needed
);


CREATE TABLE payment
(
customer_id int,
amount numeric,
mode varchar(50),
payment_date date
);

select * from payment

BULK INSERT payment
FROM 'F:\CodeRepository\Samples\SQL\payment.csv'
WITH (
    FIELDTERMINATOR = ',',
    FIRSTROW = 2,  -- Skip the header row if it exists
    ROWTERMINATOR = '\n',
    CODEPAGE = 'ACP'  -- Specify the appropriate code page if needed
);


-- System Defined Function
--• Example: rand(), round(), upper(), lower(), count(), sum(), avg(), max(),

select rand()
select UPPER('Tarun')
select lower('Tarun')
select COUNT()
select Sum(1+1)
select AVG()
select max()

-- String Functions

--• UPPER() converts the value of a field to uppercase
--• LOWER() converts the value of a field to lowercase
--• LEN() returns the length of the value in a text field
--• SUBSTRING() extracts a substring from a string
--• GETDATE() returns the current system date and time
--• FORMAT() used to set the format of a field
--• CONCAT() adds two or more strings together
--• REPLACE() Replaces all occurrences of a substring within a string, with a new substring
--• TRIM() removes leading and trailing spaces (or other specified characters) from a string

-- Aggregate Functions

--• COUNT() returns number of values
--• SUM() returns sum of all values
--• AVG() returns average value
--• MAX() returns maximum value
--• MIN() returns minimum value
--• ROUND() Rounds a number to a specified number of decimal places


select LEN(first_name) as Lenth, UPPER(first_name) as FirstName,
Lower(last_name) as LastName, REPLACE(first_name,'a','chugh') as ReplaceValue,
CONCAT(first_name,' ',last_name) as FullName, SUBSTRING(first_name,1,2) as First2Char , GETDATE() as todaydate, FORMAT(GETDATE(),'yyyy-MM-dd') as Formatteddate,
first_name from customer


select * from payment
select count(*) from payment
select Sum(Amount) from payment
select Avg(Amount) from payment
select Max(Amount) from payment
select MIN(Amount) from payment
SELECT CAST(AVG(Amount) AS DECIMAL(10, 2)) FROM payment

select Mode, sum(Amount) as Total, count (*) as NoOfTrans  
from payment 
group by Mode 
order by Total asc


select Mode, sum(Amount) as Total, count (*) as NoOfTrans  
from payment 
group by Mode 
-- having count (*)  >= 3
having count (*)  >= 3 and count (*)  < 4 
order by Total asc

-- Order of execution in SQL:
-- SELECT, FROM, WHERE, GROUP BY, HAVING, ORDER BY, top

-- FROM, WHERE, GROUP BY, HAVING, SELECT, ORDER BY, and top.

SELECT SYSDATETIMEOFFSET() AS TimeZoneOffsetInMinutes;
SELECT DATEPART(TZOFFSET, SYSDATETIMEOFFSET()) AS TimeZoneOffsetInMinutes;
SELECT SYSDATETIME() AS CurrentTimestamp;
SELECT CONVERT(TIME, SYSDATETIME()) AS CurrentTimeOfDay;
SELECT CONVERT(TIME, SYSDATETIME()) AS CurrentTime;
SELECT CONVERT(DATE, SYSDATETIME()) AS CurrentDate;


SELECT DATEPART(MONTH, payment_date) AS ExtractedMonth, 
DATEPART(YEAR, payment_date) AS Extractedyear, 
DATEPART(DAY, payment_date) AS Extracteddate, 
DATEPART(QUARTER, payment_date) AS ExtractedQUARTER, 
payment_date
FROM payment;

select * from customer
select * from payment


SELECT c.*, p.amount, p.mode, p.payment_date FROM customer c INNER JOIN payment p on c.customer_id=p.customer_id  
SELECT c.*, p.amount, p.mode, p.payment_date FROM customer c LEFT JOIN payment p on c.customer_id=p.customer_id  
SELECT c.*, p.amount, p.mode, p.payment_date FROM customer c RIGHT JOIN payment p on c.customer_id=p.customer_id  


SELECT c.*, p.amount, p.mode, p.payment_date from customer c FULL OUTER JOIN payment p on c.customer_id=p.customer_id  
where c.first_name='Madan'


alter table employee
add  manager_id int


select * from employee

update Employee
set Manager_id=3 where EmpID=5

select e.*,e1.EmpName as ManagerName from Employee e join Employee e1
on e.Manager_id=e1.EmpID

select * from customer
union 
select * from customer

select * from customer
union all
select * from customer

select * from payment
where amount >=(select avg(amount) from payment)

select * from payment
where customer_id in (select customer_id from customer)

select * from customer
where EXISTS (select * from customer where customer_id=1)


IF EXISTS (select * from customer where customer_id=1)
	BEGIN
		SELECT 'True'
	END
ELSE
	BEGIN
		SELECT 'False'
	END