using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorGrabSceneLoader : MonoBehaviour
{
    public string sceneToLoad = "KameHouseInside";

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable == null)
        {
            Debug.LogError("XRGrabInteractable not found on this object.");
            return;
        }

        grabInteractable.selectEntered.AddListener(OnGrabbed);
    }

    private void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        }
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        // Load the interior scene when grabbed
        SceneManager.LoadScene("KameHouseInside");
    }
}
