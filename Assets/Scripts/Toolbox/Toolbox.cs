using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox
{

    //Jobs for NPCs as enum
    public enum Jobs
    { 
        none,
        blacksmith,
        clockworker,
        nevermoving
    }
    //Translate job's int into its name
    public static string JobToString(int job)
    {
        string translated;
        switch (job)
        {
            case 0:
                translated = "generic";
                break;

            case 1:
                translated = "blacksmith";
                break;

            case 2:
                translated = "clockworker";
                break;

            case 3:
                translated = "nevermoving";
                break;

            default:
                translated = "generic";
                break;
        }
        return translated;
    }

    //translate job's name into its int
    public static int JobToEnum(string job)
    {
        int translated;
        switch (job)
        {
            case "none":
                translated = 0;
                break;

            case "blacksmith":
                translated = 1;
                break;

            case "clockworker":
                translated = 2;
                break;

            case "nevermoving":
                translated = 3;
                break;

            default:
                translated = 0;
                break;
        }
        return translated;
    }
    public static int optimizedRand(int min, int max)
    {
        System.Random rnd = new System.Random();
        return rnd.Next(min, max);
    }
}
