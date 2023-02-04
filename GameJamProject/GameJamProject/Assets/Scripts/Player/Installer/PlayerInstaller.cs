using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] 
    private PlayerManager m_playerManager;
    public override void InstallBindings()
    {
        Container.BindInstance(m_playerManager);
    }
}