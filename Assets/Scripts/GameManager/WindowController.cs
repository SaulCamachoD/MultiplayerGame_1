using UnityEngine;

public class WindowController : MonoBehaviour
{
    public GameObject[] windows;

    public void EnableWindows(int numberWindows)
    {
        windows[numberWindows].SetActive(true);
        for (int i = 0; i < windows.Length; i++)
        {
            if(numberWindows != i)
                windows[i].SetActive(false);
        }
    }
}
