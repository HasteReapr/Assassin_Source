using RoR2;
using UnityEngine;
using AssassinMod.Modules;
using System;
using RoR2.Projectile;
using static R2API.DamageAPI;

namespace AssassinMod.Survivors.Assassin
{
    public static class AssassinAssets
    {
        // Networked Sound Events
        internal static NetworkSoundEventDef daggerThrow;
        internal static NetworkSoundEventDef bottleShatter;
        internal static NetworkSoundEventDef pearl_warp;

        // Particle Effects
        internal static GameObject poisonExplosionEffect;
        internal static GameObject venomExplosionEffect;
        internal static GameObject smokeExplosionEffect;
        internal static GameObject pearlImpactEffect;
        internal static GameObject knifeTrail;
        internal static GameObject masteryKnifeTrail;
        internal static GameObject grandKnifeTrail;
        internal static GameObject poisonTrail;
        internal static GameObject venomTrail;
        internal static GameObject recursiveTrail;
        internal static GameObject smokeTrail;
        internal static GameObject pearlTrail;
        internal static GameObject poisonAilment;

        // Projectiles
        internal static GameObject dagger;
        internal static GameObject cutter;
        internal static GameObject poison;
        internal static GameObject virulentPoison;
        internal static GameObject virulentDOTZone;
        internal static GameObject clusterPoison;
        internal static GameObject recursivePoison;
        internal static GameObject enderPearl;
        internal static GameObject cloudyPotion;

        // Skin Daggers
        internal static GameObject masteryDagger;
        internal static GameObject grandMasteryDagger;

        // Emote API compat
        internal static GameObject emoteAPISkeleton;
        //internal static GameObject emoteAPIDecoySkeleton;

        // Damage types
        public static ModdedDamageType daggerDmgType = ReserveDamageType();
        public static ModdedDamageType poisonDmgType = ReserveDamageType();
        public static ModdedDamageType smokeDmgType = ReserveDamageType();
        public static ModdedDamageType backStabDmg = ReserveDamageType();

        private static AssetBundle _assetBundle;

        public static void Init(AssetBundle assetBundle)
        {
            _assetBundle = assetBundle;

            string assassin_skele = "rogue_emote_skeleton.prefab";
            System.Random rnd = new System.Random();
            if (rnd.Next(0, 100) <= 2)
            {
                assassin_skele = "rogue_emote_skeleton_tiny.prefab";
                Log.Info("Little guy :3");
            }
            emoteAPISkeleton = assetBundle.LoadAsset<UnityEngine.GameObject>(assassin_skele);
            //emoteAPIDecoySkeleton = assetBundle.LoadAsset<UnityEngine.GameObject>(assassin_skele);

            CreateEffects();

            CreateProjectiles();
        }

        #region effects
        private static void CreateEffects()
        {
            poisonExplosionEffect = AsnAssets.LoadEffect(_assetBundle, "poisonExplosionEffect", "Play_bottle_break");
            venomExplosionEffect = AsnAssets.LoadEffect(_assetBundle, "virulentExplosionEffect", "Play_bottle_break");
            smokeExplosionEffect = AsnAssets.LoadEffect(_assetBundle, "smokeExplosionEffect", "Play_bottle_break");
            pearlImpactEffect = AsnAssets.LoadEffect(_assetBundle, "enderPearlEffect", "Play_ender_warp");

            knifeTrail = _assetBundle.LoadAsset<GameObject>("knife_trail");
            masteryKnifeTrail = _assetBundle.LoadAsset<GameObject>("masteryAura");
            grandKnifeTrail = _assetBundle.LoadAsset<GameObject>("grandMasteryAura");
            poisonTrail = _assetBundle.LoadAsset<GameObject>("poison_trail");
            venomTrail = _assetBundle.LoadAsset<GameObject>("venom_trail");
            recursiveTrail = _assetBundle.LoadAsset<GameObject>("recursive_trail");
            smokeTrail = _assetBundle.LoadAsset<GameObject>("smokeBomb_trial");
            pearlTrail = _assetBundle.LoadAsset<GameObject>("polarity_Embers");
            poisonAilment = _assetBundle.LoadAsset<GameObject>("poison_ailment");

            bottleShatter = Content.CreateAndAddNetworkSoundEventDef("Play_bottle_break");
            daggerThrow = Content.CreateAndAddNetworkSoundEventDef("Play_dagger_sfx");
            pearl_warp = Content.CreateAndAddNetworkSoundEventDef("Play_ender_warp");
        }
        #endregion effects

