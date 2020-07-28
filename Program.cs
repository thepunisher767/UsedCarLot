using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UsedCarLot
{
    class Car
    {
        public Car()
        {
            Make = "default";
            Model = "default";
            Year = 0;
            Price = 0;
        }
        public Car(string theMake, string theModel, int theYear, double thePrice)
        {
            Make = theMake;
            Model = theModel;
            Year = theYear;
            Price = thePrice;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return String.Format("{0,-14} {1,-10} {2,-5} {3,-8}", $"{Make}", $"{Model}", $"{Year}", $"{Price}");
        }
    }
    
    class UsedCar : Car
    {
        //private double _mileage;
        public double Mileage { get; set; }
        public UsedCar(string theMake, string theModel, int theYear, double thePrice, double themileage) : base (theMake, theModel, theYear, thePrice)
        {
            Mileage = themileage;
        }
        public override string ToString()
        {
            return base.ToString() + $"(USED) {Mileage}";
        }
    }

    class CarLot
    {
        public static List<Car> CarsInLot = new List<Car>();

        public static void ListCars()
        {
            for (int i = 0; i < CarsInLot.Count; i++)
            {
                Console.WriteLine($"{i+1}. {CarsInLot[i]}");
            }
        }
        public static void AddCar(Car car)
        {
            CarsInLot.Add(car);
        }
        public static void RemoveCar(int carNumber)
        {
            CarsInLot.RemoveAt(carNumber);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CarLot.CarsInLot.Add(new UsedCar("Fordsuc", "Focus", 2014, 28000, 8764));
            CarLot.CarsInLot.Add(new UsedCar("Ford", "Taurus", 2015, 28000, 64546));
            CarLot.CarsInLot.Add(new UsedCar("Ford", "Fiesta", 2016, 28000, 9875656));
            CarLot.CarsInLot.Add(new Car("Ford", "Bronco", 2017, 28000));
            CarLot.CarsInLot.Add(new Car("Ford", "Fusion", 2018, 28000));
            CarLot.CarsInLot.Add(new Car("Ford", "F150", 2019, 28000));
            bool continueFlag = true;
            Console.WriteLine("Welcome to the Car Lot!\n");
            //Console.WriteLine(CarLot.CarsInLot.Count);

            while (continueFlag)
            {             
                CarLot.ListCars();
                Console.WriteLine($"{CarLot.CarsInLot.Count + 1}. Add a car");
                Console.WriteLine($"{CarLot.CarsInLot.Count + 2}. Quit");
                Console.WriteLine();
                Console.Write("Which car would you like?: ");
                int userInput = IntValidation(Console.ReadLine());
                if (userInput == CarLot.CarsInLot.Count + 2)
                {
                    Console.WriteLine("OK BYEEEE!!!!!");
                    continueFlag = false;
                    break;
                }
                if (userInput == CarLot.CarsInLot.Count + 1)
                {
                    Console.Write("\nPlease enter a Make: ");
                    string make = Console.ReadLine();
                    Console.Write("Please enter a Model: ");
                    string model = Console.ReadLine();
                    Console.Write("Please enter a Year: ");
                    string year = Console.ReadLine();
                    int validYear;
                    while (!int.TryParse(year, out validYear))
                    {
                        Console.Write($"Please a valid year: ");
                        year = Console.ReadLine();
                    }
                    Console.Write("Please enter a valid price: ");
                    string price = Console.ReadLine();
                    Console.WriteLine();
                    double validPrice;
                    while (!double.TryParse(price, out validPrice))
                    {
                        Console.Write($"Please a valid price: ");
                        price = Console.ReadLine();
                    }
                    CarLot.CarsInLot.Add(new Car(make, model, validYear, validPrice));
                }
                else
                {
                    Console.WriteLine($"\n{CarLot.CarsInLot[userInput - 1]}");
                    Console.Write("Would you like to purchase this car? (y/n): ");
                    string userPurchase = YesOrNo(Console.ReadLine());  //We gonna purchase?
                    if (userPurchase == "y")
                    {
                        Console.WriteLine("\nExcellent! Our Financial department will be in touch shortly!\n ");
                        CarLot.RemoveCar(userInput - 1);
                    }
                    else
                    {
                        Console.WriteLine("Well... fine....\n");
                    }
                }
            }
        }

        public static string YesOrNo(string answer) //method to check (y/n)
        {
            answer = answer.ToLower();
            while (answer != "y" && answer != "n")
            {
                Console.Write("Please enter valid input (y/n): ");
                answer = Console.ReadLine();
                answer = answer.ToLower();
                Console.WriteLine();
            }
            return answer;
        }

        public static int IntValidation(string input)   //Check for valid input
        {
            int validIntOutput;
            while (!int.TryParse(input, out validIntOutput) && validIntOutput < CarLot.CarsInLot.Count + 2)
            {
                Console.Write($"Please a valid menu item: ");
                input = Console.ReadLine();
            }
            return validIntOutput;
        }
    }
}
