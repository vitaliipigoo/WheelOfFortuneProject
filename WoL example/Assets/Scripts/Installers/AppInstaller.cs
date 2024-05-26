using Common;
using Services;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class AppInstaller : MonoInstaller
    {
        [SerializeField] private LaunchButton launchButton;
        
        public override void InstallBindings()
        {
            BindServices();
            BindMonoBehaviours();
        }

        private void BindServices()
        {
            Container.Bind<IInjectedPrefabsService>().To<InjectedPrefabsService>().AsSingle();
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