        #region projectiles
        private static void CreateProjectiles()
        {
            CreateDagger();
            Content.AddProjectilePrefab(dagger);
            
            CreateCutter();
            Content.AddProjectilePrefab(cutter);

            CreatePoison();
            Content.AddProjectilePrefab(poison);

            virulentDOTZone = _assetBundle.LoadAsset<GameObject>("virulent_DOT_Zone");
            Content.AddProjectilePrefab(virulentDOTZone);

            CreateVirulentPoison();
            Content.AddProjectilePrefab(virulentPoison);

            CreateRecursivePoison();
            Content.AddProjectilePrefab(clusterPoison);

            CreateRecursiveClusterPoison();
            Content.AddProjectilePrefab(recursivePoison);

            CreateEnderPearl();
            Content.AddProjectilePrefab(enderPearl);

            CreateCloudyPotion();
            Content.AddProjectilePrefab(cloudyPotion);
        }

        private static void CreateDagger()
        {
            dagger = AsnAssets.CloneProjectilePrefab("Bandit2ShivProjectile", "dagger");

            dagger.GetComponent<ProjectileDamage>().damageType = DamageType.Generic;
            dagger.AddComponent<ModdedDamageTypeHolderComponent>().Add(daggerDmgType);
            dagger.GetComponent<ProjectileSingleTargetImpact>().hitSoundString = "Play_dagger_impact_ground";
            dagger.GetComponent<ProjectileSingleTargetImpact>().enemyHitSoundString = "Play_dagger_impact_enemy";

            Rigidbody daggerRigidBody = dagger.GetComponent<Rigidbody>();
            if (!daggerRigidBody)
            {
                daggerRigidBody = dagger.AddComponent<Rigidbody>();
            }

            ProjectileController daggerController = dagger.GetComponent<ProjectileController>();
            daggerController.rigidbody = daggerRigidBody;
            daggerController.rigidbody.useGravity = true;
            daggerController.procCoefficient = 0.85f;

            daggerController.GetComponent<ProjectileStickOnImpact>().alignNormals = false;

            daggerController.ghostPrefab = AsnAssets.CreateProjectileGhostPrefab(_assetBundle, "mdlKnife");
            masteryDagger = AsnAssets.CreateProjectileGhostPrefab(_assetBundle, "mdlKnifeMastery");
            grandMasteryDagger = AsnAssets.CreateProjectileGhostPrefab(_assetBundle, "mdlKnifeGrandMastery");

            var knifeTrailDupe = knifeTrail;
            knifeTrailDupe.transform.parent = daggerController.ghostPrefab.transform;

            var masteryTrailDupe = masteryKnifeTrail;
            masteryTrailDupe.transform.parent = masteryDagger.transform;

            var grandTrailDupe = grandKnifeTrail;
            grandTrailDupe.transform.parent = grandMasteryDagger.transform;

            UnityEngine.Object.Destroy(dagger.transform.GetChild(0).gameObject);
        }

        private static void CreateCutter()
        {
            cutter = AsnAssets.CloneProjectilePrefab("Bandit2ShivProjectile", "cutter");

            cutter.GetComponent<ProjectileDamage>().damageType = DamageType.Generic;
            cutter.AddComponent<ModdedDamageTypeHolderComponent>().Add(daggerDmgType);
            cutter.GetComponent<ProjectileSingleTargetImpact>().hitSoundString = "Play_dagger_impact_ground";
            cutter.GetComponent<ProjectileSingleTargetImpact>().enemyHitSoundString = "Play_dagger_impact_enemy";

            Rigidbody daggerRigidBody = cutter.GetComponent<Rigidbody>();
            if (!daggerRigidBody)
            {
                daggerRigidBody = cutter.AddComponent<Rigidbody>();
            }

            ProjectileController daggerController = cutter.GetComponent<ProjectileController>();
            daggerController.rigidbody = daggerRigidBody;
            daggerController.rigidbody.useGravity = true;
            daggerController.procCoefficient = 0.8f;

            daggerController.GetComponent<ProjectileStickOnImpact>().alignNormals = false;

            daggerController.ghostPrefab = AsnAssets.CreateProjectileGhostPrefab(_assetBundle, "mdlKnife");
            masteryDagger = AsnAssets.CreateProjectileGhostPrefab(_assetBundle, "mdlKnifeMastery");
            grandMasteryDagger = AsnAssets.CreateProjectileGhostPrefab(_assetBundle, "mdlKnifeGrandMastery");

            var knifeTrailDupe = knifeTrail;
            knifeTrailDupe.transform.parent = daggerController.ghostPrefab.transform;

            var masteryTrailDupe = masteryKnifeTrail;
            masteryTrailDupe.transform.parent = masteryDagger.transform;

            var grandTrailDupe = grandKnifeTrail;
            grandTrailDupe.transform.parent = grandMasteryDagger.transform;

            UnityEngine.Object.Destroy(cutter.transform.GetChild(0).gameObject);
        }

