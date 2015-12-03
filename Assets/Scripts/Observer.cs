using UnityEngine;
public enum EVENTS { PLAYER_JUMPED, PLAYER_FIRED, JUMPED, FIRED }

public interface Observer
{
	void OnNotify(GameObject actor, EVENTS e);
}

public class AchievementObserver : Observer
{
	enum Achievements { JUMPED_TEN_TIMES, FIRED_100_TIMES }
	int _numberOfPlayerJumps;
	int _timesPlayerFired;

	public void OnNotify(GameObject actor, EVENTS e)
	{
		switch(e)
		{
			case EVENTS.PLAYER_JUMPED: HandlePlayerJump();
			break;

			case EVENTS.PLAYER_FIRED: HandlePlayerFire();
			break;
		}
	}

	void HandlePlayerFire()
	{
		_timesPlayerFired++;
		if(_timesPlayerFired == 100)
		{
			Unlock(Achievements.FIRED_100_TIMES);
		}
	}

	void HandlePlayerJump()
	{
		_numberOfPlayerJumps++;
		if(_numberOfPlayerJumps == 10)
		{
			Unlock(Achievements.JUMPED_TEN_TIMES);
		}
	}

	void Unlock(Achievements a)
	{
		Debug.Log ("You just unlocked the " + a + " achievement!");
	}
}
