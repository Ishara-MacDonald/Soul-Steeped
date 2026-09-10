using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Customer currentCustomer;
    [SerializeField] private List<Sprite> customerSprites = new();
    void Start()
    {
        NeedUIManager.manager.SetVisibility(false);
        CustomerManager.manager.gameObject.SetActive(false);
        TeaManager.manager.SetCanPickTea(false);
        new CustomerData(customerSprites);
        StartNewOrder();
    }

    public void StartNewOrder()
    {
        StartCoroutine(WaitForCustomer(4f));
    }

    IEnumerator WaitForCustomer(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        GenerateCustomer();
    }

    public void GenerateCustomer()
    {
        currentCustomer = new();
        CustomerManager.manager.gameObject.SetActive(true);
        CustomerManager.manager.CustomerGreeting();
        StartCoroutine(CustomerGreeting(5f));
    }

    IEnumerator CustomerGreeting(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        CustomerManager.manager.FinishGreeting();
        ShowNeeds();
    }

    public void ShowNeeds()
    {
        NeedUIManager.manager.SetVisibility(true);
        NeedUIManager.manager.SetNeeds(currentCustomer.GetNeeds());
        TeaManager.manager.SetCanPickTea(true);
    }

    public void ProcessTea()
    {
        if (currentCustomer == null) return;
        TeaManager.manager.SetCanPickTea(false);
        bool isRightFlavor = currentCustomer.DrinkTea(TeaManager.manager.Flavor);
        CustomerManager.manager.DrinkingTea();

        NeedUIManager.manager.SetNeeds(currentCustomer.GetNeeds());
        StartCoroutine(CustomerDrink(3f, isRightFlavor));
    }

    IEnumerator CustomerDrink(float cooldown, bool hadRightDrink)
    {
        yield return new WaitForSeconds(cooldown);
        CustomerManager.manager.CustomerLeaving(hadRightDrink);
        StartCoroutine(CustomerLeaving(5f));
    }

    IEnumerator CustomerLeaving(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        FinishOrder();
    }

    public void FinishOrder()
    {
        NeedUIManager.manager.SetVisibility(false);
        CustomerManager.manager.gameObject.SetActive(false);
        StartNewOrder();
    }

}