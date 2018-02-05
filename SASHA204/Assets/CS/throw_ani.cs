using UnityEngine;
using System.Collections;

public enum yut_ani_state
{
		None,
		OPen
}

public class throw_ani : MonoBehaviour
{

		public yut_ani_state YS;
		public Texture[] do_Images, gea_Images, gul_Images,
		yut_Images, mo_Images, nack_Images, Bdo_Images;
		int Ani_count;
		int yut_state = -2;

		public void Bdo_ani_on ()
		{
				yut_state = -1;
				YS = yut_ani_state.OPen;
				Ani_count = 0;
		}

		public void nack_ani_on ()
		{
				yut_state = 0;
				YS = yut_ani_state.OPen;
				Ani_count = 0;
		}

		public void do_ani_on ()
		{
				yut_state = 1;
				YS = yut_ani_state.OPen;
				Ani_count = 0;
		}

		public void gea_ani_on ()
		{
				yut_state = 2;
				YS = yut_ani_state.OPen;
				Ani_count = 0;
		}

		public void gul_ani_on ()
		{
				yut_state = 3;
				YS = yut_ani_state.OPen;
				Ani_count = 0;
		}

		public void yut_ani_on ()
		{
				yut_state = 4;
				YS = yut_ani_state.OPen;
				Ani_count = 0;
		}

		public void mo_ani_on ()
		{
				yut_state = 5;
				YS = yut_ani_state.OPen;
				Ani_count = 0;
		}

		public void Bdo_ani_ing ()
		{

				renderer.material.mainTexture = Bdo_Images [Ani_count];
				Ani_count++;
				if (Ani_count >= Bdo_Images.Length) {
						YS = yut_ani_state.None;
						Ani_count = 0;
				} 
				
		}

		public void nack_ani_ing ()
		{
				renderer.material.mainTexture = nack_Images [Ani_count];
				Ani_count++;
				if (Ani_count >= nack_Images.Length) {
						YS = yut_ani_state.None;
						Ani_count = 0;
				} 
		}

		public void do_ani_ing ()
		{
				renderer.material.mainTexture = do_Images [Ani_count];
				Ani_count++;
				if (Ani_count >= do_Images.Length) {
						YS = yut_ani_state.None;
						Ani_count = 0;
				} 
		}

		public void gea_ani_ing ()
		{
				renderer.material.mainTexture = gea_Images [Ani_count];
				Ani_count++;
				if (Ani_count >= gea_Images.Length) {
						YS = yut_ani_state.None;
						Ani_count = 0;
				} 
		}

		public void gul_ani_ing ()
		{
				renderer.material.mainTexture = gul_Images [Ani_count];
				Ani_count++;
				if (Ani_count >= gul_Images.Length) {
						YS = yut_ani_state.None;
						Ani_count = 0;
				} 
		}

		public void yut_ani_ing ()
		{
				renderer.material.mainTexture = yut_Images [Ani_count];
				Ani_count++;
				if (Ani_count >= yut_Images.Length) {
						YS = yut_ani_state.None;
						Ani_count = 0;
				} 
		}

		public void mo_ani_ing ()
		{
				renderer.material.mainTexture = mo_Images [Ani_count];
				Ani_count++;
				if (Ani_count >= mo_Images.Length) {
						YS = yut_ani_state.None;
						Ani_count = 0;
				} 
		}
		
		void Start ()
		{
		}

		void Update ()
		{
				if (YS == yut_ani_state.OPen) {
						switch (yut_state) {
						case -1:
								Bdo_ani_ing ();
								break;
						case 0:
								nack_ani_ing ();
								break;
						case 1:
								do_ani_ing ();
								break;
						case 2:
								gea_ani_ing ();
								break;
						case 3:
								gul_ani_ing ();
								break;
						case 4:
								yut_ani_ing ();
								break;
						case 5:
								mo_ani_ing ();
								break;
						}
						
				}
		}

}
