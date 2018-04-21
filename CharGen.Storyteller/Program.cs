using StoryTeller;

namespace CharGen.Storyteller
{
    internal static class Program
    {
        private static int Main(string[] args)
        {
            return StorytellerAgent.Run(args);
        }
    }
}