using DemoCubes.Runtime.Components;
using Unity.Entities;
using UnityEngine;

namespace DemoCubes.Runtime.Systems
{
    [UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]
    public partial class GetPlayerInputSystem : SystemBase
    {
        private PlayerInputActions _playerInputActions;
        private Entity _playerEntity;

        protected override void OnCreate()
        {
            RequireForUpdate<PlayerTag>();
            RequireForUpdate<PlayerMoveInput>();

            _playerInputActions = new PlayerInputActions();
        }

        protected override void OnStartRunning()
        {
            _playerInputActions.Enable();
            _playerEntity = SystemAPI.GetSingletonEntity<PlayerTag>();
        }

        protected override void OnUpdate()
        {
            var currentMoveInput = _playerInputActions.Map.Movement.ReadValue<Vector2>();
            SystemAPI.SetSingleton(new PlayerMoveInput { Value = currentMoveInput });
        }

        protected override void OnStopRunning()
        {
            _playerInputActions.Disable();
            _playerEntity = Entity.Null;
        }
    }
}