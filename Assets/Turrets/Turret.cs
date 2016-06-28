using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public float rotateSpeed = 1f;
	public Transform top;
    public bool shooting = true;
	Transform[] playerTransforms;
    GameObject[] players;
	void Start () {
		top = top.GetComponent<Transform> ();
	}
	
	void Update () {
		
		StartCoroutine(GetPlayers());
        StartCoroutine(Shoot(3));
        
		Transform closestPlayer = GetClosestPlayer(playerTransforms);
		Vector3.RotateTowards(top.forward, closestPlayer.position, rotateSpeed * Time.deltaTime, 0f);

        
	}
	
	 Transform GetClosestPlayer (Transform[] players) {
    
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach(Transform potentialTarget in players)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
     
        return bestTarget;
    }

    IEnumerator Shoot (float speedInSeconds) {
        if(shooting) {
            Object.Instantiate(GameObject.Find("Projectile"), top.position, top.rotation);
            yield return new WaitForSeconds(speedInSeconds);
        }
        yield return true;
         
    }

    IEnumerator GetPlayers() {
        players = GameObject.FindGameObjectsWithTag("Player");
        for(int i=0; i<players.Length; i++) {
            playerTransforms[i] = players[i].transform;
        }
        yield return true;
    }
}
