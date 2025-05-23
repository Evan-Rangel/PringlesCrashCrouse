﻿using UnityEngine;

/*---------------------------------------------------------------------------------------------
Este script Componente del Core que se encarga de detectar colisiones relevantes como suelo, 
paredes, techos, bordes.
---------------------------------------------------------------------------------------------*/

namespace Avocado.CoreSystem
{
	public class CollisionSenses : CoreComponent
    {
        private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
        private Movement movement;

        #region Check Transforms Variables

        // Propiedades que aseguran que los Transforms estén correctamente asignados o muestran un error si no.
        public Transform GroundCheck
        {
            get => GenericNotImplementedError<Transform>.TryGet(groundCheck, core.transform.parent.name);
            private set => groundCheck = value;
        }
        public Transform WallCheck
        {
            get => GenericNotImplementedError<Transform>.TryGet(wallCheck, core.transform.parent.name);
            private set => wallCheck = value;
        }
        public Transform LedgeCheckHorizontal
        {
            get => GenericNotImplementedError<Transform>.TryGet(ledgeCheckHorizontal, core.transform.parent.name);
            private set => ledgeCheckHorizontal = value;
        }
        public Transform LedgeCheckVertical
        {
            get => GenericNotImplementedError<Transform>.TryGet(ledgeCheckVertical, core.transform.parent.name);
            private set => ledgeCheckVertical = value;
        }
        public Transform CeilingCheck
        {
            get => GenericNotImplementedError<Transform>.TryGet(ceilingCheck, core.transform.parent.name);
            private set => ceilingCheck = value;
        }

        public float GroundCheckRadius { get => groundCheckRadius; set => groundCheckRadius = value; }
        public float WallCheckDistance { get => wallCheckDistance; set => wallCheckDistance = value; }
        public LayerMask WhatIsGround { get => whatIsGround; set => whatIsGround = value; }

        [SerializeField] private Transform groundCheck;
        [SerializeField] private Transform wallCheck;
        [SerializeField] private Transform ledgeCheckHorizontal;
        [SerializeField] private Transform ledgeCheckVertical;
        [SerializeField] private Transform ceilingCheck;

        [SerializeField] private float groundCheckRadius;
        [SerializeField] private float wallCheckDistance;
        [SerializeField] private LayerMask whatIsGround;

        #endregion

        // Propiedades para detectar estados de colisiones
        public bool Ceiling
        {
            get => Physics2D.OverlapCircle(CeilingCheck.position, groundCheckRadius, whatIsGround);
        }

        public bool Ground
        {
            get => Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, whatIsGround);
        }

        public bool WallFront
        {
            get => Physics2D.Raycast(WallCheck.position, Vector2.right * Movement.FacingDirection, wallCheckDistance, whatIsGround);
        }

        public bool LedgeHorizontal
        {
            get => Physics2D.Raycast(LedgeCheckHorizontal.position, Vector2.right * Movement.FacingDirection, wallCheckDistance, whatIsGround);
        }

        public bool LedgeVertical
        {
            get => Physics2D.Raycast(LedgeCheckVertical.position, Vector2.down, wallCheckDistance, whatIsGround);
        }

        public bool WallBack
        {
            get => Physics2D.Raycast(WallCheck.position, Vector2.right * -Movement.FacingDirection, wallCheckDistance, whatIsGround);
        }
    }
}
