using UnityEngine;
using Zenject;

public class AudioInstaller : MonoInstaller
{
    [SerializeField]
    private AudioManager m_audioManager;
    public override void InstallBindings()
    {
        Container.BindInstance(m_audioManager);
    }
}