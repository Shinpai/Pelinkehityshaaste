using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneAloitus : MonoBehaviour {

	public static SceneAloitus _singleton {get; private set;}
	public Grid perusGrid;
	public Tile SeinaCollider, Pohjalaatta, VoittoCollider;

	public Tilemap pohjaTaso, keskiTaso, ylaTaso;
	public GameObject pc_prefab, enemy_prefab;
	public Camera overseer;

	public AudioSource musa;
	public AudioSource[] aanet = new AudioSource[4];
	public AudioSource[] sounds = new AudioSource[3];
	private int rnd_level;
	public int xp;
	public Text text_xp;

	// Use this for initialization
	private void Awake() {

		if (_singleton == null){
			_singleton = this;
			DontDestroyOnLoad(gameObject);
		}
		else
			Destroy(gameObject);

		// musat
		musa.Play();

		generoi_map();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnGUI() {
		GUI.Label(new Rect(10,10, 100, 30),"Player XP: " + _singleton.xp.ToString());
	}
	
	public void restart(bool death){
		if (death)
			_singleton.xp = 0;
		SceneManager.LoadScene("Aloitus");
	}

	private void alusta(){
		_singleton.perusGrid = FindObjectOfType<Grid>();
		_singleton.perusGrid.transform.position = new Vector3(-10, -10, 0);
		_singleton.overseer = FindObjectOfType<Camera>();
	}

	// Generoi random numeron jonka perusteella valitsee kartan osat ja generoi Tilemapin sceneen
	private void generoi_map(){				
		// Random ääniefekti alkuun
		Random rnd = new Random();
		int r = Random.Range(0, aanet.Length);
		AudioSource valittu = aanet[r];
		valittu.Play();

		alusta();

		// TODO: randomisointi
		int[,] map_1 = new int[,] 
		{
			{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
    		{2,1,1,1,1,1,0,0,0,1,1,1,1,1,1,1,1,2,},
			{2,1,0,0,0,0,0,4,0,0,0,0,0,0,0,0,1,2,},
			{2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,},
			{2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,},
			{2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,},
			{2,1,0,4,0,0,0,0,0,0,0,0,0,0,3,0,1,2,},
			{2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,},
			{2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,},
			{2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,},
			{2,1,0,0,0,0,0,4,0,0,0,0,0,0,0,0,1,2,},
			{2,1,1,1,1,1,0,0,0,1,1,1,1,1,1,1,1,2,},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
			
		};

		int[,] map_2 = new int[,] 
		{
			{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
    		{2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,},
			{2,1,0,0,0,4,0,0,0,0,0,0,0,0,0,0,1,2,},
			{2,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,2,},
			{2,1,0,1,0,0,0,0,0,4,0,0,0,0,0,0,1,2,},
			{2,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,2,},
			{2,0,0,1,0,0,0,0,0,0,0,0,0,0,3,0,1,2,},
			{2,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,2,},
			{2,1,0,1,0,0,0,0,0,4,0,0,0,0,0,0,1,2,},
			{2,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,2,},
			{2,1,0,0,0,4,0,0,0,0,0,0,0,0,0,0,1,2,},
			{2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
			
		};

		int[,] map_3 = new int[,] 
		{
			{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
    		{2,1,1,1,1,1,1,0,0,0,1,1,1,1,1,1,1,2,},
			{2,1,0,0,0,0,0,0,4,0,0,0,0,0,0,0,1,2,},
			{2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,},
			{2,1,0,0,0,0,0,1,1,1,1,0,0,0,0,0,1,2,},
			{2,1,0,4,0,0,0,1,0,0,1,0,0,4,0,0,1,2,},
			{2,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,2,},
			{2,1,0,0,0,0,0,1,1,1,1,0,0,0,0,0,1,2,},
			{2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,},
			{2,1,0,0,0,0,0,0,3,0,0,0,0,0,0,0,1,2,},
			{2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,},
			{2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
			
		};

		List<int[,]> maps = new List<int[,]>{map_3, map_1, map_2, map_3};
		rnd_level = Random.Range(0, maps.Count);
		int[,] map = maps[rnd_level];

		// käy läpi taulukko ja aseta elementit sen mukaan
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                int cell = map[i, j];
				// Debug.Log(cell + " in [" + i + ',' + j + ']');	
				if (cell == 0)
					pohjaTaso.SetTile(new Vector3Int(j, i, 0), Pohjalaatta);
				else if (cell == 1)
					keskiTaso.SetTile(new Vector3Int(j, i, 0), SeinaCollider);
				else if (cell == 3){
					pohjaTaso.SetTile(new Vector3Int(j, i, 0), Pohjalaatta);
					// luodaan pelaajahahmo kenttään ja asetetaan se oikealle paikalle
					var m_path = Application.dataPath;
					var tile_pos = pohjaTaso.GetCellCenterWorld(new Vector3Int(j, i, 0));
					Instantiate(pc_prefab, position: tile_pos, rotation: new Quaternion(0,0,0,0));
					if (pc_prefab == null)
						continue;
				}					
				else if (cell == 4){
					// luodaan viholliset kenttään ja asetetaan ne oikealle paikalle
					pohjaTaso.SetTile(new Vector3Int(j, i, 0), Pohjalaatta);
					var tile_pos = pohjaTaso.GetCellCenterWorld(new Vector3Int(j, i, 0));
					Instantiate(enemy_prefab, position: tile_pos, rotation: new Quaternion(0,0,0,0));
				}
				else 
					ylaTaso.SetTile(new Vector3Int(j, i, 0), VoittoCollider);
            }
        }
	}
}
