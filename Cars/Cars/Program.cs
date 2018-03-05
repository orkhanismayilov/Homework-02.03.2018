using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            Car Audi = new Car("Audi", 70, 11.2);

            string select = "";

            do
            {
                Console.WriteLine("1. Drive");
                Console.WriteLine("2. Add Fuel");
                Console.WriteLine("3. Show Global KM");
                Console.WriteLine("4. Show Local KM");
                Console.WriteLine("5. Show Car Info");
                Console.WriteLine("0. Exit");
                select = Console.ReadLine();
                switch (Convert.ToInt32(select))
                {
                    case 1:
                        Console.WriteLine("\n");
                        Console.WriteLine("Please, enter the trip length:");
                        Audi.TripLength = Convert.ToDouble(Console.ReadLine());
                        if (Audi.Drive())
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("Total Drive: " + Audi.TripLength + " km");
                            Console.WriteLine("Fuel Left: " + Audi.fuelActual + " lt");
                            Console.WriteLine("\n");
                        }
                        else
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("Wrong input! You can drive up to " + Audi.MaxDrive);
                            Console.WriteLine("\n");
                        }
                        break;

                    case 2:
                        Console.WriteLine("\n");
                        Console.WriteLine("Please, enter the fuel amount:");
                        Audi.FuelAmount = Convert.ToDouble(Console.ReadLine());
                        break;

                    case 3:
                        Console.WriteLine("\n");
                        Console.WriteLine("Global KM: ");
                        break;

                    case 4:
                        Console.WriteLine("\n");
                        Console.WriteLine("Local KM: ");
                        Console.WriteLine("To clear the local km please type Y");
                        Audi.ClearLocal = Console.ReadLine();
                        break;

                    case 5:
                        Console.WriteLine();
                        break;
                }


            } while (Convert.ToInt32(select) != 0);
        }
    }

    class Car
    {
        public string Brand { get; set; }
        public double FuelCapacity { get; set; }
        public double FuelConsumption { get; set; }
        private double FuelActual { get; set; }
        public double MaxDrive { get; set; }
        public double TripLength { get; set; }
        public double FuelAmount { get; set; }
        public string ClearLocal { get; set; }
        private double GlobalKM { get; set; }
        private double LocalKM { get; set; }

        public double global
        {
            get
            {
                return this.GlobalKM;
            }
        }

        public double local
        {
            get
            {
                return this.LocalKM;
            }
        }

        public double fuelActual
        {
            get
            {
                return this.FuelActual;
            }
        }

        public Car(string Brand, double FuelCap, double FuelCon)
        {
            this.Brand = Brand;
            FuelCapacity = FuelCap;
            FuelConsumption = FuelCon;
        }

        public bool Drive()
        {
            MaxDrive = FuelCapacity / FuelConsumption * 100;
            if (TripLength > 0 && TripLength <= MaxDrive)
            {
                FuelActual = FuelCapacity - (TripLength / 100 * FuelConsumption);
                LocalKM += TripLength;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
