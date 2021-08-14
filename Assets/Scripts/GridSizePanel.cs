using UnityEngine;
using UnityEngine.UI;

public class GridSizePanel : MonoBehaviour
{
    public Slider GridSliderX;
    public Text SliderXValueText;

    public Slider GridSliderY;
    public Text SliderYValueText;

    private void Awake()
    {
        GridSliderX.value = 1;
        OnGridSizeXChanged();
        GridSliderY.value = 1;
        OnGridSizeYChanged();
    }

    public void OnGridSizeXChanged()
    {
        SliderXValueText.text = GridSliderX.value.ToString();
    }

    public void OnGridSizeYChanged()
    {
        SliderYValueText.text = GridSliderY.value.ToString();
    }

    public void OnGridSizeAccepted()
    {
        Game.Instance.StartGame((int)GridSliderX.value, (int)GridSliderY.value);
        gameObject.SetActive(false);
    }
}
