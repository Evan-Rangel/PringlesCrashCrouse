using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Avocado.CoreSystem
{
    public class AttackState : State
    {
        #region References
        private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
        private Movement movement;
        #endregion

        #region Flags
        protected bool isAnimationFinished;
        protected bool isPlayerInMinAgroRange;
        #endregion

        #region Transforms
        protected Transform attackPosition;
        #endregion


        //Constructor
        //---This means is it's going to pass the entity state machine and animation variables that we get when we call this contructor on to our base clase which is "State" so now if we want to add anything else to the construcot, we can go ahead and do that.---//
        public AttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition) : base(entity, stateMachine, animBoolName)
        {
            this.attackPosition = attackPosition;
        }

        //---With override, we can reride the function on the father script with out changing the base funtion (yo can override function with the "Virtual")---//
        //-------OVERRIDES-------//
        public override void DoChecks()
        {
            base.DoChecks();

            //Detect Player
            isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
        }

        public override void Enter()
        {
            base.Enter();

            //Animation
            entity.atsm.attackState = this;
            isAnimationFinished = false;
            //Velocity
            Movement?.SetVelocityX(0f);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Movement?.SetVelocityX(0f);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
        //-------END OVERRIDES-------//

        //-------OTHER FUNCTIONS-------//
        //Virtual TriggerAttack
        public virtual void TriggerAttack()
        {

        }
        //Virtual FinishAttack
        public virtual void FinishAttack()
        {
            //Animation ends
            isAnimationFinished = true;
        }
        //-------END OTHERS FUNCTIONS-------//
    }
}