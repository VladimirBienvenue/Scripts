//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
using RBot;

public class SeraphicWar_Story
{
    public ScriptInterface Bot => ScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreStory Story = new CoreStory();

    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        SeraphicWar_Questline();

        Core.SetOptions(false);
    }

    public void SeraphicWar_Questline()
    {
        if (Core.isCompletedBefore(6245))
            return;

        //Get the Parts
        Story.KillQuest(6238, "worldsoul", new[] { "Dwakel Infiltrator", "Dwakel Infiltrator", "Dwakel Infiltrator", "Dwakel Infiltrator" });
        //Get the Water
        Story.KillQuest(6239, "worldsoul", "Divine Water Elemental");
        //Get the Fire
        Story.KillQuest(6240, "worldsoul", "Divine Fire Elemental");
        //Gather Armaments
        Story.MapItemQuest(6241, "worldsoul", 5681, 3);
        Story.KillQuest(6241, "worldsoul", "Skeletal Squatter");
        //Plutonium For Power
        Story.KillQuest(6242, "worldsoul", "Radioactive Hydra");
        //Defeat the Undead
        Story.MapItemQuest(6243, "worldsoul", 5680);
        Story.KillQuest(6243, "worldsoul", "Legion Dreadmarch|Legion Shadowpriest");
        //Remove the Ward
        Story.MapItemQuest(6244, "worldsoul", 5682);
        Story.KillQuest(6244, "worldsoul", "Legion Dreadmarch|Legion Shadowpriest");
        //Defeat the Guardian
        Story.KillQuest(6245, "worldsoul", "Core Guardian");
    }
}
