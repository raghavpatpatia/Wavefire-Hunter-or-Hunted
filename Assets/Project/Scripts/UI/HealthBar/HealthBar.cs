using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    private Camera cam;
    private void Awake()
    {
        cam = Camera.main;
    }
    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    private void Update()
    {
        transform.rotation = cam.transform.rotation;
        transform.position = transform.position + offset;
    }
}