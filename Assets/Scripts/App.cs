using Controllers;
using UnityEngine;

public class App : MonoBehaviour
{
    PlayerController playerController;
    LogController logController;
    WeaponController weaponController;
    GameController gameController;

    [SerializeField] private AppViews appViews;
    public AppViews Views => appViews;

    private void Awake()
    {
        playerController = new PlayerController(this, Views.PlayerView.Health);
        logController = new LogController();
        gameController = new GameController(this);
        weaponController = new WeaponController(this);
        
    }
}