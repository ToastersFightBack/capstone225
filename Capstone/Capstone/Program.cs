using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


namespace Capstone
{
    class Item : IEquatable<Item>
    {
        public string _msg;
        public int Id;
        public string Name;
        public int number;
        public string Color;



        public Item(string name, int ID = 0, string MSG = "Chad", int Number =5, string color = "Yes")
        {
            this._msg = MSG;
            this.Id = ID;
            this.Name = name;
            this.number = Number;
            this.Color = color;

        }
        public bool Equals(Item other)
        {
            if (other == null) return false;
            return (this._msg.Equals(other._msg));
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            String jsonSTRING = File.ReadAllText("data.json");
            List<Item> myList = JsonConvert.DeserializeObject<List<Item>>(jsonSTRING);

            if (myList == null)
                myList = new List<Item>();

            string input = "";
            int inputID = 0;
            string inputString = "";
            string inputColor = "";
            int inputNumber = 0;
            string inputName = "";

            while (input != "q")
            {
                Console.WriteLine("Press a to add new MSG");
                Console.WriteLine("Press d to delete an MSG");
                Console.WriteLine("Press s to show all MSGS");
                Console.WriteLine("Press u to update a MSG");
                Console.WriteLine("Press q to quit");
                input = Console.ReadLine();
                switch (input)
                {
                    case "a":
                        Console.WriteLine("Add a new MSG");
                        Console.WriteLine("Enter Name:");
                        inputString = Console.ReadLine();
                        Console.WriteLine("Enter the ID");
                        try
                        {
                            inputID = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Enter A number");
                            inputID = Convert.ToInt32(Console.ReadLine());
                        }
                        
                        Console.WriteLine("Enter your MSG");
                        inputName = Console.ReadLine();
                        Console.WriteLine("Input Your favorite number");
                        try
                        {
                            inputNumber = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Enter a number");
                            inputID = Convert.ToInt32(Console.ReadLine());
                        }
                        
                        Console.WriteLine("Enter your favorite color");
                        inputColor = Console.ReadLine();
                        myList.Add(new Item(inputString, inputID, inputName, inputNumber, inputColor));
                        Console.WriteLine("Added Name: " + inputString + "ID: " + inputID + "MSG " + inputName + "Number " + inputNumber + "Color " + inputColor);
                        
                        break;
                    case "d":
                        Console.WriteLine("Delete MSG");
                        Console.WriteLine("Enter the name to delete");
                        inputString = Console.ReadLine();
                        myList.Clear();
                        break;
                    case "u":
                        Console.WriteLine("Update MSG");
                        Console.WriteLine("Enter name to Update");
                        inputString = Console.ReadLine();
                        myList.Remove(new Item(inputString));

                        Console.WriteLine("Add a new MSG");
                        Console.WriteLine("Enter Name:");
                        inputString = Console.ReadLine();
                        Console.WriteLine("Enter the ID");
                        inputID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter your MSG");
                        inputName = Console.ReadLine();
                        Console.WriteLine("Input Your favorite number");
                        inputNumber = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter your favorite color");
                        inputColor = Console.ReadLine();
                        myList.Add(new Item(inputString, inputID, inputName, inputNumber, inputColor));
                        Console.WriteLine("Updated Name: " + inputString + " ID: " + inputID + " MSG " + inputName + " Number " + inputNumber + " Color " + inputColor);
                        
                        break;
                    case "q":
                        Console.WriteLine("Exiting");
                        break;
                    case "s":
                        Console.WriteLine("Showing MSGS");
                        foreach (Item item in myList)
                        {
                            Console.WriteLine("Name: " + item._msg + " ID: " + item.Id + " MSG: " + item.Name + " Color " + item.Color + " Favorite Number " + item.number);
                        }
                        break;
                    default:
                        Console.WriteLine("Please Enter the Correct Input");
                        break;
                }
            }
            
            string data = JsonConvert.SerializeObject(myList);
            File.WriteAllText("data.json", data);

        }
    }
}
