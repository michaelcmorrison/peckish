using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal => Input.GetAxis("Horizontal");
    public float Vertical => Input.GetAxis("Vertical");
    public bool EPressed => Input.GetKeyDown(KeyCode.E);
}