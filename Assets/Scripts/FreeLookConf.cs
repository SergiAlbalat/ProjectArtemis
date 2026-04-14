using System.Linq;
using Unity.Cinemachine;
using UnityEngine;

public class FreeLookConf : MonoBehaviour
{
    private CinemachineCamera _camera;
    private void Start()
    {
        _camera = GetComponent<CinemachineCamera>();
        _camera.Follow = GameObject.FindGameObjectWithTag("LookPoint").transform;
    }
}
