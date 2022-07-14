using UnityEngine;

public class WarpGenerator : MonoBehaviour
{
    [SerializeField] private Warper warper;

    [SerializeField] private GameObject newWarp;


    private void OnEnable()
    {
        Spawner();
    }

    private void Spawner()
    {
        GameObject warp = Instantiate(newWarp);
        enabled = false;
    }
}
