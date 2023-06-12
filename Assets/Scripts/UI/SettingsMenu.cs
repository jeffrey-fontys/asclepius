using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer AudioMixer;
    public ContinuousTurnProviderBase ContinuousTurnProvider;
    public SnapTurnProviderBase SnapTurnProvider;

    public Slider MainVolumeSlider;
    public Slider MusicVolumeSlider;
    public Slider SFXVolumeSlider;
    public TMP_Dropdown TurnProviderDropdown;
    public TextMeshProUGUI VersionText;

    private void Start()
    {
        MainVolumeSlider.value = PlayerPrefs.GetFloat("VolumeMain", 1);
        MusicVolumeSlider.value = PlayerPrefs.GetFloat("VolumeMusic", 1);
        SFXVolumeSlider.value = PlayerPrefs.GetFloat("VolumeSFX", 1);
        TurnProviderDropdown.value = PlayerPrefs.GetInt("TurnProvider", 0);
        TurnProviderDropdown.RefreshShownValue();
        SetVersionInCredits();
    }

    private void OnDestroy() { PlayerPrefs.Save(); }

    private void SetVersionInCredits() { VersionText.text = VersionText.text.Replace("{V}", Application.version); }

    public void SetVolumeMain(float volume) { SetVolume("VolumeMain", volume); }

    public void SetVolumeMusic(float volume) { SetVolume("VolumeMusic", volume); }

    public void SetVolumeSFX(float volume) { SetVolume("VolumeSFX", volume); }

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
    }

    private void SetVolume(string name, float volume)
    {
        AudioMixer.SetFloat(name, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(name, volume);
    }
}
