using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ IceAge = () => Behav()

        .Init("Ice Sage", //projectile0: fast, damage med 
            new State(
                new State("start_taunt",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Taunt("Are you worthy to fight me, mortal?"),
                    new PlayerWithinTransition(10, "taunt")
                    ),
                new State("taunt",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Taunt("hahaha, then let me test you, brave warrior!"),
                    new TimedTransition(3000, "start_spawn")
                    ),
                new State("start_spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Taunt("My knights will make quick work of you!"),
                    new Spawn("Frost Knight", maxChildren: 5, initialSpawn: 2, coolDown: 30000),
                    new TimedTransition(30000, "taunt1")
                    ),
                new State("taunt1",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Taunt("I have deemed you worthy to get killed my by blade"),
                    new TimedTransition(3000, "start behavior")
                    ),
                new State("start behavior",
                    new Taunt("I have deemed you worthy to get killed my by blade"),
                    new ChangeSize(20, 150),
                    new Shoot(20, 5, shootAngle: 25, projectileIndex: 0, predictive: 1, coolDown: 500),
                    new Shoot(20, 4, shootAngle: 10, projectileIndex: 3, predictive: 1, coolDown: 3500),
                    new Shoot(10, 10, shootAngle: 36, projectileIndex: 1, coolDown: 2000),
                    new HpLessTransition(0.5, "rageup")
                    ),
                new State("rageup",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Taunt("You noisance!"),
                    new ChangeSize(10, 200),
                    new TimedTransition(3000, "rage_phase")
                    ),
                new State("rage_phase",
                    new Grenade(5, damage: 200, range: 15, coolDown: 1000),
                    new Shoot(15, count: 6, shootAngle: 50, projectileIndex: 2, predictive: 1, coolDown: 2500),
                    new Shoot(20, 12, shootAngle: 30, projectileIndex: 1, coolDown: 10000),
                    new Spawn("Frost Knight", 1, 1, coolDown: 2000),
                    new HpLessTransition(0.3, "suicidenear")
                    ),
                new State("suicidenear",
                    new Taunt("Curse you!"),
                    new Shoot(15, 1, angleOffset: 36, projectileIndex: 1, coolDown: 500),
                    new Shoot(15, 1, angleOffset: 72, projectileIndex: 1, coolDown: 800),
                    new Shoot(15, 1, angleOffset: 108, projectileIndex: 1, coolDown: 1100),
                    new Shoot(15, 1, angleOffset: 144, projectileIndex: 1, coolDown: 1400),
                    new Shoot(15, 1, angleOffset: 180, projectileIndex: 1, coolDown: 1700),
                    new Shoot(15, 1, angleOffset: 216, projectileIndex: 1, coolDown: 2000),
                    new Shoot(15, 1, angleOffset: 252, projectileIndex: 1, coolDown: 2300),
                    new Shoot(15, 1, angleOffset: 288, projectileIndex: 1, coolDown: 2600),
                    new Shoot(15, 1, angleOffset: 324, projectileIndex: 1, coolDown: 2900),
                    new Shoot(15, 1, angleOffset: 360, projectileIndex: 1, coolDown: 3200),
                    new TimedTransition(5000, "rage2"),
                    new HpLessTransition(0.1, "suicidestart")
                    ),
                new State("rage2",
                    new Shoot(20, 1, 0, 1, 40, coolDownOffset: 200),
                    new Shoot(20, 1, 0, 1, 80, coolDownOffset: 400),
                    new Shoot(20, 1, 0, 1, 120, coolDownOffset: 600),
                    new Shoot(20, 1, 0, 1, 160, coolDownOffset: 800),
                    new Shoot(20, 1, 0, 1, 200, coolDownOffset: 1000),
                    new Shoot(20, 1, 0, 1, 240, coolDownOffset: 1200),
                    new Shoot(20, 1, 0, 1, 280, coolDownOffset: 1400),
                    new Shoot(20, 1, 0, 1, 320, coolDownOffset: 1600),
                    new Shoot(20, 1, 0, 1, 360, coolDownOffset: 1800),
                    new TimedTransition(7000, "suicidenear"),
                    new HpLessTransition(0.1, "suicidestart")
                    ),
                new State("suicidestart",
                    new Buzz(2, 4, coolDown: 500),
                    new ChangeSize(-20, 130),
                    new TimedTransition(1000, "suicide")
                    ),
                new State("suicide",
                    new Decay()
                    )
                ),
            new Threshold(0.005,
                new ItemLoot("Chilled Sword", 0.005),
                new ItemLoot("Shield of Ice", 0.005),
                new ItemLoot("Frozen Armor", 0.005),
                new ItemLoot("Ring of the Frozen King", 0.005),

                new ItemLoot("Crystalized Bow", 0.005),
                new ItemLoot("Frostbite Trap", 0.005),
                new ItemLoot("Ice Armor", 0.005),
                new ItemLoot("Ice Age Bracer", 0.005),

                new ItemLoot("Crystal Wand", 0.005),
                new ItemLoot("Crystal Sword", 0.005),

                new TierLoot(11, ItemType.Weapon, 0.6),
                new TierLoot(5, ItemType.Ability, 0.6),
                new TierLoot(12, ItemType.Armor, 0.6),
                new TierLoot(5, ItemType.Ring, 0.6),
                new TierLoot(2, ItemType.Potion, 0.6)
            )
            )
        .Init("Frost Knight",
            new State(
                new State("start",
                    new Prioritize(
                        new Wander(0.4),
                        new Follow(1.2, range: 3)
                        ),
                    new Shoot(10, 4, shootAngle: 30, projectileIndex: 0, predictive: 1, coolDown: 1000),
                    new TimedTransition(10000, "protect_stage")
                    ),
                new State("protect_stage",
                    new ConditionalEffect(ConditionEffectIndex.Armored),
                    new Protect(0.7, "Ice Sage", acquireRange: 100, protectionRange: 5),
                    new Shoot(4, count: 10, shootAngle: 36, projectileIndex: 1, coolDown: 1500),
                    new TimedTransition(20000, "start")
                    )
                )
            )
        .Init("Frost Wizard",
            new State(
                new Prioritize(
                new Shoot(15, 2, shootAngle: 10, projectileIndex: 0, predictive: 1, coolDown: 1000)
                    )
                )
        );
    }
}
