using UnityEngine;
using TMPro;
using SimpleJSON;
using System.Text.RegularExpressions;
using System;

public class PlayerNameInterface : MonoBehaviour
{
    public TextAsset textAsset;           // Arquivo JSON com os nomes dos jogadores
    public TextMeshProUGUI playerName;    // Refer�ncia ao t�tulo (nome do jogador)
    public int languageID = 0;            // 0 para Hebraico, 1 para Ingl�s

    void Start()
    {
        if (textAsset != null)
        {
            LoadPlayerName();
        }
    }

    // M�todo para carregar e atualizar o nome do jogador
    public void LoadPlayerName()
    {
        // Carregar o JSON
        var N = JSON.Parse(textAsset.text);

        // Verificar o idioma
        int languageIndex = languageID == 0 ? 0 : 1;

        // Configurar o nome do jogador com base no idioma
        string playerNameText = N[languageIndex]["Title"];

        // Aplicar o nome do jogador, verificando a invers�o se necess�rio
        playerName.text = languageID == 0 ? InvertNumbersInString(playerNameText) : playerNameText;

        // Alinhamento e RTL para o nome, dependendo do idioma
        SetTextAlignment(playerName, languageID);
    }

    // Fun��o para configurar alinhamento e dire��o do texto
    private void SetTextAlignment(TextMeshProUGUI text, int languageID)
    {
        // Centralizar o nome do jogador para ambos os idiomas
        text.alignment = TextAlignmentOptions.Center;

        // Se for hebraico (languageID == 0), usar RTL
        if (languageID == 0)
        {
            text.isRightToLeftText = true;
        }
        // Se for ingl�s (languageID == 1), desativar RTL
        else
        {
            text.isRightToLeftText = false;
        }
    }

    // Fun��o para inverter n�meros e caracteres especiais
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

    // Fun��o auxiliar para reverter strings
    private string ReverseString(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
