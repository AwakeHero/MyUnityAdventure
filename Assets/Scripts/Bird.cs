using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField]private Vector3 _jumpForce;
    [SerializeField]private Rigidbody _rigidbody;

    public int JumpCount { get; private set;}

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            _rigidbody.AddForce(_jumpForce, ForceMode.Impulse);
            JumpCount++;
        }
    }

    public void ResetJumpCount() => JumpCount = 0;
}
