using System.Collections;
using System.Collections.Generic;
using Snake.Game;
using UnityEngine;

public class GameController : MonoBehaviour {

	private SnakeGame m_game;

	void Start () {
		m_game = new SnakeGame();
		m_game.Initialize(new GraphicSystem());
	}
	
	// Update is called once per frame
	void Update () {
		m_game.Update();
		m_game.Draw();
	}
}