        private static void CreatePoison()
        {
            poison = AsnAssets.CloneProjectilePrefab("CommandoGrenadeProjectile", "poison");

            poison.AddComponent<ModdedDamageTypeHolderComponent>().Add(poisonDmgType);

            Rigidbody poisonRigidBody = poison.GetComponent<Rigidbody>();
            if (!poisonRigidBody)
            {
                poisonRigidBody = poison.AddComponent<Rigidbody>();
            }

            ProjectileImpactExplosion poisonExplosion = poison.GetComponent<ProjectileImpactExplosion>();
            InitializeImpactExplosion(poisonExplosion);

            //EffectComponent effectComponent = AsnAssets.poisonExplosionEffect.GetComponent<EffectComponent>();
            //effectComponent.soundName = "assassinBottleBreak";

            poisonExplosion.GetComponent<ModdedDamageTypeHolderComponent>().Add(poisonDmgType);
            poisonExplosion.blastRadius = 6f;
            poisonExplosion.destroyOnEnemy = true;
            poisonExplosion.destroyOnWorld = true;
            poisonExplosion.impactEffect = poisonExplosionEffect;
            poisonExplosion.lifetime = 12f;
            poisonExplosion.timerAfterImpact = true;
            poisonExplosion.lifetimeAfterImpact = 0.5f;

            ProjectileController poisonController = poison.GetComponent<ProjectileController>();
            if (_assetBundle.LoadAsset<GameObject>("mdlPoison") != null) poisonController.ghostPrefab = AsnAssets.CreateProjectileGhostPrefab(_assetBundle, "mdlPoison");

            //poisonController.ghostPrefab.transform.Find("poison_trail").GetComponent<ParticleSystemRenderer>().SetMaterial(AsnAssets.smokeTrailMat);

            var poisonTrailDupe = poisonTrail;
            poisonTrailDupe.transform.parent = poisonController.ghostPrefab.transform;

            poisonController.rigidbody = poisonRigidBody;
            poisonController.rigidbody.useGravity = true;
            poisonController.procCoefficient = 0.5f;
        }

        private static void CreateVirulentPoison()
        {
            virulentPoison = AsnAssets.CloneProjectilePrefab("CommandoGrenadeProjectile", "virulentVenom");

            Rigidbody virulentRigidBody = virulentPoison.GetComponent<Rigidbody>();
            if (!virulentRigidBody)
            {
                virulentRigidBody = virulentPoison.AddComponent<Rigidbody>();
            }

            ProjectileImpactExplosion virulentExplosion = virulentPoison.GetComponent<ProjectileImpactExplosion>();
            InitializeImpactExplosion(virulentExplosion);

            virulentExplosion.blastRadius = 6f;
            virulentExplosion.destroyOnEnemy = true;
            virulentExplosion.destroyOnWorld = true;
            virulentExplosion.impactEffect = venomExplosionEffect;
            virulentExplosion.lifetime = 12f;
            virulentExplosion.timerAfterImpact = true;
            virulentExplosion.lifetimeAfterImpact = 10f;
            //virulentExplosion.childrenCount = 1;
            //virulentExplosion.childrenProjectilePrefab = virulentDOTZone;
            virulentPoison.AddComponent<virulentOnHit>();

            ProjectileController virulentController = virulentPoison.GetComponent<ProjectileController>();
            if (_assetBundle.LoadAsset<GameObject>("mdlVenom") != null) virulentController.ghostPrefab = AsnAssets.CreateProjectileGhostPrefab(_assetBundle, "mdlVenom");

            var poisonTrailDupe = venomTrail;
            poisonTrailDupe.transform.parent = virulentController.ghostPrefab.transform;

            virulentController.rigidbody = virulentRigidBody;
            virulentController.rigidbody.useGravity = true;
            virulentController.procCoefficient = 0.5f;
        }

