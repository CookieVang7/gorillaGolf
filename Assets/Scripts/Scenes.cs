

    public enum Scenes
    {
        JoshLevel,
        TutorialLevel,
        ConnerLevel2,
        SandLevel2,
        SandLevel3

}

    public static class ScenesExtensions
    {
        public static string Name(this Scenes me)
        {
            switch (me)
            {
                case Scenes.JoshLevel:
                    return "JoshLevel";
                case Scenes.TutorialLevel:
                    return "TutorialLevel";
                case Scenes.ConnerLevel2:
                    return "ConnerLevel2";
                case Scenes.SandLevel2:
                     return "SandLevel2";
                case Scenes.SandLevel3:
                   return "SandLevel3";
            default:
                    return "Scene Not Found";
            }
        }
    }

