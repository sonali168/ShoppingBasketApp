
using System;
using System.Collections.Generic;

namespace ShoppingBasketApp
{
    public class ShoppingBasket
    {
        public int CalculateTotal(List<string> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            int total = 0;
            int melons = 0;
            int limes = 0;

            foreach (string item in items)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    throw new ArgumentException(
                        "Item name cannot be null, empty, or whitespace.",
                        nameof(items));
                }

                // Ignore capitalization and surrounding spaces.
                string normalizedItem = item.Trim().ToLowerInvariant();

                switch (normalizedItem)
                {
                    case "apple":
                        total += 35;
                        break;

                    case "banana":
                        total += 20;
                        break;

                    case "melon":
                        melons++;
                        break;

                    case "lime":
                        limes++;
                        break;

                    default:
                        throw new ArgumentException(
                            $"Unknown item: {item}",
                            nameof(items));
                }
            }

            // Buy one melon, get one free.
            total += ((melons + 1) / 2) * 50;

            // Three limes for the price of two.
            total += (limes - limes / 3) * 15;

            return total;
        }
    }
}
