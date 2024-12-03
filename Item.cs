using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;
using System;
using SimpleJSON;
using TMPro;
using RenderHeads.Media.AVProVideo.Demos;

public class Item : MonoBehaviour, IPointerClickHandler
{
    public TextAsset textAsset;
    public Image img;
    public GameObject Window;
    public string video;
    public int languageID; // Adicionar uma variável para o ID de idioma

    public void OnPointerClick(PointerEventData eventData)
    {
        if (textAsset != null)
        {
            OpenWindowCard();
        }
        else
        {
            OpenImage();
        }
    }

    public void OpenWindowCard()
    {
        GameObject v = Instantiate(Window);
        View view = v.GetComponent<View>();

        // Definir a imagem
        view.photo.sprite = img.sprite;

        // Carregar o JSON
        var N = JSON.Parse(textAsset.text);

        // Verificar o idioma
        int languageIndex = languageID == 0 ? 0 : 1;

        // Configurar o título e os textos com base no idioma
        view.Title.text = languageID == 0 ? InvertNumbersInString(N[languageIndex]["Title"]) : N[languageIndex]["Title"];

        // Configurar alinhamento com base no idioma
        view.Title.isRightToLeftText = languageID == 0;
        view.Title.alignment = languageID == 0 ? TextAlignmentOptions.Right : TextAlignmentOptions.Left;

        // Textos principais
        string text1 = "<b>" + N[languageIndex]["TextBold 1"] + "</b> " + N[languageIndex]["Text 1"];
        string text2 = "<b>" + N[languageIndex]["TextBold 2"] + "</b> " + N[languageIndex]["Text 2"];
        string text3 = "<b>" + N[languageIndex]["TextBold 3"] + "</b> " + N[languageIndex]["Text 3"];
        string text4 = "<b>" + N[languageIndex]["TextBold 4"] + "</b> " + N[languageIndex]["Text 4"];
        string text5 = "<b>" + N[languageIndex]["TextBold 5"] + "</b> " + N[languageIndex]["Text 5"];
        string text6 = "<b>" + N[languageIndex]["TextBold 6"] + "</b> " + N[languageIndex]["Text 6"];
        string text7 = "<b>" + N[languageIndex]["TextBold 7"] + "</b> " + N[languageIndex]["Text 7"];
        string text8 = "<b>" + N[languageIndex]["TextBold 8"] + "</b> " + N[languageIndex]["Text 8"];
        string text9 = "<b>" + N[languageIndex]["TextBold 9"] + "</b> " + N[languageIndex]["Text 9"];
        string text10 = "<b>" + N[languageIndex]["TextBold 10"] + "</b> " + N[languageIndex]["Text 10"];

        // Aplicar os textos e verificar a inversão dependendo do idioma
        view.text1.text = languageID == 0 ? InvertNumbersInString(text1) : text1;
        view.text2.text = languageID == 0 ? InvertNumbersInString(text2) : text2;
        view.text3.text = languageID == 0 ? InvertNumbersInString(text3) : text3;
        view.text4.text = languageID == 0 ? InvertNumbersInString(text4) : text4;
        view.text5.text = languageID == 0 ? InvertNumbersInString(text5) : text5;
        view.text6.text = languageID == 0 ? InvertNumbersInString(text6) : text6;
        view.text7.text = languageID == 0 ? InvertNumbersInString(text7) : text7;
        view.text8.text = languageID == 0 ? InvertNumbersInString(text8) : text8;
        view.text9.text = languageID == 0 ? InvertNumbersInString(text9) : text9;
        view.text10.text = languageID == 0 ? InvertNumbersInString(text10) : text10;

        // Alinhamento e RTL para os textos, dependendo do idioma
        SetTextAlignment(view.text1, languageID);
        SetTextAlignment(view.text2, languageID);
        SetTextAlignment(view.text3, languageID);
        SetTextAlignment(view.text4, languageID);
        SetTextAlignment(view.text5, languageID);
        SetTextAlignment(view.text6, languageID);
        SetTextAlignment(view.text7, languageID);
        SetTextAlignment(view.text8, languageID);
        SetTextAlignment(view.text9, languageID);
        SetTextAlignment(view.text10, languageID);
    }

    private void SetTextAlignment(TextMeshProUGUI text, int languageID)
    {
        text.isRightToLeftText = languageID == 0; // Hebraico usa RTL
        text.alignment = languageID == 0 ? TextAlignmentOptions.Right : TextAlignmentOptions.Left; // Definir alinhamento com base no idioma
    }

    public string InvertNumbersInString(string input)
    {
        return Regex.Replace(input, @"\d+|[()]", match =>
        {
            if (Regex.IsMatch(match.Value, @"\d+"))
            {
                return ReverseString(match.Value);
            }
            else if (match.Value == "(")
            {
                return ")";
            }
            else if (match.Value == ")")
            {
                return "(";
            }
            return match.Value;
        });
    }

    private string ReverseString(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    private void OpenImage()
    {
        GameObject v = Instantiate(Window);
        View view = v.GetComponent<View>();

        view.photo.sprite = img.sprite;

        if (video != "")
        {
            view.vcr._videoFiles[0] = video;
        }
    }
}
