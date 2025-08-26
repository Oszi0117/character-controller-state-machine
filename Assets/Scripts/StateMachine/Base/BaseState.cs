using System;
using System.Collections.Generic;
using StateMachine.Interfaces;

namespace StateMachine.Base
{
    public abstract class BaseState : IState
    {
        protected readonly Dictionary<Type, object> References;
        protected BaseState(params object[] args)
        {
            if (args == null || args.Length == 0)
                return;
            
            References = new Dictionary<Type, object>();
            foreach (var obj in args)
            {
                References.Add(obj.GetType(), obj);
            }
        }

        public virtual void Enter() { }

        public virtual void Update() { }

        public virtual void FixedUpdate() { }

        public virtual void Exit() { }
    }
}