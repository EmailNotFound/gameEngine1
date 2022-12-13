using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class Setting : MonoBehaviour
{
    private Volume volume;
    PlayerCamera volumeController = new PlayerCamera();
    VolumeCampfire volumeCampfire = new VolumeCampfire();


    public void OnPostOnButtonClick()
    {
        volumeController.VolumeOnOff(true);
        volumeCampfire.VolumeOnOff(true);
    }

    public void OnPostOffButtonClick()
    {
        volumeController.VolumeOnOff(false);
        volumeCampfire.VolumeOnOff(false);
    }

    public void OnBackTitleButtonClick()
    {
        SceneManager.LoadScene("Title");
    }
}
