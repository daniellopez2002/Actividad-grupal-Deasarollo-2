using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    [Header("References")]
    public Camera playerCamera;
    public Transform portal;
    public Transform linkedPortal;

    private Camera _cam;

    void Awake()
    {
        _cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (!playerCamera || !portal || !linkedPortal) return;

        Quaternion relativeRot = Quaternion.Inverse(portal.rotation) * playerCamera.transform.rotation;

        Quaternion finalRot = linkedPortal.rotation * relativeRot * Quaternion.Euler(0f, 180f, 0f);
        Vector3 euler = finalRot.eulerAngles;
        transform.rotation = Quaternion.Euler(-euler.x, -euler.y, 0f);

        _cam.fieldOfView = playerCamera.fieldOfView;

    }
}
