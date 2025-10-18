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

        if (PortalTexture == null)
        {
            PortalTexture = new RenderTexture(Screen.width, Screen.height, 24);
            _portalCamera.targetTexture = PortalTexture;
        }

        _screen.material.SetTexture("_PortalTexture", PortalTexture);
    }

    void LateUpdate()
    {
        if (LinkedPortal != null && LinkedPortal.PortalTexture != null)
        {
            _screen.material.SetTexture("_PortalTexture", LinkedPortal.PortalTexture);
        }
    }
}
