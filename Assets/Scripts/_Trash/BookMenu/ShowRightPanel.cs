using UnityEngine;

public class ShowRightPanel : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject[] objectsToDeactivate;
    private PanelActivationManager activationManager;

    private void Start()
    {
        activationManager = FindObjectOfType<PanelActivationManager>();
    }

    public void ActivateObject()
    {
        objectToActivate.SetActive(true);

        activationManager.RegisterActivatedObject(objectToActivate);

        // Deactivate other GameObjects
        foreach (GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(false);
        }
    }

}
