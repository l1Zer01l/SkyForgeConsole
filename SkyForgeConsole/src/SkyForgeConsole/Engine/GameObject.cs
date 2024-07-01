/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeConsole.Events;

namespace SkyForgeConsole.Engine
{
    public abstract class GameObject : IGameObject
    {
        public bool IsActive { get; private set; } = true;

        private List<IComponent> m_components;
        private bool m_isStarted;
        public GameObject() 
        {
            m_components = new List<IComponent>();
            m_isStarted = false;
        }

        public TComponent? GetComponent<TComponent>() where TComponent : class, IComponent
        {
            var type = typeof(TComponent);
            foreach (var component in m_components)
                if (component.GetType() == type)
                    return component as TComponent;
            return null;
        }

        public void Start()
        {
            var collection = m_components.ToList();
            m_isStarted = true;
            foreach (var component in collection)
                component.Start();        
        }

        public void OnDestroy()
        {
            foreach (var component in m_components)
            {
                component.OnDestroy();            
            }
            m_components.Clear();
        }

        public void OnEvent(Event e)
        {
            foreach (var component in m_components)
                component.OnEvent(e);
        }

        public void OnUpdate()
        {
            foreach(var component in m_components)
                component.OnUpdate();
        }

        public void AddComponent(IComponent component)
        {
            component.GameObject = this;
            if(m_isStarted)
                component.Start();
            m_components.Add(component);
        }

        public void RemoveComponent<TComponent>() where TComponent : class, IComponent
        {
            var type = typeof(TComponent);
            foreach (var component in m_components)
            {
                if (component.GetType() == type)
                {
                    component.OnDestroy();
                    m_components.Remove(component);
                }
            }
        }
    }
}
