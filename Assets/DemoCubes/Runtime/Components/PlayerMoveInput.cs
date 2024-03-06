using Unity.Entities;
using Unity.Mathematics;

namespace DemoCubes.Runtime.Components
{
    public partial struct PlayerMoveInput : IComponentData
    {
        public float2 Value;
    }
}