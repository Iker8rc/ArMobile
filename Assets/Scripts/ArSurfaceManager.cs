using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;

public class ArSurfaceManager : MonoBehaviour
{

    [SerializeField]
    private ARPlaneManager planeManager;

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private GameObject canvanUI;
    [SerializeField]
    private bool planeVisibility = true;

    private PlayerInput playerInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var plane in planeManager.trackables)
        {
            plane.GetComponent<ARPlaneMeshVisualizer>().enabled = planeVisibility;
        }
    }

    public void TouchScreen(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            Vector2 touchPos = playerInput.actions["TouchPosition"].ReadValue<Vector2>();
            Ray ray = Camera.main.ScreenPointToRay(touchPos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Choco contra" + hit.transform.name);
                Instantiate(prefab, hit.point, Quaternion.identity);
            }
        }
    }

    public void TogglePlaneVisibility()
    {
        canvanUI.SetActive(false);
        planeVisibility = !planeVisibility;
    }
}
