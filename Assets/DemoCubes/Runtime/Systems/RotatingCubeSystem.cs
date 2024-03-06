using DemoCubes.Runtime.Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace DemoCubes.Runtime.Systems
{
    [BurstCompile]
    [UpdateBefore(typeof(TransformSystemGroup))]
    public partial struct RotatingCubeSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<RotateSpeed>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var rotatingCubeJob = new RotatingCubeJob
            {
                DeltaTime = SystemAPI.Time.DeltaTime
            };

            rotatingCubeJob.Schedule();
        }
        
        [BurstCompile]
        public partial struct RotatingCubeJob : IJobEntity
        {
            public float DeltaTime;
            public void Execute(ref LocalTransform localTransform, in RotateSpeed rotateSpeed)
            {
                localTransform = localTransform.RotateY(rotateSpeed.Value * DeltaTime);
            }
        }
    }
}