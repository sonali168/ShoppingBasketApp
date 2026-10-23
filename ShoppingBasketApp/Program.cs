
using System;
using System.Collections.Generic;
using ShoppingBasketApp;

var basket = new ShoppingBasket();

var items = new List<string>
{
    "apple",
    "BANANA",
    "Melon",
    "melon",
    "lime",
    "LIME",
    "Lime"
};

int total = basket.CalculateTotal(items);

Console.WriteLine($"Total cost: {total}p");
Console.WriteLine($"Total cost: £{total / 100.0:F2}");
