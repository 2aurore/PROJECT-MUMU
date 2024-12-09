using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingUI : UIBase
{
    [SerializeField] private GameObject loadingIcon;

    private void Update()
    {
        loadingIcon.transform.Rotate(Vector3.forward * Mathf.Sin(Time.time));
    }
}
