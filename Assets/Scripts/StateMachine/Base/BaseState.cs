using System;
using System.Collections.Generic;
using StateMachine.Interfaces;

namespace StateMachine.Base
{
    public abstract class BaseState : IState
    {
        protected Dictionary<Type, object> Members;
        
        protected BaseState(params object[] args)
        {
            if (args == null || args.Length == 0)
                return;
            
            Members = new Dictionary<Type, object>();
            foreach (var obj in args)
            {
                Members.TryAdd(obj.GetType(), obj);
            }
        }

        public virtual void Enter() { }

        public virtual void Update() { }

        public virtual void FixedUpdate() { }

        public virtual void Exit() { }
    }
}