//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
using RBot;
public class BurningBladeOfAbezeth
{
    public ScriptInterface Bot => ScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreStory Story = new CoreStory();

    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        GetBBoA();

        Core.SetOptions(false);
    }

    public void GetBBoA()
    {
        if (Core.CheckInventory("Burning Blade Of Abezeth"))
            return;

        Core.EquipClass(ClassType.Solo);
        Bot.Quests.UpdateQuest(6042);
        Core.HuntMonster("celestialarenad", "Aranx", "Burning Blade Of Abezeth", isTemp: false);
        Bot.Wait.ForPickup("Burning Blade Of Abezeth");
    }
}
