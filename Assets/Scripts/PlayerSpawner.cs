using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private void Start()
    {
        Instantiate(CharacterSelection.instance.currentCharacter.prefab, transform.position, Quaternion.identity);
    }
}
