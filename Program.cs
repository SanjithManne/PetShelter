// the ourAnimals array will store the following: 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices.Marshalling;

string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

// variables that support data entry
int maxPets = 8;
int petCount = 0;
string? readResult;
string menuSelection = "";
int i = 0;

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 6];

// TODO: Convert the if-elseif-else construct to a switch statement

// create some initial ourAnimals array entries
for (i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "Puss";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;

}

do
{
    // display the top-level menu options

    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();

    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    Console.WriteLine($"You selected menu option {menuSelection}.");
    Console.WriteLine("Press the Enter key to continue");
    Console.ReadLine();

    switch (menuSelection)
    {
        case "1":
            for (i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "2":
            string anotherPet = "y";
            for (i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount += 1;
                }
            }
            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {maxPets - petCount} more.");
            }

            while (maxPets > petCount)
            {
                bool validEntry = false;

                do
                {
                    Console.WriteLine("\nEnter 'dog' or 'cat' to begin a new entry");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();
                        if ((animalSpecies == "dog") || (animalSpecies == "cat"))
                        {
                            validEntry = true;
                        }
                    }
                } while (validEntry == false);

                animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                do
                {
                    Console.WriteLine("\nEnter the age, 0 if you dont know");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        string parse = "";
                        parse = readResult;
                        int age;
                        validEntry = int.TryParse(parse, out age);
                        animalAge = age.ToString();
                    }


                } while (validEntry == false);

                do
                {
                    Console.WriteLine("\nEnter a nickname");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalNickname = readResult;
                        validEntry = true;
                    }
                } while (validEntry == false);

                do
                {
                    Console.WriteLine("\nEnter a physical description");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalPhysicalDescription = readResult;
                        validEntry = true;
                    }

                } while (validEntry == false);

                do
                {
                    Console.WriteLine("\nEnter a personality description");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult;
                        validEntry = true;
                    }

                } while (validEntry == false);

                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

                petCount += 1;
                break;
            }

            if (petCount < maxPets)
            {
                Console.WriteLine("\nDo you want to add another? Y or N.");

                do
                {

                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        anotherPet = readResult.ToLower();
                    }

                } while ((anotherPet != "y") && (anotherPet != "n"));

            }


            if (petCount == maxPets)
            {
                Console.WriteLine("No more pets can be added");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
            }

            break;

        case "3":

            for (int j = 0; j < maxPets; j++)
            {
                if (ourAnimals[j, 0] != "ID #: ")
                    petCount += 1;
            }

            do
            {
                for (i = 0; i < petCount; i++)
                {
                    if (ourAnimals[i, 2] == "Age: ")
                    {

                        bool validEntry = false;

                        do
                        {
                            Console.WriteLine($"Enter an age for {ourAnimals[i, 0]}");
                            readResult = Console.ReadLine();
                            validEntry = int.TryParse(readResult, out int age);
                            animalAge = age.ToString();
                            ourAnimals[i, 2] = "Age: " + animalAge;

                        } while (validEntry == false);
                    }

                    if (ourAnimals[i, 4] == "Physical description: ")
                    {
                        bool validEntry = false;

                        do
                        {
                            Console.WriteLine($"Enter a physical description for {ourAnimals[i, 0]} (size, color, breed, gender, weight, housebroken)");
                            readResult = Console.ReadLine();
                            if (readResult != "" && readResult != null)
                            {
                                validEntry = true;
                                animalPhysicalDescription = readResult;
                                ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
                            }

                        } while (validEntry == false);
                    }
                }
            } while (i < (petCount - 1));

            Console.WriteLine("\nAge and Physical description fields are complete for all of our friends");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "4":

            for (int j = 0; j < maxPets; j++)
            {
                if (ourAnimals[j, 0] != "ID #: ")
                    petCount += 1;
            }

            do
            {
                for (i = 0; i < petCount; i++)
                {
                    if (ourAnimals[i, 3] == "Nickname: ")
                    {

                        bool validEntry = false;

                        do
                        {
                            Console.WriteLine($"Enter a nickname for {ourAnimals[i, 0]}");
                            readResult = Console.ReadLine();
                            if (readResult != null && readResult != "")
                            {
                                validEntry = true;
                                animalNickname = readResult;
                                ourAnimals[i, 3] = "Nickname: " + animalNickname;
                            }

                        } while (validEntry == false);

                    }

                    if (ourAnimals[i, 5] == "Personality: ")
                    {
                        bool validEntry = false;

                        do
                        {
                            Console.WriteLine($"Enter a personality description for {ourAnimals[i, 0]} (likes or dislikes, tricks, energy level)");
                            readResult = Console.ReadLine();
                            if (readResult != null && readResult != "")
                            {
                                validEntry = true;
                                animalPersonalityDescription = readResult;
                                ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
                            }

                        } while (validEntry == false);
                    }
                }
            } while (i < (petCount - 1));

            Console.WriteLine("\nNickname and personality description fields are complete for all of our friends. ");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "5":
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "6":
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "7":
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "8":
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

    }

} while (menuSelection != "exit");