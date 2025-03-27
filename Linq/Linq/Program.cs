namespace Linq
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Sex {  get; set; }
        public double Temperature { get; set; }
        public int HeartRate { get; set; }
        public string Speciality { get; set; }
        public int Age { get; set; }

        public Patient(int id, string name, string lastName, string sex, double temp, int heart, string speciality, int age)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Sex = sex;
            Temperature = temp;
            HeartRate = heart;
            Speciality = speciality;
            Age = age;
        }
    }

    public class PriorityPatient : Patient
    {
        public bool Priority { get; set; }

        public PriorityPatient(int id, string name, string lastName, string sex, double temp, int heart, string speciality, int age, bool priority) : base( id,  name,  lastName,  sex,  temp,  heart,  speciality,  age)
        {
            Priority = priority;
        }
        
    }
    internal class Program
    {
        public static List<Patient> LoadPatients()
        {
            List<Patient> patientList = new List<Patient>();
            patientList = [new Patient(1, "John", "Doe", "Male", 36.8, 80, "General medicine", 44),
                            new Patient(2, "Jane", "Doe", "Female", 36.8, 70, "General medicine", 43),
                            new Patient(3, "Junior", "Doe", "Male", 36.8, 90, "Pediatrics", 8),
                            new Patient(4, "Mary", "Wien", "Female", 36.8, 120, "General medicine", 20),
                            new Patient(5, "Scarlett", "Somez", "Female", 36.8, 110, "General medicine", 30),
                            new Patient(6, "Brian", "Kid", "Male", 39.8, 80, "Pediatrics", 11)
                        ];
            return patientList;
        }

        public static List<Patient> GetPediatricsPatientsLess10(List<Patient> patientList)
        {
            List<Patient> list = new List<Patient>();
            var result = from patient in patientList
                         where patient.Speciality == "Pediatrics" && patient.Age < 10
                         select patient;
            foreach (var item in result)
            {
                list.Add(new Patient(item.Id, item.Name, item.LastName, item.Sex, item.Temperature, item.HeartRate, item.Speciality, item.Age));
            }
            return list;
        }

        public static List<Patient> GetEmergency(List<Patient> patientList)
        {
            List<Patient> list = new List<Patient>();
            var result = from patient in patientList
                         where patient.HeartRate > 100 || patient.Temperature > 39
                         select patient;
            foreach (var item in result)
            {
                list.Add(new Patient(item.Id, item.Name, item.LastName, item.Sex, item.Temperature, item.HeartRate, item.Speciality, item.Age));
            }
            return list;
        }

        public static List<Patient> SwapPatientsPediatrics (List<Patient> patientList)
        {
            List<Patient> list = new List<Patient>();
            foreach (var patient in patientList)
            {
                if(patient.Speciality == "Pediatrics")
                {
                    Patient patientTemp = new Patient(patient.Id, patient.Name, patient.LastName, patient.Sex, patient.Temperature, patient.HeartRate, "General Medicine", patient.Age);
                    list.Add(patientTemp);
                }
                else
                {
                    list.Add(patient);
                }   
            }
            return list;
        }

        public static void NumberBySpecialist (List<Patient> patientList)
        {
            var specialists = patientList.GroupBy(x => x.Speciality);
            foreach (var specialist in specialists)
            {
                Console.WriteLine($"{specialist.Key} => {specialist.Count()}");
            }
        }

        public static List<PriorityPatient> PriorityPatients(List<Patient> patientList)
        {
            List<PriorityPatient> list = new List<PriorityPatient>();
            foreach (var patient in patientList)
            {
                if (patient.HeartRate > 100 || patient.Temperature > 39)
                {
                    PriorityPatient patientTemp = new PriorityPatient(patient.Id, patient.Name, patient.LastName, patient.Sex, patient.Temperature, patient.HeartRate, patient.Speciality, patient.Age, true);
                    list.Add(patientTemp);
                }
                else
                {
                    PriorityPatient patientTemp = new PriorityPatient(patient.Id, patient.Name, patient.LastName, patient.Sex, patient.Temperature, patient.HeartRate, patient.Speciality, patient.Age, false);
                    list.Add(patientTemp);
                }
            }
            return list;
        }

        public static void AverageAgeBySpecialist(List<Patient> patientList)
        {
            var specialists = patientList.GroupBy(x => x.Speciality);
            foreach (var specialist in specialists)
            {
                Console.WriteLine($"{specialist.Key} => {specialist.Average(x => x.Age)}");
            }
        }

        public static void PrintResult(List<Patient> patientList)
        {
            foreach (Patient patient in patientList)
            {
                Console.WriteLine($"Nombre: {patient.Name} - Apellidos: {patient.LastName} - Temperatura: {patient.Temperature} - Ritmo Cardíaco: {patient.HeartRate} - Especialidad: {patient.Speciality}");
            }
            Console.WriteLine("");
        }

        public static void PrintResultPriority(List<PriorityPatient> patientList)
        {
            foreach (PriorityPatient patient in patientList)
            {
                Console.WriteLine($"Nombre: {patient.Name} - Apellidos: {patient.LastName} - Temperatura: {patient.Temperature} - Ritmo Cardíaco: {patient.HeartRate} - Prioritario: {patient.Priority}");
            }
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            List<Patient> pacientes = LoadPatients();
            int num;
            do
            {
                Console.WriteLine("*** Bienvenido ***");
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1 - Pacientes de Pediatría y menores de 10 años");
                Console.WriteLine("2 - Activar protocolo de urgencia (Ritmo cardiaco mayor a 100 o temperatura mayor a 39)");
                Console.WriteLine("3 - Reasignar pacientes de Pediatría a Medicina General");
                Console.WriteLine("4 - Número de pacientes de Medicina General y Pediatría");
                Console.WriteLine("5 - Lista de pacientes con prioridad (Ritmo cardíaco mayor a 100 o temperatura mayor a 39)");
                Console.WriteLine("6 - Edad media de pacientes de Medicina General y Pediatría");
                Console.WriteLine("0 - Salir");
                //No controlo la excepción de si no introduce un número porque el menú no se pide en el ejercicio.
                num = Convert.ToInt16(Console.ReadLine());

                switch (num)
                {
                    case 1:
                        PrintResult(GetPediatricsPatientsLess10(pacientes));
                        break;
                    case 2:
                        PrintResult(GetEmergency(pacientes));
                        break;
                    case 3:
                        PrintResult(SwapPatientsPediatrics(pacientes));
                        break;
                    case 4:
                        NumberBySpecialist(pacientes);
                        break;
                    case 5:
                        PrintResultPriority(PriorityPatients(pacientes));
                        break;
                    case 6:
                        AverageAgeBySpecialist(pacientes);
                        break;
                    case 0:
                        break;
                }
            }
            while( num != 0 );
            
        }
    }
}
