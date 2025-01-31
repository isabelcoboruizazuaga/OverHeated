using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject VirtualCursor;
    private void Awake()
    {
       
    }
    public void UnSetCursor()
    {
        VirtualCursor.SetActive(false);
    }

    public void OpenMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true; 
        VirtualCursor.SetActive(true);
    }

}
