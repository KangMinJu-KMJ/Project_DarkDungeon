using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCameraUI : MonoBehaviour
{
    private Transform mainCam;
    private RectTransform rectTr;

    void Start()
    {
        mainCam = Camera.main.transform;
        rectTr = GetComponent<RectTransform>();
    }

    
    void Update()
    {
        rectTr.LookAt(mainCam.transform);
    }
}
