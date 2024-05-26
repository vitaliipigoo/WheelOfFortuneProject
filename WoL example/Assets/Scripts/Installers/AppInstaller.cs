using Services;
using Zenject;

namespace Installers
{
    public class AppInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInjectedPrefabsService>().To<InjectedPrefabsService>().AsSingle();
        }
    }
}