using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTileEmpty : MonoBehaviour
{
    // Use this for initialization
    public GameObject prefabGun;
    public RaycastHit[] hitinfo;
    void Start()
    {
        RaycastHit[] hitinfo;
        hitinfo = Physics.SphereCastAll(transform.position, .75f, transform.forward, 3);
        for (int i = 0; i < hitinfo.Length; i++)
        {
            RaycastHit hit = hitinfo[i];
            if (hit.collider.gameObject.tag == "Tile")
            {
                hit.collider.SendMessage("CheckIfBaseIsNearBy");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Collider>().enabled = false;
            RaycastHit hitInfo;
            if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 3))
            {
                hitInfo.collider.SendMessage("CheckIfIsTileTaken");
            }
            Destroy(gameObject);
        }
    }
    public void ChangeToGun()
    {
        Instantiate(prefabGun,transform.position,Quaternion.identity);
        print("Switching to Gun");
        Destroy(gameObject);
    }
}
