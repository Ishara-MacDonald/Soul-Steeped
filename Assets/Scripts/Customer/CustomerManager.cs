using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomerManager : MonoBehaviour
{
    public static CustomerManager manager;
    [SerializeField] private Image sprite;
    [SerializeField] private TextMeshProUGUI speechBubble;

    public void Awake()
    {
        manager = this;
    }

    public void CustomerGreeting()
    {
        speechBubble.transform.parent.gameObject.SetActive(true);
        sprite.gameObject.SetActive(true);

        speechBubble.text = CustomerData.data.GetRandomGreeting();
        sprite.sprite = CustomerData.data.GetRandomSprite();
    }

    public void FinishGreeting()
    {
        speechBubble.transform.parent.gameObject.SetActive(false);
    }

    public void DrinkingTea()
    {

        speechBubble.transform.parent.gameObject.SetActive(true);
        speechBubble.gameObject.SetActive(true);
        speechBubble.text = ". . .";
    }

    public void CustomerLeaving(bool hadRightDrink)
    {
        speechBubble.transform.parent.gameObject.SetActive(true);
        speechBubble.gameObject.SetActive(true);

        speechBubble.text = CustomerData.data.GetRandomFarewell(hadRightDrink);
    }
}