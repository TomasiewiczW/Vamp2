using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int level = 1;
    int experience = 0;
    [SerializeField] ExperienceBar experienceBar;

    private void Start()
    {
        experienceBar.UpdateExperienceSlider(experience, To_LEVEL_UP);
        experienceBar.SetLevelText(level);
    }

    int To_LEVEL_UP
    {
        get { return level * 1000; }
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        experienceBar.UpdateExperienceSlider(experience, To_LEVEL_UP);
    }

    private void CheckLevelUp()
    {
        if(experience >= To_LEVEL_UP)
        {
            experience -= To_LEVEL_UP;
            level += 1;
            experienceBar.SetLevelText(level);
        }
    }
}
