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
    [SerializeField] private float _activatingTimeOut = 4;

    private float _activateTime;
    private bool _isActivated;
    private Material _disactivatedMat;

    private void Start()
    {
        _disactivatedMat = GetComponent<MeshRenderer>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isActivated)
            return;
        
        _isActivated = true;
        _activateTime = Time.time;
        
        Destroy(other.gameObject);

        for (int i = 0; i < _newElectronsCount; i++)
        {
            SpawnNewElectron();
        }
        
        GetComponent<MeshRenderer>().material = _activatedMat;
    }

    void Update()
    {
        if (!_isActivated)
            return;

        if (Time.time - _activateTime > _activatingTimeOut)
        {
            _isActivated = false;
            GetComponent<MeshRenderer>().material = _disactivatedMat;
        }
            
    }
    
    

    private void SpawnNewElectron()
    {
        GameObject electron = Instantiate(_electron, transform.position, Quaternion.identity);
        electron.GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * _electronsSpeed;
        Destroy(electron, _electronLifetime);
    }
}
