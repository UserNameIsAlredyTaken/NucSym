using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    [SerializeField] private GameObject _uranAtom;
    [SerializeField] private int _diametr;
    [SerializeField] private int _count;
    
    void Start()
    {
        for (int i = 0; i < _count; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(-_diametr / 2, _diametr / 2),
                Random.Range(-_diametr / 2, _diametr / 2),
                Random.Range(-_diametr / 2, _diametr / 2));
            GameObject atom =  Instantiate(_uranAtom, position, Quaternion.identity, transform);
            //atom.isStatic = true;
        }
    }
}
