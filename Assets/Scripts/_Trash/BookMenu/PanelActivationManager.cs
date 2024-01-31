using UnityEngine;
using System.Collections.Generic;

public class PanelActivationManager : MonoBehaviour
{
    private List<GameObject> activatedObjects = new List<GameObject>();

    public void RegisterActivatedObject(GameObject obj)
    {
        // Register the activated object
        if (!activatedObjects.Contains(obj))
        {
            activatedObjects.Add(obj);
        }
    }

    public void DeactivateRegisteredObjects()
    {
        // Deactivate all registered objects
        foreach (GameObject obj in activatedObjects)
        {
            obj.SetActive(false);
        }
    }
}
