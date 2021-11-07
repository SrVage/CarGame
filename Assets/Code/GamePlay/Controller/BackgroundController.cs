using Code.GamePlay.View;
using Code.MainLogic.Controller;
using Code.Tools;
using UnityEngine;

namespace Code.GamePlay.Controller
{
    public class BackgroundController:BaseController
    {
        private Background _backgroundView;
        private readonly ResourcePath _path = new ResourcePath() { PathResource = "Prefabs/background"};
        private readonly SubscriptionProperty<float> _diff;
        private readonly IReadOnlySubscriptionProperty<float> _leftMove;
        private readonly IReadOnlySubscriptionProperty<float> _rightMove;

        public BackgroundController(IReadOnlySubscriptionProperty<float> left, IReadOnlySubscriptionProperty<float> right)
        {
            _backgroundView = CreateView();
            _diff = new SubscriptionProperty<float>();
            _leftMove = left;
            _rightMove = right;
            _backgroundView.Init(_diff);
            _leftMove.SubscribeOnChange(Move);
            _rightMove.SubscribeOnChange(Move);
        }

        private void Move(float value)
        {
            _diff.value = value;
        }

        private Background CreateView()
        {
            var back = Object.Instantiate(ResourceLoader.LoadPrefab(_path));
            AddGameObject(back);
            return back.GetComponent<Background>();
        }

        protected override void OnDispose()
        {
            _leftMove.UnSubscriptionOnChange(Move);
            _rightMove.UnSubscriptionOnChange(Move);
            base.OnDispose();
        }
    }
}