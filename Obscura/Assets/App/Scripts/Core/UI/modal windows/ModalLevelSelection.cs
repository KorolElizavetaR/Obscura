using App.Scripts.Core.Storage;
using App.Scripts.Core.Storage.Entities;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModalLevelSelection : ModalEventHandler {
    [SerializeField] TextMeshProUGUI text;

    private Levels _levelsEntity;
    
    protected override void Awake()
    {
        base.Awake();
        EntitiesStorage.Instance.TryGet(out _levelsEntity);
    }
    
    public override void onClickOpenModal() {
        text.text = $"Уровень {_levelsEntity.Id.ToString()}";
        base.onClickOpenModal();
    }

    public void loadLevel() {
        SceneManager.LoadScene("game_scene");
    }
}
