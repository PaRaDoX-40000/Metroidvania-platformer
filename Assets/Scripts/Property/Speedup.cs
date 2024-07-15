
public class Speedup : ItemProperty
{
    public override void EnableProperty(ListPropertyToApply listPropertyToApply)
    {
        listPropertyToApply.PlayerMovement.AddPropertySpeed(0.5f);
    }
    public override void DisableProperty(ListPropertyToApply listPropertyToApply)
    {
        listPropertyToApply.PlayerMovement.AddPropertySpeed(-0.5f);
    }
}
