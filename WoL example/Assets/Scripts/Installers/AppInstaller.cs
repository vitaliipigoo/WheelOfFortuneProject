using Common;
using Services;
using UnityEngine;
using Wheel_of_Luck.Scripts.Configurations;
using Wheel_of_Luck.Services;
using Zenject;

namespace Installers
{
    public class AppInstaller : MonoInstaller
    {
        [SerializeField] private LaunchButton launchButton;
        [SerializeField] private WheelOfLuckConfiguration wofConfiguration;
        
        public override void InstallBindings()
        {
            BindConfigurations();
            BindServices();
            BindMonoBehaviours();
        }

        private void BindConfigurations()
        {
            Container.BindInstance(wofConfiguration).AsSingle().NonLazy();
        }

        private void BindServices()
        {
            Container.Bind<IInjectedPrefabsService>().To<InjectedPrefabsService>().AsSingle();
            Container.Bind<IWheelOfLuckService>().To<WheelOfLuckService>().AsSingle().NonLazy();
        }

        private void BindMonoBehaviours()
        {
            InitGameObjectWithComponent<LaunchButton>(launchButton);
        }
        
        private void InitGameObjectWithComponent<T>(Object prefab) where T : Component
        {
            var canvas = FindObjectOfType<Canvas>().transform;
            Container.InstantiatePrefabForComponent<T>(prefab, canvas);
        }
    }
}