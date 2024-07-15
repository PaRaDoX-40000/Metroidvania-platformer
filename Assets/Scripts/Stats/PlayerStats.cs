using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    private List<Stat> _playerStats = new List<Stat>();
    private Dictionary<Stat.NameStats, UnityEvent<int>> listEventsStarChanged = new Dictionary<Stat.NameStats, UnityEvent<int>>();
    public UnityEvent<int> MaxHealthChanged;   
    public UnityEvent<int> EnduranceChanged;
    public UnityEvent<int> StrengthChanged;
    public UnityEvent<int> DexterityChanged;

    private void Start()
    {
        listEventsStarChanged.Add(Stat.NameStats.MaxHealth, MaxHealthChanged);
        listEventsStarChanged.Add(Stat.NameStats.Endurance, EnduranceChanged);
        listEventsStarChanged.Add(Stat.NameStats.Strength, StrengthChanged);
        listEventsStarChanged.Add(Stat.NameStats.Dexterity, DexterityChanged);

    }
    public Stat GetStar(Stat.NameStats nameStats)
    {
        return _playerStats.First(q => q.StatsName == nameStats);
    }
    private void Awake()
    {
        for(int i = 0; i < 6; i++)
        {
            _playerStats.Add(new Stat(i));           
        }
    }
    public void AddValueStats(List<Stat> stats)
    {
        foreach(Stat stat in stats)
        {
            Stat playerStat = _playerStats.FirstOrDefault(p=> p.StatsName == stat.StatsName);        
            playerStat.AddValueStat(stat.ValueStat);
            listEventsStarChanged[stat.StatsName].Invoke(playerStat.ValueStat);
        }
    }
    public void SubtractValueStats(List<Stat> stats)
    {
        foreach (Stat stat in stats)
        {
            Stat playerStat = _playerStats.FirstOrDefault(p => p.StatsName == stat.StatsName);                      
            playerStat.AddValueStat(-stat.ValueStat);
            listEventsStarChanged[stat.StatsName].Invoke(playerStat.ValueStat);

        }
    }
}
