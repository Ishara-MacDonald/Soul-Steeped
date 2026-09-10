using System.Collections.Generic;
using UnityEngine;

public class CustomerData
{
    public static CustomerData data;
    private string[] names = { "Kalista", "Keyra", "Leandra", "Robin" };
    private string[] greetings = { "Hi.", "Hiya!", "Howdy! How're you?", "Wassup?" };
    private string[] goodFareWells = { "Thanks. This is just what I needed.", "Amazing! I didn't think tea would be this good.", "This is... very nice. I'll be coming back for more." };
    private string[] badFareWells = { "Nice, but... not sure if this is what I needed.", "Mmm.. I'm not sure if this was the right one.", "It's... fine. I guess." };
    private List<Sprite> sprites;

    public CustomerData(List<Sprite> sprites)
    {
        this.sprites = sprites;
        data = this;
    }

    public Sprite GetRandomSprite()
    {
        return sprites[Random.Range(0, sprites.Count)];
    }

    public string GetRandomName()
    {
        return names[Random.Range(0, names.Length)];
    }

    public string GetRandomGreeting()
    {
        return greetings[Random.Range(0, greetings.Length)];
    }

    public string GetRandomFarewell(bool hadRightDrink)
    {
        if (hadRightDrink) return goodFareWells[Random.Range(0, goodFareWells.Length)];
        return badFareWells[Random.Range(0, badFareWells.Length)];
    }
}