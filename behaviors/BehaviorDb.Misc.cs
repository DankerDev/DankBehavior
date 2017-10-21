using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wServer.realm;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        _ Misc = () => Behav()

            .Init("XP Gift",
                    new State(
                            new Wander(0.3)
                    ),
                new Threshold(0.2,
                    new TierLoot(2, ItemType.Potion, 0.35)
                )
            )
            .Init("White Fountain",
                new State(
                    new NexusHealHp(5, 100, 1000)
                    )
            )
        .Init("XP Gift Spawner",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Idle",
                    new PlayerWithinTransition(10, "spawn")
                    ),
                new State("spawn",
                    new Spawn("XP Gift", 2, coolDown: 10000),
                    new TimedTransition(5000, "spawn2")
                    ),
                new State("spawn2",
                    new Spawn("XP Gift", 2, coolDown: 10000),
                    new TimedTransition(5000, "spawn")
            )
         )
        )
          .Init("Nexus Crier",
            new State(
                new State("Wait",
                        //new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(100, "Talk")
                        ),
                new State("Talk",
                    new Taunt("Join our discord discord.gg/GGfqPSu it has over 500 users! Thanks to Cleg."),
                    new TimedTransition(30000, "TEXT2"),
                    new NoPlayerWithinTransition(100, "Wait")
                        ),
            new State("TEXT2",
                new Taunt("Report any bugs/exploits/hackers to the owner and main developer Kierze."),
                new TimedTransition(30000, "TEXT3"),
                new NoPlayerWithinTransition(100, "Wait")
                ),
            new State("TEXT3",
                new Taunt("Feel free to suggest any features/idea's to Kierze however do not suggest custom items"),
                new TimedTransition(30000, "TEXT4"),
                new NoPlayerWithinTransition(100, "Wait")
                ),
            new State("TEXT4",
                new Taunt("Lil pump"),
                new TimedTransition(30000, "Talk"),
                new NoPlayerWithinTransition(100, "Wait")
                )
            ));
                

    }
}
