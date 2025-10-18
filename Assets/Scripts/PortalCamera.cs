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

        // --- Calcula la rotación relativa del jugador ---
        Quaternion relativeRot = Quaternion.Inverse(portal.rotation) * playerCamera.transform.rotation;
        // Quaternion finalRot = linkedPortal.rotation * relativeRot;

        Quaternion finalRot = linkedPortal.rotation * relativeRot * Quaternion.Euler(0f, 180f, 0f);
        Vector3 euler = finalRot.eulerAngles;
        transform.rotation = Quaternion.Euler(-euler.x, -euler.y, 0f);


        // Copia el FOV del jugador
        _cam.fieldOfView = playerCamera.fieldOfView;

        // Opcional: asegura que mire hacia afuera del portal
        // if (Vector3.Dot(transform.forward, portal.forward) > 0)
        //     transform.Rotate(0f, -180f, 0f);
    }
}
