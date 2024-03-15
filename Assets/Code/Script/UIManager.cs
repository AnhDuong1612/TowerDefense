using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager main;

    private bool ishoveringUI;

    private void Awake()
    {
        main = this;
    }

    // setter , getter . Cai dat gia tri bang voi state sau do tra ve gia tri 
    public void SetHoveringState(bool state)
    {
        ishoveringUI = state;
    }

    public bool IsHoveringUI()
    {
        return ishoveringUI;
    }
}

// Can phai cai dat mot lop de luu tru gia tri dang duoc su dung 