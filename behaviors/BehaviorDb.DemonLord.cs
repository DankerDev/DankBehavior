﻿using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ DemonLord = () => Behav()
            .Init("Demon King Akuma", //make him have 70000+ hp, projectile 0 : 300 damage and fast speed, the rest you can customize
            new State(
                new State("default",
                    new PlayerWithinTransition(10, "start_taunt")
                    ),
                new State("start_taunt",
                    new Taunt("Lowly humans, how dare you enter my dungeon!"),
                    new Shoot(10, 4, shootAngle: 10, projectileIndex: 1, predictive: 1, coolDown: 1000),
                    new Taunt("Ha!"),
                    new TimedTransition(5000, "start_1phase")
                    ),
                new State("start_1phase",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Taunt("Come my minions!"),
                    new Spawn("Terror Demon", maxChildren: 3, initialSpawn: 2, coolDown: 2000),
                    new TimedTransition(10000, "start_phase")
                    ),
                new State("start_phase",
                    new Prioritize(
                        new Follow(1.5, range: 5)
                        ),
                    new ConditionalEffect(ConditionEffectIndex.Armored),
                    new Taunt("You cannot pierce my supperior defense"),
                    new Taunt("I'm too fast fo you, sonic you fool!"),
                    new Shoot(10, 3, shootAngle: 9, projectileIndex: 1, predictive: 1, coolDown: 700),
                    new TimedTransition(20000, "shoot_phase")
                    ),
                new State("shoot_phase",
                    new Shoot(10, count: 2, projectileIndex: 1, shootAngle: 30, predictive: 1, coolDown: 400),
                    new Shoot(10, count: 4, projectileIndex: 2, shootAngle: 20, predictive: 1, coolDown: 600),
                    new Shoot(4, count: 8, projectileIndex: 3, shootAngle: 45, coolDown: 300),
                    new Spawn("Demon Archer", maxChildren: 3, initialSpawn: 2, coolDown: 2000),
                    new TimedTransition(10000, "start_phase"),
                    new HpLessTransition(.5, "fight_phase")
                    ),
                new State("fight_phase",
                    new Taunt("Ima get serious now!"),
                    new Taunt("My army go ravage their bootty"),
                    new Spawn("Imp of the Abyss", maxChildren: 6, initialSpawn: 3, coolDown: 10000),
                    new TossObject("Demon Archer", range: 3, angle: 45, coolDown: 70000),
                    new TossObject("Demon Archer", range: 3, angle: 90, coolDown: 70000),
                    new TossObject("Demon Archer", range: 3, angle: 135, coolDown: 70000),
                    new TossObject("Demon Archer", range: 3, angle: 180, coolDown: 70000),
                    new TossObject("Demon Archer", range: 3, angle: 225, coolDown: 70000),
                    new TossObject("Demon Archer", range: 3, angle: 270, coolDown: 70000),
                    new Shoot(20, count: 5, projectileIndex: 3, shootAngle: 40, predictive: 1, coolDown: 500),
                    new Shoot(15, count: 4, projectileIndex: 2, shootAngle: 30, predictive: 1, coolDown: 750),
                    new HpLessTransition(0.3, "final_stage")
                    ),
                new State("final_stage",
                    new Taunt("haha, you asshole, you come to my dungeon and kill my people, i'll be back"),
                    new Shoot(100, count: 12, projectileIndex: 0, shootAngle: 30, coolDown: 250),
                    new TimedTransition(2500, "decay_stage")
                    ),
                new State("decay_stage",
                    new Decay(100)
                    )
                ),
            new TierLoot(2, ItemType.Potion, 1),
            new Threshold(0.005,
                    new ItemLoot("Akuma's Bow", 0.005),
                    new ItemLoot("Quiver of the Demon Lord", 0.005),
                    new ItemLoot("Hide of Akuma", 0.005),
                    new ItemLoot("Akuma's Amulet of Hell", 0.005),
                    new ItemLoot("Demon Blade", 0.005),
                    new ItemLoot("Potion of Defense", 0.2)
                )
            )

            .Init("Terror Demon", //the boss spawns this 
                new State(
                    new Prioritize(
                        new Wander(0.4),
                        new Follow(1, range: 10)
                        ),
                        new Taunt("Fear me human!"),
                        new Shoot(10, count: 3, projectileIndex: 0, shootAngle: 20, predictive: 1, coolDown: 500)
                    )
            )
            .Init("Demonic Walker",// for the dungeon, make him have low health <3k
                new State(
                    new Prioritize(
                        new Wander(0.6)
                        ),
                        new Shoot(7, count: 8, projectileIndex: 0, shootAngle: 40, predictive: 1, coolDown: 700)
                    )
            )
        .Init("Terror Brute",//  high health <7k and is for the dungeon
            new State(
                new Prioritize(
                    new Wander(0.3),
                    new Follow(0.6, range: 3)
                    ),
                new State("spawn",
                    new Spawn("Demon Runner", maxChildren: 2, initialSpawn: 1, coolDown: 10000),
                    new Shoot(10, count: 1, projectileIndex: 0, predictive: 1, coolDown: 1000)
                    )
                )
            )


           .Init("Demon Runner", // for the dungeon, make him have low health eg: <2k
                new State(
                    new Prioritize(
                        new Wander(0.5),
                        new Follow(1.5, range: 4)
                        ),
                    new Shoot(6, count: 3, shootAngle: 40, projectileIndex: 0, predictive: 1, coolDown: 500)
                    )
            )


           .Init("Demon Archer", // the boss spawns this
                 new State(
                     new State("orbit boss",
                         new Orbit(0.7, 10, target: "Demon King Akuma"),
                         new Shoot(20, count: 1, projectileIndex: 0, predictive: 1, coolDown: 1000)
                         )
                     )
            );
    }
}