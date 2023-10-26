﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SoftUni.Data;
using SoftUni.Models;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using var context = new SoftUniContext();

            //Console.WriteLine(GetEmployeesFullInformation(context));

            //Console.WriteLine(GetEmployeesWithSalaryOver50000(context));

            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));

            Console.WriteLine(AddNewAddressToEmployee(context));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees;

            var employeesFullInformation = employees.AsNoTracking().OrderBy(e => e.EmployeeId);

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employeesFullInformation)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees;

            int aboveSalary = 50000;

            var employeesSalaryOver50000 = employees
                .Where(e => e.Salary > aboveSalary)
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .ToArray();

            StringBuilder sb = new();

            foreach (var employee in employeesSalaryOver50000)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees;

            string department = "Research and Development";

            var employeesFromRAndD = employees
                .Where(e => e.Department.Name == department)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToArray();

            //var employeesFromSpecificDepartment = employees
            //    .Join(context.Departments, e => e.DepartmentId, d => d.DepartmentId, (e, d) => new 
            //{
            //    e.FirstName,
            //    e.LastName,
            //    d.Name,
            //    e.Salary
            //})
            //    .Where(e => e.Name == department)
            //    .OrderBy(e => e.Salary)
            //    .ThenByDescending(e => e.FirstName)
            //    .ToArray();

            StringBuilder sb = new();

            foreach(var employee in employeesFromRAndD)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Name} - ${employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context) 
        {
            var employees = context.Employees;

            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };


            string searchedName = "Nakov";

            var findEmployee = employees.Where(e => e.LastName == searchedName);

            //findEmployee.Address = address;

            context.SaveChanges();

            var tenAddressesText = employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => new
                {
                    e.Address.AddressText
                }).ToArray();

            StringBuilder sb = new();

            foreach (var employee in tenAddressesText) 
            {
                sb.AppendLine(employee.AddressText);
            }

            return sb.ToString().TrimEnd();
        }
    }
}