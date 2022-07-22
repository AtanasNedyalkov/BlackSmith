using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Meal_Plan
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] meal = Console.ReadLine().Split().ToArray();
            int[] calories = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<string> mealQueue = new Queue<string>(meal);
            Stack<int> calorieStack = new Stack<int>(calories);

            int mealsEaten = 0;

            while (mealQueue.Count>0 && calorieStack.Count>0)
            {
                int currentCalories = calorieStack.Peek();
                while (currentCalories>0)
                {
                string currentMeal = mealQueue.Peek();

                    if (currentMeal == "salad")
                    {
                        currentCalories -= 350;
                        mealQueue.Dequeue();
                        mealsEaten++;
                    }
                    else if (currentMeal == "soup")
                    {
                        currentCalories -= 490;
                        mealQueue.Dequeue();
                        mealsEaten++;
                    }
                    else if (currentMeal == "pasta")
                    {
                        currentCalories -= 680;
                        mealQueue.Dequeue();
                        mealsEaten++;
                    }
                    else if (currentMeal == "steak")
                    {
                        currentCalories -= 790;
                        mealQueue.Dequeue();
                        mealsEaten++;
                    }
                    
                    if (currentCalories < 0)
                    {
                        int leftCals = currentCalories;
                        calorieStack.Pop();
                        if (calorieStack.Count == 0)
                        {
                            break;
                        }
                        currentCalories = calorieStack.Peek();
                        currentCalories += leftCals;
                        calorieStack.Pop();
                        calorieStack.Push(currentCalories);
                        break;

                    }
                }
            }

            if (mealQueue.Count == 0)
            {
                Console.WriteLine($"John had {mealsEaten} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calorieStack)} calories.");
            }
            if (calorieStack.Count == 0)
            {
                Console.WriteLine($"John ate enough, he had {mealsEaten} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", mealQueue)}.");
            }
        }
          
    }
}
