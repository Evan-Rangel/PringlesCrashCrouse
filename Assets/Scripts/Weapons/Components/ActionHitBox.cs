using Avocado.CoreSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Avocado.Weapons.Components
{
    public class ActionHitBox : WeaponComponent<ActionHitBoxData, AttackActionHitBox>
    {
        public event Action<Collider2D[]> OnDetectedCollider2D;

        private CoreComp<CoreSystem.Movement> movement;

        private Vector2 offset;

        private Collider2D[] detected;

        private void HandleAttackAction()
        {
            offset.Set(transform.position.x + (currentAttackData.HitBox.center.x * movement.Comp.FacingDirection), transform.position.y + currentAttackData.HitBox.center.y);

            detected = Physics2D.OverlapBoxAll(offset, currentAttackData.HitBox.size, 0f, data.DetectableLayers);
            Debug.Log(detected.Length);
            if (detected.Length == 0)
            {
                return;
            }

            OnDetectedCollider2D?.Invoke(detected);
        }

        protected override void Start()
        {
            base.Start();
            if (transform.root.name== "LocalGamePlayer")
            {

                movement = new CoreComp<CoreSystem.Movement>(Core);

                eventHandler.OnAttackAction += HandleAttackAction;
            }

        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (transform.root.name == "LocalGamePlayer")

                eventHandler.OnAttackAction -= HandleAttackAction;
        }

        private void OnDrawGizmosSelected()
        {
            if (data == null)
            {
                return;
            }

            foreach (var item in data.AttackData)
            {
                if (!item.Debug)
                {
                    continue;
                }

                Gizmos.DrawWireCube(transform.position + (Vector3)item.HitBox.center, item.HitBox.size);
            }
        }
    }
}