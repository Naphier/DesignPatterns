using Assets.Scripts;
using UnityEngine;

public enum EVENTS
{
    PLAYER_JUMPED,
    PLAYER_FIRED,
    JUMPED,
    FIRED
}

public interface Observer
{
    void OnNotify(GameObject actor, EVENTS e);
}

public class AchievementObserver : Observer
{
    private int _numberOfPlayerJumps;
    private int _timesPlayerFired;

    public void OnNotify(GameObject actor, EVENTS e)
    {
        switch (e)
        {
            case EVENTS.PLAYER_JUMPED:
                HandlePlayerJump();
                break;

            case EVENTS.PLAYER_FIRED:
                HandlePlayerFire();
                break;
        }
    }

    private void HandlePlayerFire()
    {
        _timesPlayerFired++;
        if (_timesPlayerFired == 100)
        {
            Unlock(Achievements.FIRED_100_TIMES);
        }
    }

    private void HandlePlayerJump()
    {
        _numberOfPlayerJumps++;
        if (_numberOfPlayerJumps == 10)
        {
            Unlock(Achievements.JUMPED_TEN_TIMES);
        }
    }

    private void Unlock(Achievements a)
    {
        Services.Logger.Info(this, "You just unlocked the " + a + " achievement!");
    }

    private enum Achievements
    {
        JUMPED_TEN_TIMES,
        FIRED_100_TIMES
    }
}