internal class Program
{
    private static void Main(string[] args)
    {
        bool programRunning = true;
            List<Employee> employeeRegistry = new List<Employee>();
        while (programRunning)
        {
            Console.WriteLine("Welcome to the employee registry");
            Console.WriteLine("Actions: \nadd employee\nfind employee\nview registry\nexit");
            bool correctInput = false;
            while (!correctInput)
            {
                string input = Console.ReadLine();
                if (input == "add employee")
                {

                    while (!correctInput)
                    {
                        Console.WriteLine("Name of employee: ");
                        input = Console.ReadLine();
                        if (input == string.Empty)
                        {
                            Console.WriteLine("Write the name of the employee and then press enter");
                        }
                        else
                            correctInput = true;
                    }
                    string nameHolder = input;
                    correctInput = false;
                    while (!correctInput)
                    {
                        Console.WriteLine("Employee salary: ");
                        input = Console.ReadLine();
                        correctInput = int.TryParse(input, out _);

                    }
                    int salaryHolder = int.Parse(input);
                    Console.WriteLine("Employee name: " + nameHolder + ". Salary: " + salaryHolder);
                    Console.WriteLine("Add this employee to the registry? \n yes/no");
                    correctInput = false;
                    while (!correctInput)
                    {
                        input = Console.ReadLine();
                        if (input == "yes")
                        {
                            employeeRegistry.Add(new Employee(nameHolder, salaryHolder));
                            Console.WriteLine(employeeRegistry[0].name);
                            correctInput = true;
                        }
                        else if (input == "no")
                        {
                            Console.WriteLine("Employee registration cancelled");
                            nameHolder = "";
                            salaryHolder = 0;
                            correctInput = true;
                        }

                    }

                }
                else if (input == "view registry")
                {
                    correctInput = true;
                    if (employeeRegistry.Count == 0)
                    {
                        Console.WriteLine("No employees have been added to registry");
                    }
                    for (int i = 0; i < employeeRegistry.Count; i++)
                    {
                        Console.WriteLine(employeeRegistry[i].name + " | "+ employeeRegistry[i].salary);
                    }
                }
                else if(input == "find employee")
                {
                    Console.WriteLine("Employee name: ");
                    input = Console.ReadLine();
                    Employee searchEmployee = employeeRegistry.Find(item => item.name.Equals(input));
                    if (searchEmployee != null)
                    {bool employeeEditor = true;
                        while (employeeEditor)
                        {
                        Console.WriteLine("Employee found! Name: " + searchEmployee.name + " Salary: " + searchEmployee.salary);
                        Console.WriteLine();
                        Console.WriteLine("Choose action: \nedit name\nedit salary\nremove employee\nreturn");
                        
                        
                            correctInput = false;
                            while (!correctInput) 
                            { 
                            input = Console.ReadLine();
                            if (input == "edit name")
                            {
                                Console.WriteLine("Input new name: ");
                                input = Console.ReadLine();
                                string nameHolder = input;
                                Console.WriteLine("Change " + searchEmployee.name + "'s name to " + nameHolder + "?");
                                while (!correctInput)
                                {
                                    input = Console.ReadLine();
                                    if (input == "yes")
                                    {
                                        Console.WriteLine("Name has been changed.");
                                        searchEmployee.name = nameHolder;
                                        correctInput = true;
                                    }
                                    if (input == "no")
                                        {
                                            Console.WriteLine("Name change cancelled.");
                                            correctInput = true;
                                        }
                                }
                                correctInput = true;
                            }
                            else if (input == "edit salary")
                            {
                                    Console.WriteLine("feature has not been added yet");
                                correctInput = true;
                            }
                            else if (input == "remove employee")
                            {
                                    Console.WriteLine(searchEmployee.name + " has been deleted from registry");
                                    employeeRegistry.Remove(searchEmployee);
                                    employeeEditor = false;
                                correctInput = true;
                            }
                            else if (input == "return")
                            {
                                    employeeEditor = false;
                                correctInput = true;
                            }
                            else
                                Console.WriteLine("incorrect input, select prompt from list");
                        } 
                    }
                        correctInput=  true;
                    }
                    else
                    {
                        Console.WriteLine("Employee not found.");
                        correctInput = true;
                    }
                }
                else if (input =="exit")
                {
                    programRunning = false;
                    correctInput = true;
                }
            }

        }
    }
    public class Employee
    {
        public string name = "";
        public int salary = 0;

        public Employee(string n, int s)
        { 
             name = n;
            salary = s;
        }

    }
}
