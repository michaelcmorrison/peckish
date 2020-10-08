using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class WigglerSpawner : MonoBehaviour
{
    public CoordinatePair xBounds;
    public CoordinatePair yBounds;
    public float boundsOffset;
    public float spawnRate;

    private float _spawnRefresh;
    
    void Update()
    {
        if (Time.time > _spawnRefresh)
        {
            SpawnWiggler(PickRandomWiggler(), PickRandomPositionInBounds());
            _spawnRefresh = Time.time + spawnRate;
        }
    }

    private void SpawnWiggler(WigglerType wigglerType, Vector2 position)
    {
        Instantiate(Resources.Load(wigglerType.ToString()),position, quaternion.identity);
    }

    private WigglerType PickRandomWiggler()
    {
        switch (Random.Range(0, 3))
        {
            case 0:
                return WigglerType.GreenWiggler;
            case 1:
                return WigglerType.PinkWiggler;
            case 2:
                return WigglerType.GoldenWiggler;
            default:
                return WigglerType.PinkWiggler;
        }
    }
    
    private Vector2 PickRandomPositionInBounds()
    {
        var randomX = Random.Range(xBounds.point1 + boundsOffset, xBounds.point2 - boundsOffset);
        var randomY = Random.Range(yBounds.point1 + boundsOffset, yBounds.point2 - boundsOffset);
        return new Vector2(randomX, randomY);
    }
}