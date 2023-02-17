using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthorizationButton : WorkButton
{
    [SerializeField] private Authorizer _authorizer;

    protected override void OnButtonClick()
    {
        _authorizer.Authorize();
    }
}
