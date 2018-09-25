using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SceneAloitus : MonoBehaviour {

	public Grid perusGrid;
	public Tile SeinaCollider;
	public Tile Pohjalaatta;
	public Tile VoittoCollider;

	public Tilemap pohjaTaso;
	public Tilemap keskiTaso;
	public Tilemap ylaTaso;


	// Use this for initialization
	void Start () {
		perusGrid.transform.position = new Vector3(-10, -10, 0);
		perusGrid = GetComponent<Grid>();	
		generoi_map();
		this.transform.position = new Vector3(7, 2, -10);
		this.transform.rotation = Quaternion.Euler(new Vector3(25, -25, 0));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
	// Generoi random numeron jonka perusteella valitsee kartan osat ja generoi Tilemapin sceneen
	void generoi_map(){
		// TODO: randomisointi
		int rnd_level = Random.Range(1, 2);
		Debug.Log("Generoitu kenttä : " + rnd_level);

		int[,] map_1 = new int[,] 
		{
			{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
    		{2,1,1,1,1,1,1,1,0,0,0,1,1,1,1,1,1,1,2,},
			{2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,},
			{2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,},
			{2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,},
			{2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,},
			{2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,},
			{2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,},
			{2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,},
			{2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,},
			{2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,},	
			{2,1,1,1,1,1,1,1,0,0,0,1,1,1,1,1,1,1,2,},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
		};

		// käy läpi taulukko ja aseta seinät sen mukaan
        for (int i = 0; i < map_1.GetLength(0); i++)
        {
            for (int j = 0; j < map_1.GetLength(1); j++)
            {
                int cell = map_1[i, j];
				// Debug.Log(cell + " in [" + i + ',' + j + ']');

				if (cell == 0)
					pohjaTaso.SetTile(new Vector3Int(j, i, 0), Pohjalaatta);
				else if (cell == 1)
					keskiTaso.SetTile(new Vector3Int(j, i, 0), SeinaCollider);
				else 
					ylaTaso.SetTile(new Vector3Int(j, i, 0), VoittoCollider);
            }
        }
	}
}