        internal class virulentOnHit : MonoBehaviour, IProjectileImpactBehavior
        {
            public void OnProjectileImpact(ProjectileImpactInfo impactInfo)
            {
                ProjectileController recursiveCtrl = GetComponent<ProjectileController>();
                Vector3 impactPos = recursiveCtrl.transform.position;

                var characterBody = recursiveCtrl.owner.GetComponent<CharacterBody>();

                FireProjectileInfo info = new FireProjectileInfo()
                {
                    owner = characterBody.gameObject,
                    damage = 3.75f * characterBody.damage,
                    force = 0,
                    position = new Vector3(impactPos.x, impactPos.y, impactPos.z),
                    rotation = Quaternion.Euler(0, 0, 0),
                    projectilePrefab = virulentDOTZone,
                    speedOverride = 0,
                    //damageTypeOverride = (DamageType?)poisonDmgType
                };
                ProjectileManager.instance.FireProjectile(info);
            }
        }

        private static void CreateRecursivePoison()
        {
            clusterPoison = AsnAssets.CloneProjectilePrefab("CommandoGrenadeProjectile", "recursivePoison");

            clusterPoison.AddComponent<ModdedDamageTypeHolderComponent>().Add(poisonDmgType);
            clusterPoison.AddComponent<recursiveOnHit>();

            Rigidbody poisonRigidBody = clusterPoison.GetComponent<Rigidbody>();
            if (!poisonRigidBody)
            {
                poisonRigidBody = clusterPoison.AddComponent<Rigidbody>();
            }

            ProjectileImpactExplosion poisonExplosion = clusterPoison.GetComponent<ProjectileImpactExplosion>();
            InitializeImpactExplosion(poisonExplosion);

            //EffectComponent effectComponent = AsnAssets.poisonExplosionEffect.GetComponent<EffectComponent>();
            //effectComponent.soundName = "assassinBottleBreak";

            poisonExplosion.GetComponent<ModdedDamageTypeHolderComponent>().Add(poisonDmgType);
            poisonExplosion.blastRadius = 6f;
            poisonExplosion.destroyOnEnemy = true;
            poisonExplosion.destroyOnWorld = true;
            poisonExplosion.impactEffect = poisonExplosionEffect;
            //poisonExplosion.explosionSoundString = AsnAssets.poisonExplosionEffect;
            poisonExplosion.lifetime = 12f;
            poisonExplosion.timerAfterImpact = true;
            poisonExplosion.lifetimeAfterImpact = 0.5f;

            ProjectileController poisonController = clusterPoison.GetComponent<ProjectileController>();
            if (_assetBundle.LoadAsset<GameObject>("mdlRecursivePoison") != null) poisonController.ghostPrefab = AsnAssets.CreateProjectileGhostPrefab(_assetBundle, "mdlRecursivePoison");

            poisonController.rigidbody = poisonRigidBody;
            poisonController.rigidbody.useGravity = true;
            poisonController.procCoefficient = 0.5f;
        }

