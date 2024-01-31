using UnityEngine;

[System.Serializable]
public class GameData
{

    public bool isHouseActive;
    public bool isBarangayActive;
    public bool isSchoolActive;
    public bool isMainCameraActive;
    public bool isMotherCameraActive;
    public bool isControlsActive;

    public bool isTimeline1Active;

    public Vector3 studentPosition;
    public Quaternion studentRotation;
    public Vector3 motherPosition;
    public Quaternion motherRotation;

    public GameData(Vector3 studentPosition, Quaternion studentRotation, Vector3 motherPosition, Quaternion motherRotation, bool isHouseActive, bool isBarangayActive, bool isSchoolActive, bool isMainCameraActive, bool isMotherCameraActive, bool isControlsActive, bool isTimeline1Active){
        this.studentPosition = studentPosition;
        this.studentRotation = studentRotation;
        this.motherPosition = motherPosition;
        this.motherRotation = motherRotation;
        this.isHouseActive = isHouseActive;
        this.isBarangayActive = isBarangayActive;
        this.isSchoolActive = isSchoolActive; 
        this.isMainCameraActive = isMainCameraActive;
        this.isMotherCameraActive = isMotherCameraActive;
        this.isControlsActive = isControlsActive;
        this.isTimeline1Active = isTimeline1Active;
    }
}
