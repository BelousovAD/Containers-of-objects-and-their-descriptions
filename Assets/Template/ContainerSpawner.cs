using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public abstract class ContainerSpawner<T> : MonoBehaviour where T : ScriptableObject
{
    [SerializeField] private Canvas _parent;
    [SerializeField] private GameObject _containerPrefab;
    [SerializeField] private AssetReferenceT<T> _assetReference;

    protected T LoadedAsset { get; private set; }
    protected GameObject ContainerInstance { get; private set; }

    protected void SetAssetReference(AssetReferenceT<T> assetReference)
    {
        if (_assetReference != assetReference)
        {
            ReleaseReference();
            _assetReference = assetReference;
        }
    }

    public IEnumerator SpawnRoutine()
    {
        if (_assetReference != null)
        {
            yield return StartCoroutine(LoadReference());
            ContainerInstance = Instantiate(_containerPrefab, _parent.transform);
            FillContainer();
        }
    }

    protected abstract void FillContainer();

    protected IEnumerator LoadReference()
    {
        if (_assetReference.Asset == null)
        {
            yield return _assetReference.LoadAssetAsync();
            LoadedAsset = (T)_assetReference.Asset;
        }
    }

    protected void ReleaseReference()
    {
        if (_assetReference.Asset != null)
        {
            _assetReference.ReleaseAsset();
        }
    }
}
