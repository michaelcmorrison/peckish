using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GreenWiggler : Wiggler
{
    [Tooltip("Number from 0 to 1")]
    public float chanceOfSnake;
    public float warningTime;

    public int pointsGiven = 3;
    public int livesGiven = 1;

    public override void Pull()
    {
        if (Random.Range(0f,1f) < chanceOfSnake)
        {
            StartCoroutine(SpawnGreenSnake());
        }
        else
        {
            WormTracker.WormsPulled++;
            WormTracker.PointsCollected += pointsGiven;
            var player = GameObject.Find("Birdie").GetComponent<Birdie>();
            if (!(player.lives + livesGiven > player.startingLives))
            {
                player.lives += livesGiven;
            }
            Destroy(gameObject);
        }
    }

    private IEnumerator SpawnGreenSnake()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        var warning = Instantiate(Resources.Load("Warning"), transform.position, quaternion.identity);
        yield return new WaitForSeconds(warningTime);
        Destroy(warning);
        Instantiate(Resources.Load("GreenSnake"), transform.position, quaternion.identity);
        Destroy(gameObject);
    }
}