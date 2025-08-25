using UnityEngine;

namespace CharacterController
{
    public class PlayerController : MonoBehaviour
    {
        private readonly InputMap inputMap = new();
        private readonly StateMachine.Base.StateMachine stateMachine = new();
        
        private void Awake()
        {
            
        }

        private void Update()
            => stateMachine.Update();

        private void FixedUpdate()
            => stateMachine.FixedUpdate();
    }
}
