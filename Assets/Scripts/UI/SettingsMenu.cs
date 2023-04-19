using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer AudioMixer;
    public ContinuousTurnProviderBase ContinuousTurnProvider;
    public SnapTurnProviderBase SnapTurnProvider;

    public Slider MainVolumeSlider;
    public Slider MusicVolumeSlider;
    public Slider SFXVolumeSlider;
    public TMP_Dropdown TurnProviderDropdown;

    private void Start()
    {
        MainVolumeSlider.value = PlayerPrefs.GetFloat("VolumeMain", 0);
        MusicVolumeSlider.value = PlayerPrefs.GetFloat("VolumeMusic", 0);
        SFXVolumeSlider.value = PlayerPrefs.GetFloat("VolumeSFX", 0);
        TurnProviderDropdown.value = PlayerPrefs.GetInt("TurnProvider", 0);
        TurnProviderDropdown.RefreshShownValue();
    }

    public void SetVolumeMain(float volume)
    {
        AudioMixer.SetFloat("VolumeMain", volume);
        PlayerPrefs.SetFloat("VolumeMain", volume);
        PlayerPrefs.Save();
    }

    public void SetVolumeMusic(float volume)
    {
        AudioMixer.SetFloat("VolumeMusic", volume);
        PlayerPrefs.SetFloat("VolumeMusic", volume);
        PlayerPrefs.Save();
    }

    public void SetVolumeSFX(float volume)
    {
        AudioMixer.SetFloat("VolumeSFX", volume);
        PlayerPrefs.SetFloat("VolumeSFX", volume);
        PlayerPrefs.Save();
    }

    public void SetTurnProvider(int turnIndex)
    {
        switch (turnIndex)
        {
            case 0: // Snap turn
                ContinuousTurnProvider.enabled = false;
                SnapTurnProvider.enabled = true;
                break;
            case 1: // Continuous turn
                ContinuousTurnProvider.enabled = true;
                SnapTurnProvider.enabled = false;
                break;
        }
        PlayerPrefs.SetInt("TurnProvider", turnIndex);
        PlayerPrefs.Save();
    }
}
