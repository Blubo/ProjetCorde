using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class LifeRestore : MonoBehaviour {
	
	bool playerIndexSet = false;
	PlayerIndex playerIndex;
	GamePadState state;
	GamePadState prevState;

	public GameObject Bullet;

	[SerializeField]
	private float _SpeedBullet;

	private float _timer = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Find a PlayerIndex, for a single player game
		// Will find the first controller that is connected ans use it
		if (!playerIndexSet || !prevState.IsConnected)
		{
			for (int i = 0; i < 4; ++i)
			{
				PlayerIndex testPlayerIndex = (PlayerIndex)i;
				GamePadState testState = GamePad.GetState(testPlayerIndex);
				if (testState.IsConnected)
				{
					Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
					playerIndex = testPlayerIndex;
					playerIndexSet = true;
				}
			}
		}
		
		prevState = state;
		state = GamePad.GetState(playerIndex);


		_timer += 1 *Time.deltaTime;
		Vector3 _temp = new Vector3(state.ThumbSticks.Right.X, 0 ,state.ThumbSticks.Right.Y);
		if(_timer>=1.5f){
			if(state.ThumbSticks.Right.X >0.5 || state.ThumbSticks.Right.X <-0.5||state.ThumbSticks.Right.Y >0.5||state.ThumbSticks.Right.Y<-0.5){
				GameObject newBullet = Instantiate(Bullet, transform.TransformPoint(1f,1f,0f)  , transform.rotation) as GameObject;
				//ajout d'un rigidbody2D sur le projectile
				Rigidbody rb = newBullet.GetComponent<Rigidbody>();

				if (rb != null){
					rb.AddForce(_temp*_SpeedBullet);
				}
				_timer = 0;
			}
		}

	}
}
