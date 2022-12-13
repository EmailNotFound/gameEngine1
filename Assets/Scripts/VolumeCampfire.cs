using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class VolumeCampfire : MonoBehaviour
{
    Volume volume;
    public static bool IsVolumeOn;

    void Start()
    {
        volume = GetComponent<Volume>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsVolumeOn == false)
        {
            volume.enabled = false;
        }
        else
        {
            volume.enabled = true;
        }
    }

    public void VolumeOnOff(bool on)
    {
        if (on)
        {
            IsVolumeOn = true;
        }
        else
        {
            IsVolumeOn = false;
        }
    }
}
