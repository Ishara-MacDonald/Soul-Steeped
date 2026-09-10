using UnityEngine;

public class ReviewManager : MonoBehaviour
{
    [SerializeField] private int reviewState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        reviewState = 0;
    }

}
