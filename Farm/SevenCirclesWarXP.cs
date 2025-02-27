//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
using RBot;

public class SevenCirclesWarXP
{
    public ScriptInterface Bot => ScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new CoreFarms();
    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        //Farm.UseBoost(ChangeToBoostID, RBot.Items.BoostType.Experience, true);
        // Change the level to 101 so it will run until you stop it.
        Farm.SevenCirclesWar(level: 100, wrathEssence: 0, heresySouls: 0);

        Core.SetOptions(false);
    }
}