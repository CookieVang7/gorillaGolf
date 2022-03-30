

    public enum Scenes
    {
        JoshLevel,
        TutorialLevel,
        ConnerLevel2

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
            default:
                    return "Scene Not Found";
            }
        }
    }

