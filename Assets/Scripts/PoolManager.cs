using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public ObjectPool Mermanpool;
    public ObjectPool Zombiepool;
    public ObjectPool Bosspool;
    public ObjectPool Coinspool;
    public ObjectPool Patientpool;
    public ObjectPool Scythepool;


    private static PoolManager instance;
    public static PoolManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }
}
