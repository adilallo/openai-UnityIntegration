// more info https://unitycoder.com/blog/2022/02/05/using-open-ai-gpt-3-api-in-unity/
using OpenAI_API;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class OpenAITest : MonoBehaviour
{
    private void Start()
    {
        var task = StartAsync();
    }

    // Start is called before the first frame update
    async Task StartAsync()
    {
        //Debug.Log("running..");

        var keypath = Path.Combine(Application.streamingAssetsPath, "apikey.txt");
        if (File.Exists(keypath) == false)
        {
            Debug.LogError("Apikey missing: " + keypath);
        }

        //Debug.Log("Load apikey: " + keypath);
        var apikey = File.ReadAllText(keypath);

        try
        {

            var api = new OpenAI_API.OpenAIAPI(apikey, Engine.Davinci);
            //var result = await api.Completions.CreateCompletionAsync("One Two Three One Two", temperature: 0.1);
            //var result = await api.Completions.CreateCompletionAsync("Lorem ipsum dolor sit amet,", temperature: 0.1);
            //var result = await api.Completions.CreateCompletionAsync("o be, or not to be:", temperature: 0.1);
            //var result = await api.Completions.CreateCompletionAsync("if (Physics.Raycast(transform.position,", temperature: 0.1);
            var result = await api.Completions.CreateCompletionAsync("Once upon a time ", temperature: 0.1);
            //var result = await api.Completions.CreateCompletionAsync("3.14159265359", temperature: 0.1);

            //var result = await api.Search.GetBestMatchAsync("Washington DC", "Canada", "China", "USA", "Spain");
            //var result = await api.Search.GetBestMatchAsync("RaycastHit", "Unity3D", "Godot", "Unreal Engine", "GameMaker");
            //Console.WriteLine(result.ToString());
            Debug.Log("result=" + result.ToString());
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
        }
    }
}