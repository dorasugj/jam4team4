using UnityEngine;
using System.Collections;

public class GL_LineDraw_Fox : MonoBehaviour {// Test Line //---------

	//ArrayIndex
	public	const	int	begin	= 0;
	public	const	int	center	= 1;
	public	const	int	end		= 2;

	//Var
	public	Material	material	= null;
	public	Vector2		canvasSize	= new Vector2(480,800);
	public	float		width		= 16;

	private	Vector3[]	point		= new Vector3[3];
	private	Vector3[]	vertex		= new Vector3[6];
	private	Vector2[]	uv			= new Vector2[6];
	private	short[]		indices		= new short[12];

	void Start () {// Use this for initialization //------------------
	
		setVertex();

		point[begin]	= new Vector3(120,200,0);
		point[center]	= new Vector3(240,200,0);
		point[end]		= new Vector3(360,200,0);

		indices[0]	= 0;
		indices[1]	= 4;
		indices[2]	= 5;
		indices[3]	= 0;
		indices[4]	= 1;
		indices[5]	= 4;
		indices[6]	= 1;
		indices[7]	= 3;
		indices[8]	= 4;
		indices[9]	= 1;
		indices[10]	= 2;
		indices[11]	= 3;

	}//---------------------------------------------------------------
	
	void Update () {// Update is called once per frame //-------------
		
		setVertex();

	}//---------------------------------------------------------------

	void OnPostRender() {// GL Draw line. //--------------------------

		if (material != null) {
			material.SetPass(0);
  
			GL.PushMatrix();
			GL.LoadOrtho();
			GL.Begin(GL.TRIANGLES);

			GL.Color(Color.white);

			for(int i = 0;i < indices.Length;i ++){

				short	vertexID	= indices[i];
				GL.TexCoord2(	uv[vertexID].x,
								uv[vertexID].y);
				GL.Vertex3(		vertex[vertexID].x,
								vertex[vertexID].y,
								vertex[vertexID].z);

			}

			GL.End();
			GL.PopMatrix();
		}

	}//---------------------------------------------------------------

	private	void	setVertex(){//------------------------------------

		vertex[0].x	= point[0].x - width;
		vertex[0].y	= point[0].y + width;
		vertex[0].z	= point[0].z;

		vertex[1].x	= point[1].x;
		vertex[1].y	= point[1].y + width;
		vertex[1].z	= point[1].z;

		vertex[2].x	= point[2].x + width;
		vertex[2].y	= point[2].y + width;
		vertex[2].z	= point[2].z;

		vertex[3].x	= point[2].x + width;
		vertex[3].y	= point[2].y - width;
		vertex[3].z	= point[2].z;

		vertex[4].x	= point[1].x;
		vertex[4].y	= point[1].y - width;
		vertex[4].z	= point[1].z;

		vertex[5].x	= point[0].x - width;
		vertex[5].y	= point[0].y - width;
		vertex[5].z	= point[0].z;

		for(int i = 0;i < vertex.Length;i ++){
			vertex[i].x	/= canvasSize.x;
			vertex[i].y	/= canvasSize.y;
		}

		uv[0].x		= 0.0f;
		uv[0].y		= 0.0f;
		uv[1].x		= 0.5f;
		uv[1].y		= 0.0f;
		uv[2].x		= 1.0f;
		uv[2].y		= 0.0f;
		uv[3].x		= 1.0f;
		uv[3].y		= 1.0f;
		uv[4].x		= 0.5f;
		uv[4].y		= 1.0f;
		uv[5].x		= 0.0f;
		uv[5].y		= 1.0f;

	}//---------------------------------------------------------------

	public	bool	setPoint(int indexNo,Vector3 pos){//--------------

		if(indexNo < 0 || indexNo >= point.Length)	return	false;

		point[indexNo]	= pos;

		return	true;

	}//---------------------------------------------------------------

}//-------------------------------------------------------------------
