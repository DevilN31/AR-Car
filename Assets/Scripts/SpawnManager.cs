using Niantic.ARDK.AR.ARSessionEventArgs;
using Niantic.ARDK.AR;
using Niantic.ARDK.Utilities.Input.Legacy;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI _LogText;
    [SerializeField]
    TextMeshProUGUI _PlacebuttonText;
    [SerializeField]
    GameObject _PlayerPrefab;
    [SerializeField]
    bool _IsPlaceMode = false;

    GameObject _CurrentPlayer;

    /// Internal reference to the session, used to get the current frame to hit test against.
    private IARSession _session;


    private void Start()
    {
        ARSessionFactory.SessionInitialized += OnAnyARSessionDidInitialize;
        _IsPlaceMode= false;
        _PlacebuttonText.text = "Place Mode Off";
    }

    private void OnAnyARSessionDidInitialize(AnyARSessionInitializedArgs args)
    {
        _session = args.Session;
        _session.Deinitialized += OnSessionDeinitialized;
    }

    private void OnSessionDeinitialized(ARSessionDeinitializedArgs args)
    {

    }

    private void OnDestroy()
    {
        ARSessionFactory.SessionInitialized -= OnAnyARSessionDidInitialize;

        _session = null;

    }

    private void Update()
    {
        if (_session == null)
        {
            return;
        }

        if (PlatformAgnosticInput.touchCount <= 0)
        {
            return;
        }

        var touch = PlatformAgnosticInput.GetTouch(0);
        if (touch.phase == TouchPhase.Ended && !touch.IsTouchOverUIObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(touch.position);

            if (Physics.Raycast(ray, out hit, 100))
            {
                _LogText.text = $"hit {hit.collider.name} at {hit.point} layer of {hit.collider.gameObject.layer} ";
                if (_IsPlaceMode)
                {
                    if (_CurrentPlayer == null)
                    {
                        _CurrentPlayer = Instantiate(_PlayerPrefab, hit.point, Quaternion.identity);
                    }
                    else
                    {
                        _CurrentPlayer.transform.position = hit.point;
                        _CurrentPlayer.transform.rotation = Quaternion.identity;


                    }
                }
            }
        }
    }

    public void TogglePlacingMode()
    {
        _IsPlaceMode= !_IsPlaceMode;
        _PlacebuttonText.text = _IsPlaceMode ? "Place Mode On" : "Place Mode Off";
    }
}
