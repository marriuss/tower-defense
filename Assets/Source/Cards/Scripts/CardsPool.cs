using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.IO;
using UnityEditor;

[CreateAssetMenu(fileName = "CardsPool", menuName = "CardsPool", order = 51)]
public class CardsPool : ScriptableObject
{
    [SerializeField] private List<CardInfo> _cardInfos;
    [SerializeField] private TextAsset _jsonFile;

    [SerializeField] private List<Card> _cards;
    [SerializeField] private Dictionary<CardInfo, int> _cardIds;

    public IReadOnlyList<Card> Cards => _cards;
    public IReadOnlyList<Card> UnlockedCards => _cards.Where(card => card.IsUnlocked).ToList();
    public IReadOnlyList<Card> LockedCards => _cards.Except(UnlockedCards).ToList();

    public int GetCardId(CardInfo cardInfo) => _cardIds.ContainsKey(cardInfo) ? _cardIds[cardInfo] : -1;

    public Card FindCardById(int id)
    {
        var result = _cardIds.FirstOrDefault(pair => pair.Value == id);

        if (_cardInfos.Contains(result.Key) == false)
            return null;

        CardInfo cardInfo = result.Key;
        return FindCardByCardInfo(cardInfo);
    }

    public Card FindCardByCardInfo(CardInfo cardInfo)
    {
        return _cards.FirstOrDefault(card => card.CardInfo == cardInfo);
    }

    private void OnValidate()
    {
        _cards = new List<Card>();

        foreach (CardInfo info in _cardInfos)
            _cards.Add(new Card(info));

        _cardIds = new Dictionary<CardInfo, int>();

        List<CardId> cardsId = GetCardIds();
        CardInfo cardInfo;

        foreach (CardId cardId in cardsId)
        {
            cardInfo = _cardInfos.FirstOrDefault(info => info.Name.name == cardId.CardName);
            _cardIds.Add(cardInfo, cardId.Id);
        }
    }

    private List<CardId> GetCardIds()
    {
        string serializedData = _jsonFile.text;
        List<CardId> cardIds = new List<CardId>();

        if (string.IsNullOrEmpty(serializedData) || serializedData == "{}")
        {
            int i = 0;

            foreach (CardInfo cardInfo in _cardInfos)
            {
                cardIds.Add(new CardId(cardInfo.Name.name, i));
                i++;
            }

#if UNITY_EDITOR
            string deserializedData = JsonUtility.ToJson(new CardIdArray(cardIds), true);
            File.WriteAllText(AssetDatabase.GetAssetPath(_jsonFile), deserializedData);
            EditorUtility.SetDirty(_jsonFile);
#endif
        }
        else
        {
            cardIds = JsonUtility.FromJson<CardIdArray>(serializedData).Array.ToList();
        }

        return cardIds;
    }
}

[Serializable]
public class CardId
{
    public string CardName;
    public int Id;

    public CardId(string cardName, int id)
    {
        CardName = cardName;
        Id = id;
    }
}

[Serializable]
public class CardIdArray
{
    public CardId[] Array;

    public CardIdArray(IEnumerable<CardId> enumerable)
    {
        Array = enumerable.ToArray();
    }
}