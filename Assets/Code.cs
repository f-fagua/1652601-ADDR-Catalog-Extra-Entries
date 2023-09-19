using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

public class Code : MonoBehaviour
{
    [SerializeField] 
    private string m_Server = "http://10.3.0.208"; 
    
    [SerializeField] 
    private string m_Port = "63510";

    [SerializeField] 
    private string m_CatalogFileName = "catalog__test.json";

    void Start()
    {
        var path = Path.Combine(m_Server + ":" + m_Port, m_CatalogFileName);
        Debug.Log(path);
        var handle = Addressables.LoadContentCatalogAsync(path);

        //var handle = Addressables.LoadContentCatalogAsync("http://10.4.184.53:52273/catalog_2023.09.06.19.21.09.json");
        handle.Completed += HandleComplete;
    }

    private void HandleComplete(AsyncOperationHandle<IResourceLocator> obj)
    {
        var result = obj.Result;
        IList<IResourceLocation> locations = new List<IResourceLocation>();
        result.Locate("MyAsset", typeof(object), out locations);
        foreach (var location in locations)
        {
            Debug.Log($"Key: {location.PrimaryKey}, Type {location.ResourceType}");
        }
    }
}
