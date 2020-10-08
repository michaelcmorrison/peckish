using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioClip chirp;
    public AudioClip squeal;
    public AudioClip gulp;
    public AudioClip flap;
    public AudioClip hiss;
    public AudioClip rattle;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
