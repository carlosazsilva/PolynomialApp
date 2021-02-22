using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace PolynomialApp
{
    public class CLI
    {
        #region Private Fields

        private readonly string inputErrorMessage = "- Command not recognized. Type help for available commands.";

        private readonly string path = "../../../Data/";
        private readonly string filename = "polynomials.json";

        #endregion

        #region Private Properties

        private List<Polynomial> Polynomials;

        private int NumPolynomials => Polynomials.Count;

        #endregion

        #region Constructors

        public CLI()
        {
            Polynomials = new List<Polynomial>();
        }

        #endregion

        #region Private Methods

        public void Start()
        {
            Console.Clear();
            Header();
            CommandHandler();
        }

        private static void Header()
        {
            Console.WriteLine("POLYNOMIAL APP");
            Console.WriteLine("--------------");
        }

        private void CommandHandler()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Write($"{Environment.UserName}@{Environment.MachineName}: ");

                string[] command = Console.ReadLine().Split(' ');

                switch (command[0])
                {
                    case "help":
                        Help();
                        break;
                    case "add":
                        Add(command);
                        break;
                    case "remove":
                        Remove(command);
                        break;
                    case "list":
                        List();
                        break;
                    case "save":
                        Save(command);
                        break;
                    case "read":
                        Read(command);
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    case "compute":
                        Compute(command);
                        break;
                    case "exit":
                        exit = true;
                        break;
                    default:
                        if (command[1].Length == 1)
                        {
                            Operator(command);
                        }
                        else
                        {
                            Console.WriteLine(inputErrorMessage);
                        }
                        break;
                }
            }
        }

        private void Add(string[] command)
        {
            if (command.Length == 2)
            {
                try
                {
                    Polynomials.Add(new Polynomial(command[1], Naming()));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (command.Length == 4)
            {
                if (command[1] == "-name")
                {
                    try
                    {
                        Polynomials.Add(new Polynomial(command[3], Naming(command[2])));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine(inputErrorMessage);
                }
            }
            else
            {
                Console.WriteLine(inputErrorMessage);
            }
        }

        private string Naming(string input = null)
        {
            string name;

            if (input != null)
            {
                name = input;

                if (int.TryParse(name[0].ToString(), out int number))
                {
                    throw new Exception("The name must start with a letter.");
                }

                foreach (Polynomial polynomial in Polynomials)
                {
                    if (polynomial.Name == name)
                    {
                        throw new Exception("- A polynomial expression with that name already exists.");
                    }
                }
            }
            else
            {
                if (NumPolynomials == 0)
                {
                    name = "p1";
                }
                else
                {
                    int number = NumPolynomials + 1;

                    foreach (Polynomial polynomial in Polynomials)
                    {
                        if (polynomial.Name == "p" + number)
                        {
                            number++;
                        }
                    }

                    name = "p" + number;
                }
            }

            return name;
        }

        private void Remove(string[] command)
        {
            if (command.Length == 3)
            {
                if (NumPolynomials > 0)
                {
                    if (command[1] == "-name")
                    {
                        bool exists = false;

                        foreach (Polynomial polynomial in Polynomials)
                        {
                            if (polynomial.Name == command[2])
                            {
                                exists = true;
                                Polynomials.Remove(polynomial);
                                break;
                            }
                        }

                        if (!exists)
                        {
                            Console.WriteLine("- No polynomial expression found with that name.");
                        }
                    }
                    else
                    {
                        Console.WriteLine(inputErrorMessage);
                    }
                }
                else
                {
                    Console.WriteLine("- No polynomial expressions to delete.");
                }
            }
            else
            {
                Console.WriteLine(inputErrorMessage);
            }
        }

        private void List()
        {
            if (NumPolynomials > 0)
            {
                foreach (Polynomial polynomial in Polynomials)
                {
                    Console.WriteLine($"{polynomial.Name}: {polynomial}");
                };
            }
            else
            {
                Console.WriteLine("- No polynomials expressions to display.");
            }
        }

        private void Save(string[] command)
        {
            if (NumPolynomials > 0)
            {
                string json = JsonSerializer.Serialize(Polynomials);

                if (command.Length == 1)
                {
                    File.WriteAllText(path + filename, json);
                }
                else
                {
                    if (command[1] == "-d")
                    {
                        try
                        {
                            Console.Write("- Name of the file: ");
                            string name = Console.ReadLine();
                            File.WriteAllText(command[2] + name + ".json", json);
                            // if a directory isn't provided bin/Debug/net5.0/ is the default path
                        }
                        catch
                        {
                            Console.Write("- Error saving the file.");
                        }
                    }
                    else
                    {
                        Console.WriteLine(inputErrorMessage);
                    }
                }
            }
            else
            {
                Console.WriteLine("- Can't save an empty list of polynomials expressions.");
            }
        }

        private void Read(string[] command)
        {
            string input = null;

            if (NumPolynomials > 0)
            {
                Console.Write("- Changes will be lost. Continue? (Y/n) ");
                input = Console.ReadLine();
            }

            if (input == null || input.ToUpper() == "Y")
            {
                string json;

                if (command.Length == 1)
                {
                    json = path + filename;
                }
                else if (command[1] == "-d" && command.Length == 3)
                {
                    json = command[2];
                }
                else
                {
                    json = null;
                    Console.WriteLine(inputErrorMessage);
                }

                if (json != null)
                {
                    try
                    {
                        Polynomials = JsonSerializer.Deserialize<List<Polynomial>>(File.ReadAllText(json));
                    }
                    catch
                    {
                        Console.WriteLine("- Error parsing the file.");
                    }
                }
            }
            else
            {
                Console.WriteLine("- Operation cancelled.");
            }
        }

        private void Compute(string[] command)
        {
            if (NumPolynomials > 0 && command.Length == 4)
            {
                if (command[1] == "-name")
                {
                    bool exists = false;

                    foreach (Polynomial polynomial in Polynomials)
                    {
                        if (polynomial.Name == command[2])
                        {
                            exists = true;
                            bool isDouble = double.TryParse(command[3], out double value);

                            if (isDouble)
                            {
                                Console.WriteLine(polynomial.Value(value));
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input value for computing.");
                            }
                        }
                    }

                    if (!exists)
                    {
                        Console.WriteLine("- No polynomial expression found with that name.");
                    }
                }
                else
                {
                    Console.WriteLine(inputErrorMessage);
                }
            }
            else
            {
                Console.WriteLine("- The polynomial list is empty.");
            }
        }

        private void Operator(string[] command)
        {
            string result;

            if (NumPolynomials > 0)
            {
                switch (command[1])
                {
                    case "+":
                        result = Sum(command);
                        break;
                    case "-":
                        result = Subtract(command);
                        break;
                    case "*":
                        result = Multiply(command);
                        break;
                    default:
                        result = inputErrorMessage;
                        break;
                }
            }
            else
            {
                result = "Cannot perform operations without polynomial expressions.";
            }

            Console.WriteLine(result);
        }

        private string Sum(string[] command)
        {
            Polynomial[] polynomials = FindPolynomialsByName(command[0], command[2], out bool exists, out string message);

            return exists ? $"({polynomials[0]}) + ({polynomials[1]}) = {polynomials[0] + polynomials[1]}" : message;
        }

        private string Subtract(string[] command)
        {
            Polynomial[] polynomials = FindPolynomialsByName(command[0], command[2], out bool exists, out string message);

            return exists ? $"({polynomials[0]}) - ({polynomials[1]}) = {polynomials[0] - polynomials[1]}" : message;
        }

        private string Multiply(string[] command)
        {
            if (int.TryParse(command[2], out int value))
            {
                Polynomial p1 = new Polynomial();

                bool exists = false;

                foreach (Polynomial polynomial in Polynomials)
                {
                    if (command[0] == polynomial.Name)
                    {
                        exists = true;
                        p1 = polynomial;
                    }
                }

                return exists ? $"({p1}) * {value} = {p1 * value}" : "Could not find the polynomial expression.";
            }
            else
            {
                Polynomial[] polynomials = FindPolynomialsByName(command[0], command[2], out bool exist, out string message);

                return exist ? $"({polynomials[0]}) * ({polynomials[1]}) = {polynomials[0] * polynomials[1]}" : message;
            }
        }

        private Polynomial[] FindPolynomialsByName(string p1name, string p2name, out bool exist, out string message)
        {
            Polynomial p1 = new Polynomial(), p2 = new Polynomial();

            bool p1exists = false, p2exists = false;

            foreach (Polynomial polynomial in Polynomials)
            {
                if (p1name == polynomial.Name)
                {
                    p1exists = true;
                    p1 = polynomial;
                }
            }

            foreach (Polynomial polynomial in Polynomials)
            {
                if (p2name == polynomial.Name)
                {
                    p2exists = true;
                    p2 = polynomial;
                }
            }

            if (p1exists && p2exists)
            {
                exist = true;
                message = string.Empty;
            }
            else
            {
                exist = false;
                message = "Could not find one or more polynomial expressions on the list.";
            }

            return new Polynomial[] { p1, p2 };
        }

        private void Help()
        {
            Console.WriteLine("add -name {name} expression      -  add a polynomial expression, -name ... is optional");
            Console.WriteLine("remove -name {name}              -  remove a polynomial expression");
            Console.WriteLine("list                             -  list all polynomial expressions");
            Console.WriteLine("save -d {path}                   -  save file, -d ... is opcional");
            Console.WriteLine("read -d {path}                   -  read from file, -d ... is opcional");
            Console.WriteLine("clear                            -  clear the console");
            Console.WriteLine("compute -name {name} -value {x}  -  resolves the polynomial expression");
            Console.WriteLine("exit                             -  exit the app");
        }

        #endregion
    }
}
