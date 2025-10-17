using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField] public PortalController LinkedPortal;
    [SerializeField] public RenderTexture PortalTexture;
    [SerializeField] private MeshRenderer _screen;
    private Camera _portalCamera;

    void Start()
    {
        _portalCamera = GetComponentInChildren<Camera>();

        // Crea un RenderTexture si no lo tiene
        if (PortalTexture == null)
        {
            PortalTexture = new RenderTexture(Screen.width, Screen.height, 24);
            _portalCamera.targetTexture = PortalTexture;
        }

        // Asigna el RenderTexture a su propio material
        _screen.material.SetTexture("_PortalTexture", PortalTexture);
    }

    void LateUpdate()
    {
        if (LinkedPortal != null && LinkedPortal.PortalTexture != null)
        {
            // Asigna la textura del otro portal a este
            _screen.material.SetTexture("_PortalTexture", LinkedPortal.PortalTexture);
        }
    }
}
