using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public PlayerController player;
    public static GameManger instance;
    public GameObject gameOver;
    private void Awake()
    {
        instance = this;
    }
}
