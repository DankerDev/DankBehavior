using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ ThunderGod = () => Behav()
            .Init("Thunder God",
                new State(
                    new State("Idle",
                        new PlayerWithinTransition(15, "Idle_Wander")
                        ),
                    new State("Idle_Wander",
                        new Prioritize(
                            new StayCloseToSpawn(0.3, 3),
                             new Wander(0.3)
                                 ),
                             new HpLessTransition(.99, "Active")
                            ),
                        new State("Active",
                            new HpLessTransition(.50, "mid-rage"),
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new ReturnToSpawn(false, 0.5),
                            new Flash(0xFFFF00, 0.5, 6),
                            new Taunt("ZZZzZzzzZzzZZzZ"),
                            new TimedTransition(4200, "Spawn_Clouds")
                            ),
                        new State("Spawn_Clouds",
                             new HpLessTransition(.50, "mid-rage"),
                             new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                             new Reproduce(densityMax: 6),
                             new TossObject("Thunder Cloud", angle: 22.5, coolDown: 4000),
                             new TossObject("Thunder Cloud", angle: 45, coolDown: 4000),
                             new TossObject("Thunder Cloud", angle: 67.5, coolDown: 4000),
                             new TossObject("Thunder Cloud", angle: 90, coolDown: 4000),
                             new TossObject("Thunder Cloud", angle: 112.5, coolDown: 4000),
                             new TossObject("Thunder Cloud", angle: 135, coolDown: 4000),
                             new TossObject("Thunder Cloud", angle: 157.5, coolDown: 4000),
                             new TossObject("Thunder Cloud", angle: 180, coolDown: 4000),
                             new TossObject("Thunder Cloud", angle: 202.5, coolDown: 4000),
                             new TossObject("Thunder Cloud", angle: 225, coolDown: 4000),
                             new TossObject("Thunder Cloud", angle: 247.5, coolDown: 4000),
                             new TossObject("Thunder Cloud", angle: 270, coolDown: 4000),
                             new TossObject("Thunder Cloud", angle: 292.5, coolDown: 4000),
                             new TossObject("Thunder Cloud", angle: 315, coolDown: 4000),
                             new TossObject("Thunder Cloud", angle: 337.5, coolDown: 4000),
                             new TossObject("Thunder Cloud", angle: 360, coolDown: 4000),
                             new Flash(0xFFFF00, 0.5, 3),
                             new Order(20, "Thunder Cloud", "Active"),
                             new Taunt("You are aboutz to experienze ze true natur of ze lightning ztorm you have venztured inzto!"),
                             new TimedTransition(3000, "Activate_Clouds")
                            ),
                        new State("Activate_Clouds",
                            new HpLessTransition(.50, "mid-rage"),
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Taunt("Zis zshall zhock you to ze bone!"),
                            new Flash(0xFFFF00, 0.5, 3),
                            new TimedTransition(5000, "Spawn_Clones")
                            ),
                        new State("Spawn_Clones",
                            new HpLessTransition(.50, "mid-rage"),
                            new Spawn("Thunder God Clone", 1, 0.2, coolDown: 2100),
                            new Spawn("Thunder God Clone", 1, 0.2, coolDown: 2100),
                            new TimedTransition(2200, "Await_Clones")
                            ),
                        new State("Await_Clones",
                            new HpLessTransition(.50, "mid-rage"),
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new EntityNotExistsTransition("Thunder God Clone", 20, "Cloud_Zap")
                            ),
                        new State("Cloud_Zap",
                            new HpLessTransition(.50, "mid-rage"),
                            new Flash(0xFFFF00, 0.5, 10),
                            new ConditionalEffect(ConditionEffectIndex.ArmorBroken),
                            new Order(20, "Thunder Cloud", "Zap"),
                            new TimedTransition(3000, "Another_Clone")
                            ),
                        new State("Another_Clone",
                            new HpLessTransition(.50, "mid-rage"),
                            new Flash(0xFFFF00, 0.5, 10),
                            new ConditionalEffect(ConditionEffectIndex.ArmorBroken),
                            new Spawn("Thunder God Clone", 1, 0.2, coolDown: 2100),
                            new TimedTransition(2200, "Check_Clone")
                            ),
                        new State("Check_Clone",
                            new Flash(0xFFFF00, 0.5, 3),
                            new HpLessTransition(.50, "mid-rage"),
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new EntityNotExistsTransition("Thunder God Clone", 20, "Order2")
                            ),
                        new State("Order2",
                            new HpLessTransition(.50, "mid-rage"),
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Order(20, "Thunder Cloud", "Orbit"),
                            new TimedTransition(2000, "Attack1")
                            ),
                        new State("Attack1",
                            new HpLessTransition(.50, "mid-rage"),
                            new Prioritize(
                                         new StayCloseToSpawn(0.4, 10),
                                        new Orbit(0.4, 4, 4),
                                         new Follow(1, range: 7),
                                        new Wander(0.4)
                                     ),
        #region Blasts
                            new State("2blast1",
                                 new Shoot(10, count: 1, shootAngle: 15, angleOffset: 15, projectileIndex: 1, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 20, angleOffset: 20, projectileIndex: 1, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 25, angleOffset: 25, projectileIndex: 1, coolDown: 500),
                                 new TimedTransition(150, "2blast2")
                                ),
                             new State("2blast2",
                                 new Shoot(10, count: 1, shootAngle: 70, angleOffset: 70, projectileIndex: 2, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 75, angleOffset: 75, projectileIndex: 2, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 80, angleOffset: 80, projectileIndex: 2, coolDown: 500),
                                 new TimedTransition(150, "2blast3")
                                ),
                              new State("2blast3",
                                  new Shoot(10, count: 1, shootAngle: 100, angleOffset: 100, projectileIndex: 3, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 105, angleOffset: 105, projectileIndex: 3, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 110, angleOffset: 110, projectileIndex: 3, coolDown: 500),
                                 new TimedTransition(150, "2blast4")
                                ),
                               new State("2blast4",
                                   new Shoot(10, count: 1, shootAngle: 170, angleOffset: 170, projectileIndex: 4, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 175, angleOffset: 175, projectileIndex: 4, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 180, angleOffset: 180, projectileIndex: 4, coolDown: 500),
                                 new TimedTransition(150, "2blast5")
                                ),
                                new State("2blast5",
                                    new Shoot(10, count: 1, shootAngle: 200, angleOffset: 200, projectileIndex: 5, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 205, angleOffset: 205, projectileIndex: 5, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 210, angleOffset: 210, projectileIndex: 5, coolDown: 500),
                                 new TimedTransition(150, "2blast6")
                                ),
                                 new State("2blast6",
                                     new Shoot(10, count: 1, shootAngle: 270, angleOffset: 270, projectileIndex: 4, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 275, angleOffset: 275, projectileIndex: 4, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 280, angleOffset: 280, projectileIndex: 4, coolDown: 500),
                                 new TimedTransition(150, "2blast7")
                                ),
                                  new State("2blast7",
                                      new Shoot(10, count: 1, shootAngle: 310, angleOffset: 310, projectileIndex: 3, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 315, angleOffset: 315, projectileIndex: 3, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 320, angleOffset: 320, projectileIndex: 3, coolDown: 500),
                                 new TimedTransition(150, "2blast8")
                                ),
                                   new State("2blast8",
                                       new Shoot(10, count: 1, shootAngle: 350, angleOffset: 350, projectileIndex: 2, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 355, angleOffset: 355, projectileIndex: 2, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 360, angleOffset: 360, projectileIndex: 2, coolDown: 500),
                                 new TimedTransition(150, "2blast1")
                                )
        #endregion

                            ),
                        new State("mid-rage",
                            new Taunt("ZE THUNDERS WILL ZTRIKE OVER YOUR HEADZz!!"),
                            new Order(20, "Thunder Cloud", "Zap"),
        #region Blasts
                            new State("3blast1",
                                 new Shoot(10, count: 1, shootAngle: 15, angleOffset: 15, projectileIndex: 1, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 20, angleOffset: 20, projectileIndex: 1, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 25, angleOffset: 25, projectileIndex: 1, coolDown: 500),
                                 new TimedTransition(150, "3blast2")
                                ),
                             new State("3blast2",
                                 new Shoot(10, count: 1, shootAngle: 70, angleOffset: 70, projectileIndex: 2, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 75, angleOffset: 75, projectileIndex: 2, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 80, angleOffset: 80, projectileIndex: 2, coolDown: 500),
                                 new TimedTransition(150, "3blast3")
                                ),
                              new State("3blast3",
                                  new Shoot(10, count: 1, shootAngle: 100, angleOffset: 100, projectileIndex: 3, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 105, angleOffset: 105, projectileIndex: 3, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 110, angleOffset: 110, projectileIndex: 3, coolDown: 500),
                                 new TimedTransition(150, "3blast4")
                                ),
                               new State("3blast4",
                                   new Shoot(10, count: 1, shootAngle: 170, angleOffset: 170, projectileIndex: 4, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 175, angleOffset: 175, projectileIndex: 4, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 180, angleOffset: 180, projectileIndex: 4, coolDown: 500),
                                 new TimedTransition(150, "3blast5")
                                ),
                                new State("3blast5",
                                    new Shoot(10, count: 1, shootAngle: 200, angleOffset: 200, projectileIndex: 5, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 205, angleOffset: 205, projectileIndex: 5, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 210, angleOffset: 210, projectileIndex: 5, coolDown: 500),
                                 new TimedTransition(150, "3blast6")
                                ),
                                 new State("3blast6",
                                     new Shoot(10, count: 1, shootAngle: 270, angleOffset: 270, projectileIndex: 4, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 275, angleOffset: 275, projectileIndex: 4, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 280, angleOffset: 280, projectileIndex: 4, coolDown: 500),
                                 new TimedTransition(150, "3blast7")
                                ),
                                  new State("3blast7",
                                      new Shoot(10, count: 1, shootAngle: 310, angleOffset: 310, projectileIndex: 3, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 315, angleOffset: 315, projectileIndex: 3, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 320, angleOffset: 320, projectileIndex: 3, coolDown: 500),
                                 new TimedTransition(150, "3blast8")
                                ),
                                   new State("3blast8",
                                       new Shoot(10, count: 1, shootAngle: 350, angleOffset: 350, projectileIndex: 2, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 355, angleOffset: 355, projectileIndex: 2, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 360, angleOffset: 360, projectileIndex: 2, coolDown: 500),
                                 new TimedTransition(150, "3blast1")
                                )
        #endregion
                                   )
                             ),
                            new Threshold(0.005,
                            new ItemLoot("Potion of Mana", 1),
                            new ItemLoot("Ray Katana", 0.005),
                            new ItemLoot("Staff of Thunder", 0.005),
                            new ItemLoot("Zeus Spell", 0.005),
                            new ItemLoot("Robe of Thunder", 0.005),
                            new ItemLoot("Thunder Orb", 0.005)
                            ),
                        new Threshold(0.1,
                            new TierLoot(13, ItemType.Weapon, 0.1),
                            new TierLoot(14, ItemType.Armor, 0.1),
                            new TierLoot(5, ItemType.Ring, 0.2),

                            new TierLoot(6, ItemType.Armor, 0.2),
                            new TierLoot(3, ItemType.Ability, 0.2),
                            new TierLoot(4, ItemType.Ability, 0.15),
                            new TierLoot(5, ItemType.Ability, 0.1)
                            ))

                    .Init("Thunder Cloud",
                        new State(
                            new State("Idle",
                                new ConditionalEffect(ConditionEffectIndex.Invincible)
                                ),
                            new State("Active",
                                 new ConditionalEffect(ConditionEffectIndex.Invincible),
                                new ChangeSize(20, 10),
                                new TimedTransition(150, "Change2")
                                ),
                            new State("Change2",
                                new ConditionalEffect(ConditionEffectIndex.Invincible),
                                new ChangeSize(20, 20),
                                new TimedTransition(150, "Change3")
                                 ),
                            new State("Change3",
                                new ConditionalEffect(ConditionEffectIndex.Invincible),
                                new ChangeSize(20, 40),
                                new TimedTransition(150, "Change4")
                                 ),
                            new State("Change4",
                                new ConditionalEffect(ConditionEffectIndex.Invincible),
                                new ChangeSize(20, 80),
                                new TimedTransition(150, "Change5")
                                 ),
                            new State("Change5",
                                new ConditionalEffect(ConditionEffectIndex.Invincible),
                                new ChangeSize(20, 160),
                                new TimedTransition(150, "Orbit")
                                ),
                            new State("Orbit",
                                new EntityNotExistsTransition("Thunder God", 20, "suicide"),
                                new ConditionalEffect(ConditionEffectIndex.Invincible),
                                new Orbit(0.2, 6, target: "Thunder God")
                                ),
                            new State("Zap",
                                new EntityNotExistsTransition("Thunder God", 20, "suicide"),
                                new ConditionalEffect(ConditionEffectIndex.Invincible),
                                 new Orbit(0.2, 9, target: "Thunder God"),
                                new Shoot(1, fixedAngle: 0, count: 15, shootAngle: 24, coolDown: 3500, projectileIndex: 0)
                                ),
                            new State("suicide",
                                new Suicide()
                                )))

                        .Init("Thunder God Clone",
                            new State(
                                new State("Active",
                                    new HpLessTransition(.40, "Rage"),
                                     new Prioritize(
                                         new StayCloseToSpawn(0.4, 10),
                                        new Orbit(0.4, 4, 4),
                                         new Follow(1, range: 7),
                                        new Wander(0.4)
                                     ),
        #region Blasts
                            new State("blast1",
                                 new Shoot(10, count: 1, shootAngle: 15, angleOffset: 15, projectileIndex: 1, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 20, angleOffset: 20, projectileIndex: 1, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 25, angleOffset: 25, projectileIndex: 1, coolDown: 500),
                                 new TimedTransition(150, "blast2")
                                ),
                             new State("blast2",
                                 new Shoot(10, count: 1, shootAngle: 70, angleOffset: 70, projectileIndex: 1, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 75, angleOffset: 75, projectileIndex: 1, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 80, angleOffset: 80, projectileIndex: 1, coolDown: 500),
                                 new TimedTransition(150, "blast3")
                                ),
                              new State("blast3",
                                  new Shoot(10, count: 1, shootAngle: 100, angleOffset: 100, projectileIndex: 1, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 105, angleOffset: 105, projectileIndex: 1, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 110, angleOffset: 110, projectileIndex: 1, coolDown: 500),
                                 new TimedTransition(150, "blast4")
                                ),
                               new State("blast4",
                                   new Shoot(10, count: 1, shootAngle: 170, angleOffset: 170, projectileIndex: 1, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 175, angleOffset: 175, projectileIndex: 1, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 180, angleOffset: 180, projectileIndex: 1, coolDown: 500),
                                 new TimedTransition(150, "blast5")
                                ),
                                new State("blast5",
                                    new Shoot(10, count: 1, shootAngle: 200, angleOffset: 200, projectileIndex: 1, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 205, angleOffset: 205, projectileIndex: 1, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 210, angleOffset: 210, projectileIndex: 1, coolDown: 500),
                                 new TimedTransition(150, "blast6")
                                ),
                                 new State("blast6",
                                     new Shoot(10, count: 1, shootAngle: 270, angleOffset: 270, projectileIndex: 1, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 275, angleOffset: 275, projectileIndex: 1, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 280, angleOffset: 280, projectileIndex: 1, coolDown: 500),
                                 new TimedTransition(150, "blast7")
                                ),
                                  new State("blast7",
                                      new Shoot(10, count: 1, shootAngle: 310, angleOffset: 310, projectileIndex: 1, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 315, angleOffset: 315, projectileIndex: 1, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 320, angleOffset: 320, projectileIndex: 1, coolDown: 500),
                                 new TimedTransition(150, "blast8")
                                ),
                                   new State("blast8",
                                       new Shoot(10, count: 1, shootAngle: 350, angleOffset: 350, projectileIndex: 1, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 355, angleOffset: 355, projectileIndex: 1, coolDown: 500),
                                 new Shoot(10, count: 1, shootAngle: 360, angleOffset: 360, projectileIndex: 1, coolDown: 500),
                                 new TimedTransition(150, "blast1")
                                )
        #endregion

                                    ),
                                 new State("Rage",
                                      new Follow(0.6, 6, 1, -1, 0),
                                      new Shoot(10, count: 5, shootAngle: 20, predictive: 1, coolDown: 500)
                             )));
    }
}