public class FGGameState
{
    public enum FGameState { Play, OpenUI }

    private static FGameState curState = FGameState.Play;


    public static void Play() { curState = FGameState.Play; }
    public static void OpenUI() { curState = FGameState.OpenUI; }

    public static bool IsPlay() { return curState == FGameState.Play; }
    public static bool IsOpenUI() { return curState == FGameState.OpenUI; }
}