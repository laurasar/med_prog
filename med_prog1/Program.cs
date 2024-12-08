using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Library.Clinic.Models;
using Library.Clinic.Services;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            bool isContinue = true;
            do
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("A. Patient controls");
                Console.WriteLine("B. Physician controls");
                Console.WriteLine("C. Appointment controls");
                Console.WriteLine("Q. Quit");

                string input = Console.ReadLine() ?? string.Empty;

                if (char.TryParse(input, out char choice))
                {
                    switch (choice)
                    {
                        case 'a':
                        case 'A':
                            Console.WriteLine("What would you like to do?");
                            Console.WriteLine("1.See patients.");
                            Console.WriteLine("2.Add patients");
                            Console.WriteLine("3.Delete patients");
                            Console.WriteLine("4. Add to patients diagnosis.");
                            Console.WriteLine("5. Add to patients prescriptions");
                            input = Console.ReadLine() ?? string.Empty;
                            char.TryParse(input, out char ch);
                            switch (ch)
                            {
                                case '1':
                                    PatientServiceProxy.Patients.ForEach(x => Console.WriteLine($"{x.Id}.{x.Name}"));
                                    break; 
                                case '2':
                                    Console.WriteLine("Please enter name:");
                                    var name = Console.ReadLine();
                                    Console.WriteLine("Please enter address");
                                    var address = Console.ReadLine();
                                    Console.WriteLine("Please enter date of birth");
                                    DateTime dob = DateTime.Parse(Console.ReadLine() ?? string.Empty);
                                    Console.WriteLine("Please enter race: ");
                                    var race = Console.ReadLine();
                                    Console.WriteLine("Please enter gender: ");
                                    var gender = Console.ReadLine();
                                    var newPatient = new Patient
                                    {
                                        Name = name ?? string.Empty,
                                        Address = address ?? string.Empty,
                                        Birthday = dob,
                                        Race = race ?? string.Empty,
                                        Gender = gender ?? string.Empty
                                    };
                                    PatientServiceProxy.AddPatient(newPatient);
                                    break;
                                case '3':
                                    PatientServiceProxy.Patients.ForEach(x => Console.WriteLine($"{x.Id}.{x.Name}"));
                                    int selectedPatient = int.Parse(Console.ReadLine() ?? "-1");
                                    PatientServiceProxy.DeletePatient(selectedPatient);
                                    break;
                                case '4':
                                    Console.WriteLine("What patient would you like to add a diagnosis to, please put their id?");
                                     var patientId = int.Parse(Console.ReadLine() ?? "-1" ) ;
                                    Console.WriteLine("Input the diagnosis you would like to add:");
                                    var diagnosed= Console.ReadLine() ?? string.Empty;

                                    PatientServiceProxy.AddDiagnosis(patientId, diagnosed);

                                    break;
                                case '5':
                                    Console.WriteLine("What patient would you like to add a prescription to ?");
                                    var patientid = int.Parse(Console.ReadLine() ?? "-1");
                                    Console.WriteLine("Input the prescription you would like to add:");
                                    var prescription = Console.ReadLine() ?? string.Empty;
                                    break;

                            }
                            

                            break;
                        case 'B':
                        case 'b':
                            Console.WriteLine("What would you like to do?");
                            Console.WriteLine("1.See physicians.");
                            Console.WriteLine("2.Add physicians");
                            Console.WriteLine("3.Delete physicians");
                            input = Console.ReadLine() ?? string.Empty;
                            char.TryParse(input, out char opt);
                            switch (opt)
                            {
                                case '1':
                                    PhysicianServiceProxy.Physicians.ForEach(x => Console.WriteLine($"{x.licenseNum}.{x.Name}"));
                                    break;
                                case '2':
                                    Console.WriteLine("Please enter the following information:");
                                    Console.WriteLine("Please enter Physician name:");

                                    var pname = Console.ReadLine();
                                    Console.WriteLine("Please enter License Number");
                                    var licnum = int.Parse(Console.ReadLine() ?? string.Empty);
                                    Console.WriteLine("Please enter graduation date");
                                    DateTime grad = DateTime.Parse(Console.ReadLine() ?? string.Empty);
                                    Console.WriteLine("Please enter specialization: ");
                                    var special = Console.ReadLine();

                                    var newPhysician = new Physician
                                    {
                                        Name = pname ?? string.Empty,
                                        licenseNum = licnum,
                                        gradDate = grad,
                                        Specialization = special ?? string.Empty,

                                    };
                                    PhysicianServiceProxy.AddPhysician(newPhysician);

                                    break;
                                case '3':
                                    PhysicianServiceProxy.Physicians.ForEach(x => Console.WriteLine($"{x.licenseNum}.{x.Name}"));
                                    int selectedPhysician = int.Parse(Console.ReadLine() ?? "-1");
                                    PhysicianServiceProxy.DeletePhysician(selectedPhysician);

                                    break;

                            }

                            break;
                        
                        case 'q':
                        case 'Q':
                            isContinue = false;
                            break;
                        default:
                            Console.WriteLine("That is an invalid choice");
                            break;

                    }
                }
                else

                {
                    Console.WriteLine(choice + "is not a char");
                }
            } while (isContinue);

            foreach( var patient in PatientServiceProxy.Patients)
            {
                Console.WriteLine($"{patient}"); 
            }
            


        }
    }
}

