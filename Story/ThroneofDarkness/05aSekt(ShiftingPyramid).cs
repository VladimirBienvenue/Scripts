//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
using RBot;
public class ShiftingPyramid
{
    public ScriptInterface Bot => ScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreStory Story = new CoreStory();

    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        ShiftingPyramidSaga();

        Core.SetOptions(false);
    }

    public void ShiftingPyramidSaga()
    {
        if (Core.isCompletedBefore(5187))
            return;

        // Hunt for the Infinity Codex
        Story.KillQuest(5166, "whitehole", "Vortex Mage");
        // Sacrific and Survival
        Story.KillQuest(5167, "whitehole", new[] { "Vortex Naga", "Vortex Hawk" });
        // The Cartouche of Isis
        Story.KillQuest(5168, "whitehole", "Gate Goblin");
        // The Cartouche of Ma'at
        Story.KillQuest(5169, "whitehole", "Vortex Walker");
        // Bound to Do Good
        Story.KillQuest(5170, "whitehole", new[] { "Dimensional Crystal", "Gate Goblin", "Vortex Matter" });
        // Honor the Goddess Isis
        Story.MapItemQuest(5171, "whitehole", 4539, 1);
        // Stick to the Task
        Story.KillQuest(5172, "whitehole", new[] { "Dimensional Crystal", "Gate Goblin", "Vortex Matter" });
        // Honor the Goddess Ma'at
        Story.MapItemQuest(5173, "whitehole", 4540, 4);
        Story.MapItemQuest(5173, "whitehole", 4542, 1);
        // Duty is light as a feather
        Story.KillQuest(5174, "whitehole", "Vortex Hawk");
        // Judgement... or Justice?
        Story.KillQuest(5175, "whitehole", "Hand of Ma'at");
        // The Cartouche of Thoth
        Story.KillQuest(5176, "whitehole", "Vortex Mage");
        // Make Your Mark
        Story.MapItemQuest(5177, "whitehole", 4541, 4);
        // The Cartouche of Kebechet
        Story.KillQuest(5178, "whitehole", "Vortex Naga");
        // Honor the Goddess Kebechet
        Story.MapItemQuest(5179, "whitehole", 4543, 1);
        // Destroy to Purify
        Story.KillQuest(5180, "whitehole", "Vortex Crystal");
        // Guardian of the Vortex
        Story.KillQuest(5181, "whitehole", "Vortex Guardian");
        // Stick with it
        Story.KillQuest(5182, "whitehole", new[] { "Dimensional Crystal", "Gate Goblin", "Vortex Matter" });
        // Honor the God Thoth
        Story.MapItemQuest(5183, "whitehole", 4544, 1);
        // The Brightest Cartouches
        if (!Story.QuestProgression(5184))
        {
            Core.EnsureAccept(5184);
            Core.HuntMonster("whitehole", "Dimensional Crystal", "Sun Cartouche");
            Core.HuntMonster("whitehole", "Dimensional Crystal", "Sky Cartouche");
            Core.HuntMonster("whitehole", "Vortex Matter", "Star Cartouche");
            Core.HuntMonster("whitehole", "Vortex Crystal", "Moon Cartouche");
            Core.EnsureComplete(5184);
        }
        // Honor the Astral Deities
        Story.MapItemQuest(5185, "whitehole", 4545, 4);
        // Serpent of the Stars
        Story.KillQuest(5186, "whitehole", "Mehensi Serpent");
        // The Infinity Shield
        Story.MapItemQuest(5187, "whitehole", 4546, 1);
    }
}
