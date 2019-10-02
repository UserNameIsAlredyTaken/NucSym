using UnityEngine;

public class ElectronShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject _electron;

    [SerializeField]
    private float _speed;

    private GameObject _electronsParent;

    private void Awake()
    {
        _electronsParent = new GameObject();
        _electronsParent.name = "Electrons";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var transform1 = transform;
            GameObject electron = Instantiate(_electron, transform1.position, Quaternion.identity, _electronsParent.transform);
            electron.GetComponent<Rigidbody>().velocity = transform1.forward * _speed;
        }
        
    }
}
