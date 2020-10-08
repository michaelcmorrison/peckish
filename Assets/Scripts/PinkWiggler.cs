public class PinkWiggler : Wiggler
{
    public int pointsGiven;
    
    public override void Pull()
    {
        WormTracker.WormsPulled++;
        WormTracker.PointsCollected += pointsGiven;
        Destroy(gameObject);
    }
}