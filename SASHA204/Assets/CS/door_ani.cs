using UnityEngine;
using System.Collections;

public enum door_ani_state
{
	None,
	OPen,
	Close,
	Master
}
public class door_ani : MonoBehaviour {

	public Texture[] door;
	public door_ani_state ANI;
	int Ani_count;
	int state = -2;
	int pre_count;
	
	void Start()
	{
				if (manage_static.turn != -1) {
						for (int i=0; i<= manage_static.turn; i++) {

				if(i == manage_static.turn)
				{
					this.SendMessage("door_open_" + i);
				}
				else
				{
					GameObject.Find ("door_" + i).GetComponent<MeshRenderer> ().enabled = false;
				}
						}
				}
		}

	public void door_close_0 ()
	{
		GameObject.Find ("door_0").GetComponent<MeshRenderer> ().enabled = true;
		state = 0;
		ANI = door_ani_state.Close;
		Ani_count = 6;
	}

	public void door_ani_closing_0 ()
	{
		renderer.material.mainTexture = door [Ani_count];
		Ani_count--;
		if (Ani_count < 0) {
			ANI = door_ani_state.None;
			Ani_count = 0;
		} 
	}


	public void door_close_1 ()
	{
		GameObject.Find ("door_1").GetComponent<MeshRenderer> ().enabled = true;
		state = 1;
		ANI = door_ani_state.Close;
		Ani_count = 6;
	}
	
	public void door_ani_closing_1 ()
	{
		GameObject.Find ("door_1").GetComponent<MeshRenderer>().material.mainTexture = door [Ani_count];
		Ani_count--;
		if (Ani_count < 0) {
			ANI = door_ani_state.None;
			Ani_count = 0;
		} 
	}

	public void door_close_2 ()
	{
		GameObject.Find ("door_2").GetComponent<MeshRenderer> ().enabled = true;
		state = 2;
		ANI = door_ani_state.Close;
		Ani_count = 6;
	}
	
	public void door_ani_closing_2 ()
	{
		GameObject.Find ("door_2").GetComponent<MeshRenderer>().material.mainTexture = door [Ani_count];
		Ani_count--;
		if (Ani_count < 0) {
			ANI = door_ani_state.None;
			Ani_count = 0;
		} 
	}

	public void door_close_3 ()
	{
		GameObject.Find ("door_3").GetComponent<MeshRenderer> ().enabled = true;
		state = 3;
		ANI = door_ani_state.Close;
		Ani_count = 6;
	}
	
	public void door_ani_closing_3 ()
	{
		GameObject.Find ("door_3").GetComponent<MeshRenderer>().material.mainTexture = door [Ani_count];
		Ani_count--;
		if (Ani_count < 0) {
			ANI = door_ani_state.None;
			Ani_count = 0;
		} 
	}


	public void door_open_0 ()
	{
		GameObject.Find ("door_0").GetComponent<MeshRenderer> ().enabled = true;
		state = 0;
		ANI = door_ani_state.OPen;
		Ani_count = 0;
	}

	public void door_ani_ing_0 ()
	{
		renderer.material.mainTexture = door [Ani_count];
		Ani_count++;
		if (Ani_count >= door.Length) {
			ANI = door_ani_state.None;
			Ani_count = 0;
		} 
		}

	public void door_open_1 ()
	{
		GameObject.Find ("door_1").GetComponent<MeshRenderer> ().enabled = true;
		state = 1;
		ANI = door_ani_state.OPen;
		Ani_count = 0;
	}
	
	public void door_ani_ing_1 ()
	{
		GameObject.Find ("door_1").GetComponent<MeshRenderer>().material.mainTexture = door [Ani_count];
		Ani_count++;
		if (Ani_count >= door.Length) {
			ANI = door_ani_state.None;
			Ani_count = 0;
		} 
	}

	public void door_open_2 ()
	{
		GameObject.Find ("door_2").GetComponent<MeshRenderer> ().enabled = true;
		state = 2;
		ANI = door_ani_state.OPen;
		Ani_count = 0;
	}
	
	public void door_ani_ing_2 ()
	{
		GameObject.Find ("door_2").GetComponent<MeshRenderer>().material.mainTexture = door [Ani_count];
		Ani_count++;
		if (Ani_count >= door.Length) {
			ANI = door_ani_state.None;
			Ani_count = 0;
		} 
	}

	public void door_open_3 ()
	{
		GameObject.Find ("door_3").GetComponent<MeshRenderer> ().enabled = true;
		state = 3;
		ANI = door_ani_state.OPen;
		Ani_count = 0;
	}
	
	public void door_ani_ing_3 ()
	{
		GameObject.Find ("door_3").GetComponent<MeshRenderer>().material.mainTexture = door [Ani_count];
		Ani_count++;
		if (Ani_count >= door.Length) {
			ANI = door_ani_state.None;
			Ani_count = 0;
		} 
	}

	// Update is called once per frame
	void Update () {

			if (ANI == door_ani_state.OPen) {
				switch (state) {
				case 0:
					door_ani_ing_0 ();
					break;
				case 1:
					door_ani_ing_1 ();
					break;
				case 2:
					door_ani_ing_2 ();
					break;
				case 3:
					door_ani_ing_3 ();
					break;
				}
			}

		if (ANI == door_ani_state.Close) {
			switch (state) {
			case 0:
				door_ani_closing_0 ();
				break;
			case 1:
				door_ani_closing_1 ();
				break;
			case 2:
				door_ani_closing_2 ();
				break;
			case 3:
				door_ani_closing_3 ();
				break;
			}
		}
	
	}
}
