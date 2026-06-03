using UnityEngine;

public class Pausemenu : MonoBehaviour
{
    [SerializeField] private GameObject pausemenu;
    void Start()
    {
        if (Application.isPlaying)
        {
            if (pausemenu.activeInHierarchy)
            {
                pausemenu.SetActive(false);
                Time.timeScale = 1f;
            }

        }

       
    }


    void Update()
    {
        if (pausemenu.activeSelf == false)
        {
        
            {
                pausemenu.SetActive(true);
            }

        }
    }








}
