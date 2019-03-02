using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Level1;

public class MedeaRightAngel : MedeaAngel {
    public GameObject reaperPrefab;
    List<GameObject> reapers;

    private void Awake()
    {
        reapers = new List<GameObject>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void GenerateReaper()
    {
        GameObject obj = Instantiate(reaperPrefab);
        obj.transform.position = this.transform.position;
        reapers.Add(obj);
    }

    private void OnDestroy()
    {
        foreach(var i in reapers)
        {
            if (i != null)
            {
                Destroy(i.gameObject);
            }
        }
    }

}
