using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    private Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    private void CameraMovement()
    {
        mainCam.transform.localPosition = new Vector3(transform.position.x, transform.position.y, -1f);
        transform.position = Vector2.MoveTowards(transform.position, mainCam.transform.localPosition, Time.deltaTime);
    }

    private void Update()
    {
        CameraMovement();
    }
}
