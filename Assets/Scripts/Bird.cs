using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField]private Vector3 _jumpForce;
    [SerializeField]private Vector3 _jumpLeftForce;
    [SerializeField]private Vector3 _jumpRightForce;
    [SerializeField]private Rigidbody _rigidbody;
    private int _upJumpCount = 1;
    private int _leftAndRightJumpCount = 3;
    public int JumpCount { get; private set;}

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            
            _rigidbody.AddForce(_jumpForce, ForceMode.Impulse);
            AddJumpCount(_upJumpCount);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {

            _rigidbody.AddForce(_jumpLeftForce, ForceMode.Impulse);
            AddJumpCount(_leftAndRightJumpCount);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {

            _rigidbody.AddForce(_jumpRightForce, ForceMode.Impulse);
            AddJumpCount(_leftAndRightJumpCount);
        }
    }

    public void ResetJumpCount() => JumpCount = 0;
    public void AddJumpCount(int count) => JumpCount += count;
}
