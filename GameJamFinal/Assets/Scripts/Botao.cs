using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botao : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChamaCenaJogo()
    {
        SceneManager.LoadScene("CenaPrincipal");
    }

    public void ChamaCenaLore()
    {
        SceneManager.LoadScene("Lore");
    }
}
