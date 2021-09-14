using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Cinemachine;

public class FreeLookCameraDragHandler : MonoBehaviour, IDragHandler
{
    public CinemachineFreeLook freeLookCamera;

    public float sensitivityX = 2f;
    public float sensitivityY = 0.005f;

    [Tooltip("Uncheck it to keep the Axis input")]
    public bool disableAxisInput = true;

    [Tooltip("Uncheck it if another raycast here")]
    public bool createRaycastImage = true;

    private void Start()
    {
        if (!freeLookCamera)
        {
            Debug.LogError("Setup the freeLookCamera first");
        }

        if(createRaycastImage)
        {
            Image image = gameObject.AddComponent<Image>();
            image.color = new Color(0, 0, 0, 0);
        }

        if (disableAxisInput)
        {
            freeLookCamera.m_XAxis.m_InputAxisName = null;
            freeLookCamera.m_YAxis.m_InputAxisName = null;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        freeLookCamera.m_XAxis.Value += eventData.delta.x * sensitivityX;
        freeLookCamera.m_YAxis.Value += eventData.delta.y * sensitivityY;
    }
}
