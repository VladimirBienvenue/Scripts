//cs_include Scripts/CoreBots.cs
using RBot;

public class YeeaaahhBabbyyThaaatsWhatImTalkingAbout
{
    public ScriptInterface Bot => ScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;

    // [Can Change]
    // True = Bot will farm both ac & non-AC items
    // False = Bot will only farm AC items
    // Recommended: false
    private bool GetNONac = false;

    string[] WOOOOODropsAC = {
    "Cr1tikal Hair",
    "Cr1tikal Hair + Beard",
    "Cr1tikal Hat",
    "Cr1tikal Hat + Beard",
    "Cr1tikal Hero",
    "Cr1tikal Meme Poster",
    "2D Moistverse House",
    "GIANT Mushroom Guard (R)",
    "GIANT Mushroom Guard (L)",
    "Major Mushroom Guard (L)",
    "Major Mushroom Guard (R)",
    "Treasure Chest"
    };

    string[] WOOOOODropsNonAC =
    {
    "YugiWOAH Card",
    "ARTX 3090 Controller",
    "ARTX Dome",
    "ARTX Shelf",
    "ARTX Twilly Pet",
    "CCCG Set",
    "Major Mushroom Pet",
    "Moist Water Bottle",
    };

    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        WOOOOOOOOOOOOOOO();

        Core.SetOptions(false);
    }

    public void WOOOOOOOOOOOOOOO()
    {
        string[] FocussedArray;
        if (GetNONac) FocussedArray = WOOOOODropsAC.Concat(WOOOOODropsNonAC).ToArray();
        else FocussedArray = WOOOOODropsAC;
        while (!Core.CheckInventory(FocussedArray))
        {
            Core.EnsureAccept(8497);
            Core.HuntMonster("Mverse", "Major Mushroom", "Dark Caster Card", 1, isTemp: true);
            Core.HuntMonster("Mverse", "Major Mushroom", "Green-Eyes Red Dragon Card", 1, isTemp: true);
            Core.HuntMonster("Mverse", "Major Mushroom", "Mirror Realm's Force Card", 1, isTemp: true);
            Core.HuntMonster("Mverse", "Major Mushroom", "Drakath The Outlawed One Card", 1, isTemp: true);
            Core.EnsureComplete(8497);
        }
    }
}