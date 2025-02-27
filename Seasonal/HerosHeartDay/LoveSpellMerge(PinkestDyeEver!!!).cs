//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Seasonal/HerosHeartDay/LoveSpellStory.cs
using RBot;

public class PinkestDyeEver
{
    public ScriptInterface Bot => ScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public LoveSpell LSS = new LoveSpell();

    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        PinkestDyeEverScript();

        Core.SetOptions(false);
    }

    public void PinkestDyeEverScript()
    {
        if (Core.CheckInventory("Pinkest Dye Ever!!!", 200))
        {
            Core.Logger("You already have 200 (Max Quantity) Pinkest Dye Ever!!!");
            return;
        }

        Core.AddDrop("Pinkest Dye Ever!!!");
        LSS.LoveSpellScript();

        while (!Core.CheckInventory("Pinkest Dye Ever!!!", 200))
        {
            Core.EnsureAccept(7935);
            Core.HuntMonster("lovespell", "Mood Slime", "Mood Slime Hearts", 10);
            Core.HuntMonster("lovespell", "Stolen Heart");
            Core.EnsureComplete(7935);
        }
        Core.Logger("You now have 200 (Max Quantity) Pinkest Dye Ever!!!");
    }
}