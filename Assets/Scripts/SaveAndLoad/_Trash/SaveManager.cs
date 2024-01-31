using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class SaveManager : MonoBehaviour
{
    //Variables sht
    public GameData gameData;

    public Transform student; 
    public Transform mother;  
    public GameObject houseGameObject;    
    public GameObject barangayGameObject; 
    public GameObject schoolGameObject;
    public GameObject mainCameraGameObject;
    public GameObject motherCameraGameObject;
    public GameObject controlsGameObject;
    public GameObject timelineGameObject;

    public Vector3 studentPosition;
    public Quaternion studentRotation;
    public Vector3 motherPosition;
    public Quaternion motherRotation;

    //bool for loading the data once.
    private bool gameDataLoaded = false;

    //Start of the scene
    private void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/gameData.json") && !gameDataLoaded)
        {
            LoadGameData();
            gameDataLoaded = true; // Set the flag to true to indicate that data is already loaded
        }
    }


    //Save data, connect it to save button
    public void SaveGameData()
    {
        if (student != null)
        {
            gameData.studentPosition = student.transform.position;
            gameData.studentRotation = student.transform.rotation;
        }

        if (mother != null)
        {
            gameData.motherPosition = mother.transform.position;
            gameData.motherRotation = mother.transform.rotation;
        }

        gameData.isHouseActive = IsHouseActive();
        gameData.isBarangayActive = IsBarangayActive();
        gameData.isSchoolActive = IsSchoolActive();
        gameData.isMainCameraActive = IsMainCameraActive();
        gameData.isMotherCameraActive = false;
        gameData.isControlsActive = true;
        gameData.isTimeline1Active = IsTimeline1Active();

        string json = JsonUtility.ToJson(gameData);

        // Get the platform-specific persistent data path
        string savePath = Path.Combine(Application.persistentDataPath, "gameData.json");

        // Write the JSON data to the persistent data path
        File.WriteAllText(savePath, json);
        Debug.Log("Saved a game data");
    }

    //Load Data once the scene is loaded
    private void LoadGameData(){
        string json = File.ReadAllText(Application.persistentDataPath + "/gameData.json");
        gameData = JsonUtility.FromJson<GameData>(json);

        // Set your game objects based on the loaded data
        timelineGameObject.SetActive(gameData.isTimeline1Active);
        mainCameraGameObject.SetActive(gameData.isMainCameraActive);
        motherCameraGameObject.SetActive(gameData.isMotherCameraActive);
        controlsGameObject.SetActive(gameData.isControlsActive);
        barangayGameObject.SetActive(gameData.isBarangayActive);
        schoolGameObject.SetActive(gameData.isSchoolActive);
        houseGameObject.SetActive(gameData.isHouseActive);

        // Set positions and rotations if needed
        if (student != null){
            student.transform.position = gameData.studentPosition;
            student.transform.rotation = gameData.studentRotation;
        }

        if (mother != null)
        {
            mother.transform.position = gameData.motherPosition;
            mother.transform.rotation = gameData.motherRotation;
        }
        Debug.Log("Game data loaded!");
}

    
    //Check Automatically if the gameobject is active
    private bool IsGameObjectActive(GameObject gameObject){
        if (gameObject != null)
        {
            return gameObject.activeSelf;
        }
        return false;
    }

    //Save file        
    private bool IsHouseActive(){
        return IsGameObjectActive(houseGameObject);
    }

    private bool IsBarangayActive(){
        return IsGameObjectActive(barangayGameObject);
    }

    private bool IsSchoolActive(){
        return IsGameObjectActive(schoolGameObject);
    }

    private bool IsMainCameraActive(){
        return IsGameObjectActive(mainCameraGameObject);
    }

    private bool IsMotherCameraActive(){
        return IsGameObjectActive(motherCameraGameObject);
    }

    private bool IsTimeline1Active(){
        return IsGameObjectActive(timelineGameObject);
    }

}
    