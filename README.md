 Shopping Basket Application

 Overview
A simple C# console application that calculates the total cost of a shopping basket based on item prices and special offers.

 Technologies Used
- C#
- .NET 8
- xUnit for unit testing

Item Prices

| Item | Price |
|---|---:|
| Apple | 35p |
| Banana | 20p |
| Melon | 50p |
| Lime | 15p |

#Special Offers
- Melon: Buy one, get one free.
- Lime: Three for the price of two.

 Business Rules
- An empty basket returns a total of 0p.
- Item names are case-sensitive. For example, `Apple` is valid, but `apple` is invalid.
- Unknown or null items throw an `ArgumentException`.
- A null basket throws an `ArgumentNullException`.
- The total is calculated in pence and can also be displayed in pounds.

 Prerequisites
- .NET 8 SDK
- Git (optional, for cloning the repository)

How to Run

1. Clone or download this repository.
2. Open a terminal in the repository root folder.
3. Build the solution:
   dotnet build ShoppingBasketApp.slnx

4. Run the console application:
   dotnet run --project ShoppingBasketApp/ShoppingBasketApp.csproj
  
How to Run Unit Tests:
Run the following command from the repository root:

dotnet test ShoppingBasketApp.slnx

The tests cover item prices, special offers, mixed baskets, empty baskets, invalid items, null items, and null baskets.

#Example Output

```text
Total cost: 135p
Total cost: £1.35
```

 Project Structure

```text
ShoppingBasketApp/
├── ShoppingBasketApp.slnx
├── .gitignore
├── ShoppingBasketApp/
│   ├── Program.cs
│   ├── ShoppingBasket.cs
│   └── ShoppingBasketApp.csproj
└── ShoppingBasketApp.Tests/
    ├── UnitTest1.cs
    └── ShoppingBasketApp.Tests.csproj
```
