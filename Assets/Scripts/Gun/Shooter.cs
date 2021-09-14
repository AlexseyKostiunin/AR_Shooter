using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletTemplate;

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            CreatingBullet();
        }
    }

    private void CreatingBullet()
    {
        Instantiate(_bulletTemplate, _shootPoint);
    }
}
