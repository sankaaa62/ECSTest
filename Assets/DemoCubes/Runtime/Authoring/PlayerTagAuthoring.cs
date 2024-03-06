using DemoCubes.Runtime.Components;
using Unity.Entities;
using UnityEngine;

namespace DemoCubes.Runtime.Authoring
{
    public class PlayerTagAuthoring : MonoBehaviour
    {
        private class Baker : Baker<PlayerTagAuthoring>
        {
            public override void Bake(PlayerTagAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);

                AddComponent(entity, new PlayerTag { });
            }
        }
    }
}