using System;
using Code.MainLogic.Model;
using Code.MainLogic.View;
using Code.Tools;
using Unity.Notifications.Android;
using Unity.Notifications.iOS;
using UnityEngine;

namespace Code.MainLogic.Controller
{
    public class MainMenuController:BaseController
    {
        private const string AndroidNotifierId = "android_notifier_id";
        private ResourcePath _mainMenuResourcePath = new ResourcePath() { PathResource = "Prefabs/mainMenu"};
        private ProfilePlayer _model;
        private MainMenuView _view;

        public MainMenuController(Transform canvasParent, ProfilePlayer model)
        {
            _view = CreateView(canvasParent);
            AddGameObject(_view.gameObject);
            _view.Init(OnStart, Reward, Fight);
            _model = model;
            CreateNotification();
        }

        private void OnStart()
        {
            _model.CurrentState.value = GameState.Game;
        }

        private void Reward()
        {
            _model.CurrentState.value = GameState.Reward;
        }

        private void Fight()
        {
            _model.CurrentState.value = GameState.Fight;
        }

        private MainMenuView CreateView(Transform canvasParent)
        {
            var prefab = ResourceLoader.LoadPrefab(_mainMenuResourcePath);
            var go = GameObject.Instantiate(prefab, canvasParent);
            var view = go.GetComponent<MainMenuView>();
            return view;
        }
        
        private void CreateNotification()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                var androidSettingsChanel = new AndroidNotificationChannel
                {
                    Id = AndroidNotifierId,
                    Name = "Car Game",
                    Importance = Importance.High,
                    CanBypassDnd = true,
                    CanShowBadge = true,
                    Description = "You entered game for a long time",
                    EnableLights = true,
                    EnableVibration = true,
                    LockScreenVisibility = LockScreenVisibility.Public
                };

                AndroidNotificationCenter.RegisterNotificationChannel(androidSettingsChanel);

                var androidSettingsNotification = new AndroidNotification
                {
                    Color = Color.white,
                    FireTime = DateTime.Today.Date.AddDays(1)
                };
                AndroidNotificationCenter.SendNotification(androidSettingsNotification, AndroidNotifierId);
            }
        }

    }
}