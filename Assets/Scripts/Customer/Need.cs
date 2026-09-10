using UnityEngine;

public class Need
{
    private int maxRating = 5;
    private NeedType type;
    private int rating;

    public NeedType Type => type;
    public int Rating => rating;

    public Need(NeedType type, int rating)
    {
        this.type = type;
        this.rating = rating;
    }

    public int BoostRating(int boost)
    {
        rating += boost;
        if (rating > maxRating) rating = 5;
        return rating;
    }

    public override string ToString()
    {
        return "Type: " + type + "\nRating: " + rating;
    }

}