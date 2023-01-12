using DomainLayer.Entities;
using ServiceLayer.Helpers;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Controllers
{
    public class LibraryController
    {

        private readonly ILibraryService _libraryService;

        public LibraryController()
        {
            _libraryService = new LibraryService();
        }

        public void Create()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add library name:");
            LibraryName: string libraryName = Console.ReadLine();

            if(libraryName == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please dont empty library name");
                goto LibraryName;
            }

            ConsoleColor.DarkCyan.WriteConsole("Please add library seat count:");
            SeatCount: string seatCountStr = Console.ReadLine();

            int seatCount;

            bool isCorrectSeatCount = int.TryParse(seatCountStr, out seatCount);

                if (isCorrectSeatCount)
                {
                    try
                    {
                        Library library = new Library
                        {
                            Name = libraryName,
                            SeatCount = seatCount
                        };

                        var response = _libraryService.Create(library);

                        ConsoleColor.Green.WriteConsole($"Id: {response.Id}, Name: {response.Name}, Seat count: {response.SeatCount}");
                    }
                    catch (Exception ex)
                    {
                        ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add library name again:");
                        goto LibraryName;

                    }

                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please add correct format seat count"); 
                    goto SeatCount;
                }
       



        }

        public void GetAll()
        {
            var result = _libraryService.GetAll();

            if(result.Count == 0)
            {
                ConsoleColor.Red.WriteConsole("Data not found");
            }
            else
            {
                foreach (var item in result)
                {
                    ConsoleColor.Green.WriteConsole($"Id: {item.Id}, Name: {item.Name}, Seat count: {item.SeatCount}");
                }
            }
        }

        public void Delete()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add library id for delete:");
            LibraryId: string libraryId = Console.ReadLine();

            int id;

            bool isCorrectId = int.TryParse(libraryId, out id);

            if (isCorrectId)
            {
                try
                {
                    _libraryService.Delete(id);
                    ConsoleColor.Green.WriteConsole("Successfully deleted");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add library id again");
                    goto LibraryId;
                }
                
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please add correct format library id");
                goto LibraryId;
            }
        }


        public void Search()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add search text:");
            SearchText: string searchText = Console.ReadLine();

            if (searchText == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please dont empty search text");
                goto SearchText;
            }

            try
            {
                var response = _libraryService.Search(searchText);

                foreach (var item in response)
                {
                    ConsoleColor.Green.WriteConsole($"Id: {item.Id}, Name: {item.Name}, Seat count: {item.SeatCount}");
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add search text again");
                goto SearchText;
            }
        }

    }
}
