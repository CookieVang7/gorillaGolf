
    public enum Scenes
    {
        MainMenu,
        JungleLevel3,
        TutorialLevel,
        JungleLevel2,
        SandLevel1,
        SandLevel2,
        SandLevel3,
        SnowLevel1,
        SnowLevel2,
        JoshSnow,
        BenChallenge,
        JoshChallenge

}

    public static class ScenesExtensions
    {
        public static string Name(this Scenes me)
        {
            switch (me)
            {
                case Scenes.MainMenu:
                    return "MainMenu";
                case Scenes.JungleLevel3:
                    return "JungleLevel3";
                case Scenes.TutorialLevel:
                    return "TutorialLevel";
                case Scenes.JungleLevel2:
                    return "JungleLevel2";
                case Scenes.SandLevel1:
                    return "SandLevel1";
                case Scenes.SandLevel2:
                     return "SandLevel2";
                case Scenes.SandLevel3:
                   return "SandLevel3";
                case Scenes.SnowLevel1:
                    return "SnowLevel1";
                case Scenes.SnowLevel2:
                    return "SnowLevel2";
                case Scenes.JoshSnow:
                    return "JoshSnow";
                case Scenes.BenChallenge:
                    return "BenChallenge";
                case Scenes.JoshChallenge:
                    return "JoshChallenge";

            default:
                    return "Scene Not Found";
            }
        }
    }

