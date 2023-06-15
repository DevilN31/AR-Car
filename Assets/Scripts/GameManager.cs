using Niantic.ARDK.AR.ARSessionEventArgs;
using Niantic.ARDK.AR;
using Niantic.ARDK.Utilities.Input.Legacy;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Niantic.ARDKExamples.Helpers;
using Niantic.ARDK.Extensions.Meshing;

public class GameManager : MonoBehaviour
{
   
    [SerializeField]
    ARMeshManager _ArMeshManagerRef;
    [SerializeField]
    TextMeshProUGUI _MeshViewButtonText;

    bool _meshView;


    private void Start()
    {
        _meshView = _ArMeshManagerRef.UseInvisibleMaterial;
        _MeshViewButtonText.text = _meshView ? "Mesh View On" : "Mesh View Off";


    }

    public void ToggleMeshView()
    {
        _meshView= !_meshView;
        _ArMeshManagerRef.UseInvisibleMaterial = _meshView;
        _MeshViewButtonText.text = _meshView ? "Mesh View On" : "Mesh View Off";
    }

}
