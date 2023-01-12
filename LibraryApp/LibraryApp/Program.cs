





using LibraryApp.Controllers;
using ServiceLayer.Helpers;
using ServiceLayer.Helpers.Enums;

LibraryController libraryController = new();

while (true)
{

    GetOptions();

    Option: string option = Console.ReadLine();

    int selectedOption;

    bool isCorrectOption = int.TryParse(option, out selectedOption);

    if (isCorrectOption)
    {
        switch (selectedOption)
        {
            case (int)Options.CreateLibrary:
                libraryController.Create();
                break;
            case (int)Options.GetAllLibrary:
                libraryController.GetAll();
                break;
            case (int)Options.DeleteLibrary:
                libraryController.Delete();
                break;
            case (int)Options.SearchByLibrary:
                libraryController.Search();
                break;
            default:
                ConsoleColor.Red.WriteConsole("Please add correct option");
                goto Option;
        }
    }
    else
    {
        ConsoleColor.Red.WriteConsole("Please add correct format option");
        goto Option;
    }
    
}


static void GetOptions()
{
    ConsoleColor.Cyan.WriteConsole("Please select one option: ");
    ConsoleColor.Cyan.WriteConsole("Library options: 1 - Create, 2 - Get all, 3 - Delete, 4 - Search");
}
