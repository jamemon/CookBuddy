using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endgame : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] private float value;
    private void Start()
    {
        AudioManager.instance.PlaySfxWithPitch("End",value);
    }
}
