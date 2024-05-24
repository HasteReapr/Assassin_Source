using RoR2;
using R2API;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System;
using UnityEngine.Networking;

namespace AssassinMod.Survivors.Assassin.Components
{
    public class AssassinPoisonController : NetworkBehaviour
    {
        private static readonly float _INTERVAL = 0.3f;

        public float stacks = 1;
        public GameObject attackerObject;
        public TeamIndex attackerTeam;
        public GameObject victimObject;
        
        private HealthComponent victimHealthComponent;
        private CharacterBody attackerBody;
        private CharacterBody victimBody;
        private DamageInfo info;
        private float timer;
        private float bigTimer;
        private float duration = 10f;
        private float totalDamage;
        private float tickPercent;
        //ticks 3 times a second for 3.5% of the total damage.
        
        public AssassinPoisonController()
        {

        }

        private void Start()
        {
            victimBody = victimObject.GetComponent<CharacterBody>();
            victimHealthComponent = victimBody.GetComponent<HealthComponent>();

            tickPercent = _INTERVAL / duration;
            duration = 10f;
        }

        /*private void FixedUpdate()
        {
            timer += Time.fixedDeltaTime;
            bigTimer += Time.fixedDeltaTime;
            duration -= Time.fixedDeltaTime;
            if (timer >= _INTERVAL && duration >= 0)
            {
                if (victimHealthComponent)
                {
                    info = new DamageInfo()
                    {
                        attacker = attackerBody.gameObject,
                        crit = false,
                        damage = (tickPercent * totalDamage) * stacks,// * victimBody.GetBuffCount(poisonDebuff), //this should be 1% of the total damage since it tics 10 times/second for 10 seconds.
                        damageColorIndex = DamageColorIndex.Heal,
                        force = Vector3.zero,
                        procCoefficient = 0.005f, //0.5% chance,
                        damageType = DamageType.PoisonOnHit,
                        position = victimHealthComponent.body.corePosition,
                        dotIndex = DotController.DotIndex.None,
                        inflictor = gameObject
                    };
                    victimHealthComponent.TakeDamage(info);
                }
                timer = 0f;
            }

            if (bigTimer % 10 == 0)
                stacks--;

            if (duration < 0f)
            {
                Destroy(this);
            }
        }*/

        private void FixedUpdate()
        {
            // If the victim dies, kill ourself.
            if (!this.victimObject)
            {
                if (NetworkServer.active)
                {
                    UnityEngine.Object.Destroy(base.gameObject);
                }
            }

            if (NetworkServer.active)
            {
                if (this.victimObject)
                {
                    if (this.victimBody)
                    {
                        EffectManager.SpawnEffect(AssassinAssets.poisonAilment, new EffectData
                        {
                            origin = this.victimBody.transform.position,
                        }, true);
                    }

                    if (this.victimHealthComponent)
                    {
                        info = new DamageInfo()
                        {
                            attacker = attackerObject,
                            crit = false,
                            damage = tickPercent * totalDamage * stacks,
                            force = Vector3.zero,
                            inflictor = base.gameObject,
                            position = victimBody.corePosition,
                            procCoefficient = 0.01f,
                            damageColorIndex = DamageColorIndex.Poison,
                        };
                        victimHealthComponent.TakeDamage(info);
                    }
                }
            }
        }
    }
}
