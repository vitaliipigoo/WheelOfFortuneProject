using UnityEngine;
using Zenject;

namespace Services
{
    public class InjectedPrefabsService : IInjectedPrefabsService
    {
        private DiContainer _container;

        public InjectedPrefabsService(DiContainer container) =>
            _container = container;

        public GameObject InstantiatePrefab(Object prefab, Transform parentTransform) =>
            _container.InstantiatePrefab(prefab, parentTransform);
    }
}