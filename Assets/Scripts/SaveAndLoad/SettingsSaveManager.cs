using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class SettingsSaveManager : MonoBehaviour
{
    public SettingsData settingsData;
    public GameObject joystickGameObject;
    public GameObject DPADGameObject;
    public GameObject volumeGameObject;

    //Music and sounds
    public AudioSource backgroundMusic;
    public Slider volumeSlider;
    public TextMeshProUGUI musicStatusText;
    public TextMeshProUGUI volumeText;


    //other settings data
    public TextMeshProUGUI middleControllerTextGameObject;

    private bool gameSettingsLoaded = false;


    void Awake()
    {
        if(!gameSettingsLoaded){
            LoadSettingsData();
            gameSettingsLoaded = true;
        }
    }

    public void TurnMusicOff()
    {
        settingsData.isMusicOn = false; // Set music volume to 0 (off)
        SaveSettingsData(); // Save the updated settings data
        UpdateAudioVolume(); // Apply the changes to audio immediately
        musicStatusText.text = "Off"; // Update UI text to show music is off
    }
    public void TurnMusicOn()
    {
        settingsData.isMusicOn = true; // Set music volume to maximum (on)
        SaveSettingsData(); // Save the updated settings data
        UpdateAudioVolume(); // Apply the changes to audio immediately
        musicStatusText.text = "On"; // Update UI text to show music is on
    }

    public void UpdateAudioVolume()
    {
        // Check if music is on (true) or off (false)
        if (settingsData.isMusicOn)
        {
            // always divide to 100f
            backgroundMusic.volume = settingsData.musicVolume / 100f;
            volumeGameObject.SetActive(true);
        }
        else
        {
            // Mute the volume if music is off
            backgroundMusic.volume = 0f;
            volumeGameObject.SetActive(false);
        }
    }

    public void SetVolume()
    {
        float volumeLevel = volumeSlider.value / 100f;
        backgroundMusic.volume = volumeLevel;
        settingsData.musicVolume = volumeSlider.value;

        volumeText.text = settingsData.musicVolume.ToString();
        SaveSettingsData();
    }

    public void RightButtonForGameScene(){
        // Update settingsData and save the data
        middleControllerTextGameObject.text = "Joystick";
        settingsData.isDPADActive = false;
        settingsData.isJoystickActive = true;
        settingsData.middleControllerText = middleControllerTextGameObject.text;

        // Save the updated settings data
        SaveSettingsData();

        // Activate/deactivate DPAD and joystick GameObjects as needed
        DPADGameObject.SetActive(settingsData.isDPADActive);
        joystickGameObject.SetActive(settingsData.isJoystickActive);
    }

    public void LeftButtonForGameScene(){
        // Update the text and settingsData
        middleControllerTextGameObject.text = "DPAD";
        settingsData.isDPADActive = true;
        settingsData.isJoystickActive = false;
        settingsData.middleControllerText = middleControllerTextGameObject.text;

        // Save the updated settings data
        SaveSettingsData();

        DPADGameObject.SetActive(settingsData.isDPADActive);
        joystickGameObject.SetActive(settingsData.isJoystickActive);
    }

    public void RightButtonMainMenu(){
        middleControllerTextGameObject.text = "Joystick";
        settingsData.isDPADActive = false;
        settingsData.isJoystickActive = true;
        settingsData.middleControllerText = middleControllerTextGameObject.text;

        // Save the updated settings data
        SaveSettingsData();
    }

    public void LeftButtonMainMenu(){
        middleControllerTextGameObject.text = "DPAD";
        settingsData.isDPADActive = true;
        settingsData.isJoystickActive = false;
        settingsData.middleControllerText = middleControllerTextGameObject.text;

        // Save the updated settings data
        SaveSettingsData();
    }
    public void SaveSettingsData(){
        string json = JsonUtility.ToJson(settingsData, true);
        string savePath = Path.Combine(Application.persistentDataPath, "settingsData.json");

        File.WriteAllText(savePath, json);
    }


    public void LoadSettingsData(){
        string filePath = Application.persistentDataPath + "/settingsData.json";
        if (File.Exists(filePath)){
            string json = File.ReadAllText(filePath);
            settingsData = JsonUtility.FromJson<SettingsData>(json);

            DPADGameObject.SetActive(settingsData.isDPADActive);
            joystickGameObject.SetActive(settingsData.isJoystickActive);
            middleControllerTextGameObject.text = settingsData.middleControllerText;

            volumeSlider.value = settingsData.musicVolume;

            //Music
            if (settingsData.isMusicOn)
            {
                musicStatusText.text = "On";
                backgroundMusic.volume = settingsData.musicVolume / 100f;
                volumeGameObject.SetActive(true);
            }
            else
            {
                musicStatusText.text = "Off";
                backgroundMusic.volume = 0.0f;
                volumeGameObject.SetActive(false);
            }

        }
        else {
            settingsData.isDPADActive = true;
            settingsData.isJoystickActive = false;
            settingsData.isMusicOn = true;
            settingsData.middleControllerText = "DPAD";
            settingsData.musicStatusText = "On";
            settingsData.musicVolume = 100f;
            
            SaveSettingsData();
            LoadSettingsData();
            Debug.Log("Created a new data because a file does not exist");
        }
    }

    private bool IsGameObjectActive(GameObject gameObject){
        if (gameObject != null)
        {
            return gameObject.activeSelf;
        }
        return false;
    }

    private bool IsDPADActive(){
        return IsGameObjectActive(DPADGameObject);
    }

    private bool IsJoystickActive(){
        return IsGameObjectActive(joystickGameObject);
    }
}
