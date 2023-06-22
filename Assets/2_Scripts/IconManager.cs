using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IconManager : MonoBehaviour
{
    public static IconManager Instance;

    public Text IconNameText;
    public GameObject Icon;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance == this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MouseFollow());
    }

    private IEnumerator MouseFollow()
    {
        while (Icon.gameObject.activeSelf)
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
           Input.mousePosition.y, -Camera.main.transform.position.z));

            Icon.transform.position = new Vector3(Input.mousePosition.x + 40f, Input.mousePosition.y + 15f);
            Icon.transform.SetAsLastSibling();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
