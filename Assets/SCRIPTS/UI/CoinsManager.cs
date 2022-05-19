using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.Collections.Generic;

public class CoinsManager : MonoBehaviour
{

	/*---------------------------------------------------------------------------------------------
    *  Attached to HudController gameObject.
    *  Manage coin animations
    *--------------------------------------------------------------------------------------------*/

	public static CoinsManager Inst;

	//References
	[Header("UI references")]
	[SerializeField] TMP_Text coinUIText;
	[SerializeField] GameObject animatedCoinPrefab;
	[SerializeField] GameObject animatedHeartPrefab;
	[SerializeField] Transform target;
	[SerializeField] Transform targetHearts;

	[Space]
	[Header("Available coins : (coins to pool)")]
	[SerializeField] int maxCoins;
	Queue<GameObject> coinsQueue = new Queue<GameObject>();
	Queue<GameObject> HeartsQueue = new Queue<GameObject>();

	[Space]
	[Header("Deliveri")]
	[SerializeField] GameObject[] deliverables;	

	[Space]
	[Header("Animation settings")]
	[SerializeField][Range(0.5f, 0.9f)] float minAnimDuration;
	[SerializeField][Range(0.9f, 2f)] float maxAnimDuration;

	[SerializeField] Ease easeType;
	[SerializeField] float spread;

	Vector3 targetPositionCoins;
	Vector3 targetPositionHearts;


	private int _c = 0;

	public int Coins
	{
		get { return _c; }
		set
		{
			_c = value;
			//update UI text whenever "Coins" variable is changed
			coinUIText.text = Coins.ToString();
		}
	}

	void Awake()
	{
		Inst = this;

		targetPositionCoins = target.position;
		targetPositionHearts = targetHearts.position;

		//prepare pool
		PrepareCoins();
	}

	private void OnEnable()
	{
		GameManager.resetAll += ResetCoins;
;
	}

	private void OnDisable()
	{
		GameManager.resetAll -= ResetCoins;
;
	}

	void PrepareCoins()
	{
		GameObject coin;
		GameObject heart;
		for (int i = 0; i < maxCoins; i++)
		{
			coin = Instantiate(animatedCoinPrefab);
			coin.transform.parent = transform;
			coin.SetActive(false);
			coinsQueue.Enqueue(coin);

			heart = Instantiate(animatedHeartPrefab);
			heart.transform.parent = transform;
			heart.SetActive(false);
			HeartsQueue.Enqueue(heart);
		}
	}

	void AnimateCoin(Vector3 collectedCoinPosition, int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			//check if there's coins in the pool
			if (coinsQueue.Count > 0)
			{
				//extract a coin from the pool
				GameObject coin = coinsQueue.Dequeue();
				coin.SetActive(true);

				//move coin to the collected coin pos
				coin.transform.position = collectedCoinPosition + new Vector3(Random.Range(-spread, spread), 0f, 0f);

				//animate coin to target position
				float duration = Random.Range(minAnimDuration, maxAnimDuration);
				coin.transform.DOMove(targetPositionCoins, duration)
				.SetEase(easeType)
				.OnComplete(() => {
					//executes whenever coin reach target position
					coin.SetActive(false);
					coinsQueue.Enqueue(coin);

					Coins++;
				});
			}
		}
	}

	void AnimateHeart(Vector3 collectedHeartPosition, int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			//check if there's coins in the pool
			if (HeartsQueue.Count > 0)
			{
				//extract a coin from the pool
				GameObject heart = HeartsQueue.Dequeue();
				heart.SetActive(true);

				//move coin to the collected coin pos
				heart.transform.position = collectedHeartPosition + new Vector3(Random.Range(-spread, spread), 0f, 0f);

				//animate coin to target position
				float duration = Random.Range(minAnimDuration, maxAnimDuration);
				heart.transform.DOMove(targetPositionHearts, duration)
				.SetEase(easeType)
				.OnComplete(() => {
					//executes whenever coin reach target position
					heart.SetActive(false);
					HeartsQueue.Enqueue(heart);

					Coins++;
				});
			}
		}
	}

	public void AnimateDelivery(Transform targetTransform, int Type)
	{
		//Instantiate deliver
		GameObject deliver = Instantiate(deliverables[Type - 1]);
		deliver.SetActive(true);

		//move coin to the player
		deliver.transform.SetParent(targetTransform);
		deliver.transform.position = Player_Data.Inst.gameObject.transform.position + new Vector3(0, 1f, -1f);


		//animate coin to target position
		deliver.transform.DOMove(targetTransform.position, 0.4f)
		.SetEase(easeType)
		.OnComplete(() => {
			//executes whenever coin reach target position
			Destroy(deliver);
		});
	}

	public void AddCoins(Vector3 collectedCoinPosition, int amount)
	{
		AnimateCoin(collectedCoinPosition, amount);
	}

	public void AddHearts(Vector3 collectedHeartPosition, int amount)
	{
		AnimateHeart(collectedHeartPosition, amount);
	}

	void ResetCoins()
    {
		Coins = 0;
    }
}
