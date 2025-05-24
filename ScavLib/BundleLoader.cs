//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using UnityEngine;
//using Object = UnityEngine.Object;


//namespace ScavLib
//{
//    public static class BundleLoader
//    {
//        public static event Action? OnAllBundlesLoaded;

//        private static readonly List<LoadOperation> _operations = new List<LoadOperation>();

//        public static Object[] assets;

//        internal static void LoadAllBundles(string root, string withExtension)
//        {
//            Logger.LogInfo($"Loading all bundles with extension {withExtension} from root {root}", extended: true);

//            string[] files = Directory.GetFiles(root, "*" + withExtension, SearchOption.AllDirectories);

//            foreach (string path in files)
//            {
//                LoadBundleContent()
//            }
//        }


//        private static IEnumerator LoadBundleContent(LoadOperation operation, AssetBundle bundle)
//        {
//            operation.CurrentState = LoadOperation.State.LoadingContent;
//            var assetRequest = bundle.LoadAllAssetsAsync<ScriptableObject>();
//            yield return assetRequest;

//            assets = assetRequest.allAssets;
//            //Mod[] mods = assets.OfType<Mod>().ToArray();

            

//            //foreach (var content in assets.OfType<Content>())
//            //{
//            //    try
//            //    {
//            //        content.Initialize(mod);
//            //    }
//            //    catch (Exception e)
//            //    {
//            //        Logger.LogError($"Failed to load {content.Name} ({content.GetType().Name}) from bundle {operation.FileName} ({mod.Identifier}): {e}");
//            //    }
//            //}
//        }


//        private class LoadOperation
//        {
//            LoadOperation(string path, Func<AssetBundle, IEnumerator>? onBundleLoaded = null, bool loadContents = true)
//            {
//                Path = path;
//                LoadContents = loadContents;
//                OnBundleLoaded = onBundleLoaded;
//                BundleRequest = AssetBundle.LoadFromFileAsync(path);
//            }
//            public string Path { get; private set; }
//            public DateTime StartTime { get; } = DateTime.Now;
//            public State CurrentState { get; set; } = State.LoadingBundle;
//            public bool LoadContents { get; private set; }
//            public Func<AssetBundle, IEnumerator>? OnBundleLoaded { get; private set; }

//            public AssetBundleCreateRequest BundleRequest { get; private set; }

//            public TimeSpan ElapsedTime => DateTime.Now - StartTime;
//            public string FileName => System.IO.Path.GetFileNameWithoutExtension(Path);

//            public enum State
//            {
//                LoadingBundle,
//                LoadingContent
//            }
//        }
//    }
//}
