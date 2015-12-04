using Assets.Scripts;

public class PlayerComponent : CharacterComponent
{
    public override void Fire()
    {
        Notify(gameObject, EVENTS.PLAYER_FIRED);
        base.Fire();
        Services.Logger.Info(this, "Firing " + name + "'s weapon.");
    }

    public override void Jump()
    {
        Notify(gameObject, EVENTS.PLAYER_JUMPED);
        base.Jump();
        Services.Logger.Info(this, "Make " + name + " jump.");
    }

    void Awake()
    {
        Observers.Add(new AchievementObserver());
    }
}