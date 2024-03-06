using DemoCubes.Runtime.Components;
using Unity.Entities;
using UnityEngine;

namespace DemoCubes.Runtime.Authoring
{
    public class PlayerMoveInputAuthoring : MonoBehaviour
    {
        private class Baker : Baker<PlayerMoveInputAuthoring>
        {
            public override void Bake(PlayerMoveInputAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);

                AddComponent(entity, new PlayerMoveInput
                {
                    Value = default
                });
            }
        }
    }
}