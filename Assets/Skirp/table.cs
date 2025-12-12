using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class table : MonoBehaviour
{
    public InputActionReference input;
    public GameObject canvas;
    private bool isactive= false;
    private Animator anim;
    public controller move;
    private bool busy;

    void Start()
    {
        anim = canvas.GetComponent<Animator>();
    }

    void OnEnable()
    {
        input.action.performed += canvases;
        input.action.Enable();
    }
    void OnDisable()
    {
        input.action.performed -= canvases;
        input.action.Disable();
    }
    public void canvases(InputAction.CallbackContext context)
{
    if (busy) return; 

    if (isactive)
        StartCoroutine(exit());
    else
        StartCoroutine(entry());
}
    IEnumerator exit()
{
    busy = true;
    move.enabled = true;     
    input.action.Disable();

    anim.SetTrigger("Exit");
    yield return new WaitForSeconds(1f);

    isactive = false;
    input.action.Enable();

    busy = false;             
}

IEnumerator entry()
{
    busy = true;              
    move.enabled = false;
    anim.SetTrigger("Entry");
    yield return new WaitForSeconds(1f);

    isactive = true;

    busy = false;
}
}
