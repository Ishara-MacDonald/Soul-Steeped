using System;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class TeaFlavor : MonoBehaviour
{
    enum FlavorType
    {
        Herbal,
        Black,
        Sweet,
        Green
    }

    [SerializeField] private NeedType needType;
    [SerializeField] private FlavorType flavorType;
    [SerializeField] private Color defaultColor;
    public static event Action<TeaFlavor> OnFlavorPress;

    public Color Color => defaultColor;
    public NeedType Type => needType;

    public void FlavorSelected()
    {
        OnFlavorPress?.Invoke(this);
    }

    public void SetColor(Color newColor)
    {
        GetComponent<Image>().color = newColor;
    }

    public void FlavorDeselected()
    {
        GetComponent<Image>().color = defaultColor;
    }
}
