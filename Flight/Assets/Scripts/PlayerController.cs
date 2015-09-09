using UnityEngine;

namespace Assets.Scripts
{
	public class PlayerController {

		private readonly Player _player;

		private float 
						_baseVelocity,
						_targetVelocity,
						_variableVelocity;

		public Vector3 MousePosition { get; private set; }

		public float CurrentVelocity { get; private set; }

		public float MaxVariableVelocity { get; set; }

		public float MinimumVelocity { get; set; }

		public float Acceleration { get; set; }

		public float VelocityDanp { get; set; }

		public float RotationSpeed { get; set; }

		public bool UseRelativeMovement { get; set; }

		public Vector2 MouseSensivity { get; set; }

		public float AfterBurnerModifier { get; set; }

		public float StrafeModifier { get; set; }

		public PlayerController(Player player){
			MaxVariableVelocity = 20;
			Acceleration = 70;
			VelocityDanp = 20;
			RotationSpeed = .03f;
			AfterBurnerModifier = 50;
			StrafeModifier = 7;

			MouseSensivity = new Vector2 (700, 700);
			UseRelativeMovement = false;

			_player = player;
		}

		public void Update(){
			Screen.lockCursor = UseRelativeMovement;

			if(UseRelativeMovement){
				MousePosition += new Vector3 (
					Input.GetAxis("Mouse X") * Time.deltaTime * MouseSensivity.x,
					Input.GetAxis("Mouse Y") * Time.deltaTime * MouseSensivity.y);
			} else 
				MousePosition = Input.mousePosition;

			UpdatePosition ();
			UpdateRotation ();
		}

		private void UpdatePosition(){
			_variableVelocity = Mathf.Clamp (
				_variableVelocity + Input.GetAxis ("Vertical") * Time.deltaTime * Acceleration,
				0,
				MaxVariableVelocity);

			_targetVelocity = _variableVelocity + MinimumVelocity;

			if(Input.GetKey(KeyCode.Tab))
				_targetVelocity += AfterBurnerModifier;

			CurrentVelocity = Mathf.Lerp(CurrentVelocity, _targetVelocity, Time.deltaTime * VelocityDanp);

			_player.transform.Translate(
				Input.GetAxis("Horizontal") * Time.deltaTime * StrafeModifier,
				0,
				CurrentVelocity * Time.deltaTime,
				Space.Self);
		}

		private void UpdateRotation(){

			if(Input.GetKey("e"))
				_player.transform.Rotate(0, 0, -90f * Time.deltaTime);

			if(Input.GetKey("q"))
				_player.transform.Rotate(0, 0, 90f * Time.deltaTime);

			var mouseMovement = (MousePosition - (new Vector3 (Screen.width / 2f, Screen.height / 2f))) * .2f;

			if (mouseMovement.sqrMagnitude >= 1)
								_player.transform.Rotate (new Vector3 (-mouseMovement.y, mouseMovement.x, 0) * RotationSpeed);
		}
	}
}























































