using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Avocado.CoreSystem
{
    public class Archer_IdleState : IdleState
    {
        //Data reference
        private SpaceArcher archer;

        //Constructor
        //---This means is it's going to pass the entity state machine and animation variables that we get when we call this contructor on to our base clase which is "State" so now if we want to add anything else to the construcot, we can go ahead and do that.---//
        public Archer_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, SpaceArcher archer) : base(entity, stateMachine, animBoolName, stateData)
        {
            this.archer = archer;
        }

        //---With override, we can reride the function on the father script with out changing the base funtion (yo can override function with the "Virtual")---//
        //-------OVERRIDES-------//
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

            //Conditions thst if we detect a player, change to playerdetected state
            if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(archer.playerDetectedState);
            }
            //Condition that if the idletime is over transition to movestate
            else if (isIdleTimeOver)
            {
                stateMachine.ChangeState(archer.moveState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
        public override void DoChecks()
        {
            base.DoChecks();
        }
        //-------END OVERRIDES-------//
    }
}