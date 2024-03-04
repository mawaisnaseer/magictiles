using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private Button restarGame; 

    // Start is called before the first frame update
    void Start()
    {
        restarGame.onClick.AddListener(() => {
            SceneManager.LoadScene(0);
        });
    }

}
