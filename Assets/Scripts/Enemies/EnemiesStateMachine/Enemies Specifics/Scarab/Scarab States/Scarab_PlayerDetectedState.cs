using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Avocado.CoreSystem
{
    public class Scarab_PlayerDetectedState : PlayerDetectedState
    {
        #region References
        private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
        private Movement movement;
        private CollisionSenses CollisionSenses { get => collisionSenses ?? core.GetCoreComponent(ref collisionSenses); }
        private CollisionSenses collisionSenses;

        private Scarab scarab;
        #endregion

        #region Constructor
        public Scarab_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetectedState stateData, Scarab scarab) : base(entity, stateMachine, animBoolName, stateData)
        {
            this.scarab = scarab;
        }
        #endregion

        #region Override Functions
        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            //Condition that detected if player is enough close to do the action
            if (performCloseRangeAction)
            {
                stateMachine.ChangeState(scarab.meleeAttackState);
            }
            else if (performLongRangeAction) //Condition that if not a player detected, then trasition back to Idle
            {
                stateMachine.ChangeState(scarab.chargeState);
            }
            else if (!isPlayerInMaxAgroRange)
            {
                stateMachine.ChangeState(scarab.lookForPlayerState);
            }
            else if (!isDetectingLedge)
            {
                Movement?.Flip();
                stateMachine.ChangeState(scarab.moveState);
            }

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
        #endregion
    }
}