        internal class recursiveOnHit : MonoBehaviour, IProjectileImpactBehavior
        {
            public void OnProjectileImpact(ProjectileImpactInfo impactInfo)
            {
                ProjectileController recursiveCtrl = GetComponent<ProjectileController>();
                Vector3 impactPos = recursiveCtrl.transform.position;

                var characterBody = recursiveCtrl.owner.GetComponent<CharacterBody>();
                if (Util.HasEffectiveAuthority(characterBody.gameObject))
                {
                    FireProjectileInfo info = new FireProjectileInfo()
                    {
                        owner = characterBody.gameObject,
                        damage = (AssassinStaticValues.poisonDamageCoef * characterBody.damage) * 0.3f,
                        //damageTypeOverride = (DamageType?)poisonDmgType,
                        force = 0,
                        position = new Vector3(impactPos.x, impactPos.y + 2, impactPos.z),
                        rotation = Quaternion.Euler(0, 0, 0),
                        projectilePrefab = poison,
                        speedOverride = 16,
                        //damageTypeOverride = (DamageType?)poisonDmgType
                    };
                    FireProjectileInfo info2 = new FireProjectileInfo()
                    {
                        owner = characterBody.gameObject,
                        damage = (AssassinStaticValues.poisonDamageCoef * characterBody.damage) * 0.3f,
                        //damageTypeOverride = (DamageType?)poisonDmgType,
                        force = 0,
                        position = new Vector3(impactPos.x, impactPos.y + 2, impactPos.z),
                        rotation = Quaternion.Euler(0, 120, 0),
                        projectilePrefab = poison,
                        speedOverride = 16,
                        //damageTypeOverride = (DamageType?)poisonDmgType
                    };
                    FireProjectileInfo info3 = new FireProjectileInfo()
                    {
                        owner = characterBody.gameObject,
                        damage = (AssassinStaticValues.poisonDamageCoef * characterBody.damage) * 0.3f,
                        //damageTypeOverride = (DamageType?)poisonDmgType,
                        force = 0,
                        position = new Vector3(impactPos.x, impactPos.y + 2, impactPos.z),
                        rotation = Quaternion.Euler(0, 240, 0),
                        projectilePrefab = poison,
                        speedOverride = 16,
                        //damageTypeOverride = (DamageType?)poisonDmgType
                    };

                    ProjectileManager.instance.FireProjectile(info);
                    ProjectileManager.instance.FireProjectile(info2);
                    ProjectileManager.instance.FireProjectile(info3);
                }
            }
        }

        private static void CreateRecursiveClusterPoison()
        {
            recursivePoison = AsnAssets.CloneProjectilePrefab("CommandoGrenadeProjectile", "recursivePoison");

            recursivePoison.AddComponent<ModdedDamageTypeHolderComponent>().Add(poisonDmgType);
            recursivePoison.AddComponent<recursiveClusterOnHit>();

            Rigidbody poisonRigidBody = recursivePoison.GetComponent<Rigidbody>();
            if (!poisonRigidBody)
            {
                poisonRigidBody = recursivePoison.AddComponent<Rigidbody>();
            }

            ProjectileImpactExplosion poisonExplosion = recursivePoison.GetComponent<ProjectileImpactExplosion>();
            InitializeImpactExplosion(poisonExplosion);

            //EffectComponent effectComponent = AsnAssets.poisonExplosionEffect.GetComponent<EffectComponent>();
            //effectComponent.soundName = "assassinBottleBreak";

            poisonExplosion.GetComponent<ModdedDamageTypeHolderComponent>().Add(poisonDmgType);
            poisonExplosion.blastRadius = 6f;
            poisonExplosion.destroyOnEnemy = true;
            poisonExplosion.destroyOnWorld = true;
            poisonExplosion.impactEffect = poisonExplosionEffect;
            //poisonExplosion.explosionSoundString = AsnAssets.poisonExplosionEffect;
            poisonExplosion.lifetime = 12f;
            poisonExplosion.timerAfterImpact = true;
            poisonExplosion.lifetimeAfterImpact = 0.5f;

            ProjectileController poisonController = recursivePoison.GetComponent<ProjectileController>();
            if (_assetBundle.LoadAsset<GameObject>("mdlRecursivePoison") != null) poisonController.ghostPrefab = AsnAssets.CreateProjectileGhostPrefab(_assetBundle, "mdlRecursivePoison");

            poisonController.rigidbody = poisonRigidBody;
            poisonController.rigidbody.useGravity = true;
            poisonController.procCoefficient = 0.5f;
        }

