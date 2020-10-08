using UnityEngine;
using UnityEngine.UI;

public class HungerBarUI : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    private Birdie _birdie;
    
    private void Awake()
    {
        _birdie = GameObject.Find("Birdie").GetComponent<Birdie>();
    }

    private void Update()
    {
        fillImage.fillAmount = _birdie.hunger.currentValue / _birdie.maxHunger;
    }
}
