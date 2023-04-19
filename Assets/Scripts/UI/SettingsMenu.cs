using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.XR.Interaction.Toolkit;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer AudioMixer;
    public ContinuousTurnProviderBase ContinuousTurnProvider;
    public SnapTurnProviderBase SnapTurnProvider;

    public void SetVolumeMain(float volume)
    {
        AudioMixer.SetFloat("VolumeMain", volume);
    }

    public void SetVolumeMusic(float volume)
    {
        AudioMixer.SetFloat("VolumeMusic", volume);
    }

    public void SetVolumeSFX(float volume)
    {
        AudioMixer.SetFloat("VolumeSFX", volume);
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
    }
}
