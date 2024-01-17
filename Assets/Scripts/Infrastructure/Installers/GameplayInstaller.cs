using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        RegisterTickService();
        RegisterInputService();
        RegisterTractorFactories();
        RegisterUIHandlerFactory();
        RegisterUIFactory();
        RegisterLossHandler();
        RegisterFruitFactory();
        RegisterLevelFruitCreator();
    }

    private void RegisterUIHandlerFactory()
    {
        IUIHandlerFactory uiHandlerFactory = Container.Instantiate<UIHandlerFactory>();
        Container.Bind<IUIHandlerFactory>().FromInstance(uiHandlerFactory).AsSingle();
    }

    private void RegisterLevelFruitCreator()
    {
        ILevelFruitCreator levelFruitCreator = Container.Instantiate<LevelFruitCreator>();
        Container.Bind<ILevelFruitCreator>().FromInstance(levelFruitCreator).AsSingle();
    }

    private void RegisterFruitFactory()
    {
        IFruitFactory fruitFactory = Container.Instantiate<FruitFactory>();
        Container.Bind<IFruitFactory>().FromInstance(fruitFactory).AsSingle();
    }

    private void RegisterLossHandler()
    {
        ILossHandler lossHandler = Container.Instantiate<LossHandler>();
        Container.Bind<ILossHandler>().FromInstance(lossHandler).AsSingle();
    }

    private void RegisterUIFactory()
    {
        IUIFactory uiFactory = Container.Instantiate<UIFactory>();
        Container.Bind<IUIFactory>().FromInstance(uiFactory).AsSingle();
    }

    private void RegisterTractorFactories()
    {
        ITractorFactory tractorFactory = Container.Instantiate<TractorFactory>();
        Container.Bind<ITractorFactory>().FromInstance(tractorFactory).AsSingle();
    }

    private void RegisterInputService()
    {
        IInputService inputService = Container.Instantiate<InputService>();
        Container.Bind<IInputService>().FromInstance(inputService).AsSingle();
    }

    private void RegisterTickService()
    {    
        GameObject tickObject = new GameObject("TickService");
        DontDestroyOnLoad(tickObject);
        ITickService tickService = tickObject.AddComponent<TickService>();
        Container.Bind<ITickService>().FromInstance(tickService).AsSingle();
    }
    
    
}