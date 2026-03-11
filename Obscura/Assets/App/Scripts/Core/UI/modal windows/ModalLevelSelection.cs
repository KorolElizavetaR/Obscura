using App.Scripts.Core.Storage;
using App.Scripts.Core.Storage.Entities;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModalLevelSelection : ModalEventHandler {
    [SerializeField] TextMeshProUGUI text;

    private Level _levelEntity;
    
    private void Awake()
    {
        EntitiesStorage.Instance.TryGet(out _levelEntity);
    }
    
    public override void onClickOpenModal() {
        text.text = $"Запустить {_levelEntity.Id.ToString()}";
        base.onClickOpenModal();
    }

    public void loadLevel() {
        SceneManager.LoadScene("game_scene");
    }
}
