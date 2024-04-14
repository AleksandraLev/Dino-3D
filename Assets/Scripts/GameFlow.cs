using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameFlow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform platformobj;
    private Vector3 nextPlatformSpawn;
    public Transform TallCactusObj;
    private Vector3 nextTallCactusSpawn;
    public Transform ShortCactusObj;
    private Vector3 nextShortCactusSpawn;
    public Transform CanyonObj;
    private Vector3 nextRightCanyonSpawn;
    private Vector3 nextLeftCanyonSpawn;
    private int randomX;

    public NewPlayerController1 movement; // ¡˚ÎÓ: public Player_Movement movement; 
    public float levelRestartDelay = 2f;

    public void EndGame()
    {
        movement.enabled = false;

        //Invoke("RestartLevel", levelRestartDelay);
        SceneManager.LoadScene(0);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Start()
    {
        nextRightCanyonSpawn.z = 64;
        nextLeftCanyonSpawn.z = 64;
        nextPlatformSpawn.z = 70;
        StartCoroutine(spawnPlatform());
        StartCoroutine(spawnCanyon());
        StartCoroutine(spawnObstacles());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawnPlatform()
    {
        yield return new WaitForSeconds(2);
        Instantiate(platformobj, nextPlatformSpawn, platformobj.rotation);
        nextPlatformSpawn.z += 10;
        StartCoroutine(spawnPlatform());
    }

    IEnumerator spawnObstacles()
    {

        yield return new WaitForSeconds(2);
        //—œ¿¬Õ Õ»« Œ√Œ  ¿ “”—¿
        int Random_X_For_Short_Cactus = Random.Range(-1, 2);
        //nextShortCactusSpawn.z += 10;
        nextShortCactusSpawn.z = nextPlatformSpawn.z;
        nextShortCactusSpawn.y = .1f;
        nextShortCactusSpawn.x = Random_X_For_Short_Cactus;
        Instantiate(ShortCactusObj, nextShortCactusSpawn, ShortCactusObj.rotation);

        //—œ¿¬Õ œ≈–¬Œ√Œ ¬€—Œ Œ√Œ  ¿ “”—¿
        int Random_X_For_The_First_Tall_Cactus = Random.Range(-1, 2);
        if (Random_X_For_The_First_Tall_Cactus == 0 && Random_X_For_Short_Cactus == 0)
        {
            Random_X_For_The_First_Tall_Cactus = 1;
        }
        else if (Random_X_For_The_First_Tall_Cactus == 1 && Random_X_For_Short_Cactus == 1)
        {
            Random_X_For_The_First_Tall_Cactus = -1;
        }
        else if (Random_X_For_The_First_Tall_Cactus == -1 && Random_X_For_Short_Cactus == -1)
        {
            Random_X_For_The_First_Tall_Cactus = 0;
        }
        nextTallCactusSpawn = nextPlatformSpawn;
        nextTallCactusSpawn.y = 0.01f;
        nextTallCactusSpawn.x = Random_X_For_The_First_Tall_Cactus;
        Instantiate(TallCactusObj, nextTallCactusSpawn, TallCactusObj.rotation);

        //—œ¿¬Õ ¬“Œ–Œ√Œ ¬€— Œ√Œ  ¿ “”—¿ 
        int Add_A_Second_Tall_Cactus = Random.Range(0, 2);
        if (Add_A_Second_Tall_Cactus == 1)
        {
            int Random_X_For_The_Second_Tall_Cactus = Random.Range(-1, 2);
            if ((Random_X_For_The_First_Tall_Cactus == 0 && Random_X_For_Short_Cactus == 1) || (Random_X_For_The_First_Tall_Cactus == 1 && Random_X_For_Short_Cactus == 0))
            {
                Random_X_For_The_Second_Tall_Cactus = -1;
            }
            else if ((Random_X_For_The_First_Tall_Cactus == 0 && Random_X_For_Short_Cactus == -1) || (Random_X_For_The_First_Tall_Cactus == -1 && Random_X_For_Short_Cactus == 0))
            {
                Random_X_For_The_Second_Tall_Cactus = 1;
            }
            else
            {
                Random_X_For_The_Second_Tall_Cactus = 0;
            }
            nextTallCactusSpawn = nextPlatformSpawn;
            nextTallCactusSpawn.y = 0.01f;
            nextTallCactusSpawn.x = Random_X_For_The_Second_Tall_Cactus;
            Instantiate(TallCactusObj, nextTallCactusSpawn, TallCactusObj.rotation);
        }
        

        StartCoroutine(spawnObstacles());
    }

    IEnumerator spawnCanyon()
    {
        yield return new WaitForSeconds(2);
        //—œ¿¬Õ  ¿Õ‹ŒÕ¿ —œ–¿¬¿
        nextRightCanyonSpawn.x = -16;
        nextRightCanyonSpawn.y = 0;
        Instantiate(CanyonObj, nextRightCanyonSpawn, CanyonObj.rotation);
        nextRightCanyonSpawn.z += 8.5f;

        //—œ¿¬Õ  ¿Õ‹ŒÕ¿ —À≈¬¿
        nextLeftCanyonSpawn.x = -26;
        nextLeftCanyonSpawn.y = 0;
        Instantiate(CanyonObj, nextLeftCanyonSpawn, CanyonObj.rotation);
        nextLeftCanyonSpawn.z += 8.5f;

        StartCoroutine(spawnCanyon());
    }
}