        internal class recursiveClusterOnHit : MonoBehaviour, IProjectileImpactBehavior
        {
            public void OnProjectileImpact(ProjectileImpactInfo impactInfo)
            {
                ProjectileController recursiveCtrl = GetComponent<ProjectileController>();
                Vector3 impactPos = recursiveCtrl.transform.position;

                var characterBody = recursiveCtrl.owner.GetComponent<CharacterBody>();
                if (Util.HasEffectiveAuthority(characterBody.gameObject))
                {
                    FireProjectileInfo info = new FireProjectileInfo()
                    {
                        owner = characterBody.gameObject,
                        damage = (AssassinStaticValues.poisonDamageCoef * characterBody.damage) * 0.3f,
                        //damageTypeOverride = (DamageType?)poisonDmgType,
                        force = 0,
                        position = new Vector3(impactPos.x, impactPos.y + 2, impactPos.z),
                        rotation = Quaternion.Euler(0, 0, 0),
                        projectilePrefab = clusterPoison,
                        speedOverride = 24,
                        //damageTypeOverride = (DamageType?)poisonDmgType
                    };
                    FireProjectileInfo info2 = new FireProjectileInfo()
                    {
                        owner = characterBody.gameObject,
                        damage = (AssassinStaticValues.poisonDamageCoef * characterBody.damage) * 0.3f,
                        //damageTypeOverride = (DamageType?)poisonDmgType,
                        force = 0,
                        position = new Vector3(impactPos.x, impactPos.y + 2, impactPos.z),
                        rotation = Quaternion.Euler(0, 120, 0),
                        projectilePrefab = clusterPoison,
                        speedOverride = 24,
                        //damageTypeOverride = (DamageType?)poisonDmgType
                    };
                    FireProjectileInfo info3 = new FireProjectileInfo()
                    {
                        owner = characterBody.gameObject,
                        damage = (AssassinStaticValues.poisonDamageCoef * characterBody.damage) * 0.3f,
                        //damageTypeOverride = (DamageType?)poisonDmgType,
                        force = 0,
                        position = new Vector3(impactPos.x, impactPos.y + 2, impactPos.z),
                        rotation = Quaternion.Euler(0, 240, 0),
                        projectilePrefab = clusterPoison,
                        speedOverride = 24,
                        //damageTypeOverride = (DamageType?)poisonDmgType
                    };

                    ProjectileManager.instance.FireProjectile(info);
                    ProjectileManager.instance.FireProjectile(info2);
                    ProjectileManager.instance.FireProjectile(info3);
                }
            }
        }

        private static void CreateEnderPearl()
        {
            enderPearl = AsnAssets.CloneProjectilePrefab("CommandoGrenadeProjectile", "enderPearl");

            Rigidbody enderPearlRigidBody = enderPearl.GetComponent<Rigidbody>();
            if (!enderPearlRigidBody)
            {
                enderPearlRigidBody = enderPearl.AddComponent<Rigidbody>();
            }

            enderPearl.AddComponent<enderPearlOnHit>();

            ProjectileImpactExplosion pearlExplosion = enderPearl.GetComponent<ProjectileImpactExplosion>();
            InitializeImpactExplosion(pearlExplosion);

            pearlExplosion.blastRadius = 0f;
            pearlExplosion.lifetime = 12f;
            pearlExplosion.destroyOnEnemy = true;
            pearlExplosion.destroyOnWorld = true;
            pearlExplosion.impactEffect = pearlImpactEffect;

            ProjectileController enderPearlController = enderPearl.GetComponent<ProjectileController>();
            if (_assetBundle.LoadAsset<GameObject>("mdlTpPotion") != null) enderPearlController.ghostPrefab = AsnAssets.CreateProjectileGhostPrefab(_assetBundle, "mdlTpPotion");

            var poisonTrailDupe = pearlTrail;
            poisonTrailDupe.transform.parent = enderPearlController.ghostPrefab.transform;

            enderPearlController.rigidbody = enderPearlRigidBody;
            enderPearlController.rigidbody.useGravity = true;
            enderPearlController.procCoefficient = 0f;
        }

