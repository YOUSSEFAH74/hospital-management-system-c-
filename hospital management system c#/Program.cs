using System;
using System.Collections.Generic;
using System.Linq;
namespace hospital_management_system_c_
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
    }

    public class Appointment
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }
    }

    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string Contact { get; set; }
    }

    class Program
    {
        static List<Patient> patients = new List<Patient>();
        static List<Appointment> appointments = new List<Appointment>();
        static List<Doctor> doctors = new List<Doctor>();

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Hospital Management System");
                Console.WriteLine("------------------------");
                Console.WriteLine("1. Patient Management");
                Console.WriteLine("2. Appointment Scheduling");
                Console.WriteLine("3. Doctor Management");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        PatientManagement();
                        break;
                    case 2:
                        AppointmentScheduling();
                        break;
                    case 3:
                        DoctorManagement();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            //onsole.ReadKey();
        }

        static void PatientManagement()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Patient Management");
                Console.WriteLine("----------------");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. View Patients");
                Console.WriteLine("3. Back");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddPatient();
                        break;
                    case 2:
                        ViewPatients();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void AddPatient()
        {
            Console.Clear();
            Console.WriteLine("Add Patient");
            Console.WriteLine("---------");

            Console.Write("Enter patient name: ");
            string name = Console.ReadLine();
            Console.Write("Enter patient age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter patient address: ");
            string address = Console.ReadLine();
            Console.Write("Enter patient contact: ");
            string contact = Console.ReadLine();

            Patient patient = new Patient
            {
                Id = patients.Count + 1,
                Name = name,
                Age = age,
                Address = address,
                Contact = contact
            };

            patients.Add(patient);
            Console.WriteLine("Patient added successfully.");
        }

        static void ViewPatients()
        {
            Console.Clear();
            Console.WriteLine("View Patients");
            Console.WriteLine("-----------");

            if (patients.Count == 0)
            {
                Console.WriteLine("No patients found.");
            }
            else
            {
                Console.WriteLine("{0,-5} {1,-20} {2,-5} {3,-30} {4,-20}", "ID", "Name", "Age", "Address", "Contact");
                Console.WriteLine("---------------------------------------------------------");

                foreach (var patient in patients)
                {
                    Console.WriteLine("{0,-5} {1,-20} {2,-5} {3,-30} {4,-20}", patient.Id, patient.Name, patient.Age, patient.Address, patient.Contact);
                }
            }
        }

        static void AppointmentScheduling()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Appointment Scheduling");
                Console.WriteLine("----------------------");
                Console.WriteLine("1. Schedule Appointment");
                Console.WriteLine("2. View Appointments");
                Console.WriteLine("3. Back");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ScheduleAppointment();
                        break;
                    case 2:
                        ViewAppointments();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void ScheduleAppointment()
        {
            Console.Clear();
            Console.WriteLine("Schedule Appointment");
            Console.WriteLine("--------------------");

            Console.Write("Enter patient ID: ");
            int patientId = int.Parse(Console.ReadLine());

            Console.Write("Enter doctor ID: ");
            int doctorId = int.Parse(Console.ReadLine());

            Console.Write("Enter appointment date (YYYY-MM-DD): ");
            DateTime appointmentDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter appointment reason: ");
            string reason = Console.ReadLine();

            Patient patient = patients.FirstOrDefault(p => p.Id == patientId);
            Doctor doctor = doctors.FirstOrDefault(d => d.Id == doctorId);

            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            if (doctor == null)
            {
                Console.WriteLine("Doctor not found.");
                return;
            }

            Appointment appointment = new Appointment
            {
                Id = appointments.Count + 1,
                Patient = patient,
                Doctor = doctor,
                AppointmentDate = appointmentDate,
                Reason = reason
            };

            appointments.Add(appointment);
            Console.WriteLine("Appointment scheduled successfully.");
        }

        static void ViewAppointments()
        {
            Console.Clear();
            Console.WriteLine("View Appointments");
            Console.WriteLine("-----------------");

            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments found.");
            }
            else
            {
                Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-15} {4,-30}", "ID", "Patient", "Doctor", "Date", "Reason");
                Console.WriteLine("-----------------------------------------------------------------");

                foreach (var appointment in appointments)
                {
                    Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-15} {4,-30}", appointment.Id, appointment.Patient.Name, appointment.Doctor.Name, appointment.AppointmentDate.ToString("yyyy-MM-dd"), appointment.Reason);
                }
            }
        }

        static void DoctorManagement()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Doctor Management");
                Console.WriteLine("-----------------");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. View Doctors");
                Console.WriteLine("3. Back");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddDoctor();
                        break;
                    case 2:
                        ViewDoctors();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void AddDoctor()
        {
            Console.Clear();
            Console.WriteLine("Add Doctor");
            Console.WriteLine("----------");

            Console.Write("Enter doctor name: ");
            string name = Console.ReadLine();
            Console.Write("Enter doctor specialization: ");
            string specialization = Console.ReadLine();
            Console.Write("Enter doctor contact: ");
            string contact = Console.ReadLine();

            Doctor doctor = new Doctor
            {
                Id = doctors.Count + 1,
                Name = name,
                Specialization = specialization,
                Contact = contact
            };

            doctors.Add(doctor);
            Console.WriteLine("Doctor added successfully.");
        }

        static void ViewDoctors()
        {
            Console.Clear();
            Console.WriteLine("View Doctors");
            Console.WriteLine("-----------");

            if (doctors.Count == 0)
            {
                Console.WriteLine("No doctors found.");
            }
            else
            {
                Console.WriteLine("{0,-5} {1,-20} {2,-30} {3,-20}", "ID", "Name", "Specialization", "Contact");
                Console.WriteLine("---------------------------------------------------------");

                foreach (var doctor in doctors)
                {
                    Console.WriteLine("{0,-5} {1,-20} {2,-30} {3,-20}", doctor.Id, doctor.Name, doctor.Specialization, doctor.Contact);
                }
            }
        }
    }
}