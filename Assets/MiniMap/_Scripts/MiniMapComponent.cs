using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapEntity{
	public bool showDetails = false;
	public Sprite icon;
	public bool rotateWithObject = true;
	public Vector3 upAxis;
	public float rotation;
	public Vector2 size;
	public bool clampInBorder;
	public float clampDist;
	public List<GameObject> mapObjects;
}

public class MiniMapComponent : MonoBehaviour {
	[Tooltip("Set the icon of this gameobject")]
	public Sprite icon;
	[Tooltip("Set size of the icon")]
	public Vector2 size = new Vector2(20,20);
	[Tooltip("Set true if the icon rotates with the gameobject")]
	public bool rotateWithObject = false;
	[Tooltip("Adjust the rotation axis according to your gameobject. Values of each axis can be either -1,0 or 1")]
	public Vector3 upAxis = new Vector3(0,1,0);
	[Tooltip("Adjust initial rotation of the icon")]
	public float initialIconRotation;
	[Tooltip("If true the icons will be clamped in the border")]
	public bool clampIconInBorder = true;
	[Tooltip("Set the distance from target after which the icon will not be shown. Setting it 0 will always show the icon.")]
	public float clampDistance = 100;

	MiniMapController miniMapController;
	MiniMapEntity mme;
	MapObject mmo;

	void OnEnable(){
		miniMapController = GameObject.Find ("CanvasMiniMap").GetComponent<MiniMapController> ();
		mme = new MiniMapEntity ();
		mme.icon = icon;
		mme.rotation = initialIconRotation;
		mme.size = size;
		mme.upAxis = upAxis;
		mme.rotateWithObject = rotateWithObject;
		mme.clampInBorder = clampIconInBorder;
		mme.clampDist = clampDistance;

		mmo = miniMapController.RegisterMapObject(this.gameObject, mme);
	}

	void OnDisable(){
		miniMapController.UnregisterMapObject (mmo,this.gameObject);
	}

	void OnDestroy(){
		miniMapController.UnregisterMapObject (mmo,this.gameObject);
	}

}
