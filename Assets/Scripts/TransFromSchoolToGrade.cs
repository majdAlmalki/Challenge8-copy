using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransFromSchoolToGrade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            SceneManager.LoadScene(2);

    }

    public void GoScens(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
