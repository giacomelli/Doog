using System;
using System.Collections;
using System.Collections.Generic;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;
using UnityEngine;

public class GraphicSystem : MonoBehaviour, IGraphicSystem
{
	private GameObject[,] m_cubes;
	private bool[,] m_drawnCubes;

	public IntRectangle Bounds { get; private set; }

	public void Initialize()
	{
		Bounds = new IntRectangle(0, 0, 80, 80);

		m_cubes = new GameObject[Bounds.Right, Bounds.Bottom];
		m_drawnCubes = new bool[Bounds.Right, Bounds.Bottom];
		var screen = GameObject.CreatePrimitive(PrimitiveType.Cube);
		screen.transform.position = Vector3.zero;
	
		for (int x = 0; x < Bounds.Right; x++)
		{
			for (int y = 0; y < Bounds.Bottom; y++)
			{
				var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cube.transform.parent = screen.transform;
				cube.name = String.Format("sprite_{0}_{1}", x, y);
				cube.transform.position = new Vector3(x, y, 0);
				cube.GetComponent<BoxCollider>().enabled = false;
				m_cubes[x, y] = cube;
			}
		}
	}

	public void Draw(int x, int y, char sprite)
	{
		m_drawnCubes[x, y] = true;
	}

	public void Render()
	{
		for (int x = 0; x < Bounds.Right; x++)
		{
			for (int y = 0; y < Bounds.Bottom; y++)
			{
				if (m_drawnCubes[x, y])
				{
					m_cubes[x, y].GetComponent<MeshRenderer>().material.color = Color.green;
					m_cubes[x, y].transform.localScale = new Vector3(1, 1, 5);
					m_drawnCubes[x, y] = false;
				}
				else
				{
					m_cubes[x, y].GetComponent<MeshRenderer>().material.color = Color.white;
					m_cubes[x, y].transform.localScale = Vector3.one;
				}
			}
		}
	}
}
