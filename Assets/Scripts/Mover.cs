using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class Mover : MonoBehaviour
{
    public float moveSpeed;
    
    private SpriteRenderer _spriteRenderer;
    private PlayerInput _playerInput;
    private Camera _mainCamera;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerInput = GetComponent<PlayerInput>();
        _mainCamera = Camera.main;
    }
    
    void Update()
    {
        if (Mathf.Abs(_playerInput.Horizontal) > 0 || Mathf.Abs(_playerInput.Vertical) > 0)
        {
            var movement = new Vector3(_playerInput.Horizontal, _playerInput.Vertical, 0);
            transform.position += movement * (Time.deltaTime * moveSpeed);
            FlipSprite(movement);
            ClampPosition();
        }
    }

    private void FlipSprite(Vector3 movement)
    {
        if (movement.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (movement.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }

    private void ClampPosition()
    {
        Vector3 pos = _mainCamera.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = _mainCamera.ViewportToWorldPoint(pos);
    }
}