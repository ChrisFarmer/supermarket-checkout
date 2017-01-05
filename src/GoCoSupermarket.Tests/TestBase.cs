using System;
using GoCoSupermarket.BusinessLogic;
using GoCoSupermarket.DTO;
using NUnit.Framework;
using System.Collections.Generic;

namespace GoCoSupermarketCheckout.Tests
{
    [TestFixture]
    public abstract class TestBase
    {
        protected PriceCalculatorBusinessLogic PriceCalculatorBusinessLogic;

        // Expected results
        protected readonly Dictionary<string, decimal> ExpectedOutcomes = new Dictionary<string, decimal>
        {
            { "", 0M },
            { "A", 45M },
            { "AB", 80M },
            { "CDBA", 115M },
            { "AA", 100M },
            { "AAA", 130M },
            { "AAABB", 175M }
        };

        // These would usually come from a mocked database
        protected readonly Dictionary<char, StockKeepingUnit> Items = new Dictionary<char, StockKeepingUnit>
        {
            {
                'A',
                new StockKeepingUnit
                {
                    ItemCode = 'A',
                    Price = 50.00M,
                    OfferCalculator = new List<ICalculateDiscountedPrice>
                    {
                        new DateBasedOffer(0.9M, DateTime.Now.AddDays(28)),
                        new MultiBuyOffer(OfferType.MultiBuy)
                        {
                            Number = 3,
                            TotalPrice = 130.00M
                        }
                    }                }
            },

            {
                'B',
                new StockKeepingUnit
                {
                    ItemCode = 'B',
                    Price = 30.00M,
                    OfferCalculator = new List<ICalculateDiscountedPrice>
                    {
                        new MultiBuyOffer(OfferType.MultiBuy)
                        {
                            Number = 2,
                            TotalPrice = 45.00M
                        }
                    } 
                }
            },

            {
                'C',
                new StockKeepingUnit
                {
                    ItemCode = 'C',
                    Price = 20.00M,
                    OfferCalculator = new List<ICalculateDiscountedPrice>
                    {
                        new StandardOffer()
                    }
                }
            },

            {
                'D',
                new StockKeepingUnit
                {
                    ItemCode = 'D',
                    Price = 15.00M,
                    OfferCalculator = new List<ICalculateDiscountedPrice>
                    {
                        new StandardOffer()
                    }
                }
            }
        };

        [SetUp]
        protected void TestSetup()
        {
            this.PriceCalculatorBusinessLogic = new PriceCalculatorBusinessLogic();
        }
    }
}