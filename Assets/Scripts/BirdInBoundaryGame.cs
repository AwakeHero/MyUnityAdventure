using UnityEngine;

public class BirdInBoundaryGame : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private float _upperYLimit;
    [SerializeField] private float _lowerYLimit;
    [SerializeField] private float _leftXLimit;
    [SerializeField] private float _rightXLimit;
    
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

        if (_IsOutOfBoundary()) LoseGame();

        if (_IsWinner()) WinGame();
    }

    private bool _IsOutOfBoundary() => _bird.transform.position.y > _upperYLimit || _bird.transform.position.y < _lowerYLimit || _bird.transform.position.x < _leftXLimit || _bird.transform.position.x > _rightXLimit;
    private bool _IsWinner() => _bird.JumpCount >= 30;

    private void StartGame()
    {
        _bird.gameObject.SetActive(true);
        _bird.transform.position = Vector3.zero;
        _bird.Reset();
        _isRunning = true;
    }

    private void LoseGame()
    {
        Debug.Log($"Ваши счет: {_bird.JumpCount}");
        _bird.gameObject.SetActive(false);
        _isRunning = false;
    }

    private void WinGame()
    {
        Debug.Log($"Вы победили!");
        Debug.Log($"Ваши счет: {_bird.JumpCount}");
        _bird.gameObject.SetActive(false);
        _isRunning = false;
    }
}
