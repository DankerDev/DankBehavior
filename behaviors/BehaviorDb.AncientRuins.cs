using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ AncientRuins = () => Behav()

            .Init("Sand General", //sand general
            new State(
                new State("check for player",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("Sand Golem", 200, "startbehav")
                    ),
                new State("startbehav",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Taunt("You did well hero. Congrats on getting this far!"),
                    new Taunt("But this will be your grave!"),
                    new TimedTransition(2000, "startphase")
                    ),
                new State("startphase",
                    new Taunt("Come attack me! Show me what you got!"),
                    new HpLessTransition(0.8, "worthy"),
                    new TimedTransition(15000, "notworthy")
                    ),
                new State("notworthy",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new HealSelf(coolDown: 300, amount: 100),
                    new Taunt("You are not worthy to fight me..."),
                    new Taunt("Lets try that again"),
                    new TimedTransition(2000, "startphase")
                    ),
                new State("worthy",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new HealSelf(300, 100),
                    new Taunt("You have proven your self.I'll take you on seriously!"),
                    new TimedTransition(2000, "serious")
                    ),
                new State("serious",
                    new Prioritize(
                        new Follow(1.2, range: 0)
                        ),
                    new Shoot(15, 4, 15, projectileIndex: 1, predictive: 0.2, coolDown: 500),
                    new Spawn("Sand Golem", 2, 1, coolDown: 5000),
                    new HpLessTransition(0.65, "phase2")
                    ),
                new State("phase2",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Taunt("Hahaha! You truly are strong."),
                    new Taunt("But you are still no match for my true power!"),
                    new ChangeSize(20, 220),
                    new TimedTransition(3000, "veryserious")
                    ),
                new State("veryserious",
                    new Taunt("Feel my wrath!"),
                    new Flash(0xf389E13, 0.5, 60),
                    new TossObject("Sand Golem", 9, 48, 320000),
                    new TossObject("Sand Golem", 9, 120, 320000),
                    new TossObject("Sand Golem", 9, 168, 320000),
                    new TossObject("Sand Golem", 9, 240, 320000),
                    new TossObject("Sand Golem", 9, 288, 320000),
                    new TossObject("Sand Golem", 9, 360, 320000),
                    new ConditionalEffect(ConditionEffectIndex.Armored),
                    new Shoot(20, 4, shootAngle: 20, projectileIndex: 2, angleOffset: 0, coolDown: 3000),
                    new Shoot(20, 4, shootAngle: 20, projectileIndex: 2, angleOffset: 80, coolDown: 3400),
                    new Shoot(20, 4, shootAngle: 20, projectileIndex: 2, angleOffset: 160, coolDown: 3800),
                    new Shoot(20, 4, shootAngle: 20, projectileIndex: 2, angleOffset: 240, coolDown: 4200),
                    new Shoot(20, 4, shootAngle: 20, projectileIndex: 2, angleOffset: 320, coolDown: 4600),
                    new Shoot(15, 3, 7, projectileIndex: 3, predictive: 1, coolDown: 1500),
                    new HpLessTransition(0.4, "rage")
                    ),
                new State("rage",
                    new Shoot(20, 4, shootAngle: 20, projectileIndex: 4, angleOffset: 0, coolDown: 1000),
                    new Shoot(20, 4, shootAngle: 20, projectileIndex: 0, angleOffset: 80, coolDown: 1400),
                    new Shoot(20, 4, shootAngle: 20, projectileIndex: 4, angleOffset: 160, coolDown: 1800),
                    new Shoot(20, 4, shootAngle: 20, projectileIndex: 0, angleOffset: 240, coolDown: 2200),
                    new Shoot(20, 4, shootAngle: 20, projectileIndex: 4, angleOffset: 320, coolDown: 2600),
                    new Shoot(15, 3, 7, projectileIndex: 3, coolDown: 1500),
                    new TimedTransition(20000, "suicide")
                    ),
                new State("suicide",
                    new Suicide()
                    )
                ),
            new Threshold(0.005,
                new ItemLoot("Sand Storm Armor", 0.005),
                new ItemLoot("Amulet of Sand", 0.005),
                new ItemLoot("Sand Sword", 0.005),
                new ItemLoot("Seal of the Sand General", 0.005),
                new ItemLoot("Ring of the Pyramid", 0.01),
                new ItemLoot("Ring of the Nile", 0.01),
                new ItemLoot("Ring of the Sphinx", 0.01),
                new ItemLoot("Tome of Holy Protection", 0.005),
                new ItemLoot("Helm of the Juggernaut", 0.005),
                new ItemLoot("Potion of Life", 0.5),
                new TierLoot(6, ItemType.Ring, 0.1)
                )
            )
        .Init("Sand Golem", // sand golem
            new State(
                new State("nobossnear",
                    new Prioritize(
                        new Wander(0.4)
                        ),
                    new Shoot(20, 2, 10, 0, coolDown: 1000),
                    new Spawn("Sand Crawler", 2, 1, coolDown: 10000),
                    new EntityExistsTransition("Sand General", 15, "protect")
                    ),
                new State("protect",
                    new Protect(1.2, "Sand General", 20, 5),
                    new ConditionalEffect(ConditionEffectIndex.Armored),
                    new TimedTransition(10000, "attack")
                    ),
                new State("attack",
                    new Prioritize(
                        new Follow(0.4, range: 3)
                        ),
                    new Shoot(20, 2, 10, 0, predictive: 0.31, coolDown: 1000),
                    new Spawn("Sand Crawler", 2, 1, coolDown: 5000),
                    new TimedTransition(10000, "protect")
                    )
                )
            )
        .Init("Sand Crawler", // sand crawler
            new State(
                new Prioritize(
                    new Wander(0.5),
                    new Follow(1, range: 0)
                    ),
                new Shoot(10, 2, 10, projectileIndex: 0, coolDown: 1000)
                )
            )
        .Init("Sand Salamander",
            new State(
                new Prioritize(
                    new Wander(0.6),
                    new Follow(1.5, range: 3)
                    ),
                new Shoot(10, 3, 15, 0, predictive: 0, coolDown: 1000)
                )
            )
        .Init("Sand Slurp",
            new State(
                new Prioritize(
                    new Follow(0.7, 15, 15)
                    ),
                new Shoot(15, 1, projectileIndex: 0, predictive: 0.1, coolDown: 500)
                )
            )
        .Init("Sand Maggot",
            new State(
                new State("start",
                    new Spawn("Sand Eater", 3, 1, coolDown: 20000),
                    new TimedTransition(1000, "defend")

                    ),
                new State("defend",
                    new Prioritize(
                        new Wander(0.5)
                        ),
                    new Shoot(15, 3, 20, projectileIndex: 0, predictive: 0, coolDown: 1500)
                    )
                )
            )
        .Init("Sand Eater",
            new State(
                new State("defend",
                    new Orbit(0.7, 10, 4, "Sand Maggot"),
                    new Shoot(7, 1, projectileIndex: 0, predictive: 0.3, coolDown: 2000)
                    )
                )
            )
        .Init("Sand Archer",
            new State(
                new Prioritize(
                    new Wander(0.4)
                    ),
                new Shoot(10, 2, 10, 0, predictive: 0.5, coolDown: 400)
                )
            );
    }
}
