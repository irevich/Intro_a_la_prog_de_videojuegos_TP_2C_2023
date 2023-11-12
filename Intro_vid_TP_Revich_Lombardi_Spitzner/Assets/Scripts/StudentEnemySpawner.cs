using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentEnemySpawner : MonoBehaviour
{
    public int teacherQuantity = 1;
    public int studentQuantity = 2;
    public int bookRacksQuantity = 2;
    public int backpackQuantity = 3;
    public float min_position;
    public float max_position;
    public float bookLeftBorder = 3.5f;
    public float bookRightBorder = 10;
    // public Transform parent;
    public GameObject teacherPrefab;
    public GameObject studentEnemyPrefab;
    public GameObject studentEnemyZAxisPrefab;
    public GameObject bookRackPrefab;
    public GameObject backpackPrefab;
    public Vector3 initPos = new Vector3(7.7f,-6.69f,0);
    public float obstacleZOffset = 8f;
    public float obstacleSize = 2;
    public enum AxisType
    {
        X,
        // Y,
        Z
    }

    public AxisType axisToToggle = AxisType.X;
    private List<float> existingObstacles = new List<float>();



    void SpawnStudentEnemies(GameObject prefab)
    {
        float spawnDistance = (max_position - min_position)/studentQuantity;
        float currentPos = min_position;
        Vector3 newPos = initPos;
        GameObject obj;
        for (int i=0; i<studentQuantity; i++)
        {
            if (i>0)
            {
                newPos.z = Random.Range(Mathf.Max(currentPos,newPos.z+obstacleSize),currentPos+spawnDistance);
            }
            else 
            {
                newPos.z = Random.Range(currentPos,currentPos+spawnDistance);
            }
            existingObstacles.Add(newPos.z);
            obj = Instantiate(prefab, newPos, Quaternion.identity);
            obj.transform.SetParent(transform);
            currentPos += spawnDistance;
        }
    }

    void SpawnStudentEnemiesZAxis(GameObject prefab, Quaternion rotation)
    {
        float spawnDistance = (max_position - min_position)/studentQuantity;
        float currentPos = min_position;
        Vector3 newPos = initPos;
        GameObject obj;
        for (int i=0; i<studentQuantity; i++)
        {
            if (i>0)
            {
                newPos.x = Random.Range(Mathf.Max(currentPos,newPos.x+obstacleSize),currentPos+spawnDistance);
            }
            else 
            {
                newPos.x = Random.Range(currentPos,currentPos+spawnDistance);
            }
            existingObstacles.Add(newPos.x);
            obj = Instantiate(prefab, newPos, Quaternion.identity);
            obj.transform.SetParent(transform);
            obj.transform.rotation = rotation;
            currentPos += spawnDistance;
        }
    }

    void SpawnObstacle(GameObject prefab, int quantity, Quaternion rotation)
    {
        Vector3 newPos = initPos;
        float randomValue;
        int i = 0;
        float pos;
        bool isValid = true;
        int it = 0;
        GameObject obj;


        while (i<quantity && it <10)
        {
            it++;
            isValid = true;
            randomValue = Random.Range(min_position,max_position);
            for (int j=0; isValid && j<existingObstacles.Count;j++)
            {
                pos = existingObstacles[i];
                if (Mathf.Abs(pos-randomValue) <= obstacleSize)
                {
                    isValid = false;
                    break;
                }

            }
            if (isValid)
            {
                newPos.z = randomValue;
                existingObstacles.Add(newPos.z);
                newPos.x = Random.Range(bookLeftBorder,bookRightBorder);
                obj = Instantiate(prefab, newPos, Quaternion.identity);
                obj.transform.SetParent(transform);
                obj.transform.rotation = rotation;
                i++;
            }
            
        }
        if (it >= 20)
        {
            Debug.Log("Reached iteration limit on obstacle spawn");
        }
    }

    void SpawnObstacleZAxis(GameObject prefab, int quantity, Quaternion rotation)
    {
        Vector3 newPos = initPos;
        float randomValue;
        int i = 0;
        float pos;
        bool isValid = true;
        int it = 0;
        GameObject obj;


        while (i<quantity && it <10)
        {
            it++;
            isValid = true;
            randomValue = Random.Range(min_position,max_position);
            for (int j=0; isValid && j<existingObstacles.Count;j++)
            {
                pos = existingObstacles[i];
                if (Mathf.Abs(pos-randomValue) <= obstacleSize)
                {
                    isValid = false;
                    break;
                }

            }
            if (isValid)
            {
                newPos.x = randomValue;
                existingObstacles.Add(newPos.x);
                newPos.z = initPos.z - obstacleZOffset + Random.Range(bookLeftBorder,bookRightBorder);
                obj = Instantiate(prefab, newPos, Quaternion.identity);
                obj.transform.SetParent(transform);
                obj.transform.rotation = rotation;
                i++;
            }
            
        }
        if (it >= 20)
        {
            Debug.Log("Reached iteration limit on obstacle spawn");
        }
    }

    private void SpawnTeacher()
    {
        float old_max = max_position;
        max_position = max_position - (max_position-min_position)/2;
        switch (axisToToggle)
        {
            case AxisType.X:
                SpawnObstacle(teacherPrefab,teacherQuantity,Quaternion.Euler(0, 0, 0));
                break;
            case AxisType.Z:
                SpawnObstacleZAxis(teacherPrefab,teacherQuantity,Quaternion.Euler(0, 0, 0));
                break;
        }
        max_position = old_max;
    }

    void Start()
    {
        switch (axisToToggle)
        {
            case AxisType.X:
                SpawnStudentEnemies(studentEnemyPrefab);
                SpawnTeacher();
                SpawnObstacle(bookRackPrefab,bookRacksQuantity,Quaternion.Euler(0, 0, 0));
                SpawnObstacle(backpackPrefab,backpackQuantity,Quaternion.Euler(0, -90, 0));
                break;
            case AxisType.Z:
                SpawnStudentEnemiesZAxis(studentEnemyZAxisPrefab,Quaternion.Euler(0, 90, 0));
                SpawnTeacher();
                SpawnObstacleZAxis(bookRackPrefab,bookRacksQuantity,Quaternion.Euler(0, 90, 0));
                SpawnObstacleZAxis(backpackPrefab,backpackQuantity,Quaternion.Euler(0, 0, 0));
                break;
        }
        
    }

}
