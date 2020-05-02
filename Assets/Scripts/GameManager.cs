using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject debugSystem;
    [SerializeField] GameObject objectPooler;

    GameObject debugSystemReference;
    GameObject objectPoolerReference;
    PlayerController playerController;
    CameraManager mainCamera;

    private void Awake()
    {
        debugSystemReference = Instantiate(debugSystem,GameObject.FindGameObjectWithTag("UI").transform);
        objectPoolerReference = Instantiate(objectPooler);
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if (playerController == null)
            Debug.LogWarning("Player couldn't be found in the scene. Drag a prefab from the prefab folder into the scene");
        mainCamera = Camera.main.GetComponent<CameraManager>();
        if (mainCamera == null)
            Debug.LogWarning("No main camera in the scene. Or main camera doesn't have <CameraManager> component attached to it");

        //Small initialization if the camera doesn't have the player attached
        if (mainCamera != null && playerController != null)
        {
            mainCamera.SetTarget(playerController.transform);
        }
    }
}
