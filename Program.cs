// See https://aka.ms/new-console-template for more information
List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Red Oak",
        LightNeeds =  2,
        AskingPrice = 11.50M,
        City = "Nashville",
        ZIP = 37135,
        Sold = false
    },
    new Plant()
    {
        Species = "White Oak",
        LightNeeds =  4,
        AskingPrice = 16.50M,
        City = "Chattanooga",
        ZIP = 35209,
        Sold = false
    },
    new Plant()
    {
        Species = "Maple",
        LightNeeds =  1,
        AskingPrice = 18.29M,
        City = "Birmingham",
        ZIP = 35208,
        Sold = false
    },
    new Plant()
    {
        Species = "Spruce",
        LightNeeds =  3,
        AskingPrice = 10.55M,
        City = "Knoxville",
        ZIP = 37154,
        Sold = false
    },
    new Plant()
    {
        Species = "Willow",
        LightNeeds =  5,
        AskingPrice = 9.54M,
        City = "Decatur",
        ZIP = 32054,
        Sold = false
    }
};



 
string greeting = @"Hello there, Welcome to ExtraVert!";

Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        a. Display all plants
                        b. Post a plant to be adopted
                        c. Adopt a plant
                        d. Delist a plant");
    choice = Console.ReadLine();
    Console.ReadKey();
    Console.Clear();

    if (choice == "0")
    {
        Console.WriteLine("The Program is Ending Now.");
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "a")
    {
        ListPlants();
    }
    else if (choice == "b")
    {
        throw new NotImplementedException("Display all plants");
    }
    else if (choice == "c")
    {
        throw new NotImplementedException("Display all plants");
    }
    else if (choice == "d")
    {
        throw new NotImplementedException("Display all plants");
    }
    else
    {
        Console.WriteLine("Invalid input. Please select a valid option.");
    }
}

void ListPlants()
 {
    decimal totalValue = 0.0M;
    foreach (Plant plant in plants)
    {
        if (!plant.Sold)
        {
            totalValue += plant.AskingPrice;
        }
    }
    Console.WriteLine($"Total inventory value: ${totalValue}");
    Console.WriteLine("Plants:");
    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species}");
    }
 }


