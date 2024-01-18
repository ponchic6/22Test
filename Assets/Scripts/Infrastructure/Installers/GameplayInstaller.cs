using System.Collections.Generic;
using Factories;
using Handlers;
using Services;
using StaticData;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private List<LevelStaticData> _levelConfigsList;
    public override void InstallBindings()
    {
        RegisterTickService();
        RegisterInputService();
        RegisterTractorFactories();
        RegisterUIHandlerFactory();
        RegisterStaticData();
        RegisterUIFactory();
        RegisterCoinsService();
        RegisterFruitFactory();
        RegisterLevelFruitCreator();
        RegisterWinLossHandler();
        RegisterBonusService();
    }

    private void RegisterBonusService()
    {
        IBonusService bonusService = Container.Instantiate<BonusService>();
        Container.Bind<IBonusService>().FromInstance(bonusService).AsSingle();
    }

    private void RegisterCoinsService()
    {
        ICoinsService coinsService = Container.Instantiate<CoinsService>();
        Container.Bind<ICoinsService>().FromInstance(coinsService).AsSingle();
    }

    private void RegisterStaticData()
    {
        ILevelStaticDataService levelStaticDataService = Container.Instantiate<LevelStaticDataService>();
        levelStaticDataService.FillConfigLevelList(_levelConfigsList);
        Container.Bind<ILevelStaticDataService>().FromInstance(levelStaticDataService).AsSingle();
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

    private void RegisterWinLossHandler()
    {
        IWinLossHandler winLossHandler = Container.Instantiate<WinLossHandler>();
        Container.Bind<IWinLossHandler>().FromInstance(winLossHandler).AsSingle();
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