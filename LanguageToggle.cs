using UnityEngine;
using UnityEngine.UI;

public class LanguageToggle : MonoBehaviour
{
    public ItemInterface itemInterface;
    public PlayerNameInterface[] playerNameInterfaces;
    public Item[] items;

    // Refer�ncias para as imagens dos dois idiomas
    public Sprite englishImage; // Imagem para o idioma ingl�s
    public Sprite hebrewImage;  // Imagem para o idioma hebraico
    public Image buttonImage;   // Refer�ncia para o componente Image do bot�o

    void Start()
    {
        if (itemInterface == null)
        {
            itemInterface = FindObjectOfType<ItemInterface>();
        }

        if (playerNameInterfaces == null || playerNameInterfaces.Length == 0)
        {
            playerNameInterfaces = FindObjectsOfType<PlayerNameInterface>();
        }

        if (items == null || items.Length == 0)
        {
            items = FindObjectsOfType<Item>();
        }

        // Atualiza a imagem do bot�o com base no idioma atual ao iniciar
        UpdateButtonImage();
    }

    public void ToggleLanguage()
    {
        // Alternar entre 0 e 1 no script ItemInterface
        itemInterface.languageID = itemInterface.languageID == 0 ? 1 : 0;
        itemInterface.LoadTexts();

        // Alternar entre 0 e 1 nos scripts PlayerNameInterface para todos os jogadores
        foreach (var playerNameInterface in playerNameInterfaces)
        {
            playerNameInterface.languageID = playerNameInterface.languageID == 0 ? 1 : 0;
            playerNameInterface.LoadPlayerName(); // Recarrega os nomes dos jogadores ap�s mudan�a de idioma
        }

        // Alternar entre 0 e 1 nos scripts Item
        foreach (var item in items)
        {
            item.languageID = item.languageID == 0 ? 1 : 0;
        }

        // Atualizar a imagem do bot�o
        UpdateButtonImage();
    }

    private void UpdateButtonImage()
    {
        // Define a imagem do bot�o com base no idioma atual
        if (itemInterface.languageID == 0)
        {
            buttonImage.sprite = hebrewImage;
        }
        else
        {
            buttonImage.sprite = englishImage;
            
        }
    }
}
