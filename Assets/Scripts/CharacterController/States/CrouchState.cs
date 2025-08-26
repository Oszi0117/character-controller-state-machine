using System.Collections.Generic;
using StateMachine.Base;
using UnityEngine;

namespace CharacterController.States
{
    public class CrouchState : BaseState
    {
        private readonly InputMap inputMap;

        public CrouchState(params object[] args) : base(args)
        {
            inputMap = References.GetValueOrDefault(typeof(InputMap)) as InputMap;
        }

        public override void Enter()
        {
            Debug.Log("Enter Crouch State");
        }
    }
}