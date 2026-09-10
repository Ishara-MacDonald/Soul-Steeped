using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Customer
{
    private string name;
    private List<Need> Needs = new();
    public string Name => name;

    public Customer()
    {
        name = CustomerData.data.GetRandomName();

        List<int> ratings = GenerateRatings();
        Needs.Add(new Need(NeedType.Peace, ratings[0]));
        Needs.Add(new Need(NeedType.Confidence, ratings[1]));
        Needs.Add(new Need(NeedType.Connection, ratings[2]));
        Needs.Add(new Need(NeedType.Purpose, ratings[3]));
    }

    public List<Need> GetNeeds()
    {
        return Needs;
    }

    public bool DrinkTea(TeaFlavor teaFlavor)
    {
        int lowestRating = Needs.Min(need => need.Rating);
        Need lowestNeed = Needs.Where(need => need.Rating == lowestRating).ToList()[0];

        NeedType teaType = teaFlavor.Type;
        Need affectedNeed = Needs.Where(Need => Need.Type == teaType).ToList()[0];
        affectedNeed.BoostRating(2);

        return lowestNeed.Type == affectedNeed.Type;
    }

    public List<int> GenerateRatings()
    {
        List<int> ratings = new();
        while (ratings.Count < 5)
        {
            int rating = Random.Range(1, 6);
            if (!ratings.Contains(rating)) ratings.Add(rating);
        }
        return ratings;
    }

    public override string ToString()
    {
        string toString = "Name: " + Name + "\nneeds: ";

        foreach (Need need in Needs)
        {
            toString += need.ToString() + "\n";
        }

        return toString;
    }
}
