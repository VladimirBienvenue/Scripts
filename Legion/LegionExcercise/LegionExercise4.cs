//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Legion/CoreLegion.cs
//cs_include Scripts/CoreStory.cs
using RBot;

public class LegionExercise4
{
    public ScriptInterface Bot => ScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreAdvanced Adv = new CoreAdvanced();
    public CoreLegion Legion = new CoreLegion();
    public CoreStory Story = new CoreStory();

    private string[] Rewards = { "Corrupted Dragon Slayer", "Judgement Scythe", "PainSaw of Eidolon", "Soul Eater Advanced", "Legion Token" };

    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        Exercise(Rewards);

        Core.SetOptions(false);
    }

    public void Exercise(string[] item)
    {
        if (Core.CheckInventory(item))
            return;
        Core.AddDrop(item);

        Legion.JoinLegion();
        Core.BuyItem("underworld", 216, "Undead Warrior");

        Core.Logger("Disclaimer: Percentages are randomized, just made purely for fun. i cba making it an actualy %age");

        int Dice = Bot.Runtime.Random.Next(1, 101);
        //-------------------------------------------------------------------------------------------------------

        int i = 1;
        var displayPercentage = $"{(decimal)Dice / 100:P}";

        Core.Logger($"Potato Prediction Inc. Decided: {displayPercentage} is The Chance for Desired Rewards.");

        while (!Core.CheckInventory(new[] { "Undead Champion Blade", "Legendary Golden Death Blade" }))
        {
            Core.EnsureAccept(824);
            Core.EquipClass(ClassType.Farm);
            Core.HuntMonster("Doomhaven", "Skeletal Ice Mage", "Frostbit Skull", 15, isTemp: false, publicRoom: false);
            Core.HuntMonster("Marsh2", "Lesser Shadow Serpent", "Potent Viper's Blood", publicRoom: false);
            Bot.Sleep(2500);
            Core.EquipClass(ClassType.Solo);
            Core.HuntMonster("Marsh2", "Soulseeker", "Soul Scythe", isTemp: false, publicRoom: false);
            Core.EnsureComplete(824);
            Core.Logger($"Finished Quest {i++} Times");
        }

        Core.Logger($"Farming {item} Took {i++} Times");

        if (i++ > Dice)
            Core.Logger($"Perdiction: {displayPercentage} May have been a bit Low");
        if (i++ < Dice)
            Core.Logger($"Perdiction: {displayPercentage} Was waaaay to high... Congratulations!");

        Core.ToBank(Rewards);
    }

}