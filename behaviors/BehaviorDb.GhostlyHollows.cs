using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Ghost = () => Behav()

        .Init("Ghost God Zaros",
            new State(
                new State("start",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new ConditionalEffect(ConditionEffectIndex.Invisible),
                    new EntityNotExistsTransition("Ghost Protector", 1000, "behav")
                ),
                new State("behav",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Taunt("Ughhhh.... annoying human.."),
                    new Taunt("How dare you distrub me from my sleep"),
                    new Taunt("you better be prepare for your action!"),
                    new TimedTransition(4000, "behav1")
                    ),
                new State("behav1",
                    new Prioritize(
                        new Follow(1, range: 7)
                        ),
                    new ConditionalEffect(ConditionEffectIndex.Invisible),
                    new Shoot(20, 10, shootAngle: 36, projectileIndex: 0, coolDown: 5000),
                    new Shoot(15, 3, shootAngle: 10, projectileIndex: 1, predictive: 1, coolDown: 1000),
                    new Shoot(15, 4, shootAngle: 15, projectileIndex: 2, predictive: 1, coolDown: 3500),
                    new TimedTransition(5000, "jinx"),
                    new HpLessTransition(0.8, "realstage")
                    ),
                new State("jinx",
                    new Taunt("hahahaha"),
                    new Shoot(15, 3, projectileIndex: 3, fixedAngle: 0, coolDown: 100),
                    new Shoot(15, 3, projectileIndex: 1, shootAngle: 10, predictive: 1, coolDown: 400000),
                    new TimedTransition(300, "jinx1"),
                    new HpLessTransition(0.8, "realstage")
                    ),
                new State("jinx1",
                    new Shoot(15, 3, projectileIndex: 3, fixedAngle: 18, coolDown: 100),
                    new TimedTransition(300, "jinx2"),
                    new HpLessTransition(0.8, "realstage")
                    ),
                new State("jinx2",
                    new Shoot(15, 3, projectileIndex: 3, fixedAngle: 36, coolDown: 100),
                    new TimedTransition(300, "jinx3"),
                    new HpLessTransition(0.8, "realstage")
                    ),
                new State("jinx3",
                    new Shoot(15, 3, projectileIndex: 3, fixedAngle: 54, coolDown: 100),
                    new Shoot(15, 3, projectileIndex: 1, shootAngle: 10, predictive: 1, coolDown: 400000),
                    new TimedTransition(300, "jinx4"),
                    new HpLessTransition(0.8, "realstage")
                    ),
                new State("jinx4",
                    new Shoot(15, 3, projectileIndex: 3, fixedAngle: 72, coolDown: 100),
                    new TimedTransition(300, "jinx5"),
                    new HpLessTransition(0.8, "realstage")
                    ),
                new State("jinx5",
                    new Shoot(15, 3, projectileIndex: 3, fixedAngle: 90, coolDown: 100),
                    new TimedTransition(300, "jinx6"),
                    new HpLessTransition(0.8, "realstage")
                    ),
                new State("jinx6",
                    new Shoot(15, 3, projectileIndex: 3, fixedAngle: 108, coolDown: 100),
                    new Shoot(15, 3, projectileIndex: 1, shootAngle: 10, predictive: 1, coolDown: 400000),
                    new TimedTransition(300, "jinx7"),
                    new HpLessTransition(0.8, "realstage")
                    ),
                new State("jinx7",
                    new Shoot(15, 3, projectileIndex: 3, fixedAngle: 126, coolDown: 100),
                    new TimedTransition(300, "jinx8"),
                    new HpLessTransition(0.8, "realstage")
                    ),
                new State("jinx8",
                    new Shoot(15, 3, projectileIndex: 3, fixedAngle: 144, coolDown: 100),
                    new TimedTransition(300, "jinx9"),
                    new HpLessTransition(0.8, "realstage")
                    ),
                new State("jinx9",
                    new Shoot(15, 3, projectileIndex: 3, fixedAngle: 162, coolDown: 100),
                    new Shoot(15, 3, projectileIndex: 1, shootAngle: 10, predictive: 1, coolDown: 400000),
                    new TimedTransition(300, "jinx10"),
                    new HpLessTransition(0.8, "realstage")
                    ),
                new State("jinx10",
                    new Shoot(15, 3, projectileIndex: 3, fixedAngle: 180, coolDown: 100),
                    new TimedTransition(300, "jinx11"),
                    new HpLessTransition(0.8, "realstage")
                    ),
                new State("jinx11",
                    new Shoot(15, 3, projectileIndex: 3, fixedAngle: 198, coolDown: 100),
                    new TimedTransition(300, "jinx12"),
                    new HpLessTransition(0.8, "realstage")
                    ),
                new State("jinx12",
                    new Shoot(15, 3, projectileIndex: 3, fixedAngle: 216, coolDown: 100),
                    new Shoot(15, 3, projectileIndex: 1, shootAngle: 10, predictive: 1, coolDown: 400000),
                    new TimedTransition(300, "jinx13"),
                    new HpLessTransition(0.8, "realstage")
                    ),
                new State("jinx13",
                    new Shoot(15, 3, projectileIndex: 3, fixedAngle: 234, coolDown: 100),
                    new TimedTransition(300, "jinx14"),
                    new HpLessTransition(0.8, "realstage")
                    ),
                new State("jinx14",
                    new Shoot(15, 3, projectileIndex: 3, fixedAngle: 252, coolDown: 100),
                    new TimedTransition(300, "jinx15"),
                    new HpLessTransition(0.8, "realstage")
                    ),
                new State("jinx15",
                    new Shoot(15, 3, projectileIndex: 3, fixedAngle: 270, coolDown: 100),
                    new Shoot(15, 3, projectileIndex: 1, shootAngle: 10, predictive: 1, coolDown: 400000),
                    new TimedTransition(300, "jinx16"),
                    new HpLessTransition(0.8, "realstage")
                    ),
                new State("jinx16",
                    new Shoot(15, 3, projectileIndex: 3, fixedAngle: 288, coolDown: 100),
                    new TimedTransition(300, "jinx17"),
                    new HpLessTransition(0.8, "realstage")
                    ),
                new State("jinx17",
                    new Shoot(15, 3, projectileIndex: 3, fixedAngle: 306, coolDown: 100),
                    new TimedTransition(300, "jinx18"),
                    new HpLessTransition(0.8, "realstage")
                    ),
                new State("jinx18",
                    new Shoot(15, 3, projectileIndex: 3, fixedAngle: 324, coolDown: 100),
                    new Shoot(15, 3, projectileIndex: 1, shootAngle: 10, predictive: 1, coolDown: 400000),
                    new TimedTransition(300, "jinx19"),
                    new HpLessTransition(0.8, "realstage")
                    ),
                new State("jinx19",
                    new Shoot(15, 3, projectileIndex: 3, fixedAngle: 344, coolDown: 100),
                    new TimedTransition(300, "jinx20"),
                    new HpLessTransition(0.8, "realstage")
                    ),
                new State("jinx20",
                    new Shoot(15, 3, projectileIndex: 3, fixedAngle: 360, coolDown: 100),
                    new TimedTransition(300, "behav1"),
                    new HpLessTransition(0.8, "realstage")
                    ),
                new State("realstage",
                    new Taunt("Come my reapers!"),
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new TossObject("Ghost Protector", 5, 0, coolDown: 2000),
                    new TimedTransition(6100, "check")
                    ),
                new State("check",
                    new Taunt("Checking"),
                    new ChangeSize(-10, 0),
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new EntityNotExistsTransition("Ghost Protector", 100, "checkdone")
                    ),
                new State("checkdone",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Taunt("Well done"),
                    new Taunt("You did well for a maggot!"),
                    new ChangeSize(10, 180),
                    new TimedTransition(4000, "realstage1")
                    ),
                new State("realstage1",
                    new ConditionalEffect(ConditionEffectIndex.Armored),
                    new Taunt("Now die!"),
                    new TossObject("Ghost Tower", 7, 0, coolDown: 10000000),
                    new TossObject("Ghost Tower", 7, 90, coolDown: 10000000),
                    new TossObject("Ghost Tower", 7, 180, coolDown: 10000000),
                    new TossObject("Ghost Tower", 7, 270, coolDown: 10000000),
                    new TimedTransition(2000, "die")
                    ),
                new State("die",
                    new Prioritize(
                        new Wander(0.4)
                            ),
                    new Shoot(10, 3, shootAngle: 20, projectileIndex: 3, predictive: 0.8, coolDown: 700), //make projectile 4
                    new HpLessTransition(0.5, "rage")
                    ),
                new State("rage",
                    new Taunt("RAHH!!!"),
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new ChangeSize(5, 180),
                    new TimedTransition(4000, "ragereal")
                    ),
                new State("ragereal",
                    new Prioritize(
                        new Follow(0.9, range: 2)
                        ),
                    new Shoot(15, 4, shootAngle: 10, projectileIndex: 2, predictive: 0.7),
                    new TimedTransition(10000, "ragereal2"),
                    new HpLessTransition(0.3, "death")
                    ),
                new State("ragereal2",
                    new Shoot(20, 5, 36, projectileIndex: 3, fixedAngle: 0, coolDown: 1000),
                    new Shoot(20, 5, 36, projectileIndex: 2, fixedAngle: 180, coolDown: 2000),
                    new Shoot(20, 12, 30, projectileIndex: 3, coolDown: 5000),
                    new Shoot(20, 2, 5, projectileIndex: 4, predictive: 1, coolDown: 500),
                    new TimedTransition(10000, "ragereal"),
                    new HpLessTransition(0.3, "death")
                    ),
                new State("death",
                    new Taunt("YOU FOOL, DIE!!!!!"),
                    new Shoot(20, 12, 30, projectileIndex: 4, coolDown: 500),
                    new Shoot(20, 8, 45, projectileIndex: 4, coolDown: 900),
                    new Shoot(20, 10, 36, projectileIndex: 4, coolDown: 1400),
                    new Shoot(20, 2, 5, projectileIndex: 3, predictive: 1, coolDown: 500),
                    new TimedTransition(15000, "suicide"),
                    new HpLessTransition(0.1, "suicide")
                    ),
                new State("suicide",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new ChangeSize(-10, 10),
                    new Suicide()
                    )
                ),
            new Threshold(0.005, //examples
                new ItemLoot("Ghostly Dagger", 0.005),
                new ItemLoot("Cloak of Trapped Souls", 0.005),
                new ItemLoot("Soul Armor", 0.005),
                new ItemLoot("Amulet of Souls", 0.005),
                new TierLoot(2, ItemType.Potion, 0.5)
                )
            )
        .Init("Ghost Protector", //10k hp, 1st prjectile damage 110, seconds 120
            new State(
                new State("lol",
                    new Prioritize(
                        new Wander(0.7)
                        ),
                    new Shoot(15, 8, projectileIndex: 0, fixedAngle: 0, coolDownOffset: 600, coolDown: 7200),
                    new Shoot(15, 8, projectileIndex: 0, fixedAngle: 36, coolDownOffset: 1200, coolDown: 7200),
                    new Shoot(15, 8, projectileIndex: 0, fixedAngle: 72, coolDownOffset: 1800, coolDown: 7200),
                    new Shoot(15, 8, projectileIndex: 0, fixedAngle: 104, coolDownOffset: 2400, coolDown: 7200),
                    new Shoot(15, 8, projectileIndex: 0, fixedAngle: 144, coolDownOffset: 3000, coolDown: 7200),
                    new Shoot(15, 8, projectileIndex: 0, fixedAngle: 180, coolDownOffset: 3600, coolDown: 7200),
                    new Shoot(15, 8, projectileIndex: 0, fixedAngle: 216, coolDownOffset: 4200, coolDown: 7200),
                    new Shoot(15, 8, projectileIndex: 0, fixedAngle: 252, coolDownOffset: 4800, coolDown: 7200),
                    new Shoot(15, 8, projectileIndex: 0, fixedAngle: 288, coolDownOffset: 5400, coolDown: 7200),
                    new Shoot(15, 8, projectileIndex: 0, fixedAngle: 324, coolDownOffset: 6000, coolDown: 7200),
                    new Shoot(15, 8, projectileIndex: 0, fixedAngle: 360, coolDownOffset: 6600, coolDown: 7200),
                    new TimedTransition(7800, "orbit")
                    ),
                new State("orbit",
                    new Orbit(0.7, 7, target: "Ghost God Zaros"),
                    new Shoot(10, 3, shootAngle: 20, projectileIndex: 0, predictive: 0.7, coolDown: 1200), //change to one
                    new TimedTransition(15000, "lol")
                    )
                )
            )
        .Init("Ghost Tower", //make their range long, damage: 100
            new State(
                new State("Shoot",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Shoot(20, 4, 90, 0, coolDown: 50),
                    new TimedTransition(30000, "nothing")
                    ),
                new State("nothing",
                    new Taunt("Your majesty we've ran out of power")
                    )
                )
            );
    }
}
