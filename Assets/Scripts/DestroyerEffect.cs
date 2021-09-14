using UnityEngine;

public class DestroyerEffect : MonoBehaviour
{
    [SerializeField] private float _timeDestroy;

    private void Start()
    {
        Destroy(gameObject, _timeDestroy);
    }

}
