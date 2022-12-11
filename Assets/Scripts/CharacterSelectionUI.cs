using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionUI : MonoBehaviour
{
    public GameObject optionPrefab;
    public Transform previousCharacter;
    public Transform selectedCharacter;

    private void Start()
    {
        foreach(Character c in CharacterSelection.instance.characters)
        {
            GameObject option = Instantiate(optionPrefab, transform);
            Button button = option.GetComponent<Button>();

            button.onClick.AddListener(() =>
            {
                CharacterSelection.instance.SetCharacter(c);
                if (selectedCharacter != null)
                {
                    previousCharacter = selectedCharacter;
                }

                selectedCharacter = option.transform;
            });

            Image image = option.GetComponentInChildren<Image>();
            image.sprite = c.icon;
            Text text = option.GetComponentInChildren<Text>();
            text.text = c.name;

        }
    }

    private void Update()
    {
        if(selectedCharacter != null)
        {
            selectedCharacter.localScale = Vector3.Lerp(selectedCharacter.localScale, new Vector3(1.2f, 1.2f, 1.2f), Time.deltaTime * 10);
        }

        if (previousCharacter != null)
        {
            previousCharacter.localScale = Vector3.Lerp(previousCharacter.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10);
        }
    }
}
