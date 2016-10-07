using UnityEngine;
using System.Collections;

public class BackgroundBalls : MonoBehaviour {

	struct Ball
	{
		public GameObject gobj;
		public Vector3 dir;
		public Ball(GameObject gobj, Vector3 dir) {
			this.gobj = gobj;
			this.dir = dir;
		}
	}
	private Ball[] balls;
	private const int NUM_BALLS = 80;

	void Start () {
		Random.InitState((int)System.DateTime.Now.Ticks);
		// Generate balls
		balls = new Ball[NUM_BALLS];
		for (var i = 0; i < NUM_BALLS; ++i) {
			var pos = new Vector3( Random.Range(CameraLimits.Min.x, CameraLimits.Max.x), Random.Range(CameraLimits.Min.y, CameraLimits.Max.y));
			var dir = new Vector2(Random.Range(-4, 4), Random.Range(-4, 4));

			GameObject gobj = GameManager.CreateSprite("Ball", "Sprites/WhiteBall", pos, gameObject);
			balls[i] = new Ball(gobj, dir);
		}
	}

	void Update () {
		for(var i = 0; i < NUM_BALLS; ++i) {
			balls[i].gobj.transform.position += balls[i].dir * Time.deltaTime;
			// check border collisions
			float px = balls[i].gobj.transform.position.x,
				py = balls[i].gobj.transform.position.y;

			if (px > CameraLimits.Max.x-1 || px < CameraLimits.Min.x)
				balls[i].dir.x = -balls[i].dir.x;
			if (py > CameraLimits.Max.y-1 || py < CameraLimits.Min.y)
				balls[i].dir.y = -balls[i].dir.y;
		}
	}
}
