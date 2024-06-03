using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializeController : MonoBehaviour
{
    [SerializeField] private StarsSegmentaeSpawn segmentae;
    [SerializeField] private PlanetarySystemSpawn planetary;
    [SerializeField] private CivilizationSpawn civilization;


    // Start is called before the first frame update
    void Start()
    {
        segmentae.wakeSpanwer(createSegmentumInfor(), this);
    }


    private SegmentumInfor createSegmentumInfor()
    {
        SegmentumInfor infor = new SegmentumInfor();
        infor.largeSegmentaeNum = 1;
        infor.middleContinedLarge = 1;
        infor.smallContinedmiddlle = 1;
        return infor;
    }

    public void awakePlanetarySpawner(List<SmallSegmentae> segmentaes)
    {
        planetary.wakeSpanwer(segmentaes, this);
    }

    public void awakeCivilizationSpawn(List<PlanetarySystem> planetarySystems)
    {
        List<Colony> colonies = new List<Colony>();
        foreach(PlanetarySystem planetarySystem in planetarySystems)
        {
            colonies.Add(planetarySystem.GetComponent<Colony>());
        }
        civilization.wakeSpawn(colonies, this);
    }


}
