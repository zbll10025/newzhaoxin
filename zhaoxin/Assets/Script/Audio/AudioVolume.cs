using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class AudioVolume : MonoBehaviour
{
    public int[] minVolume;
    public Text[] volText;
    public AudioMixer audioMixer;
    public void SetMasterVolume(float volume)
    {
        float value = minVolume[0] / 10 * (10 - volume);//-60 ~ 0;
        audioMixer.SetFloat("Master",value);
        volText[0].text = volume.ToString();
    }
    public void SetSoundVolume(float volume)
    {
        float value = minVolume[1] / 10 * (10 - volume);//-60 ~ 0;
        audioMixer.SetFloat("Sound", value);
        volText[1].text = volume.ToString();
    }
    public void SetMusicVolume(float volume)
    {
        float value = minVolume[2] / 10 * (10 - volume);//-60 ~ 0;
        audioMixer.SetFloat("Music", value);
        volText[2].text = volume.ToString();
    }
}
