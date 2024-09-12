using Employee_registry;


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
                    string name;
                    int salary;
                    bool employeeAdded = AddEmployee(out name, out salary);
                    if (true)
                    {
                        employeeRegistry.Add(new Employee(name, salary));
                        Console.WriteLine(employeeRegistry[0].GetName());
                    }
                    correctInput = true;
                }
                else if (input == "view registry")
                {
                    PrintRegistry(employeeRegistry);
                    correctInput = true;
                }
                else if (input == "find employee")
                {
                    Employee searchEmployee = EmployeeSearch(employeeRegistry);
                    
                    if (searchEmployee != null)
                    {
                        bool employeeEditor = true;
                        while (employeeEditor)
                        {
                            Console.WriteLine("Employee found! Name: \t" + searchEmployee.GetName() + " Salary: \t" + searchEmployee.GetSalary());
                            Console.WriteLine();
                            EmployeeEditor(searchEmployee);
                        }
                        correctInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Employee not found.");
                        correctInput = true;
                    }
                }
                else if (input == "exit")
                {
                    programRunning = false;
                    correctInput = true;
                }
            }

        }





    }
    private static bool AddEmployee(out string name, out int salary)
    {
        bool active = true;

        name = SetName();
        salary = SetSalary();
        Console.WriteLine("Employee name: " + name + ". Salary: " + salary);
        Console.WriteLine("Add this employee to the registry? \n yes/no");
        bool correctInput = false;
        while (!correctInput)
        {
            string input = Console.ReadLine();
            if (input == "yes")
            {

                return true;
                correctInput = true;
            }
            else if (input == "no")
            {
                Console.WriteLine("Employee registration cancelled");

                return false;
                correctInput = true;
            }

        }
        return false;
    }
    private static string SetName()
    {
        bool correctInput = false;
        string input;
        do
        {
            Console.WriteLine("Name of employee: ");
            input = Console.ReadLine();
        }
        while (!correctInput);
        {

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Write the name of the employee and then press enter");
            }
            else
                correctInput = true;
        }
        return input;
    }
    private static int SetSalary()
    {
        bool correctInput = false;
        string input;
        int salary;
        do
        {
            Console.WriteLine("Employee salary: ");
            input = Console.ReadLine();
        } while (!correctInput || string.IsNullOrWhiteSpace(input));
        {

            correctInput = int.TryParse(input, out _);

        }
        return int.Parse(input);
    }
    private static void PrintRegistry(List<Employee> employee)
    {
        
        if (employee.Count == 0)
        {
            Console.WriteLine("No employees have been added to registry");
        }
        for (int i = 0; i < employee.Count; i++)
        {
            Console.WriteLine(employee[i].GetName() + " | " + employee[i].GetSalary());
        }
        return;
    }
    private static Employee EmployeeSearch(List<Employee> employeeList)
    {
        Console.WriteLine("Employee name: ");
        string input = Console.ReadLine();
        Employee searchEmployee = employeeList.Find(item => item.GetName().Equals(input));
        return searchEmployee;
    }
    private static void EmployeeEditor(Employee employee)
    {
        bool editorActive = true;
        bool correctInput = false;
        string input;
        do
        {
            Console.WriteLine("Choose action: \nedit name\nedit salary\nremove employee\nreturn");
            input = Console.ReadLine();

        }
        while (editorActive);
        {
           
            if (input == "edit name")
            {
                Console.WriteLine("Input new name: ");
                input = SetName();
                string nameHolder = input;
                Console.WriteLine("Change " + employee.GetName() + "'s name to " + nameHolder + "?");
                while (!correctInput)
                {
                    input = Console.ReadLine();
                    if (input == "yes")
                    {
                        Console.WriteLine("Name has been changed.");
                        employee.SetName(nameHolder);
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
                int newSalary = SetSalary();
                Console.WriteLine("feature has not been added yet");
                Console.WriteLine($"Salary changed from {employee.GetSalary} to {newSalary}.");
                employee.SetSalary(newSalary);
            }
            //else if (input == "remove employee")
            //{
            //    Console.WriteLine(employee.GetName() + " has been deleted from registry");
            //    employeeRegistry.Remove(searchEmployee);
            //    employeeEditor = false;
            //    editorActive = false;
            //}
            else if (input == "return")
            {
                editorActive = false;
                correctInput = true;
            }
            else
                Console.WriteLine("incorrect input, select prompt from list");
        }
    }
}
