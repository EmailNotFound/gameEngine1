using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] public GameObject target;
    [SerializeField] public float speed;

    Volume volume;
    Vignette vignette;
    Player player;
    
    public static bool IsVolumeOn;
    public bool Onhit;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        volume = GetComponent<Volume>();
        volume.profile.TryGet(out vignette);
    }

    private void Update()
    {
        if (target != null)
        {
            vignette.intensity.Override(1 - player.GetHpRatio());
            var targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, -10);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.unscaledDeltaTime);
        }

        if(IsVolumeOn == false)
        {
            volume.enabled = false;
        }
        else
        {
            volume.enabled = true;
        }
    }


    public void Shake()
    {
        transform.position = new Vector3(transform.position.x + 1, transform.position.y - 2, -10);
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
