using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager _Instance = null;

    public int PlayerIndex;
    public int PlayerWeaponLevel;
    public float HurtCoolDownTime;


    private void Awake()
    {
        _Instance = this;
    }

    private void Start()
    {
        HurtCoolDownTime = 1;
    }
}
