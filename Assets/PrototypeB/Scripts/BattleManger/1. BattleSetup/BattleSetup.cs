using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSetup : MonoBehaviour
{
    // Start is called before the first frame update
    private GameData receivedData;
    private CreateSceneEnvironment map;
    private CharacterSetting characters;
    private CalculateStartTurn settingTurn;

    public GameObject BlackScreen;

    void Start()
    {
        receivedData=GameObject.Find("GameData").GetComponent<GameData>();
        gameObject.GetComponentInParent<Battle_Manager>().Initialize(this);
    }

    public void Initialize(CreateSceneEnvironment createSceneEnvironment)
    {
        map = createSceneEnvironment;
    }

    public void Initialize(CharacterSetting characterSetting)
    {
        characters = characterSetting;
    }

    public void Initialize(CalculateStartTurn calculateStartTurn)
    {
        settingTurn = calculateStartTurn;
    }

    public void TriggerSettingSystem()
    {
        StartCoroutine(TriggerMapGenerator());
    }

    private IEnumerator TriggerMapGenerator()
    {
        yield return new WaitForSeconds(0.2f);

        map.PlaceMapObject(receivedData);

        yield return new WaitForSeconds(0.2f);

        StartCoroutine(TriggerCharacterSetting());
    }

    private IEnumerator TriggerCharacterSetting()
    {
        characters.PlaceCharacterObjects(receivedData);

        yield return new WaitForSeconds(0.2f);

        StartCoroutine(TriggerCalculateStartTurn());
    }

    private IEnumerator TriggerCalculateStartTurn()
    {
        settingTurn.CalStartTurn(receivedData);

        yield return new WaitForSeconds(0.2f);

        RemoveBlackScreen();
    }

    public void RemoveBlackScreen()
    {
        //BlackScreen.SetActive(false);
    }
}
