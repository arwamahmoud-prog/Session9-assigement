using System;

namespace Session09_Assignment
{
    // ================== Part 1: Primary Constructor & Records ==================
    // Q1: Primary Constructor
    public class Patient(int id, string fullName, string phoneNumber, string medicalHistory)
    {
        // تحويل المعاملات إلى خصائص (Properties) لكي نتمكن من الوصول إليها لاحقاً
        public int Id { get; set; } = id;
        public string FullName { get; set; } = fullName;
        public string PhoneNumber { get; set; } = phoneNumber;
        public string MedicalHistory { get; set; } = medicalHistory;

        public override string ToString()
        {
            return $"Id: {Id} :: FullName: {FullName} :: PhoneNumber: {PhoneNumber} :: MedicalHistory: {MedicalHistory}";
        }
    }

    // Q3: Positional Record
    public record PatientDto(int Id, string FullName, string PhoneNumber);

    // Q4: Static Mapper Class
    public static class PatientMapper
    {
        public static PatientDto MapFromModelToDto(Patient patient)
        {
            return new PatientDto(patient.Id, patient.FullName, patient.PhoneNumber);
        }
    }

    // ================== Part 2: Singleton ==================
    // Q5: AppLogger Singleton
    public class AppLogger
    {
        private static AppLogger _instance = null;

        // Private constructor لمنع إنشاء الكائنات من الخارج
        private AppLogger() { }

        public static AppLogger GetLogger()
        {
            if (_instance == null)
            {
                _instance = new AppLogger();
            }
            return _instance;
        }
    }

    // ================== Part 5: Extension Methods ==================
    // Q9: TextHelper Extension Methods
    public static class TextHelper
    {
        public static bool IsShorterThan(this string value, int length)
        {
            return value.Length < length;
        }

        public static string Repeat(this string value, int times)
        {
            string result = "";
            for (int i = 0; i < times; i++)
            {
                result += value;
            }
            return result;
        }
    }

    // ================== Part 6: Unit Testing (Main Logic) ==================
    // Q11: FineCalculator Class
    public class FineCalculator
    {
        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
        public int Multiply(int a, int b) => a * b;
        public int Divide(int a, int b)
        {
            if (b == 0) throw new DivideByZeroException();
            return a / b;
        }
    }

    // ================== MAIN METHOD ==================
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Part 1: Primary Constructors & Records ---");
            // Q2
            Patient patient01 = new Patient(1, "Ahmed Ali", "010123", "Diabetes");
            Patient patient02 = new Patient(1, "Ahmed Ali", "010123", "Diabetes");

            Console.WriteLine($"patient01 HashCode: {patient01.GetHashCode()}");
            Console.WriteLine($"patient02 HashCode: {patient02.GetHashCode()}");
            // Are they equal? No, because they are separate reference types (classes) pointing to different memory locations.

            Console.WriteLine($"patient01.Equals(patient02): {patient01.Equals(patient02)}");
            // Result: false, because classes use reference equality by default.

            patient01 = patient02;
            Console.WriteLine($"After assigning patient01 = patient02, Equals: {patient01.Equals(patient02)}");
            // What changed? Both variables now point to the exact same object in memory, so it returns true.

            // Q3
            PatientDto dto1 = new PatientDto(1, "Ahmed Ali", "010123");
            PatientDto dto2 = new PatientDto(1, "Ahmed Ali", "010123");
            Console.WriteLine($"dto1 HashCode: {dto1.GetHashCode()}");
            Console.WriteLine($"dto2 HashCode: {dto2.GetHashCode()}");
            Console.WriteLine($"dto1.Equals(dto2): {dto1.Equals(dto2)}");
            // Difference observed: Records use Value Equality automatically. Even though they are different objects in memory, 
            // their GetHashCode is the same and Equals returns true because their values are identical.

            // Q4
            Patient newPatient = new Patient(2, "Sara", "011", "None");
            PatientDto mappedDto = PatientMapper.MapFromModelToDto(newPatient);
            Console.WriteLine($"Mapped DTO: {mappedDto}");


            Console.WriteLine("\n--- Part 2: Singleton ---");
            // Q6
            var logger1 = AppLogger.GetLogger();
            var logger2 = AppLogger.GetLogger();
            var logger3 = AppLogger.GetLogger();
            var logger4 = AppLogger.GetLogger();
            Console.WriteLine($"Logger1 HashCode: {logger1.GetHashCode()}");
            Console.WriteLine($"Logger2 HashCode: {logger2.GetHashCode()}");
            Console.WriteLine($"Logger3 HashCode: {logger3.GetHashCode()}");
            Console.WriteLine($"Logger4 HashCode: {logger4.GetHashCode()}");
            // Observation: All 4 have the exact same HashCode.
            // Why: Because of the Singleton pattern, only one instance is ever created in memory, and GetLogger() returns that same instance every time.


            Console.WriteLine("\n--- Part 3: var & dynamic ---");
            // Q7
            Patient p1 = new(3, "Omar", "012", "Asthma");      // Target-typed new
            var p2 = new Patient(4, "Ziad", "015", "None");    // var
            dynamic p3 = new Patient(5, "Mona", "010", "Flu"); // dynamic
            Console.WriteLine(p3);
            // Difference between var and dynamic:
            // 'var' is strongly typed and resolved at Compile-time (the compiler figures out the type).
            // 'dynamic' skips compile-time type checking and is resolved at Run-time.


            Console.WriteLine("\n--- Part 4: Anonymous Types ---");
            // Q8
            var doctor01 = new { Name = "Sara", Specialty = "Cardiology", ExperienceYears = 8, Salary = 25000 };
            var doctor02 = new { Name = "Sara", Specialty = "Cardiology", ExperienceYears = 8, Salary = 25000 };

            Console.WriteLine($"Name: {doctor01.Name}, Specialty: {doctor01.Specialty}");
            Console.WriteLine($"doctor01 HashCode: {doctor01.GetHashCode()}");
            Console.WriteLine($"doctor02 HashCode: {doctor02.GetHashCode()}");
            Console.WriteLine($"doctor01.GetType(): {doctor01.GetType()}");
            Console.WriteLine($"doctor01.Equals(doctor02): {doctor01.Equals(doctor02)}");
            Console.WriteLine($"doctor01.ToString(): {doctor01.ToString()}");
            // Comparison: Anonymous types behave like Records (Value Equality). If all properties match, Equals returns true and HashCodes match. Classes (by default) use Reference Equality.


            Console.WriteLine("\n--- Part 5: Extension Methods ---");
            // Q10
            Console.WriteLine($"'Stethoscope'.IsShorterThan(5): {"Stethoscope".IsShorterThan(5)}");
            Console.WriteLine($"'Ab'.Repeat(4): {"Ab".Repeat(4)}");
        }
    }
}
