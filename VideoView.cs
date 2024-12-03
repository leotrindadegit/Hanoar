using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using RenderHeads.Media.AVProVideo.Demos;

public class VideoView : MonoBehaviour, IPointerClickHandler
{
    public Image img;
    public GameObject Window; // Prefab padrão
    public GameObject alternativeWindow; // Prefab alternativo
    private GameObject currentWindow; // Prefab atual
    public string video;

    void Start()
    {
        currentWindow = Window; // Inicialmente define o prefab padrão
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OpenImage();
    }

    public void OpenWindowCard()
    {
        GameObject v = Instantiate(currentWindow); // Usando o prefab atual
        View view = v.GetComponent<View>();

        // Definir a imagem
        view.photo.sprite = img.sprite;
    }

    private void OpenImage()
    {
        GameObject v = Instantiate(currentWindow); // Usando o prefab atual
        View view = v.GetComponent<View>();

        view.photo.sprite = img.sprite;

        if (video != "")
        {
            view.vcr._videoFiles[0] = video;
        }
    }

    // Função para alternar o prefab
    public void SwitchPrefab()
    {
        if (currentWindow == Window)
        {
            currentWindow = alternativeWindow;
        }
        else
        {
            currentWindow = Window;
        }
    }
}
