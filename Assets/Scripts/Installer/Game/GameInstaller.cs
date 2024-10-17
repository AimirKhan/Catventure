using Game.World;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [Header("WorldParameters")]
    [SerializeField] private float gravityVelocity = -9.8f;
    
    public override void InstallBindings()
    {
        Bind();
    }

    private void Bind()
    {
        Container.BindInstance(new WorldParams(){ GravityVelocity = gravityVelocity });
    }
}