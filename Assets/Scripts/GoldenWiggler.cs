using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GoldenWiggler : Wiggler
{
    [Tooltip("Number from 0 to 1")]
    public float chanceOfSnake;
    public float warningTime;

    public int pointsGiven;
    
    public override void Pull()
    {
        if (Random.Range(0f,1f) < chanceOfSnake)
        {
            StartCoroutine(SpawnGoldenSnake());
        }
        else
        {
            WormTracker.WormsPulled++;
            WormTracker.PointsCollected += pointsGiven;
            Destroy(gameObject);
        }
    }

    private IEnumerator SpawnGoldenSnake()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        var warning = Instantiate(Resources.Load("Warning"), transform.position, quaternion.identity);
        yield return new WaitForSeconds(warningTime);
        Destroy(warning);
        Instantiate(Resources.Load("GoldenSnake"), transform.position, quaternion.identity);
        Destroy(gameObject);
    }
}