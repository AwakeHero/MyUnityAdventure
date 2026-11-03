using TMPro;
using UnityEngine;

public class DistanceDetector : MonoBehaviour
{
    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondPoint;
    [SerializeField] private TMP_Text _distanceText;
    private float distance;
    Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        direction = _secondPoint.position - _firstPoint.position;
        distance = direction.magnitude;
        _distanceText.text = distance.ToString("0.00");
    }
}
