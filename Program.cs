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

Random random = new Random();

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
                        d. Delist a plant
                        e. Search for Plants by Light Needs
                        f. Plant of the day");
    choice = Console.ReadLine();
    Console.WriteLine("(Press any key to continue.)");
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
        AdoptPlant();
    }
    else if (choice == "d")
    {
        DelistPlant();
    }
    else if (choice == "e")
    {
        SearchPlantsByLightNeeds();
    }
    else if (choice == "f")
    {
        PlantOfTheDay();
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
         (plants[i].Sold ? $" was sold for ${plants[i].AskingPrice}" : " is available"));
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
        Sold = false
    };

    plants.Add(newPlant);

    Console.WriteLine($"Successfully added {species} to the list!");
}

void AdoptPlant()
{
    List<Plant> availablePlants = new List<Plant>();

    foreach (Plant plant in plants)
    {
        if (!plant.Sold)
        {
            availablePlants.Add(plant);
        }
    }

    if (availablePlants.Count == 0)
    {
        Console.WriteLine("No plants are available for adoption at the moment");
        return;
    }

    Console.WriteLine("Available plants for adoption: ");
    for (int i = 0; i < availablePlants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {availablePlants[i].Species} in {availablePlants[i].City}" + 
        $" - ${availablePlants[i].AskingPrice}");
    }

    Plant chosenPlant = null;

    while (chosenPlant == null)
    {
        Console.WriteLine("Please enter the plant # you would like to adopt or press 0 to return to the menu: ");
        try
        {
            int response =int.Parse(Console.ReadLine().Trim());
        
            if (response > 0 && response <= availablePlants.Count)
            {
                chosenPlant = availablePlants[response - 1];
                chosenPlant.Sold = true;
                Console.WriteLine($"Congratulations! You have adopted: {chosenPlant.Species} from {chosenPlant.City}");
            }
            else if (response == 0)
            {
                return;
            }
            else
            {
                Console.WriteLine("Please choose and existing item only!");
            }
        }

        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!.");
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

}

void DelistPlant()
{
    ListPlants();

    if (plants.Count == 0)
    {
        Console.WriteLine("No plants available to delist.");
        return;
    }


    while (true)
    {
        Console.WriteLine("Enter the number of the plant you want to delist: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());

            if(response > 0 && response <= plants.Count)
            {
                var removedPlant = plants[response - 1];
                plants.RemoveAt(response - 1);
                Console.WriteLine($"{removedPlant.Species} has been successfully delisted.");
                break;
            }
            else
            {
                Console.WriteLine("Please choose a valid plant number.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}

void PlantOfTheDay()
{
    if (plants.Count == 0)
    {
        Console.WriteLine("No plants available.");
        return;
    }

    Plant randomPlant = null;

    while (randomPlant == null)
    {
        int randomIndex = random.Next(0, plants.Count);
        if (!plants[randomIndex].Sold)
        {
            randomPlant = plants[randomIndex];
        }
    }

    Console.WriteLine("🌱 Featured Plant 🌱");
    Console.WriteLine($"Species: {randomPlant.Species}");
    Console.WriteLine($"Location: {randomPlant.City}");
    Console.WriteLine($"Light Needs: {randomPlant.LightNeeds}");
    Console.WriteLine($"Price: ${randomPlant.AskingPrice}");
}

void SearchPlantsByLightNeeds()
{
    int maxLightNeeds = 0;
    bool validInput = false;

    while (!validInput)
    {
        try
        {
            Console.WriteLine("Enter the maximum light needs (1 to 5): ");
            maxLightNeeds = int.Parse(Console.ReadLine().Trim());

            if (maxLightNeeds >= 1 && maxLightNeeds <= 5)
            {
                validInput = true; // Valid input
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid number between 1 and 5.");
        }
    }

    List<Plant> matchingPlants = new List<Plant>();

    foreach (Plant plant in plants)
    {
        if (plant.LightNeeds <= maxLightNeeds && !plant.Sold)
        {
            matchingPlants.Add(plant);
        }
    }

    if (matchingPlants.Count > 0)
    {
        Console.WriteLine("Plants matching your light needs:");
        foreach (Plant plant in matchingPlants) // Change this line to iterate over matchingPlants
        {
            Console.WriteLine($"{plant.Species} - Light Needs: {plant.LightNeeds} - Price: ${plant.AskingPrice}");
        }
    }
    else
    {
        Console.WriteLine("No plants found that match your light needs.");
    }
}