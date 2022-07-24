using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

using Niantic.ARDK.Templates;

#if (UNITY_EDITOR)
namespace Niantic.ARDK.Templates 
{
    public class LightshipWelcomeWindow : EditorWindow 
    {
        private static VisualElement _root;
        private ScrollView _templates;
        private ScrollView _aboutUs;
        private ScrollView _help;
            

        public static void ShowWindow() 
        {
            var window = GetWindow<LightshipWelcomeWindow>();
            window.titleContent = new GUIContent("Welcome to Lightship Templates");
            window.minSize = new Vector2(970,680);
            window.maxSize = new Vector2(970,680);
            window.Show();
        }

        private void OnEnable() 
        {
            VisualTreeAsset design = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/LightShipHUB/Editor/Scripts/LightshipWelcomeWindow.uxml");
            TemplateContainer structure = design.CloneTree();
            rootVisualElement.Add(structure);
            StyleSheet style = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/LightShipHUB/Editor/Scripts/LightshipWelcomeWindowStyles.uss");
            rootVisualElement.styleSheets.Add(style);
            _root = rootVisualElement;
            AddLogo();
            CreateMenu();
            CreateTemplates();
            CreateHelp();
        }

        private void AddLogo()
        {
        }

        public void ShowTemplates()
        {
            _templates.RemoveFromClassList("hide");
            _aboutUs.AddToClassList("hide");
            _help.AddToClassList("hide");
        }

        public void ShowAboutUs()
        {
            _templates.AddToClassList("hide");
            _aboutUs.RemoveFromClassList("hide");
            _help.AddToClassList("hide");
        }

        public void ShowHelp()
        {
            _templates.AddToClassList("hide");
            _aboutUs.AddToClassList("hide");
            _help.RemoveFromClassList("hide");
        }

        private void CreateMenu()
        {
            Label templatesBtn = rootVisualElement.Query<Label>("menuTemplates").First();
            templatesBtn.RegisterCallback<MouseDownEvent>( evt=>{
                rootVisualElement.Query<Label>("menuAbout").First().RemoveFromClassList("active");
                rootVisualElement.Query<Label>("menuTemplates").First().AddToClassList("active");
                rootVisualElement.Query<Label>("menuHelp").First().RemoveFromClassList("active");
                ShowTemplates();
            });

            Label aboutBtn = rootVisualElement.Query<Label>("menuAbout").First();
            aboutBtn.RegisterCallback<MouseDownEvent>( evt=>{
                rootVisualElement.Query<Label>("menuAbout").First().AddToClassList("active");
                rootVisualElement.Query<Label>("menuTemplates").First().RemoveFromClassList("active");
                rootVisualElement.Query<Label>("menuHelp").First().RemoveFromClassList("active");
                ShowAboutUs();
            });

            Label helpBtn = rootVisualElement.Query<Label>("menuHelp").First();
            helpBtn.RegisterCallback<MouseDownEvent>( evt=>{
                rootVisualElement.Query<Label>("menuAbout").First().RemoveFromClassList("active");
                rootVisualElement.Query<Label>("menuTemplates").First().RemoveFromClassList("active");
                rootVisualElement.Query<Label>("menuHelp").First().AddToClassList("active");
                ShowHelp();
            });
        }

