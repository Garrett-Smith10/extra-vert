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
        Sold = true
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
        PostPlant();
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
        Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City}" +
         $"{(plants[i].Sold ? " is available" : $" was sold for ${plants[i].AskingPrice}")}");
    }
 }

void PostPlant()
{
    Console.WriteLine("Post a new plant for adoption:");

    Console.WriteLine("Enter Species: ");
    string species = Console.ReadLine();

    int lightNeeds;
    while (true)
    {
        try
        {
            Console.WriteLine("Enter light needs (1-5, 1 = Low, 5 = High: ");
            lightNeeds = int.Parse(Console.ReadLine().Trim());

            if (lightNeeds < 1 || lightNeeds > 5)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5");
            }
            else
            {
                break; //Valid input, exit loop
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Invalid input. The number is too large or too small.");
        }
    }
    Console.WriteLine("Enter asking price: ");
    decimal askingPrice;
    while (true)
    {
        try
        {
            Console.Write("Enter asking price (must be a positive value): ");
            askingPrice = decimal.Parse(Console.ReadLine().Trim());

            if (askingPrice <= 0)
            {
                Console.WriteLine("Invalid input. The price must be a positive value.");
            }
            else 
            {
                break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid decimal number.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Invalid input. The number is too large or too small.");
        }
    }
    string city;

    while (true)
    {
        Console.WriteLine("Enter city: ");
        city = Console.ReadLine().Trim();

        bool isValidCity = true;

        foreach (char c in city) 
        {
            if (!char.IsLetter(c))
            {
                isValidCity = false;
                break;
            }
        }
        
        if (isValidCity && !string.IsNullOrWhiteSpace(city))
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalid input. Only letter are allowed, and the city name cannot be empty.");
        }

    }
    
    int zipCode;

    while (true)
    {
        try
        {
            Console.WriteLine("Enter ZIP code: ");
            string zipCodeInput = (Console.ReadLine().Trim());

            if (string.IsNullOrEmpty(zipCodeInput) || zipCodeInput.Length != 5)
            {
                Console.WriteLine("Please enter a valid ZIP code (5 digits long).");
            }
            else
            {
                zipCode = int.Parse(zipCodeInput);
                break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid ZIP code (only numbers).");
        }
    }

    Plant newPlant = new Plant()
    {
        Species = species,
        LightNeeds = lightNeeds,
        AskingPrice = askingPrice,
        City = city,
        ZIP = zipCode,
        Sold = true
    };

    plants.Add(newPlant);

    Console.WriteLine($"Successfully added {species} to the list!");
}



