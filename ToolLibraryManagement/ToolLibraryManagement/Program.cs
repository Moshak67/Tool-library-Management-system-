using System;
using System.Collections.Generic;

namespace ToolLibraryManagement
{


    

    class Program
    {
        
        static List<Tool> ToolList = new List<Tool>();
        static List<Category> CategoryList = new List<Category>();
        static List<RentInformation> rentList = new List<RentInformation>();
        static RentInformation rent = new RentInformation();
        
        public static void Main(string[] args)
        {
            ToolList.Add(new Tool(1, "Gardening Tools", "Very good indeed", 2));
            ToolList.Add(new Tool(2, "Flooring Tools", "Very good indeed", 9));
            ToolList.Add(new Tool(3, "Fencing Tools", "Good tool", 5));
            ToolList.Add(new Tool(4, "Gardening Tools", "Very good indeed", 2));
            ToolList.Add(new Tool(5, "Flooring Tools", "Very good indeed", 9));
            ToolList.Add(new Tool(6, "Fencing Tools", "Good tool", 5));

            CategoryList.Add(new Category("Gardening Tools"));
            CategoryList.Add(new Category("Flooring Tools"));
            CategoryList.Add(new Category("Fencing Tools"));
            CategoryList.Add(new Category("Electrical Tools"));
            CategoryList.Add(new Category("Electricity Tools"));
            CategoryList.Add(new Category("Cleaning Tools"));
            CategoryList.Add(new Category("Automative Tools"));
            CategoryList.Add(new Category("Measuring Tools"));
            CategoryList.Add(new Category("Painting Tools"));

            bool run = true;

            while (run)
            {
                
                Console.WriteLine("\nWelcome To Brisbane Tool Library\n" +
                "****************************************************\n" +
                "\n1)Display All the Categories in the Library\n" +
                "2)Display All the tools in the Library\n" +
                "3)Add Tools to the Library\n" +
                "4)Rent Tools to a member\n" +
                "5)Return Tools\n" +
                "6)Exit\n\n");
                Console.Write("What Would you like to do? Choose from the menu:");

                int option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    DisplayCategory();
                }
                else if (option == 2)
                {
                    DisplayTools();
                }
                else if (option == 3)
                {
                    AddTool();
                }
                else if (option == 4)
                {
                    RentTool();
                }
                else if (option == 5)
                {
                    ReturnTool();
                }

                else if (option == 6)
                {
                    Console.WriteLine("Thank you");
                    run = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option\nRetry !!!");
                }
            }
            Console.ReadLine();
        }

        
        public static void DisplayCategory()
        {
            Tool tool = new Tool();
            foreach (var category in CategoryList)
            {
                Console.WriteLine("{0}", category.categoryName);

            }
            Console.WriteLine("what category?");
            string input = Console.ReadLine();
            if (input == tool.toolName)
            {
                foreach (var item in ToolList)
                {
                    DisplayTools();
                }
            }
        }


        public static void DisplayTools()
        {
            foreach (var item in ToolList)
            {
                Console.WriteLine("{0},{1},{2}, Quantity:{3}", item.toolId, item.toolName,item.toolDescription, item.toolQuantity);
            }

        }

        public static void AddTool()
        {
            Tool tool = new Tool();
            Console.WriteLine("Tool Id:{0}", tool.toolId = ToolList.Count + 1);
            Console.Write("Tool Name:");
            tool.toolName = Console.ReadLine();
            Console.Write("Description:");
            tool.toolDescription = Console.ReadLine();
            Console.Write("Quantity:");
            tool.toolQuantity = int.Parse(Console.ReadLine());
            ToolList.Add(tool);
        }

        public static void SearchInventory()
        {
            Tool tool = new Tool();
            Console.Write("Search by Tool id :");
            int search = int.Parse(Console.ReadLine());

            if (ToolList.Exists(toolCount => toolCount.toolId == search))
            {
                foreach (Tool searchId in ToolList)
                {
                    if (searchId.toolId == search)
                    {
                        Console.WriteLine("Tool id :{0}\n" +
                        "Tool name :{1}\n" +
                        "Description :{2}\n" +
                        "Quantity :{3}", searchId.toolId, searchId.toolName, searchId.toolDescription, searchId.toolQuantity);
                    }
                }
            }
            else
            {
                Console.WriteLine("Tool id {0} not found", search);
            }
        }

        public static void RentTool()
        {
            Tool tool = new Tool();
            RentInformation rent = new RentInformation();
            Console.WriteLine("User id : {0}", (rent.personId = rentList.Count + 1));
            Console.Write("Please enter renter's Full Name:");
            rent.personName = Console.ReadLine();
            Console.Write("Renter's Phone number :");
            rent.personPhone = int.Parse(Console.ReadLine());
            Console.Write("Please enter the Id of the tool you want to rent out:");
            rent.rentByToolId = int.Parse(Console.ReadLine());
            Console.Write("How many Tools are you renting : ");
            rent.rentQuantity = int.Parse(Console.ReadLine());

            if (ToolList.Exists(toolCount => toolCount.toolId == rent.rentByToolId))
            {
                foreach (Tool searchId in ToolList)
                {
                    if (searchId.toolQuantity >= searchId.toolQuantity - rent.rentQuantity && searchId.toolQuantity - rent.rentQuantity >= 0)
                    {
                        if (searchId.toolId == rent.rentByToolId)
                        {
                            searchId.toolQuantity = searchId.toolQuantity - rent.rentQuantity;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("We only Have {0} of this tool", searchId.toolQuantity);
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Tool id {0} not found", rent.rentByToolId);
            }
            rentList.Add(rent);
        }

        public static void ReturnTool()
        {
            Tool tool = new Tool();
            Console.WriteLine("You can return a tool by Id:");

            Console.Write("Tool id : ");
            int returnId = int.Parse(Console.ReadLine());

            Console.Write("Quantity:");
            int returnCount = int.Parse(Console.ReadLine());

            if (ToolList.Exists(i => i.toolId == returnId))
            {
                foreach (Tool returnQuantity in ToolList)
                {
                    if (returnQuantity.toolQuantity >= returnCount + returnQuantity.toolQuantity)
                    {
                        if (returnQuantity.toolId == returnId)
                        {
                            returnQuantity.toolQuantity = returnQuantity.toolQuantity + returnCount;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Quantity Exceeds the actual inventory record");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Tool id {0} not found", returnId);
            }
        }

    }
}

