using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Add this to your menu prefab
public class RadialMenu : MonoBehaviour
{
    string selectedName;
    GameObject objectToSendMsgTo;
    public Text label;                  //object name appears here
    public RadialButton buttonPrefab;   //button to instantiate
    public RadialButton selected;       //button that is selected (leave this empty)

    // Use this for initialization
    public void SpawnButtons(Interactable obj)
    {
        StartCoroutine(AnimateButtons(obj));
    }

    //animate buttons in around a circle, one at a time
    IEnumerator AnimateButtons(Interactable obj)
    {
        for (int i = 0; i < obj.options.Length; i++)
        {
            RadialButton newButton = Instantiate(buttonPrefab) as RadialButton;
            newButton.transform.SetParent(transform, false);
            float theta = (2 * Mathf.PI / obj.options.Length) * i;
            float xPos = Mathf.Sin(theta);
            float yPos = Mathf.Cos(theta);
            newButton.transform.localPosition = new Vector3(xPos, yPos, 0f) * 50f;
            newButton.circle.color = obj.options[i].color;
            newButton.icon.sprite = obj.options[i].sprite;
            newButton.title = obj.options[i].title;
            newButton.myMenu = this;
            newButton.Anim();
            yield return new WaitForSeconds(0.12f);
        }
    }

    //if mouse is released over a button, activate that button
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                objectToSendMsgTo = hit.collider.gameObject;
                print(objectToSendMsgTo);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (selected)
            {
                if (selected.title == "Hold/Fire")
                {
                    objectToSendMsgTo.GetComponentInChildren<BulletBehavior>().FlipCanFire();
                }
                if (selected.title == "GunTurret")
                {
                    objectToSendMsgTo.SendMessage("ChangeToGun");
                }
            }
            Destroy(gameObject);
        }
    }
}
