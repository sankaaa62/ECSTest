using DemoCubes.Runtime.Components;
using Unity.Entities;
using UnityEngine;

namespace DemoCubes.Runtime.Authoring
{
    public class MoveSpeedAuthoring : MonoBehaviour
    {
        public float Value;
    
        private class Baker : Baker<MoveSpeedAuthoring>
        {
            public override void Bake(MoveSpeedAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
            
                AddComponent(entity, new PlayerMoveSpeed
                {
                    Value = authoring.Value
                });
            }
        }
    }
}