using CharacterController.States;
using StateMachine;
using StateMachine.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CharacterController
{
    public class PlayerController : MonoBehaviour
    {
        private readonly StateMachine.Base.StateMachine stateMachine = new();
        private InputMap inputMap;

        private bool isCrouching;
        
        private void Awake()
        {
            inputMap = new InputMap();
            inputMap.Player.Enable();
            inputMap.Player.Crouch.performed += HandleCrouched;
            var locomotionState = new LocomotionState(inputMap);
            var crouchState = new CrouchState(inputMap);
            
            At(locomotionState, crouchState, new FuncPredicate(()=> isCrouching));
            At(crouchState, locomotionState, new FuncPredicate(()=> !isCrouching));
            
            stateMachine.SetState(locomotionState);

            return;
            
            void At(IState from, IState to, IPredicate condition)
                => stateMachine.AddTransition(from, to, condition);
            
            void Any(IState to, IPredicate condition)
                => stateMachine.AddAnyTransition(to, condition);
        }

        private void HandleCrouched(InputAction.CallbackContext obj)
            => isCrouching = !isCrouching;

        private void Update()
            => stateMachine.Update();

        private void FixedUpdate()
            => stateMachine.FixedUpdate();
    }
}
