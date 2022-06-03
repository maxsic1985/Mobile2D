using UnityEngine;
using UnityEngine.Purchasing;
using Profile;
public class ShoperTest : MonoBehaviour
{
    [SerializeField] private GameObject _data;
    public void GetBuy(int grade)
    {
        Debug.Log($"item- {GetComponent<IAPButton>().productId} was buy ");
        _data.TryGetComponent<Root>(out Root root);
        root.ProfilePlayer.CurrenMoney.Value += grade;
    }
    public void GetBuyError()
    {
        Debug.Log($"error to buy {GetComponent<IAPButton>().productId}");
    }
}
