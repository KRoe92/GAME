using UnityEngine;

public class SettingsController : MonoBehaviourSingleton<SettingsController>
{
    private const string VolumePrefsKey = "Volume";
    private const float DeafultVolume = 0.75f;

    protected override void Awake()
    {
        base.Awake();
        AudioListener.volume = PlayerPrefs.HasKey(VolumePrefsKey) ? PlayerPrefs.GetFloat(VolumePrefsKey) : DeafultVolume;
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
