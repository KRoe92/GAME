using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider _VolumeSlider;

    private void Awake()
    {
        _VolumeSlider = GetComponent<Slider>();
        if(!_VolumeSlider)
        {
            Debug.LogError("VolumeSlider must have a Slider component attached");
        }

    }

    private void Start()
    {
        _VolumeSlider.value = SettingsController.Instance.GetVolume();
    }

    public void OnVolumeChanged()
    {
        SettingsController.Instance.UpdateVolume(_VolumeSlider.value);
    }
}
