using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPanelInitialisation : MonoBehaviour
{
    public EnemyPanel[] enemyPanel;

    void Awake()
    {
        var enemies = BattleManager.Instance.GetEnemies();
        if (enemies == null || enemies.Length == 0) { Debug.LogError("Enemies of Battle scene not set!"); return; }
        if (enemies.Length > enemyPanel.Length) { Debug.LogError("Too much enemies for Battle scene!"); return; }

        for (int i = 0; i < enemies.Length; i++)
        {
            enemyPanel[i].gameObject.SetActive(true);
            enemyPanel[i].Initialise();
            enemyPanel[i].SetEnemy(enemies[i]);
        }
    }

    public void EnemyCheck()
    {
        foreach (EnemyPanel panel in enemyPanel) if (panel.gameObject.activeSelf) return;
        Debug.Log("Victory!");
        BattleManager.Instance.EnemyLose();
        SceneManager.UnloadScene("Battle");
    }

}
