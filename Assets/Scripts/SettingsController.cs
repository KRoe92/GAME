using UnityEngine;

public class SettingsController : MonoBehaviourSingleton<SettingsController>
{
    private const string VolumePrefsKey = "Volume";

    protected override void Awake()
    {
        base.Awake();
        AudioListener.volume = PlayerPrefs.GetFloat(VolumePrefsKey);
    }

    public void UpdateVolume(float newVolume)
    {
        AudioListener.volume = newVolume;
        PlayerPrefs.SetFloat(VolumePrefsKey, newVolume);
    }

    public float GetVolume()
    {
        return PlayerPrefs.GetFloat(VolumePrefsKey);
    }
}
