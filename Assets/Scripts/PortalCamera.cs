using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    [Header("References")]
    public Camera playerCamera;
    public Transform portal;

    private Transform _linkedPortal;
    private Camera _cam;
    private PortalController _portalController;

    void Awake()
    {
        _cam = GetComponent<Camera>();
        _portalController = GetComponentInParent<PortalController>();
        _linkedPortal = _portalController.LinkedPortal.transform;
    }

    void LateUpdate()
    {
        if (!playerCamera || !portal || !_linkedPortal) return;

        Quaternion relativeRot = Quaternion.Inverse(portal.rotation) * playerCamera.transform.rotation;

        Quaternion finalRot = _linkedPortal.rotation * relativeRot * Quaternion.Euler(0f, 180f, 0f);
        Vector3 euler = finalRot.eulerAngles;
        transform.rotation = Quaternion.Euler(-euler.x, euler.y, 0f);

        _cam.fieldOfView = playerCamera.fieldOfView;

    }
}
