using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IconManager : StatIcon
{
    public static IconManager Instance;
    public SkillPoint skillPoint;



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
        if (Input.GetKeyDown(KeyCode.K))
        {
            skillPoint.SP += 1;
        }
    }

    private IEnumerator MouseFollow()
    {
        while (iconDes.gameObject.activeSelf)
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
           Input.mousePosition.y, -Camera.main.transform.position.z));

            iconDes.transform.position = new Vector3(Input.mousePosition.x + 55f, Input.mousePosition.y + 20f);
            iconDes.transform.SetAsLastSibling();
            yield return new WaitForSeconds(0.1f);
        }
    }


}
