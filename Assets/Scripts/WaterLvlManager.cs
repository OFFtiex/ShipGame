using UnityEngine;

public class WaterLvlManager : MonoBehaviour
{
    [Header("Water config")]
    [SerializeField] private Transform waterTransform;
    [SerializeField] private float baseFloodSpeed = 0.01f;
    [SerializeField] private float addBreachSpeed = 0.03f;
    [SerializeField] private float maxWaterLvl = 5f;

    private float currentWaterLvl;
    private int activeBreachesCount = 0;
    void Start()
    {
        if (waterTransform != null) currentWaterLvl = waterTransform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (waterTransform == null) return;

        if (activeBreachesCount > 0 && baseFloodSpeed > 0)
        {
            float currentFloodSpeed = baseFloodSpeed + (activeBreachesCount * addBreachSpeed);

            currentWaterLvl = Mathf.MoveTowards(currentWaterLvl, maxWaterLvl, currentFloodSpeed * Time.deltaTime);
            waterTransform.position = new Vector2(waterTransform.position.y, currentWaterLvl);
        }
    }

    public void AddBreach()
    {
        activeBreachesCount++;
    }

    public void RepairBreaches()
    {
        activeBreachesCount = Mathf.Max(0, activeBreachesCount - 1);
    }
}
