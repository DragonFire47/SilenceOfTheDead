using PulsarModLoader;

namespace SilenceOfTheDead
{
    public class Mod : PulsarMod
    {
        public override string Version => "1.0.0";

        public override string Author => "Dragon";

        public override string Name => "SilenceOfTheDead";

        public override string HarmonyIdentifier()
        {
            return $"{Author}.{Name}";
        }
    }
}
