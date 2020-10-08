using System;
using UnityEngine;

public class Pullable : MonoBehaviour
{
    public int currentPresses;
    [SerializeField] private int numPressesToPull = 10;

    private Wiggler _wiggler;
    private bool _playerNearby;
    private PlayerInput _playerInput;

    private void Start()
    {
        _wiggler = GetComponent<Wiggler>();
    }

    private void Update()
    {
        if (!_playerNearby) return;
        
        if (_playerInput.EPressed)
        {
            currentPresses++;
            if (currentPresses == numPressesToPull)
            {
                _wiggler.Pull();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (_playerInput == null)
            {
                _playerInput = other.gameObject.GetComponent<PlayerInput>();    
            }

            _playerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerNearby = false;
        }
    }
}
