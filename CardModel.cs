using UnityEngine;
using System.Collections;

public class CardModel : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public Sprite[] faces;
    public Sprite cardBack;
    public int cardIndex; // e.g. faces[cardIndex];
    CardFlipper cardFlipper;
    bool showingBack = true;
    public void ToggleFace(bool showFace)
    {
        if (showFace)
        {
            if (showingBack)
            {
                cardFlipper.FlipCard(cardBack, faces[cardIndex], cardIndex);
                showingBack = false;
            }
            //spriteRenderer.sprite = faces[cardIndex];
        }
        else
        {
            if (!showingBack)
            {
                cardFlipper.FlipCard(faces[cardIndex], cardBack, cardIndex);
                showingBack = true;
            }
            spriteRenderer.sprite = cardBack;
        }
    }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cardFlipper = GetComponent<CardFlipper>();
    }

}
