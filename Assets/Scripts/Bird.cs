using UnityEngine;

public class Bird : MonoBehaviour
{
    private string _jumpKey = "Jump";

    [SerializeField]private Vector3 _jumpForce;
    [SerializeField]private Vector3 _jumpLeftForce;
    [SerializeField]private Vector3 _jumpRightForce;
    [SerializeField]private Rigidbody _rigidbody;
    [SerializeField]private ParticleSystem _jumpEffect;
    [SerializeField]private Animator _animator;

    private int _upJumpScore = 1;
    private float _defaultScale;
    private float _targetScale;
    private float _additiveScalePerJump = 0.25f;
    private int _leftAndRightJumpScore = 3;
    public int JumpCount { get; private set;}
    public float MaxScale => _defaultScale * 2;

    private void Start()
    {
        _defaultScale = _targetScale = transform.localScale.y;
    }

    private void Update()
    {
        UpdateScale();
        if (Input.GetKeyDown(KeyCode.W))
        {
            
            _rigidbody.AddForce(_jumpForce, ForceMode.Impulse);
            AddJumpCount(_upJumpScore);
            IncreaseTargetScale();
            _jumpEffect.Play();
            _animator.SetTrigger(_jumpKey);
            
        }
        if (Input.GetKeyDown(KeyCode.A))
        {

            _rigidbody.AddForce(_jumpLeftForce, ForceMode.Impulse);
            AddJumpCount(_leftAndRightJumpScore);
            IncreaseTargetScale();
            _jumpEffect.Play();
            _animator.SetTrigger(_jumpKey);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {

            _rigidbody.AddForce(_jumpRightForce, ForceMode.Impulse);
            AddJumpCount(_leftAndRightJumpScore);
            IncreaseTargetScale();
            _jumpEffect.Play();
            _animator.SetTrigger(_jumpKey);
        }
    }
    public void Reset()
    {
        JumpCount = 0;
        _rigidbody.linearVelocity = Vector3.zero;
    }
    public void AddJumpCount(int count) => JumpCount += count;

    private void IncreaseTargetScale()
    {
        _targetScale += _additiveScalePerJump;

        if (_targetScale > MaxScale) _targetScale = MaxScale;
    }

    private void UpdateScale()
    {
        if (_targetScale > _defaultScale) _targetScale -= Time.deltaTime;

        transform.localScale = new Vector3(_targetScale, _targetScale, _targetScale);
    }
}
