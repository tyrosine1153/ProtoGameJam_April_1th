using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomUtility : MonoBehaviour
{
    /// <summary>
    /// 주어진 확률 분포에 따라 무작위로 인덱스를 반환하는 메서드입니다.
    /// </summary>
    /// <param name="probs">각 인덱스에 대한 확률을 나타내는 부동 소수점 값 배열입니다. 배열의 합계는 100%가 아니어도 상관 없습니다.</param>
    /// <returns>주어진 확률 분포에 따라 무작위로 선택된 인덱스를 반환합니다.</returns>
    public static int Probability(float[] probs)
    {
        var total = probs.Sum();
        var randomPoint = Random.value * total;

        for (var i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }

            randomPoint -= probs[i];
        }

        return probs.Length - 1;
    }

    /// <summary>
    /// 주어진 확률에 따라 무작위로 true/false를 반환하는 메서드입니다.
    /// </summary>
    /// <param name="prob">참으로 반환될 확률을 나타내는 0에서 100 사이의 부동 소수점 값입니다.</param>
    /// <returns>주어진 확률에 따라 무작위로 true/false를 반환합니다.</returns>
    public static bool Probability(float prob)
    {
        if (prob >= 100) return true;
        if (prob <= 0) return false;

        return Probability(new[] { prob, 100 - prob }) == 0;
    }
}