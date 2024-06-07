using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FlashlightToggle : MonoBehaviour
{
    public GameObject lightGO; //light gameObject to work with
    private bool isOn = false; //is flashlight on or off?

    private Vector3 originalScale;
    public Vector3 hoverScale;

    public GameObject playerCamera;

    // Use this for initialization
    void Start()
    {
        //set default off
        lightGO.SetActive(isOn);

        originalScale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //toggle flashlight on key down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //toggle light
            isOn = !isOn;
            //turn light on
            if (isOn)
            {
                lightGO.SetActive(true);
            }
            //turn light off
            else
            {
                lightGO.SetActive(false);

            }
        }
    }

    private void OnMouseEnter()
    {
        gameObject.transform.localScale = hoverScale;
    }

    private void OnMouseExit()
    {
        gameObject.transform.localScale = originalScale;
    }

    private void OnMouseDown()
    {
        if (playerCamera != null)
        {
            transform.position = playerCamera.transform.position + playerCamera.transform.forward * -0.5f;
            transform.rotation = playerCamera.transform.rotation * Quaternion.Euler(0, 90, 90);
            transform.SetParent(playerCamera.transform);

            Debug.Log("Get Flashlight!");
        }
        else
        {
            Debug.LogWarning("Fail!");
        }
    }
}
