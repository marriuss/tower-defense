using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : UnitSpawner
{
    public int Waves { get; private set; }
    public int CurrentWave { get; private set; }
    public int WaveUnits { get; private set; }
    public int CurrentUnit { get; private set; }

    public void StartSpawn(float wavesDelay, float spawnDelay, List<Wave> waves)
    {
        StartCoroutine(SpawnUnits(wavesDelay, spawnDelay, waves));
    }

    private IEnumerator SpawnUnits(float wavesDelay, float spawnDelay, List<Wave> waves)
    {
        Waves = waves.Count;
        WaitForSeconds waitForWave = new WaitForSeconds(wavesDelay);
        WaitForSeconds waitForSpawn = new WaitForSeconds(spawnDelay);
        Stack<Unit> units;
        Unit unit;

        foreach (Wave wave in waves)
        {
            CurrentWave++;
            CurrentUnit = 0;
            units = GenerateUnitStack(wave);
            WaveUnits = units.Count;
            yield return waitForWave;

            while (units.Count > 0)
            {
                unit = units.Pop(); 
                Spawn(unit);
                CurrentUnit++;
                yield return waitForSpawn;
            }
        }
    }

    private Stack<Unit> GenerateUnitStack(Wave wave)
    {
        List<Unit> units = wave.Units;

        units = Utils.Shuffle(units).ToList();
        Stack<Unit> unitStack = new();

        foreach (Unit unit in units)
            unitStack.Push(unit);

        return unitStack;
    }
}
