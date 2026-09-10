using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedUIManager : MonoBehaviour
{
    public static NeedUIManager manager;
    [SerializeField] private GameObject MainNeeds;
    [SerializeField] private NeedBarUI PeaceNeed;
    [SerializeField] private NeedBarUI ConfidenceNeed;
    [SerializeField] private NeedBarUI ConnectionNeed;
    [SerializeField] private NeedBarUI PurposeNeed;

    public void Awake()
    {
        manager = this;
    }

    public void SetVisibility(bool newValue)
    {
        GetComponent<Image>().enabled = newValue;
        MainNeeds.SetActive(newValue);
    }

    public void SetNeeds(List<Need> needs)
    {
        foreach (Need need in needs)
        {
            switch (need.Type)
            {
                case NeedType.Peace:
                    PeaceNeed.SetRating(need.Rating);
                    break;
                case NeedType.Confidence:
                    ConfidenceNeed.SetRating(need.Rating);
                    break;
                case NeedType.Connection:
                    ConnectionNeed.SetRating(need.Rating);
                    break;
                case NeedType.Purpose:
                    PurposeNeed.SetRating(need.Rating);
                    break;
            }
        }
    }
}