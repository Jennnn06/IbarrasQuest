using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class LongPressedSaveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent onLongClick;

    public float buttonHoldTime;
    private float onClickTimer;

    private bool buttonIsClicked;

    public GameObject objectToShowOnLongPress; // Reference to the GameObject to show
    public GameObject objectToDisableOnLongPress; //Reference to the GameObject to hide

    private void Start()
    {
        if (objectToShowOnLongPress != null)
        {
            objectToShowOnLongPress.SetActive(false); // Hide the object initially
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonIsClicked = true;

        // Show the object when the button is pressed
        if (objectToShowOnLongPress != null)
        {
            objectToShowOnLongPress.SetActive(true);
            objectToDisableOnLongPress.SetActive(false);
        }

        // Start a timer for a long press
        onClickTimer = 0f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Button Pressed!");
        Reset();
    }

    private void Update()
    {
        if (buttonIsClicked)
        {
            onClickTimer += Time.deltaTime;

            // Check if the button has been pressed for the required duration
            if (onClickTimer >= buttonHoldTime)
            {
                // Long press detected
                if (onLongClick != null)
                {
                    onLongClick.Invoke();
                }
            }
        }
    }

    private void Reset()
    {
        buttonIsClicked = false;

        // Hide the object after releasing the button
        if (objectToShowOnLongPress != null)
        {
            objectToShowOnLongPress.SetActive(false);
            objectToDisableOnLongPress.SetActive(true);
        }
    }
}
