using DemoCubes.Runtime.Components;
using Unity.Entities;
using UnityEngine;

namespace DemoCubes.Runtime.Authoring
{
    public class RotateSpeedAuthoring : MonoBehaviour
    {
        public float Value;
    
        private class Baker : Baker<RotateSpeedAuthoring>
        {
            public override void Bake(RotateSpeedAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
            
                AddComponent(entity, new RotateSpeed
                {
                    Value = authoring.Value
                });
            }
        }
    }
}