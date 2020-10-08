using UnityEngine;

public class Wings : MonoBehaviour
{

    [SerializeField] private float hungerDecay = .02f;

    private Birdie _birdie;
    private Animator _birdieAnimator;
    private static readonly int IsFlying = Animator.StringToHash("IsFlying");

    private void Awake()
    {
        _birdie = GetComponent<Birdie>();
        _birdieAnimator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && _birdie.hunger.currentValue > 0)
        {
            _birdieAnimator.SetBool(IsFlying, true);
            Birdie.IsFlying = true;
            _birdie.hunger.currentValue -= hungerDecay;
        }
        else
        {
            _birdieAnimator.SetBool(IsFlying, false);
            Birdie.IsFlying = false;
        }
    }
}