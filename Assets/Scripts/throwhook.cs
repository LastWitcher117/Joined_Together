using UnityEngine;
using System.Collections;

public class throwhook : MonoBehaviour
{
	public GameObject hook;
	GameObject curHook;
	public GameObject hooktarget;

	public bool ropeActive;

	void Start()
	{
		Vector2 destiny = hooktarget.transform.position;

		curHook = (GameObject)Instantiate(hook, transform.position, Quaternion.identity);

		curHook.GetComponent<RopeScript>().destiny = destiny;

		curHook.transform.parent = GameObject.Find("SLAVE").transform;

		ropeActive = true;
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (ropeActive == false)
			{
				Vector2 destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);

				curHook = (GameObject)Instantiate(hook, transform.position, Quaternion.identity);

				curHook.GetComponent<RopeScript>().destiny = destiny;

				ropeActive = true;
			}
			else
			{
				//delete rope
				Destroy(curHook);

				ropeActive = false;
			}
		}
	}

	//void Update()
	//{
	//	if (Input.GetMouseButtonDown(0))
	//	{
	//		if (ropeActive == false)
	//		{
	//			Vector2 destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);

	//			curHook = (GameObject)Instantiate(hook, transform.position, Quaternion.identity);

	//			curHook.GetComponent<RopeScript>().destiny = destiny;

	//			ropeActive = true;
	//		}
	//		else
	//		{
	//			//delete rope
	//			Destroy(curHook);

	//			ropeActive = false;
	//		}
	//	}
	//}
}