using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Cinemachine;

/// <summary>
/// UI Drap handler for Cinemachine https://docs.unity3d.com/Packages/com.unity.cinemachine@latest/index.html
/// </summary>

public class CinemachineCoreDragInput : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public string axisNameX = "Mouse X";
    public float sensitivityX = 1f;
    public string axisNameY = "Mouse Y";
    public float sensitivityY = 1f;

    [Tooltip("Uncheck it if another raycast here")]
    public bool createRaycastImage = true;

    private float deltaX;
    private float deltaY;
    private bool onDrag;

    private void Start()
    {
        CinemachineCore.GetInputAxis = HandleAxisInputDelegate;

        if (createRaycastImage)
        {
            Image image = gameObject.AddComponent<Image>();
            image.color = new Color(0, 0, 0, 0);
        }
    }

    public float HandleAxisInputDelegate(string axisName)
    {
        if (!onDrag) return 0f;

        if (axisName == axisNameX)
        {
            float x = deltaX;
            deltaX = 0;
            return x;
        }
        else if(axisName == axisNameY)
        {
            float y = deltaY;
            deltaY = 0;
            return y;
        }
        else
        {
            Debug.LogError("Input axisName " + axisName + " not match.", this);
            return 0f;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        onDrag = true;
        deltaX = eventData.delta.x * sensitivityX;
        deltaY = eventData.delta.y * sensitivityY;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        onDrag = false;
    }
}
