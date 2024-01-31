using System.IO;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;


public class PlayerSaveManager : MonoBehaviour
{
    public PlayerData playerData;
    public Transform player;


    //bool for loading the data once.
    private bool playerDataLoaded = false;

    void Awake(){
        if(!playerDataLoaded && File.Exists(Application.persistentDataPath + "/playerData.json")){
            LoadPlayerData();
            playerDataLoaded =true;
        }
        else{
            Debug.Log("File not found");
        }
    }
    void Start(){
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            InvokeRepeating("SavePlayerData", 0f, 1f);
        }
    }

    public void SaveNewPlayerData(){
        //Declare what you want to save
        playerData.playerPosition.x = -0.82f;
        playerData.playerPosition.y = -0.81f;
        playerData.playerPosition.z = 0f;

        //Save
        string json = JsonUtility.ToJson(playerData, true);
        string savePath = Path.Combine(Application.persistentDataPath, "playerData.json");
        File.WriteAllText(savePath, json);
        Debug.Log("Saved New Player Data");
    }

    public void SavePlayerData(){
        if(player != null){
            playerData.playerPosition = player.position;
            playerData.playerRotation = player.rotation;
        }

        //Save
        string json = JsonUtility.ToJson(playerData, true);
        string savePath = Path.Combine(Application.persistentDataPath, "playerData.json");
        File.WriteAllText(savePath, json);
    }

    public void LoadPlayerData(){
        string json = File.ReadAllText(Application.persistentDataPath + "/playerData.json");
        playerData = JsonUtility.FromJson<PlayerData>(json);

        //declare what you want to load "Use the playerData or any data u want always"
        if(player != null){
            player.position = playerData.playerPosition;
            player.rotation = playerData.playerRotation;
        }
        Debug.Log("Game Loaded");
    }

    //Call When Saving
    

}
