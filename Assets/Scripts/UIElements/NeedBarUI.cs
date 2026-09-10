using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedBarUI : MonoBehaviour
{
    [SerializeField] private GameObject NeedBar;
    private List<GameObject> FillableBars = new();

    void Awake()
    {
        foreach (Transform child in NeedBar.transform)
        {
            child.GetComponent<Image>().color = Color.black;
            FillableBars.Add(child.gameObject);
        }
    }

    public void SetRating(int rating)
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < rating) FillableBars[i].GetComponent<Image>().color = Color.white;
            else FillableBars[i].GetComponent<Image>().color = Color.black;
        }
    }
}
