using System;
using System.Collections;
using System.Collections.Generic;
using Catventure;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Catventure.Input
{
    public class RunPerform : MonoBehaviour
    {
        [Inject] private IPlayerParams playerParams;
    
        [SerializeField] private float runModifier = 1.2f;
        [SerializeField] private InputActionReference playerRun;

        private void OnEnable()
        {
            playerRun.action.performed += (run => playerParams.PlayerSpeed.Value *= runModifier);
            playerRun.action.canceled += (run => playerParams.PlayerSpeed.Value /= runModifier);
        }
        private void OnDisable()
        {
            playerRun.action.performed -= (run => playerParams.PlayerSpeed.Value *= runModifier);
            playerRun.action.canceled -= (run => playerParams.PlayerSpeed.Value /= runModifier);
        }
    }
}