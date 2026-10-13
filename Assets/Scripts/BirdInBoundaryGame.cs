using UnityEngine;

public class BirdInBoundaryGame : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private float _upperYLimit;
    [SerializeField] private float _lowerYLimit;

    
    private bool _isRunning;

    private void Awake()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) StartGame();
   
        if (!_isRunning) return;

        if (_IsOutOfBoundary()) LooseGame();
    }

    private bool _IsOutOfBoundary() => _bird.transform.position.y > _upperYLimit || _bird.transform.position.y < _lowerYLimit;

    private void StartGame()
    {
        _bird.gameObject.SetActive(true);
        _bird.transform.position = Vector3.zero;
        _bird.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        _bird.ResetJumpCount();
        _isRunning = true;
    }

    private void LooseGame()
    {
        Debug.Log($"Ваши счет: {_bird.JumpCount}");
        _bird.gameObject.SetActive(false);
        _isRunning = false;
    }
}
