using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARSessionOriginController : MonoBehaviour
{

    public GameObject arSession;
    public GameObject arSession_Origin;
    public GameObject arCam;

    // Update is called once per frame
    void Update()
    {
        TrackingAccuration(0.6f);

    }

    // for tracking accuracy
    Vector3 pos_last = Vector3.zero;
    Vector3 pos_now = Vector3.zero;
    float rot_last = 0;
    float rot_now = 0;

    private void TrackingAccuration(float accuracy)
    {
        // rotation - y축만 고려
        rot_now = arCam.transform.rotation.eulerAngles.y;
        float rot_dif = rot_now - rot_last;
        if (Mathf.Abs(rot_dif) > 90 && Mathf.Abs(rot_dif) < 270)
        {
            arSession_Origin.transform.Rotate(0, -rot_dif, 0);
        }
        //

        // position
        pos_now = arCam.transform.position;
        Vector3 pos_dif = pos_now - pos_last;
        if (pos_dif.magnitude > accuracy)
        {
            Debug.Log(pos_dif.magnitude);
            arSession_Origin.transform.position -= pos_dif;
        }

        pos_last = arCam.transform.position;
        rot_last = arCam.transform.rotation.eulerAngles.y;
    }
}
