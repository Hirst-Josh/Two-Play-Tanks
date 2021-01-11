using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CHARACTERTYPE {
    _none = -1,
    john,
    ted,
    anya,
    zoe,
    lilith,
    andrew,
    melissa
}

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [SerializeField] private CharacterData[] characterData;
    [SerializeField] private CHARACTERTYPE[] characters;
    private CharacterData[] currentCharacters;

    [System.Serializable]
    public struct CharacterData {
        public string name;
        public int hp;
        public int Team;
        public int damagedone;
        public int armor;
    }

    public string Health;

    public GameObject dead;
    public GameObject[] deadlist;

    void Awake() {
        instance = this;
        currentCharacters = new CharacterData[characters.Length];
        for (int i = 0; i < currentCharacters.Length; i++) {
            currentCharacters[i] = characterData[(int)characters[i]];
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            Fight();
            CSVManager.AppendToReport(GetReportLine());
            Debug.Log("<color=magenta>Report updated in game!</color>");

            if (deadlist == null)
            {
                deadlist = GameObject.FindGameObjectsWithTag("Dead");
            }
            foreach(GameObject dead in deadlist)
            {
                Health = dead.GetComponent<Tankfsm>().healh.ToString();
            }
        }


    }

    void Fight() {
       currentCharacters[0].hp -= Mathf.Max(Random.Range(1, currentCharacters[1].damagedone + 1) - currentCharacters[0].armor, 0);
       currentCharacters[1].hp -= Mathf.Max(Random.Range(1, currentCharacters[0].damagedone + 1) - currentCharacters[1].armor, 0);
    }

    string[] GetReportLine() {
        string[] returnable = new string[5];
        returnable[0] = Health;
        returnable[1] = currentCharacters[0].hp.ToString() + " vs " + currentCharacters[1].hp.ToString();
        returnable[2] = currentCharacters[0].Team.ToString() + " vs " + currentCharacters[1].Team.ToString();
        returnable[3] = currentCharacters[0].damagedone.ToString() + " vs " + currentCharacters[1].damagedone.ToString();
        returnable[4] = currentCharacters[0].armor.ToString() + " vs " + currentCharacters[1].armor.ToString();
        return returnable;
    }

}
