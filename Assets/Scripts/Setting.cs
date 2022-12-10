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


    public void OnPostOnButtonClick()
    {
        volumeController.VolumeOnOff(true);
    }

    public void OnPostOffButtonClick()
    {
        volumeController.VolumeOnOff(false);
    }

    public void OnBackTitleButtonClick()
    {
        SceneManager.LoadScene("Title");
    }
}