        private void CreateTemplates()
        {
            _templates = _root.Query<ScrollView>("tutorials").First() as ScrollView;
            _aboutUs = _root.Query<ScrollView>("aboutus").First() as ScrollView;
            _help = _root.Query<ScrollView>("help").First() as ScrollView;

            rootVisualElement.Query<Box>("tuto1_1").First().RegisterCallback<MouseDownEvent>( evt=>{
                TemplateFactory.CreateTemplate_AnchorPlacement();
                this.Close();
            });
            // rootVisualElement.Query<Box>("tuto1_2").First().RegisterCallback<MouseDownEvent>( evt=>{
            //     TemplateFactory.CreateTemplate_AnchorInteraction();
            //     this.Close();
            // });
            rootVisualElement.Query<Box>("tuto1_3").First().RegisterCallback<MouseDownEvent>( evt=>{
                TemplateFactory.CreateTemplate_PlaneTracker();
                this.Close();
            });
            rootVisualElement.Query<Box>("tuto2_1").First().RegisterCallback<MouseDownEvent>( evt=>{
                TemplateFactory.CreateTemplate_DepthTextureOcclusion();
                this.Close();
            });
            rootVisualElement.Query<Box>("tuto2_2").First().RegisterCallback<MouseDownEvent>( evt=>{
                TemplateFactory.CreateTemplate_MeshOcclusion();
                this.Close();
            });
            rootVisualElement.Query<Box>("tuto2_3").First().RegisterCallback<MouseDownEvent>( evt=>{
                TemplateFactory.CreateTemplate_RealtimeMeshing();
                this.Close();
            });
            rootVisualElement.Query<Box>("tuto2_4").First().RegisterCallback<MouseDownEvent>( evt=>{
                TemplateFactory.CreateTemplate_MeshCollider();
                this.Close();
            });
            rootVisualElement.Query<Box>("tuto3_1").First().RegisterCallback<MouseDownEvent>( evt=>{
                TemplateFactory.CreateTemplate_SemanticSegmentation();
                this.Close();
            });
            // rootVisualElement.Query<Box>("tuto3_2").First().RegisterCallback<MouseDownEvent>( evt=>{
            //     TemplateFactory.CreateTemplate_ObjectMasking();
            //     this.Close();
            // });
            rootVisualElement.Query<Box>("tuto3_3").First().RegisterCallback<MouseDownEvent>( evt=>{
                TemplateFactory.CreateTemplate_OptimizedObjectMasking();
                this.Close();
            });
            rootVisualElement.Query<Box>("tuto4_1").First().RegisterCallback<MouseDownEvent>( evt=>{
                TemplateFactory.CreateTemplate_SharedObjectInteraction();
                this.Close();
            });
            rootVisualElement.Query<Box>("tuto5_1").First().RegisterCallback<MouseDownEvent>( evt=>{
                TemplateFactory.CreateTemplate_VPSCoverage();
                this.Close();
            });
            rootVisualElement.Query<Box>("tuto5_2").First().RegisterCallback<MouseDownEvent>( evt=>{
                TemplateFactory.CreateTemplate_VPSCoverageList();
                this.Close();
            });
            rootVisualElement.Query<Box>("tuto5_3").First().RegisterCallback<MouseDownEvent>( evt=>{
                TemplateFactory.CreateTemplate_WayspotAnchors();
                this.Close();
            });
        }

        public void CreateHelp()
        {
            rootVisualElement.Query<Label>("learn_more").First().RegisterCallback<MouseDownEvent>( evt=>{
                Application.OpenURL("https://lightship.dev/");
            });

            rootVisualElement.Query<Box>("help_iosbuild").First().RegisterCallback<MouseDownEvent>( evt=>{
                Application.OpenURL("https://lightship.dev/docs/building_ios.html");
            });

            rootVisualElement.Query<Box>("help_androidbuild").First().RegisterCallback<MouseDownEvent>( evt=>{
                Application.OpenURL("https://lightship.dev/docs/building_android.html");
            });

            rootVisualElement.Query<Box>("help_gettingstarted").First().RegisterCallback<MouseDownEvent>( evt=>{
                Application.OpenURL("https://lightship.dev/docs/getting_started.html");
            });

            rootVisualElement.Query<Box>("help_documentation").First().RegisterCallback<MouseDownEvent>( evt=>{
                Application.OpenURL("https://lightship.dev/account/documentation");
            });
        }

        public void SendMouseUpEventTo(IEventHandler handler)
        {
            using (var mouseUp = MouseUpEvent.GetPooled(new Event()))
            {
                mouseUp.target = handler;
                handler.SendEvent(mouseUp);
            }
        }
    }
}
#endif