﻿using ECS.Movement.Systems;
using ECS.Views.Systems;
using JCMG.EntitasRedux;
using UnityEngine;

namespace ECS
{
    public class GameController : MonoBehaviour
    {
        private Systems _systems;
        private Contexts _contexts;

        private void Start()
        {
            _contexts = Contexts.SharedInstance;
            _systems = CreateSystems(_contexts);
            _systems.Initialize();
        }

        private void Update()
        {
            _systems.Execute();
            _systems.Cleanup();
        }

        private static Systems CreateSystems(Contexts contexts)
        {
            return new Feature("Systems")
                .Add(new ViewSystems(contexts))
                .Add(new PositionSystems(contexts));
        }
    }
}