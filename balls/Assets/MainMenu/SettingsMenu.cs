using UnityEngine;
using UnityEngine.Audio;
public class SettingsMenu : MonoBehaviour
{
   public AudioMixer MainMenuMixer;
    public void SetVolume(float volume)
    {
        MainMenuMixer.SetFloat("Volume", volume);

    }
    public void SetFullscreen(bool isfullscreen)
    {
        Screen.fullScreen = isfullscreen; 

    }

    public void SetQuality(int qualityIndex)
    {

        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
