using UnityEngine;

public class Order : MonoBehaviour
{
    private int maxRating = 5;
    private NeedType type;
    private int rating;

    public int BoostRating(int boost)
    {
        rating += boost;
        if (rating > maxRating) rating = 5;
        return rating;
    }

}