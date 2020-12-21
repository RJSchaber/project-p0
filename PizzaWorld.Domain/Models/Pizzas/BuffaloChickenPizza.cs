using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class BuffaloChickenPizza : APizzaModel
    {
        protected override void AddCrust()
        {
            Crust = "garlic";
        }

        protected override void AddSize()
        {
            Size = "Medium";
        }

        protected override void AddToppings()
        {
            Toppings = new List<string>
            {
                "cheese",
                "tomato",
                "hot sauce",
                "ranch",
                "chicken"
            };
        }
    }
}