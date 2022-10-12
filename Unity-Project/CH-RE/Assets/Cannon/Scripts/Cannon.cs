using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour
{
	public GameObject objetoAInstanciar;
    public Transform lugar ;

	private bool IsAvailable = true;
	private float CooldownDuration = 1.0f;
	private const float plusBullets = .75f;

    private void Update()
    {
		// if not available to use (still cooling down) just exit
		if (IsAvailable && Input.anyKeyDown)
		{
			if (Input.GetKeyDown(KeyCode.J)){ 
				Shoot(2);
			}		
			else if (Input.GetKeyDown(KeyCode.K)){
				Shoot(3);
			}	
			else if (Input.GetKeyDown(KeyCode.L)){
				Shoot(4);
			}											
		}
    }

	private void Shoot(int NumberOfBullets)
	{
		IsAvailable = false;
		for(int i = 0; i < NumberOfBullets; i++){
			Instantiate(	objetoAInstanciar,
								new Vector3(	lugar.position.x-(plusBullets*i), 
												lugar.position.y-(plusBullets*i),
												lugar.position.z-(plusBullets*i)),
								transform.rotation	);	
		}
		// start the cooldown timer
        StartCoroutine(StartCooldown());			
	}	

	public IEnumerator StartCooldown()
	{
		yield return new WaitForSeconds(CooldownDuration);
		IsAvailable = true;
	}

}
