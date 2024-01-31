using UnityEngine;

[System.Serializable]
public class SettingsData
{
    public bool isDPADActive;
    public bool isJoystickActive;
    public bool isMusicOn; 
    public string middleControllerText;
    public string musicStatusText;
    public float musicVolume;

    public SettingsData(bool isDPADActive, bool isJoystickActive, bool isMusicOn, string middleControllerText, string musicStatusText, float musicVolume)
    {
        this.isDPADActive = isDPADActive;
        this.isJoystickActive = isJoystickActive;
        this.isMusicOn = isMusicOn;
        this.middleControllerText = middleControllerText;
        this.musicStatusText = musicStatusText;
        this.musicVolume = musicVolume;
    }
}
