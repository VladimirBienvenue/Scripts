//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Nulgath/CoreNulgath.cs
using RBot;

public class VoidKnightSword
{
    public ScriptInterface Bot => ScriptInterface.Instance;

    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new CoreFarms();
    public CoreNulgath Nulgath = new CoreNulgath();

    public void ScriptMain(ScriptInterface bot)
    {
        Core.BankingBlackList.AddRange(Nulgath.bagDrops);
        Core.SetOptions();

        VoidKightSwordQuest();

        Core.SetOptions(false);
    }

    public void VoidKightSwordQuest(string item = "Any", int quant = 1)
    {
        if (Core.CheckInventory(item, quant) || (!Core.CheckInventory(38275) && !Core.CheckInventory(38254)))
            return;

        Core.Logger($"Farming for {item}({quant})");
        int i = 1;
        while (!Bot.Inventory.Contains(item, quant))
        {
            if (Core.CheckInventory(38275))
                Core.EnsureAccept(5662);
            else
                Core.EnsureAccept(5659);
            Core.HuntMonster("mobius", "Slugfit", "Slugfit Horn", 5);
            Core.HuntMonster("faerie", "Aracara", "Aracara Silk");
            Core.KillMonster("tercessuinotlim", "m2", "Bottom", "Dark Makai", "Makai Fang", 5);
            Core.HuntMonster("hydra", "Fire Imp", "Imp Flame", 3);
            Core.HuntMonster("battleunderc", "Crystalized Jellyfish", "Aquamarine of Nulgath", 3, false);
            if (Core.CheckInventory(38275))
                Core.EnsureComplete(5662);
            else
                Core.EnsureComplete(5659);
            Bot.Player.Pickup(Nulgath.bagDrops);
            Core.Logger($"Completed x{i++}");
        }
    }
}