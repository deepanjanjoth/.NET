﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment06
    {
        class Program
        {
            static void Main1(string[] args)
            {
                List<Employees1> li = new List<Employees1>();
                Employees1 e = new Employees1();
                // e.EmpId = 100000;
                try
                {
                    char choice = 'y';
                    while (choice == 'y')
                    {
                        Employees1.insertEmployee(li);
                        Console.Write("Do you Want to continue type (y/n) : ");
                        choice = Convert.ToChar(Console.ReadLine());

                    }
                }
                catch (InvalidEmpIdException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidEmpNameException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidEmpSalException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please Enter Valid Input");
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }



                Employees1[] arr = li.ToArray();

                foreach (Employees1 el in arr)
                {
                    Console.WriteLine(el.EmpId + "  " + el.EmpName + "  " + el.EmpSal);
                }


                Console.ReadLine();
            }
        }
        class Employees1
        {
            private int empId;

            private string empName;
            private decimal empSal;

            public int EmpId
            {
                get { return empId; }
                set
                {
                    if (value < 10) empId = value;
                    else
                    {
                        Exception ex;
                        ex = new InvalidEmpIdException("Invalid Emp Id !!");
                        throw ex;
                    }
                }
            }
            public string EmpName
            {
                get { return empName; }
                set
                {
                    if (value == null)
                    {
                        Exception ex;
                        ex = new InvalidEmpNameException("Invalid Name !!");
                        throw ex;
                    }
                    else empName = value;
                }
            }
            public decimal EmpSal
            {
                get { return empSal; }
                set
                {
                    if (value < 1000)
                    {
                        Exception ex;
                        ex = new InvalidEmpSalException("Invalid Emp Sal !!");
                        throw ex;
                    }
                    else empSal = value;
                }
            }

            public Employees1(int empId, string empName, decimal empSal)
            {
                this.EmpId = empId;
                this.EmpName = empName;
                this.EmpSal = empSal;
            }
            public Employees1()
            {

            }
            public static void insertEmployee(List<Employees1> li)
            {
                Employees1 emp = new Employees1();
                Console.WriteLine("-------------------------------------------------");
                Console.Write("Enter Employee Id : ");
                int empId = Convert.ToInt32(Console.ReadLine());
                emp.EmpId = empId;
                Console.Write("Enter Employee Name : ");
                string empName = Console.ReadLine();
                emp.EmpName = empName;
                Console.Write("Enter Employee Sal : ");
                decimal empSal = Convert.ToDecimal(Console.ReadLine());
                emp.EmpSal = empSal;
                li.Add(new Employees1(empId, empName, empSal));
                //li.Add(new Employees { EmpId = empId, EmpName = empName, EmpSal = empSal });
            }



        }
        public class InvalidEmpIdException : ApplicationException
        {
            public InvalidEmpIdException(string massage) : base(massage)
            {

            }
        }
        public class InvalidEmpNameException : ApplicationException
        {
            public InvalidEmpNameException(string massage) : base(massage)
            {

            }
        }
        public class InvalidEmpSalException : ApplicationException
        {
            public InvalidEmpSalException(string massage) : base(massage)
            {

            }
        }
    
}
