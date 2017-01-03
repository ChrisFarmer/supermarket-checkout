using GoCoSupermarket.BusinessLogicInterfaces;
using GoCoSupermarket.DTO;
using GoCoSupermarket.Globalisation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoCoSupermarket.UI
{
    internal class GoCoSupermarket
    {
        private readonly IStockParserBusinessLogic stockParserBusinessLogic;
        private readonly IPriceCalculatorBusinessLogic priceCalculatorBusinessLogic;

        public GoCoSupermarket(IStockParserBusinessLogic stockParserBusinessLogic, IPriceCalculatorBusinessLogic priceCalculatorBusinessLogic)
        {
            this.stockParserBusinessLogic = stockParserBusinessLogic;
            this.priceCalculatorBusinessLogic = priceCalculatorBusinessLogic;
        }

        internal void Run(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Console.WriteLine("===============================");
            Console.WriteLine(ResourceStrings.WelcomeToTheGoCoSupermarket);
            Console.WriteLine("===============================");
            Console.WriteLine();

            // Items passed in may be empty
            string items = this.GetSanitisedInput(args);
            decimal totalPrice = this.CalculatePrice(items);

            Console.WriteLine();
            Console.WriteLine(string.Format("{0} {1:C}", ResourceStrings.TheTotalPriceOfYourItemsIs, totalPrice));

            Console.WriteLine();
            Console.WriteLine(ResourceStrings.PleasePressAnyKeyToContinue);
            Console.ReadKey();
        }

        /// <summary>
        /// Handles exceptions thrown from the application. Displays an error message and terminates the app.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // These errors would typically be logged to a database/Windows event viewer etc.
            string errorMsg = (e.ExceptionObject is Exception)
                ? ((Exception)e.ExceptionObject).Message
                : string.Empty;

            Console.WriteLine(ResourceStrings.AnErrorHasOccurred);

            if (!string.IsNullOrWhiteSpace(errorMsg)) 
            {
                Console.WriteLine(errorMsg);
            }

            Console.WriteLine();
            Console.WriteLine(ResourceStrings.TheApplicationWillNowClose);
            Console.WriteLine(ResourceStrings.PleasePressAnyKeyToContinue);
            Console.ReadKey();

            Environment.Exit(-1);
        }

        /// <summary>
        /// Calculates the total price of the purchased items.
        /// </summary>
        /// <param name="items">The items that have been purchased as a string.</param>
        /// <returns>A decimal representing the total price of the items.</returns>
        private decimal CalculatePrice(string items)
        {
            Dictionary<char, IEnumerable<StockKeepingUnit>> stockKeepingUnits = this.stockParserBusinessLogic.ParseStockItems(items);

            return this.priceCalculatorBusinessLogic.GetTotalCostOfItems(stockKeepingUnits);
        }

        /// <summary>
        /// Ensures any characters other than letters are removed before parsing the input string.
        /// </summary>
        /// <param name="args">The stock items passed in on the command line.</param>
        /// <returns>A string containing letters only.</returns>
        private string GetSanitisedInput(string[] args)
        {
            string result = string.Empty;

            if (args.Length == 1) 
            {
                result = args[0];
            } 
            else if (args.Length > 1) 
            {
                result = string.Join(string.Empty, args).Replace(" ", string.Empty);
            } 
            else if (args.Length > int.MaxValue) 
            {
                throw new ArgumentException(ResourceStrings.TooManyItemsSpecified);
            }

            return new string(result.Where(char.IsLetter).ToArray());
        }
    }
}