        private static void CreateCloudyPotion()
        {
            cloudyPotion = AsnAssets.CloneProjectilePrefab("CommandoGrenadeProjectile", "smokeBomb");

            cloudyPotion.GetComponent<ProjectileDamage>().damageType = DamageType.Stun1s;
            cloudyPotion.AddComponent<ModdedDamageTypeHolderComponent>().Add(smokeDmgType);

            Rigidbody cloudRigidBody = cloudyPotion.GetComponent<Rigidbody>();
            if (!cloudRigidBody)
            {
                cloudRigidBody = cloudyPotion.AddComponent<Rigidbody>();
            }

            ProjectileImpactExplosion cloudExplosion = cloudyPotion.GetComponent<ProjectileImpactExplosion>();
            InitializeImpactExplosion(cloudExplosion);

            cloudExplosion.blastRadius = 6f;
            cloudExplosion.destroyOnEnemy = true;
            cloudExplosion.destroyOnWorld = true;
            cloudExplosion.impactEffect = smokeExplosionEffect;
            cloudExplosion.lifetime = 12f;

            cloudExplosion.timerAfterImpact = true;
            cloudExplosion.lifetimeAfterImpact = 0.5f;

            ProjectileController cloudController = cloudyPotion.GetComponent<ProjectileController>();
            if (_assetBundle.LoadAsset<GameObject>("mdlSmokeBomb") != null) cloudController.ghostPrefab = AsnAssets.CreateProjectileGhostPrefab(_assetBundle, "mdlSmokeBomb");

            GameObject smokeTrailDupe = smokeTrail;
            smokeTrailDupe.transform.parent = cloudController.ghostPrefab.transform;

            cloudController.rigidbody = cloudRigidBody;
            cloudController.rigidbody.useGravity = true;
            cloudController.procCoefficient = 0.2f;
        }

        internal class enderPearlOnHit : MonoBehaviour, IProjectileImpactBehavior
        {
            public void OnProjectileImpact(ProjectileImpactInfo impactInfo)
            {
                if (impactInfo.collider)
                {
                    Util.PlaySound("Play_ender_warp", gameObject);

                    ProjectileController tpControl = GetComponent<ProjectileController>();
                    Vector3 tpPosition = tpControl.transform.position;

                    var characterBody = tpControl.owner.GetComponent<CharacterBody>();

                    characterBody.AddTimedBuff(RoR2Content.Buffs.CloakSpeed, 3);

                    /*Vector3 validTeleportPos;
                    if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("moon2"))
                        validTeleportPos = tpPosition;
                    else
                        validTeleportPos = (Vector3)RoR2.TeleportHelper.FindSafeTeleportDestination(tpPosition, characterBody, RoR2Application.rng);*/

                    RoR2.TeleportHelper.TeleportBody(characterBody, tpPosition);

                    ProjectileController recursiveCtrl = GetComponent<ProjectileController>();
                    Vector3 impactPos = recursiveCtrl.transform.position;

                    FireProjectileInfo info = new FireProjectileInfo()
                    {
                        owner = characterBody.gameObject,
                        damage = AssassinStaticValues.poisonDamageCoef * characterBody.damage,
                        force = 0,
                        position = new Vector3(impactPos.x, impactPos.y, impactPos.z),
                        rotation = Quaternion.Euler(0, 0, 0),
                        projectilePrefab = poison,
                        speedOverride = 0,
                        //damageTypeOverride = (DamageType?)poisonDmgType
                    };

                    if (characterBody.HasBuff(AssassinBuffs.assassinDrugsBuff))
                        ProjectileManager.instance.FireProjectile(info);

                    Destroy(gameObject);
                }
            }
        }

        #endregion projectiles

        private static void InitializeImpactExplosion(ProjectileImpactExplosion projectileImpactExplosion)
        {
            projectileImpactExplosion.blastDamageCoefficient = 1f;
            projectileImpactExplosion.blastProcCoefficient = 1f;
            projectileImpactExplosion.blastRadius = 1f;
            projectileImpactExplosion.bonusBlastForce = Vector3.zero;
            projectileImpactExplosion.childrenCount = 0;
            projectileImpactExplosion.childrenDamageCoefficient = 0f;
            projectileImpactExplosion.childrenProjectilePrefab = null;
            projectileImpactExplosion.destroyOnEnemy = false;
            projectileImpactExplosion.destroyOnWorld = false;
            projectileImpactExplosion.falloffModel = RoR2.BlastAttack.FalloffModel.None;
            projectileImpactExplosion.fireChildren = false;
            projectileImpactExplosion.impactEffect = null;
            projectileImpactExplosion.lifetime = 0f;
            projectileImpactExplosion.lifetimeAfterImpact = 0f;
            projectileImpactExplosion.lifetimeRandomOffset = 0f;
            projectileImpactExplosion.offsetForLifetimeExpiredSound = 0f;
            projectileImpactExplosion.timerAfterImpact = false;

            projectileImpactExplosion.GetComponent<ProjectileDamage>().damageType = DamageType.Generic;
        }
    }
}
