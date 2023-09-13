using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private Hud _hud;

    private void Awake()
    {
        Services();
    }

    private void Services()
    {
        _hud.Initialize();
    }
}
