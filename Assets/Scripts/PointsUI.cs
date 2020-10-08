using TMPro;
using UnityEngine;

public class PointsUI : MonoBehaviour
{
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _text.text = WormTracker.PointsCollected.ToString();
    }
}
