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
        Sold = true
    }
};

Plant chosenPlant = null;

while (chosenPlant == null)
{
    Console.WriteLine("Please enter a product number: ");
    try
    {
    int response = int.Parse(Console.ReadLine().Trim());
    chosenProduct = products[response - 1];
    }
    catch (FormatException)
    {
    Console.WriteLine("Please type only integers!");
    }
    catch (ArgumentOutOfRangeException)
    {
    Console.WriteLine("Please choose an existing item only!");
    }
    catch (Exception ex)
    {
    Console.WriteLine(ex);
    Console.WriteLine("Do Better!");
    }
}


 
string greeting = @"Hello there, Welcome to ExtraVert!";

 Console.WriteLine(greeting);
string choice = null;
 while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. View All Plants
                        2. View Plant Details");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ListPlants();
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
 }


