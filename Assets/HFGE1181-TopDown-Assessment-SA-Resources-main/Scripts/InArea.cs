using UnityEngine;

public class InArea : MonoBehaviour
{
    public bool inArea;
    public GameObject fixBtn;
    void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
        {
            inArea = true;
            fixBtn.SetActive(true);

            Debug.Log("InArea");
        }  
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inArea = false;
            fixBtn.SetActive(false);
            Debug.Log("ExitArea");
        } 
    }

}
