using UnityEngine;

public enum EVENTS { FIRED, RELOADED }

public interface Observer
{
	void OnNotify(GameObject actor, EVENTS e);
}

public class AchievementObserver : Observer
{
	enum Achievements { FIRED_100_TIMES, RELOADED_10_TIMES }
	int _timesPlayerReloaded;
	int _timesPlayerFired;
	public void OnNotify(GameObject actor, EVENTS e)
	{
		switch(e)
		{
			case EVENTS.FIRED: HandleFire(actor);
			break;

            case EVENTS.RELOADED: HandleReload(actor);
            break;
		}
	}

	void HandleFire(GameObject actor)
	{
		_timesPlayerFired++;
		if(_timesPlayerFired == 100)
		{
			Unlock(Achievements.FIRED_100_TIMES);
		}
	}
    void HandleReload(GameObject actor)
    {
        if(actor.GetComponent<PlayerComponent>())
        {
            _timesPlayerReloaded++;
        }

        if(_timesPlayerReloaded == 10)
        {
            Unlock(Achievements.RELOADED_10_TIMES);
        }
    }

	void Unlock(Achievements a)
	{
		Debug.Log ("You just unlocked the " + a + " achievement!");
	}
}
