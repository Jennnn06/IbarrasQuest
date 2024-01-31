using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public Vector3 playerPosition;
    public Quaternion playerRotation;

    public PlayerData(Vector3 playerPosition, Quaternion playerRotation){
        this.playerPosition = playerPosition;
        this.playerRotation = playerRotation;
    }

}
