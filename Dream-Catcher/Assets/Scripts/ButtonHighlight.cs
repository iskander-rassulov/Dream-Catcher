using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float hoverScale = 1.2f;  // the scale to apply when the cursor is hovering over the button
    public float transitionSpeed = 5f;  // the speed at which the button transitions to the new scale

    private Vector3 originalScale;
    private bool isHovering = false;
    private RectTransform rectTransform;
    private Text buttonText;

    private void Start()
    {
        // Get a reference to the button's RectTransform component and the Text component of the button's child object
        rectTransform = GetComponent<RectTransform>();
        buttonText = GetComponentInChildren<Text>();

        // Store the button's original scale
        originalScale = rectTransform.localScale;
    }

    private void Update()
    {
        // If the cursor is hovering over the button, gradually increase its scale towards the hoverScale value
        if (isHovering)
        {
            rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, originalScale * hoverScale, Time.deltaTime * transitionSpeed);
            if (buttonText != null)
            {
            buttonText.fontSize = (int)(buttonText.fontSize * hoverScale);
            }
        }
        // Otherwise, gradually return the button to its original scale
        else
        {
            rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, originalScale, Time.deltaTime * transitionSpeed);
            if (buttonText != null)
            {
                buttonText.fontSize = (int)(buttonText.fontSize / hoverScale);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }
}
