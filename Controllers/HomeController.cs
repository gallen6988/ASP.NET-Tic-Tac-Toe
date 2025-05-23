using Microsoft.AspNetCore.Mvc;
using FinalProjectTicTacToe.Models;

namespace FinalProjectTicTacToe.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new TicTacToeModel();
            return View(model);
        }

        [HttpPost]
        // This post method takes not only a model instance as a parameter, but a string too. When a user clicks a button, that button passes the string stored in its value attribute to this method for processing.
        public IActionResult Index(TicTacToeModel model, string button)
        {
            // The below block of code splits and converts the numbers stored in the button parameter to be used as gameboard coordinates below.
            string[] bleh2 = button.Split(" ");
            int rowNum = Int32.Parse(bleh2[0]);
            int index = Int32.Parse(bleh2[1]);

            // This switch statement determines which gameboard row array needs to be used based on the rowNum integer. The index integer then determines the index of the corresponding array to store the current player's mark in the cell that they clicked on.
            switch(rowNum)
            {
                case 1:
                    model.gameboardRow0[index] = model.WhosTurn;
                    break;
                case 2:
                    model.gameboardRow1[index] = model.WhosTurn;
                    break;
                case 3:
                    model.gameboardRow2[index] = model.WhosTurn;
                    break;
            }

            // This if-else statement switches to the next player's turn.
            if (model.WhosTurn == "X")
            {
                model.WhosTurn = "O";
            }
            else
            {
                model.WhosTurn = "X";
            }

            // This statement simply sets the model's WinPlayer property to whatever it's Winner() method returns.
            model.WinPlayer = model.Winner();

            return View(model);
        }
    }
}