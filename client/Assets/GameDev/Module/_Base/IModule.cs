namespace GameDev.Module
{
    internal interface IModule
    {
        int InitOrder { get; }
        void Init();
        void Deinit();
        void OnUpdate(float dt);
    }
}