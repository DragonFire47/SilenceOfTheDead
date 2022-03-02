using PulsarModLoader.CustomGUI;
using static UnityEngine.GUILayout;

namespace SilenceOfTheDead
{
    class GUI : ModSettingsMenu
    {
        public override string Name()
        {
            return "Silence Of The Dead";
        }
        public static bool ShouldBeMuting = true;
        public override void Draw()
        {
            ShouldBeMuting = Toggle(ShouldBeMuting, "Should be muting the dead");
        }
    }
}
