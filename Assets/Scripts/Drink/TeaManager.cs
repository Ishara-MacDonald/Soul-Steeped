using UnityEngine;
using UnityEngine.UI;

public class TeaManager : MonoBehaviour
{
    public static TeaManager manager;
    private TeaFlavor selectedFlavor;
    [SerializeField] private Image teaImage;
    [SerializeField] private GameObject giveDrinkBtn;

    public TeaFlavor Flavor => selectedFlavor.GetComponent<TeaFlavor>();
    private bool canPickTea;

    public void Awake()
    {
        manager = this;
        giveDrinkBtn.SetActive(false);
    }

    void OnEnable()
    {
        TeaFlavor.OnFlavorPress += SetFlavor;
    }

    void OnDisable()
    {
        TeaFlavor.OnFlavorPress -= SetFlavor;
    }

    public void SetCanPickTea(bool newValue)
    {
        canPickTea = newValue;
        giveDrinkBtn.SetActive(newValue);
    }

    public void SetFlavor(TeaFlavor flavorObject)
    {
        if (!canPickTea) return;

        if (selectedFlavor != null && selectedFlavor != flavorObject) selectedFlavor.FlavorDeselected();
        selectedFlavor = flavorObject;
        teaImage.color = flavorObject.Color;
        flavorObject.SetColor(Color.white);
    }
}
