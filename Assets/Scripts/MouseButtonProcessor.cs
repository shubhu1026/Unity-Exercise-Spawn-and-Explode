using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Processes mouse button inputs
/// </summary>
public class MouseButtonProcessor : MonoBehaviour
{
    [SerializeField]
    GameObject prefabExplosion;
    [SerializeField]
    GameObject prefabTeddyBear;

    // first frame input support
    bool spawnInputOnPreviousFrame = false;
	bool explodeInputOnPreviousFrame = false;

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
        // spawn teddy bear as appropriate
        if(Input.GetAxis("SpawnTeddyBear") > 0)
        {
            if (!spawnInputOnPreviousFrame)
            {
                Vector3 position = Input.mousePosition;
                position.z = -Camera.main.transform.position.z;

                position = Camera.main.ScreenToWorldPoint(position);

                Instantiate<GameObject>(prefabTeddyBear, position, Quaternion.identity);

                spawnInputOnPreviousFrame = true;
            }
        }
        else
        {
            spawnInputOnPreviousFrame = false;
        }

        // explode teddy bear as appropriate
        if (Input.GetAxis("ExplodeTeddyBear") > 0)
        {
            if (!explodeInputOnPreviousFrame)
            {
                GameObject explosionTeddy = GameObject.FindWithTag("TeddyBear");
                if(explosionTeddy != null)
                {
                    Vector3 explosionPosition = explosionTeddy.transform.position;

                    Destroy(explosionTeddy);

                    Instantiate<GameObject>(prefabExplosion, explosionPosition, Quaternion.identity);

                }

                explodeInputOnPreviousFrame = true;
            }
        }
        else
        {
            explodeInputOnPreviousFrame = false;
        }
    }
}
