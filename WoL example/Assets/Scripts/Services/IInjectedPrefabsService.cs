using UnityEngine;

namespace Services
{
    public interface IInjectedPrefabsService
    {
        GameObject InstantiatePrefab(Object prefab, Transform parentTransform);
    }
}