using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
/*
/// <summary>
/// 独自のUI描画
/// </summary>
[RequireComponent( typeof( CanvasRenderer ) )]
[RequireComponent( typeof( RectTransform ) )]
public class EnergyGenerator
	: Graphic
{
	// 変数宣言


	/// <summary>
	/// メッシュに設定したいテクスチャをここで指定
	/// </summary>
	[SerializeField]
	private Texture texture_;

	/// <summary>
	/// メッシュに設定するテクスチャの指定
	/// </summary>
	public override Texture mainTexture
	{
		get
		{
			// ここで設定したいテクスチャを返すようにする
			return texture_;
		}
	}

	/// <summary>
	/// ここでメッシュを生成する
	/// </summary>
	/// <param name="vbo">Vbo.</param>
	protected override void OnPopulateMesh( Mesh mesh )
	{
		
		// 1左
		UIVertex l1 = UIVertex.simpleVert;
		l1.position = new Vector3( 0, 20, 0 );
		l1.uv0 = new Vector2(1,1);
		//lt.color = Color.green;

		// 1右
		UIVertex r1 = UIVertex.simpleVert;
		r1.position = new Vector3( 100, 20, 0 );
		r1.uv0 = new Vector2(0,1);
		//rt.color = Color.red;

		// 2左
		UIVertex l2 = UIVertex.simpleVert;
		l2.position = new Vector3( 0, 0, 0 );
		l2.uv0 = new Vector2(1,0);
		//lb.color = Color.white;

		// 2右
		UIVertex r2 = UIVertex.simpleVert;
		r2.position = new Vector3( 100, 0, 0 );
		r2.uv0 = new Vector2(0,0);
		//rb.color = Color.yellow;

		using ( var vb0 = new VertexHelper() ) {
			vb0.AddUIVertexQuad( new UIVertex[] { l2, r2, r1, l1 } );
			vb0.FillMesh( mesh );
		}
	}
}*/