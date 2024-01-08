﻿public static class Utiity
{
    public static T[] ShuffleArray<T>(T[] array, int seed)
    {
        System.Random psudoRandomNumberGenerator = new System.Random(seed);
        for (int i = 0; i < array.Length; i++)
        {
            int randomIndex = psudoRandomNumberGenerator.Next(i, array.Length);
            T temp = array[randomIndex];
            array[randomIndex] = array[i];
            array[i] = temp;
        }
        return array;
    }
}