using DemoCubes.Runtime.Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace DemoCubes.Runtime.Systems
{
    [BurstCompile]
    [UpdateBefore(typeof(TransformSystemGroup))]
    public partial struct PlayerMoveSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<PlayerMoveInput>();
            state.RequireForUpdate<PlayerMoveSpeed>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;
            new PlayerMoveJob
            {
                DeltaTime = deltaTime
            }.Schedule();
        }
    }

    public partial struct PlayerMoveJob : IJobEntity
    {
        public float DeltaTime;

        private void Execute(ref LocalTransform transform, in PlayerMoveInput moveInput,
            in PlayerMoveSpeed moveSpeed)
        {
            transform.Position.xz += moveInput.Value * moveSpeed.Value * DeltaTime;
            if (math.lengthsq(moveInput.Value) > float.Epsilon)
            {
                var forward = new float3(moveInput.Value.x, 0f, moveInput.Value.y);
                transform.Rotation = quaternion.LookRotation(forward, math.up());
            }
        }
    }
}