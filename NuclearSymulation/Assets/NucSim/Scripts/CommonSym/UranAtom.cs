using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class UranAtom : MonoBehaviour
{
    [SerializeField] 
    private GameObject _electron;
    [SerializeField] 
    private int _newElectronsCount;
    [SerializeField] 
    private Material _activatedMat;
    [SerializeField]
    private float _electronsSpeed;

    [SerializeField] 
    private float _electronLifetime;
    
    private bool _isActivated;
    
    private void OnTriggerEnter(Collider other)
    {
        if (_isActivated)
            return;
        _isActivated = true;
        
        Destroy(other.gameObject);

        for (int i = 0; i < _newElectronsCount; i++)
        {
            SpawnNewElectron();
        }
        
        GetComponent<MeshRenderer>().material = _activatedMat;
    }

    private void SpawnNewElectron()
    {
        GameObject electron = Instantiate(_electron, transform.position, Quaternion.identity);
        electron.GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * _electronsSpeed;
        Destroy(electron, _electronLifetime);
    }
}
