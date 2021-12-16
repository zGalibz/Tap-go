using UnityCore.Menu;
using UnityEngine;

public class GameOverPage : Page
{

    public void TryAgain()
    {
        GameController.instance.TryAgain();
        PageController.instance.TurnPageOff(Type);
    }
    protected override void OnPageEnabled()
    {
    
    }
}
