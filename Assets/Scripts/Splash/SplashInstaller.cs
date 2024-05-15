using Zenject;

namespace Splash
{
    public class SplashInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SplashManager>().AsSingle().NonLazy();
        }
    }
}