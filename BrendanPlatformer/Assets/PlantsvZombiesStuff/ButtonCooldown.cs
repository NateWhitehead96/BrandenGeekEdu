using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCooldown : MonoBehaviour
{
    public Button self;
    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Button>();
    }

    public void ActivateCooldown()
    {
        StartCoroutine(HandleCooldown());
    }

    IEnumerator HandleCooldown()
    {
        self.interactable = false;
        yield return new WaitForSeconds(1);
        self.interactable = true;
    }
}
