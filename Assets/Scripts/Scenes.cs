
    public enum Scenes
    {
        JungleLevel3,
        TutorialLevel,
        JungleLevel2,
        SandLevel2,
        SandLevel3,
        SnowLevel1,
        SnowLevel2,
        SnowLevel3

}

    public static class ScenesExtensions
    {
        public static string Name(this Scenes me)
        {
            switch (me)
            {
                case Scenes.JungleLevel3:
                    return "JungleLevel3";
                case Scenes.TutorialLevel:
                    return "TutorialLevel";
                case Scenes.JungleLevel2:
                    return "JungleLevel2";
                case Scenes.SandLevel2:
                     return "SandLevel2";
                case Scenes.SandLevel3:
                   return "SandLevel3";
                case Scenes.SnowLevel1:
                    return "SnowLevel1";
                case Scenes.SnowLevel2:
                    return "SnowLevel2";
                case Scenes.SnowLevel3:
                    return "SnowLevel3";

            default:
                    return "Scene Not Found";
            }
        }
    }

