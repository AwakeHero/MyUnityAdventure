using TMPro;
using UnityEngine;

public class DistanceDetector : MonoBehaviour
{
    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondPoint;
    [SerializeField] private TMP_Text _distanceText;
    [SerializeField] private float _agroDistance;
    private float distance;
    Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        direction = _secondPoint.position - _firstPoint.position;
        distance = direction.magnitude;
        _distanceText.text = distance.ToString("0.00");
        if(distance <= _agroDistance)
        {
            _distanceText.color = Color.red;
            Debug.DrawLine(_firstPoint.position, _secondPoint.position);
        }
        else
        {
            _distanceText.color = Color.white;
        }
    }
}
