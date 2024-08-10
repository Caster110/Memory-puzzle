using System;
public static class EventBus
{
    public static Action <Tile> OnTileClicked;
    public static Action OnSolutionShown;
    public static Action OnStagePassed;
    public static Action OnGameStarted;
    public static Action OnGameFailed;
    public static void RemoveAllListeners()
    { 
        OnTileClicked = null;
        OnSolutionShown = null;
        OnStagePassed = null;
        OnGameStarted = null;
        OnGameFailed = null;
    }
}
